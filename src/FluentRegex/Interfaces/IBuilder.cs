using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using FluentRegex.Exceptions;
[assembly: InternalsVisibleTo("FluentRegex.Tests")]
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

  public StringBuilder Pattern { get; set; }

  // An internal reference for grouping structures (parentheses, square brackets, curly braces, etc.)
  // used for validation purposes.
  private static readonly Dictionary<string, List<char>> _groupingStructures = new()
  {
    { "Brace", new List<char>() { '{', '}' } },
    { "Bracket", new List<char>() { '[', ']' } },
    { "Paren", new List<char>() { '(', ')' } }
  };

  /// <summary>
  /// Builds the regular expression pattern.
  /// </summary>
  public dynamic Build();

  /// <summary>
  /// Returns the regular expression pattern as a string.
  /// </summary>
  public string ToString();

  /// <summary>
  /// The <c>AppendLiteral</c> method appends a literal character to the pattern, escaping any special characters.
  /// </summary>
  public dynamic AppendLiteral(char character)
  {
    var outLiteral = new StringBuilder();
    var shouldEscape = true;

    ProcessCharacter(character, outLiteral, shouldEscape, character.ToString());

    Pattern.Append(outLiteral.ToString());
    return this;
  }

  /// <summary>
  /// The <c>AppendLiteral</c> method appends a literal string to the pattern, escaping any special characters.
  /// </summary>
  public dynamic AppendLiteral(string literal)
  {
    var outLiteral = new StringBuilder();
    var shouldEscape = true;

    foreach (var character in literal)
    {
      ProcessCharacter(character, outLiteral, shouldEscape, literal);
    }
    Pattern.Append(outLiteral);
    return this;
  }

  private bool ProcessCharacter(char character, StringBuilder outLiteral, bool shouldEscape, string literal)
  {
    var isGroupChar = IsGroupingCharacter(character);
    var isCustomCharacterClass = IsCustomCharacterClass(literal);
    if (isGroupChar && !isCustomCharacterClass)
    {
      var groupType = GetGroupType(character);
      var typeStart = _groupingStructures[groupType][0];
      var typeEnd = _groupingStructures[groupType][1];
      shouldEscape = !(Pattern.ToString().StartsWith(typeStart) && Pattern.ToString().EndsWith(typeEnd));
    }
    else if (isCustomCharacterClass)
    {
      shouldEscape = false;
    }

    if (_specialCharacters.Contains(character) && shouldEscape)
      outLiteral.Append(@"\" + character);
    else
      outLiteral.Append(character);
    return shouldEscape;
  }

  private static string GetGroupType(char character)
  {
    if (_groupingStructures["Brace"].Contains(character))
      return "Brace";
    if (_groupingStructures["Bracket"].Contains(character))
      return "Bracket";
    if (_groupingStructures["Paren"].Contains(character))
      return "Paren";
    return string.Empty;
  }

  internal static bool IsCustomCharacterClass(string literal)
  {
    bool isValidRegex = true;
    bool isCustomCharacterClass = false;
    try
    {
      isCustomCharacterClass = Regex.Match(literal, @"^\[.*\]$").Success;
    }
    catch
    {
      isValidRegex = false;
    }
    return isValidRegex && isCustomCharacterClass;
  }

  private static bool IsGroupingCharacter(char character) => _groupingStructures["Brace"].Contains(character)
                                                      || _groupingStructures["Bracket"].Contains(character)
                                                      || _groupingStructures["Paren"].Contains(character);

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


  /// <summary>
  /// Validates the pattern to ensure it does not end with any characters that would cause an exception when building the regular expression.
  /// </summary>
  internal void ValidateEnd()
  {
    var badEndChars = new char[] { '|', '{', '(', '[' };
    var pattern = Pattern.ToString();
    var patternLengthLessOne = pattern.Length - 1;
    if (badEndChars.Contains(pattern[pattern.Length - 1]))
      throw new InvalidOperationException($"The pattern cannot end with a '{Pattern[patternLengthLessOne]}' character. (pattern : {pattern})");
  }

  /// <summary>
  /// Validates the pattern to ensure it does not start with any characters that would cause an exception when building the regular expression.
  /// </summary>
  /// <exception cref="InvalidOperationException"></exception>
  internal void ValidateStart()
  {
    var badStartChars = new char[]
    {

        '{',
        '*',
        '+',
        '?',
        '|',
        '}',
        ')',
        ']'
    };
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
    if (GetType() == typeof(GroupBuilder))
      return;

    var counts = GetOpenCloseCharacterCounts();
    if (counts['('] != counts[')'])
      // How can I account for situations where a user may just want a literal parenthesis in the pattern, while still validating the pattern?
      // A: You can add a check to see if the pattern contains a literal parenthesis, and if it does, skip the validation.
      throw new InvalidOperationException($"The number of opening and closing parentheses do not match in pattern: {Pattern}");
  }

  /// <summary>
  /// Validates the pattern to ensure it does not contain empty structures. Including empty parentheses, empty non-capturing groups, and empty named capturing groups, empty Character classes.
  /// </summary>
  internal void ValidateNoEmptyStructures()
  {
    var pattern = Pattern.ToString();

    if (pattern.Contains("()"))
      throw new InvalidOperationException("Empty parentheses are not allowed.");

    if (pattern.Contains("(?:)"))
      throw new InvalidOperationException("Empty non-capturing group is not allowed.");

    var groupNameIsEmpty = pattern.Contains("(?<>)") || pattern.Contains("(?P<>)") || pattern.Contains("(?'')");
    if (groupNameIsEmpty)
      throw new InvalidOperationException("Empty named capturing group is not allowed.");

  }

  /// <summary>
  /// Validates the pattern to ensure there are no unescaped characters that are not escapable.
  /// </summary>
  internal void ValidateNoUnEscapedCharacters(bool checkForZero = false)
  {
    var pattern = Pattern.ToString();
    var closingCharacters = new char[] { ')', ']', '}' };
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

    // Are there an uneven number of closing characters?
    CheckInvalidEscapedClosure(pattern, closingCharacters, checkForZero);

    // Check for instances of '\' where the next character is not a character that can be escaped OR where it is not part of an Anchor or Character Class
    for (int i = 0; i < pattern.Length; i++)
    {
      char patternPlusOne;
      var indexPlusOne = i + 1;
      if (indexPlusOne >= pattern.Length)
        patternPlusOne = new char();
      else
        patternPlusOne = pattern[indexPlusOne];
      var patternChar = pattern[i];
      var escapePattern = $"{patternChar}{patternPlusOne}";
      if (pattern[i] == '\\' && !escapableCharacters.Contains(patternPlusOne) && !characterClasses.Contains(escapePattern))
        throw new InvalidOperationException($"The character ({patternPlusOne}) following the escape character is not escapable, or the '\\' is out of place. Check the pattern at {indexPlusOne}. (pattern : {pattern} | patternPlusOne : {patternPlusOne} | escapePattern : {escapePattern})");
    }

  }

  internal Dictionary<char, int> GetOpenCloseCharacterCounts()
  {
    var pattern = Pattern.ToString();
    var openCloseCharacters = new char[] { '(', ')', '[', ']', '{', '}' };
    var OpenCloseCharacterCounts = new Dictionary<char, int>();
    foreach (var character in openCloseCharacters)
    {
      var count = GetUnescapedCharacterCount(character, pattern);
      OpenCloseCharacterCounts.Add(character, count);
    }
    return OpenCloseCharacterCounts;

  }

  /// <summary>
  /// Gets the count of a character in a pattern, accounting for escaped characters.
  /// </summary>
  /// <param name="character"></param>
  /// <param name="pattern"></param>
  /// <returns>
  /// <see cref="int"/>
  /// </returns>
  public int GetUnescapedCharacterCount(char character, string pattern)
  {
    var count = GetCountOfCharacter(character, pattern);
    return ReduceCountForEscapedCharacter(pattern, character, count);
  }

  internal static int ReduceCountForEscapedCharacter(string pattern, char character, int count)
  {
    var targetIndex = pattern.IndexOf(character, 1);
    if (targetIndex > -1 && pattern[targetIndex] == '\\' && pattern[targetIndex - 1] == '\\')
      count--;
    while (targetIndex > 0)
    {
      if (pattern[targetIndex - 1] == '\\')
        count--;
      targetIndex = pattern.IndexOf(character, targetIndex + 1);
    }
    return count;
  }

  internal int GetCountOfCharacter(char character, string pattern)
  {
    return pattern.Count(x => x == character);
  }

  internal bool OpenClosingCharacterCountsMatch(string pattern)
  {
    var counts = GetOpenCloseCharacterCounts();
    return counts['('] == counts[')']
           && counts['['] == counts[']']
           && counts['{'] == counts['}'];
  }


  internal bool CountsAreEven(char targetCharacter, char comparisonCharacter, bool checkForZero = false)
  {
    Dictionary<char, int> counts = new()
    {
        { targetCharacter, GetUnescapedCharacterCount(targetCharacter, Pattern.ToString()) },
        { comparisonCharacter, GetUnescapedCharacterCount(comparisonCharacter, Pattern.ToString()) }
    };
    if (checkForZero)
      return counts[targetCharacter] == counts[comparisonCharacter] && counts[targetCharacter] != 0;
    return counts[targetCharacter] == counts[comparisonCharacter];

  }

  internal void CheckInvalidEscapedClosure(string pattern, char[] closingCharacters, bool checkForZero = false)
  {
    // FIXME: There is an issue right now where when appending a literal, we need to account for the potential for the counts being zero. But this breaks the validation for some situations. I need to work out a way to account for this, without changing the code too much.


    // Check for instances of '\' where the next character is a closing character for a Character Class, Anchor, or Group
    for (int i = 0; i < pattern.Length; i++)
    {
      char patternPlusOne;
      var indexPlusOne = i + 1;
      if (indexPlusOne >= pattern.Length)
        patternPlusOne = new char();
      else
        patternPlusOne = pattern[indexPlusOne];
      var patternChar = pattern[i];
      var escapePattern = $"{patternChar}{patternPlusOne}";

      if (patternChar == '\\' && closingCharacters.Contains(patternPlusOne))
      {
        ValidateClosingCharacterCounts(pattern, patternPlusOne, indexPlusOne, escapePattern, checkForZero);
      }

    }
  }

  internal void ValidateClosingCharacterCounts(string pattern, char patternPlusOne, int indexPlusOne, string escapePattern, bool checkForZero = false)
  {
    var parenCounts = CountsAreEven('(', ')', checkForZero);
    var squareBracketCounts = CountsAreEven('[', ']', checkForZero);
    var curlyBraceCounts = CountsAreEven('{', '}', checkForZero);

    if (patternPlusOne == ')' && parenCounts)
      throw new InvalidCharacterEscapeException(patternPlusOne, pattern, indexPlusOne, escapePattern);
    if (patternPlusOne == ']' && squareBracketCounts)
      throw new InvalidCharacterEscapeException(patternPlusOne, pattern, indexPlusOne, escapePattern);
    if (patternPlusOne == '}' && curlyBraceCounts)
      throw new InvalidCharacterEscapeException(patternPlusOne, pattern, indexPlusOne, escapePattern);
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
      if (GetType() == typeof(GroupBuilder) && !CountsAreEven('(', ')'))
        return;
      throw new ArgumentException($"Invalid Pattern: {Pattern}", ex);
    }
  }

}