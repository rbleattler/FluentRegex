using System;
using System.Text;
namespace FluentRegex;

/// <summary>
/// Interface <c>IBuilder</c> defines the methods and properties for building a regular expression pattern.
/// </summary>
public interface IBuilder
{
  internal const string _specialCharacters = @"\.^$*+?()[{|";

  /// <summary>
  /// Gets or sets the pattern.
  /// </summary>
  /// <value></value>
  public StringBuilder Pattern { get; set; }
  // public AnchorBuilder StartAnchor();
  // public GroupBuilder StartGroup();
  // public CharacterClassBuilder StartCharacterClass();

  /// <summary>
  /// Builds the regular expression pattern.
  /// </summary>
  /// <returns></returns>
  public PatternBuilder Build();

  /// <summary>
  /// Returns the regular expression pattern as a string.
  /// </summary>
  /// <returns></returns>
  public string ToString();

  /// <summary>
  /// The <c>AppendLiteral</c> method appends a literal string to the pattern, escaping any special characters.
  /// </summary>
  public dynamic AppendLiteral(string literal)
  {
    var outLiteral = string.Empty;
    foreach (var character in literal)
    {
      if (_specialCharacters.Contains(character))
        outLiteral += @"\" + character;
      else
        outLiteral += character;
    }
    Pattern.Append(outLiteral);
    return this;
  }

  /// <summary>
  /// Validates the pattern to ensure it is well-formed. Each validation method contains explicit error messages which are thrown when the validation fails. This should help the user to understand what is wrong with the pattern, rather than just throwing a generic exception. However the final validation method checks that the pattern is a valid regular expression, and throws a generic exception if it is not, bubbling up the error message from the regular expression engine.
  /// </summary>
  public void Validate();

  /// <summary>
  /// Validates the pattern to ensure it does not end with any characters that would cause an exception when building the regular expression. Allows the user to skip the regular expression validation.
  /// </summary>
  /// <param name="skipRegexValidation">
  /// A <see cref="bool"/> value to skip the regular expression validation.
  ///</param>
  public void Validate(bool skipRegexValidation);
  // {
  //   ValidateNoUnEscapedCharacters();
  //   ValidateParenthesesPairs();
  //   ValidateStart();
  //   ValidateEnd();
  //   ValidateNoEmptyStructures();
  //   if (!skipRegexValidation)
  //     ValidatePatternRegex();
  // }

  /// <summary>
  /// Validates the pattern to ensure it does not end with any characters that would cause an exception when building the regular expression.
  /// </summary>
  internal void ValidateEnd()
  {
    var badEndChars = new char[] { '|', '{', '(', '[' };
    var pattern = Pattern.ToString();
    var patternLengthLessOne = pattern.Length - 1;
    if (badEndChars.Contains(pattern[pattern.Length - 1]))
      throw new InvalidOperationException($"The pattern cannot end with a '{patternLengthLessOne}' character. (pattern : {pattern})");
  }

  /// <summary>
  /// Validates the pattern to ensure it does not start with any characters that would cause an exception when building the regular expression.
  /// </summary>
  /// <exception cref="InvalidOperationException"></exception>
  internal void ValidateStart()
  {
    var badStartChars = new char[] { '*', '+', '?', '|', '}', ')', ']' };
    var pattern = Pattern.ToString();
    if (badStartChars.Contains(pattern[0]))
      throw new InvalidOperationException("The pattern cannot start with a '" + pattern[0] + "' character.");
  }

  /// <summary>
  /// Validates the pattern to ensure that the number of opening and closing parentheses match.
  /// </summary>
  /// <exception cref="InvalidOperationException"></exception>
  internal void ValidateParenthesesPairs()
  {
    var pattern = Pattern.ToString();
    var openParenthesesCount = 0;
    var closeParenthesesCount = 0;

    foreach (var character in pattern)
    {
      if (character == '(')
      {
        if (pattern.IndexOf(character) == 0)
        {
          openParenthesesCount++;
        }
        if (pattern.IndexOf(character) > 0 && pattern[pattern.IndexOf(character) - 1] != '\\')
          openParenthesesCount++;
      }
      if (character == ')')
      {
        if (pattern.IndexOf(character) > 0 && pattern[pattern.IndexOf(character) - 1] != '\\')
          closeParenthesesCount++;
      }
    }
    if (openParenthesesCount != closeParenthesesCount)
      throw new InvalidOperationException("The number of opening and closing parentheses do not match.");
  }

