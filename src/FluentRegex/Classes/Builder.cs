using System;
using System.Text;
namespace FluentRegex;

/// <summary>
/// The <c>Builder</c> class is the base class for all builders in the FluentRegex library. It contains methods for building regular expression patterns, and for validating the pattern to ensure it is well-formed.
/// </summary>
/// <remarks>
/// The use of @dynamic as the return type for the methods in this class allows the methods to be called from any of the derived classes without needing to cast the return value or override the method in each class.
/// </remarks>
public abstract class Builder : IBuilder
{
  /// <inheritdoc/>
  public abstract StringBuilder Pattern { get; set; }
  internal StringBuilder _pattern = new StringBuilder();
  internal const string _specialCharacters = @"\.^$*+?()[{|";

  /// <summary>
  /// Adds an anchor to the pattern.
  /// </summary>
  /// <returns></returns>
  public abstract AnchorBuilder StartAnchor();

  /// <summary>
  /// Adds a group to the pattern.
  /// </summary>
  /// <returns></returns>
  public abstract GroupBuilder StartGroup();

  /// <summary>
  /// Adds a character class to the pattern.
  /// </summary>
  public abstract CharacterClassBuilder StartCharacterClass();

  /// <summary>
  /// Builds the regular expression pattern.
  /// </summary>
  public abstract PatternBuilder Build();

  /// <summary>
  /// The <c>ToString</c> method returns the current value of the pattern as a string.
  /// </summary>
  public override string ToString()
  {
    Validate();
    return Pattern.ToString();
  }

  // /// <summary>
  // /// The <c>AppendLiteral</c> method appends a literal string to the pattern, escaping any special characters.
  // /// </summary>
  // public dynamic AppendLiteral(string literal)
  // {
  //   var outLiteral = String.Empty;
  //   foreach (var character in literal)
  //   {
  //     if (_specialCharacters.Contains(character))
  //       outLiteral += @"\" + character;
  //     else
  //       outLiteral += character;
  //   }
  //   Pattern.Append(outLiteral);
  //   return this;
  // }

  /// <summary>
  /// The <c>Times</c> method appends a quantifier to the pattern. The method can take two parameters, <paramref name="minimum"/> and <paramref name="maximum"/>.
  /// If both parameters are -1, the method appends an empty string. If <paramref name="minimum"/> is 0 and <paramref name="maximum"/> is -1, the method appends an asterisk.
  /// If <paramref name="minimum"/> is 1 and <paramref name="maximum"/> is -1, the method appends a plus.
  /// If <paramref name="minimum"/> is 0 and <paramref name="maximum"/> is 1, the method appends a question mark.
  /// If <paramref name="minimum"/> is equal to <paramref name="maximum"/>, the method appends the minimum value in curly braces.
  /// If <paramref name="minimum"/> is -1 and <paramref name="maximum"/> is not -1, the method appends the maximum value in curly braces.
  /// If <paramref name="maximum"/> is -1 and <paramref name="minimum"/> is not -1, the method appends the minimum value in curly braces.
  /// If both <paramref name="minimum"/> and <paramref name="maximum"/> are not -1, the method appends the minimum and maximum values in curly braces.
  /// </summary>
  /// <param name="minimum"></param>
  /// <param name="maximum"></param>
  public dynamic Times(int minimum = -1, int maximum = -1)
  {
    switch (minimum, maximum)
    {
      case (-1, -1):
        Pattern.Append(string.Empty);
        break;
      case (0, -1):
        Pattern.Append("*");
        break;
      case (1, -1):
        Pattern.Append("+");
        break;
      case (0, 1):
        Pattern.Append("?");
        break;
      case var (min, max) when min == max:
        Pattern.Append($"{{{min}}}");
        break;
      case var (min, max) when min == -1:
        Pattern.Append($"{{0,{max}}}");
        break;
      case var (min, max) when max == -1:
        Pattern.Append($"{{{min},}}");
        break;
      default:
        if (minimum < 0 && maximum < 0)
          throw new ArgumentException("At least one of the parameters must be greater than or equal to 0.");
        Pattern.Append($"{{{minimum},{maximum}}}");
        break;
    }
    return this;
  }

