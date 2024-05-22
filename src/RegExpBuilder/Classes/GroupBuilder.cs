namespace Builder;

/// <summary>
/// Represents a builder for creating groups in a regular expression.
/// </summary>
public class GroupBuilder : Builder
{


  /// <summary>
  /// Initializes a new instance of the <see cref="GroupBuilder"/> class with a new <see cref="Builder"/>.
  /// </summary>
  public GroupBuilder()
  {
    _Builder = this;
  }
  /// <summary>
  /// Initializes a new instance of the <see cref="GroupBuilder"/> class.
  /// </summary>
  /// <param name="Builder">The parent <see cref="Builder"/> instance.</param>
  /// <param name="expression">The current regular expression expression.</param>
  public GroupBuilder(Builder Builder, string expression = "")
  {
    _Builder = Builder;
    _expression = expression;
  }

  /// <summary>
  /// Adds a capturing group to the regular expression pattern.
  /// </summary>
  /// <param name="pattern">The pattern to capture.</param>
  /// <returns>A new <see cref="GroupBuilder"/> instance with the updated expression.</returns>
  public GroupBuilder CaptureGroup(string pattern)
  {
    if (string.IsNullOrEmpty(pattern))
      throw new ArgumentException("Pattern cannot be null or empty.");
    return new GroupBuilder(_Builder, _expression + $"({pattern})");
  }
  public GroupBuilder CaptureGroup()
  {
    if (string.IsNullOrEmpty(_expression))
      throw new ArgumentException("Pattern cannot be null or empty.");
    return new GroupBuilder(_Builder, $"({_expression})");
  }

  /// <summary>
  /// Adds a non-capturing group to the regular expression pattern.
  /// </summary>
  /// <param name="pattern">The pattern to include in the group.</param>
  /// <returns>A new <see cref="GroupBuilder"/> instance with the updated expression.</returns>
  public GroupBuilder NonCaptureGroup(string pattern)
  {
    if (string.IsNullOrEmpty(pattern))
      throw new ArgumentException("Pattern cannot be null or empty.");
    return new GroupBuilder(_Builder, _expression + $"(?:{pattern})");
  }

  /// <summary>
  /// Adds a named capturing group to the regular expression pattern.
  /// </summary>
  /// <param name="name">The name of the group.</param>
  /// <param name="pattern">The pattern to capture.</param>
  /// <param name="style">The style of the named group.</param>
  /// <returns>A new <see cref="GroupBuilder"/> instance with the updated expression.</returns>
  public GroupBuilder NamedCaptureGroup(string name, string pattern, NamedGroupStyle style)
  {
    if (string.IsNullOrEmpty(name))
      throw new ArgumentException("Name cannot be null or empty.");
    if (string.IsNullOrEmpty(pattern))
      throw new ArgumentException("Pattern cannot be null or empty.");

    string newExpression = "";
    switch (style)
    {
      case NamedGroupStyle.SingleQuote:
        newExpression += $"(?'{name}'{pattern})";
        break;
      case NamedGroupStyle.AngleBrackets:
        newExpression += $"(?<{name}>{pattern})";
        break;
      case NamedGroupStyle.PStyle:
        newExpression += $"(?P<{name}>{pattern})";
        break;

    }
    return new GroupBuilder(_Builder, newExpression);
  }

  /// <summary>
  /// Adds a named capturing group to the regular expression pattern.
  /// </summary>
  /// <param name="name">The name of the group.</param>
  /// <param name="pattern">The pattern to capture.</param>
  /// <param name="style">The style of the named group as a string.</param>
  /// <returns>A new <see cref="GroupBuilder"/> instance with the updated expression.</returns>
  public GroupBuilder NamedCaptureGroup(string name, string pattern, string style)
  {
    if (Enum.TryParse(style, true, out NamedGroupStyle namedGroupStyle))
      return NamedCaptureGroup(name, pattern, namedGroupStyle);
    else
      throw new ArgumentException($"Invalid style: {style}");
  }

  /// <summary>
  /// Adds an atomic group to the regular expression pattern.
  /// </summary>
  /// <param name="pattern`">The pattern to include in the group.</param>
  /// <returns>The current <see cref="GroupBuilder"/> instance.</returns>
  public GroupBuilder AtomicGroup(string pattern)
  {
    _expression += $"(?>{pattern})";
    return this;
  }

  /// <summary>
  /// Adds a subpattern group number reset to the regular expression pattern.
  /// </summary>
  /// <param name="pattern">The pattern to include in the group.</param>
  /// <returns>The current <see cref="GroupBuilder"/> instance.</returns>
  public GroupBuilder SubpatternGroupNumberReset(string pattern)
  {
    _expression += $"(?|{pattern})";
    return this;
  }

  /// <summary>
  /// Adds a comment group to the regular expression pattern.
  /// </summary>
  /// <param name="comment">The comment to include in the group.</param>
  /// <returns>The current <see cref="GroupBuilder"/> instance.</returns>
  public GroupBuilder CommentGroup(string comment)
  {
    _expression += $"(?#{comment})";
    return this;
  }

  /// <summary>
  /// Adds inline modifiers to the regular expression pattern.
  /// </summary>
  /// <param name="modifiers">The modifiers to include.</param>
  /// <returns>The current <see cref="GroupBuilder"/> instance.</returns>
  public GroupBuilder InlineModifiers(string modifiers)
  {
    _expression += $"(?{modifiers})";
    return this;
  }

  /// <summary>
  /// Adds localized inline modifiers to the regular expression pattern.
  /// </summary>
  /// <param name="modifiers">The modifiers to include.</param>
  /// <param name="pattern">The pattern to apply the modifiers to.</param>
  /// <returns>The current <see cref="GroupBuilder"/> instance.</returns>
  public GroupBuilder LocalizedInlineModifiers(string modifiers, string pattern)
  {
    _expression += $"(?{modifiers}:{pattern})";
    return this;
  }

  /// <summary>
  /// Adds a conditional statement to the regular expression pattern.
  /// </summary>
  /// <param name="number">The number to evaluate the condition against.</param>
  /// <param name="yesPattern">The pattern to match if the condition is true.</param>
  /// <param name="noPattern">The pattern to match if the condition is false.</param>
  /// <returns>The current <see cref="GroupBuilder"/> instance.</returns>
  public GroupBuilder ConditionalStatementNumber(string number, string yesPattern, string noPattern)
  {
    _expression += $"(?({number}){yesPattern}|{noPattern})";
    return this;
  }

}
