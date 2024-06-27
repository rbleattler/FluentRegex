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
  internal StringBuilder _pattern = new();
  internal const string _specialCharacters = @"\.^$*+?()[{|";

  /// <summary>
  /// Adds an anchor to the pattern.
  /// </summary>
  /// <returns></returns>
  public abstract AnchorBuilder StartAnchor();

  /// <summary>
  /// Adds a character class to the pattern.
  /// </summary>
  public abstract CharacterClassBuilder StartCharacterClass();

  /// <summary>
  /// Builds the regular expression pattern.
  /// </summary>
  public abstract dynamic Build();

  /// <summary>
  /// The <c>ToString</c> method returns the current value of the pattern as a string.
  /// </summary>
  public override string ToString()
  {
    var type = GetType();
    if (type != typeof(GroupBuilder))
      Validate();
    else
    {
      var groupStyle = ((GroupBuilder)this).GroupStyle;
      if (groupStyle == NamedGroupStyle.PStyle)
        Validate(true);
    }
    return Pattern.ToString();
  }

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
        _ = Pattern.Append(string.Empty);
        break;
      case (0, -1):
        _ = Pattern.Append('*');
        break;
      case (1, -1):
        _ = Pattern.Append('+');
        break;
      case (0, 1):
        _ = Pattern.Append('?');
        break;
      case var (min, max) when min == max:
        _ = Pattern.Append($"{{{min}}}");
        break;
      case var (min, max) when min == -1:
        _ = Pattern.Append($"{{0,{max}}}");
        break;
      case var (min, max) when max == -1:
        _ = Pattern.Append($"{{{min},}}");
        break;
      default:
        if (minimum < 0 && maximum < 0)
          throw new ArgumentException("At least one of the parameters must be greater than or equal to 0.");
        _ = Pattern.Append($"{{{minimum},{maximum}}}");
        break;
    }
    return this;
  }

  /// <summary>
  /// The <c>Lazy</c> method appends a lazy quantifier (`?`) to the pattern.
  /// </summary>
  public dynamic Lazy()
  {
    _ = Pattern.Append('?');
    return this;
  }

  /// <summary>
  /// The <c>OneOrMore</c> method appends a one or more quantifier (`+`) to the pattern.
  /// </summary>
  public dynamic OneOrMore()
  {
    if (Pattern.ToString().EndsWith('?'))
      throw new InvalidOperationException("Cannot apply one or more quantifier to a zero or one quantifier.");
    if (Pattern.ToString().EndsWith('*'))
      throw new InvalidOperationException("Cannot apply one or more quantifier to a zero or one quantifier.");
    if (Pattern.ToString().EndsWith('+'))
      throw new InvalidOperationException("Cannot apply one or more quantifier to a one or more quantifier.");
    _ = Pattern.Append('+');
    return this;
  }

  /// <summary>
  /// The <c>ZeroOrMore</c> method appends a zero or more quantifier (`*`) to the pattern.
  /// </summary>
  public dynamic ZeroOrMore()
  {
    var lastCharacter = Pattern.Length > 0 ? Pattern.ToString()[Pattern.Length - 1] : '\0';

    switch (lastCharacter)
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
        _ = Pattern.Append('*');
        break;
    }
    return this;
  }

  /// <summary>
  /// The <c>ZeroOrOne</c> method appends a zero or one quantifier (`?`) to the pattern. The zero or one quantifier is equivalent to the regular expression `{0,1}`, and shares a character with the lazy quantifier.
  /// </summary>
  public dynamic ZeroOrOne()
  {
    _ = Pattern.Append('?');
    return this;
  }

  /// <summary>
  /// The <c>Or</c> method appends an alternation operator (`|`) to the pattern.
  /// </summary>
  public dynamic Or()
  {
    _ = Pattern.Append('|');
    return this;
  }


  /// <summary>
  /// Adds a <see cref="GroupBuilder"/> to the pattern.
  /// </summary>
  /// <returns><see cref="GroupBuilder"/></returns>
  ///
  public GroupBuilder StartGroup()
  {
    return CaptureGroup();
  }

  /// <summary>
  /// Adds a <see cref="GroupBuilder"/> to the pattern.
  /// </summary>
  /// <returns><see cref="GroupBuilder"/></returns>
  public GroupBuilder CaptureGroup()
  {
    return new GroupBuilder(this);
  }

  /// <summary>
  /// Adds a <see cref="GroupBuilder"/> to the pattern.
  /// </summary>
  public GroupBuilder NonCaptureGroup()
  {
    return new GroupBuilder(this, GroupType.NonCapturing);
  }

  /// <summary>
  /// Adds a <see cref="GroupBuilder"/> to the pattern.
  /// </summary>
  /// <param name="namedGroupStyle"></param>
  /// <param name="groupName"></param>
  public GroupBuilder NamedCaptureGroup(NamedGroupStyle namedGroupStyle = NamedGroupStyle.AngleBrackets, string? groupName = null)
  {
    return new GroupBuilder(this, namedGroupStyle, groupName);
  }

  /// <summary>
  /// Validates the pattern to ensure it does not end with any characters that would cause an exception when building the regular expression. Allows the user to skip the regular expression validation.
  /// </summary>
  /// <param name="skipRegexValidation">
  /// A <see cref="bool"/> value to skip the regular expression validation.
  ///</param>
  public void Validate(bool skipRegexValidation)
  {
    var type = GetType();
    var patternIsPGroup = Pattern.ToString().StartsWith("(?P<");
    var isPTypeGroup = type == typeof(GroupBuilder) && ((GroupBuilder)this).GroupStyle == NamedGroupStyle.PStyle;
    if (patternIsPGroup || type == typeof(GroupBuilder) && isPTypeGroup)
    {
      skipRegexValidation = true;
    }

    ((IBuilder)this).ValidateNoUnEscapedCharacters();
    ((IBuilder)this).ValidateParenthesesPairs();
    ((IBuilder)this).ValidateStart();
    ((IBuilder)this).ValidateEnd();
    ((IBuilder)this).ValidateNoEmptyStructures();
    if (!skipRegexValidation)
      ((IBuilder)this).ValidatePatternRegex();
  }

  /// <inheritdoc/>
  public void Validate()
  {
    Validate(false);
  }
}