  /// <summary>
  /// Validates the pattern to ensure it does not contain empty structures. Including empty parentheses, empty non-capturing groups, and empty named capturing groups, empty Character classes.
  /// /// </summary>
  internal void ValidateNoEmptyStructures()
  {
    var pattern = Pattern.ToString();

    if (pattern.Contains("()"))
      throw new InvalidOperationException("Empty parentheses are not allowed.");

    if (pattern.Contains("(?:)"))
      throw new InvalidOperationException("Empty non-capturing group is not allowed.");

    if (
      pattern.Contains("(?<>)") |
      pattern.Contains("(?P<>)") |
      pattern.Contains("(?'')")
      )
      throw new InvalidOperationException("Empty named capturing group is not allowed.");

  }

  /// <summary>
  /// Validates the pattern to ensure there are no unescaped characters that are not escapable.
  /// </summary>
  internal void ValidateNoUnEscapedCharacters()
  {
    var pattern = Pattern.ToString();
    var escapableCharacters = new char[]
    {
        '\\',
        '.',
        '^',
        '$',
        '*',
        '+',
        '?',
        '(',
        ')',
        '[',
        ']',
        '{',
        '}',
        '|',
        '<',
        '>',
        '-',
        ' '
    };
    var characterClasses = new List<string>()
    {
        CharacterClasses.Digit,
        CharacterClasses.NonDigit,
        CharacterClasses.Word,
        CharacterClasses.NonWord,
        CharacterClasses.Whitespace,
        CharacterClasses.NonWhitespace,
        CharacterClasses.Tab,
        CharacterClasses.Newline,
        CharacterClasses.LowercaseLetter,
        CharacterClasses.UppercaseLetter,
        CharacterClasses.HexDigit,
        CharacterClasses.NonHexDigit,
        CharacterClasses.AnyCharacter,
        CharacterClasses.StartOfLine,
        CharacterClasses.EndOfLine,
        CharacterClasses.WordBoundary,
        CharacterClasses.NonWordBoundary,
        CharacterClasses.EndOfString,
        CharacterClasses.EndOfStringNoLineBreak,
    };
    // Check for instances of '\' where the next character is not a character that can be escaped OR where it is not part of an Anchor or Character Class
    for (int i = 0; i < pattern.Length; i++)
    {
      var indexPlusOne = i + 1;
      char patternPlusOne;
      if (indexPlusOne >= pattern.Length)
        patternPlusOne = new char();
      else
        patternPlusOne = pattern[indexPlusOne];
      var patternChar = pattern[i];
      var escapePattern = $"{patternChar}{patternPlusOne}";
      if (pattern[i] == '\\')
      {
        if (!escapableCharacters.Contains(patternPlusOne) && !characterClasses.Contains(escapePattern))
          // throw new InvalidOperationException("The character () following the escape character is not escapable, or the '\\' is out of place. Check the pattern at index " + i + 1 + ".");
          throw new InvalidOperationException($"The character ({patternPlusOne}) following the escape character is not escapable, or the '\\' is out of place. Check the pattern at {indexPlusOne}. (pattern : {pattern} | patternPlusOne : {patternPlusOne} | escapePattern : {escapePattern})");
      }
    }

  }

  /// <summary>
  /// Validates the pattern to ensure it is a valid regular expression.
  /// </summary>
  internal void ValidatePatternRegex()
  {
    var pattern = Pattern.ToString();
    try
    {
      _ = new System.Text.RegularExpressions.Regex(pattern);
    }
    catch (ArgumentException ex)
    {
      throw new ArgumentException("The pattern is invalid.", ex);
    }
  }

}