  /// <summary>
  /// The <c>Lazy</c> method appends a lazy quantifier (`?`) to the pattern.
  /// </summary>
  public dynamic Lazy()
  {
    Pattern.Append("?");
    return this;
  }

  /// <summary>
  /// The <c>OneOrMore</c> method appends a one or more quantifier (`+`) to the pattern.
  /// </summary>
  public dynamic OneOrMore()
  {
    if (Pattern.ToString().EndsWith("?"))
      throw new InvalidOperationException("Cannot apply one or more quantifier to a zero or one quantifier.");
    if (Pattern.ToString().EndsWith("*"))
      throw new InvalidOperationException("Cannot apply one or more quantifier to a zero or one quantifier.");
    Pattern.Append("+");
    return this;
  }

  /// <summary>
  /// The <c>ZeroOrMore</c> method appends a zero or more quantifier (`*`) to the pattern.
  /// </summary>
  public dynamic ZeroOrMore()
  {
    switch (Pattern.ToString().Last())
    {
      case '*':
        throw new InvalidOperationException("Cannot apply greedy quantifier to a zero or more quantifier.");
      case '+':
        throw new InvalidOperationException("Cannot apply greedy quantifier to a one or more quantifier.");
      case '?':
        throw new InvalidOperationException("Cannot apply greedy quantifier to a lazy quantifier.");
      case '}':
        throw new InvalidOperationException("Cannot apply greedy quantifier to a custom quantifier.");
      default:
        Pattern.Append("*");
        break;
    }
    return this;
  }

  /// <summary>
  /// The <c>ZeroOrOne</c> method appends a zero or one quantifier (`?`) to the pattern. The zero or one quantifier is equivalent to the regular expression `{0,1}`, and shares a character with the lazy quantifier.
  /// </summary>
  public dynamic ZeroOrOne()
  {
    Pattern.Append("?");
    return this;
  }

  /// <summary>
  /// The <c>Or</c> method appends an alternation operator (`|`) to the pattern.
  /// </summary>
  public dynamic Or()
  {
    Pattern.Append("|");
    return this;
  }

  /// <summary>
  /// Validates the pattern to ensure it is well-formed. Each validation method contains explicit error messages which are thrown when the validation fails. This should help the user to understand what is wrong with the pattern, rather than just throwing a generic exception. However the final validation method checks that the pattern is a valid regular expression, and throws a generic exception if it is not, bubbling up the error message from the regular expression engine.
  /// </summary>
  public void Validate()
  {
    ValidateNoUnEscapedCharacters();
    ValidateParenthesesPairs();
    ValidateStart();
    ValidateEnd();
    ValidateNoEmptyStructures();
    ValidatePatternRegex();
  }

  /// <summary>
  /// Validates the pattern to ensure it does not end with any characters that would cause an exception when building the regular expression.
  /// </summary>
  internal void ValidateEnd()
  {
    var badEndChars = new char[] { '|', '{', '(', '[' };
    var pattern = Pattern.ToString();
    if (badEndChars.Contains(pattern[pattern.Length - 1]))
      throw new InvalidOperationException("The pattern cannot end with a '" + pattern[pattern.Length - 1] + "' character.");
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
    var escapableCharacters = new char[] { '\\', '.', '^', '$', '*', '+', '?', '(', ')', '[', ']', '{', '}', '|', '<', '>', '-', ' ' };
    // Check for instances of '\' where the next character is not a character that can be escaped.
    for (int i = 0; i < pattern.Length; i++)
    {
      if (pattern[i] == '\\')
      {
        if (!escapableCharacters.Contains(pattern[i + 1]))
          throw new InvalidOperationException("The character following the escape character is not escapable, or the '\\' is out of place. Check the pattern at index " + i + 1 + ".");
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