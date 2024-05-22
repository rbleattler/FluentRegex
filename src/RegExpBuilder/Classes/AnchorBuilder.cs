namespace Builder;

/// <summary>
/// Represents a builder for creating regular expression patterns with anchor constraints.
/// </summary>
public class AnchorBuilder : Builder
{

  /// <summary>
  /// Initializes a new instance of the <see cref="AnchorBuilder"/> class with the specified <see cref="Builder"/>.
  /// </summary>
  /// <param name="Builder">The <see cref="Builder"/> to associate with this <see cref="AnchorBuilder"/>.</param>
  public AnchorBuilder(Builder Builder)
  {
    _Builder = Builder;
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="AnchorBuilder"/> class with a new <see cref="Builder"/>.
  /// </summary>
  public AnchorBuilder()
  {
    _Builder = this;
  }

  /// <summary>
  /// Specifies that the pattern should start with the specified string.
  /// </summary>
  /// <param name="startsWith">The string that the pattern should start with.</param>
  /// <param name="nonMultiLine">Indicates whether the pattern should match only at the start of the input, regardless of multi-line mode.</param>
  /// <returns>The current <see cref="AnchorBuilder"/> instance.</returns>
  public AnchorBuilder StartsWith(string startsWith, bool? nonMultiLine = null)
  {
    if (nonMultiLine.HasValue && nonMultiLine.Value)
      _expression = $"\\A{startsWith}";
    else
      _expression = $"^{startsWith}";
    return this;
  }

  /// <summary>
  /// Specifies that the pattern should end with the specified string.
  /// </summary>
  /// <param name="endsWith">The string that the pattern should end with.</param>
  /// <param name="nonMultiLine">Indicates whether the pattern should match only at the end of the input, regardless of multi-line mode.</param>
  /// <returns>The current <see cref="AnchorBuilder"/> instance.</returns>
  public AnchorBuilder EndsWith(string endsWith, bool? nonMultiLine = null)
  {
    if (nonMultiLine.HasValue && nonMultiLine.Value)
      _expression += $"{endsWith}\\Z";
    else
      _expression += $"{endsWith}$";
    return this;
  }

  /// <summary>
  /// Specifies that the pattern should end with the specified string, without allowing a line terminator at the end.
  /// </summary>
  /// <param name="endsWith">The string that the pattern should end with.</param>
  /// <returns>The current <see cref="AnchorBuilder"/> instance.</returns>
  public AnchorBuilder AbsoluteEndsWith(string endsWith)
  {
    _expression = $"{endsWith}\\z";
    return this;
  }

  /// <summary>
  /// Specifies a word boundary in the pattern.
  /// </summary>
  /// <returns>The current <see cref="AnchorBuilder"/> instance.</returns>
  public AnchorBuilder WordBoundary()
  {
    _expression = @"\b";
    return this;
  }

  /// <summary>
  /// Specifies a non-word boundary in the pattern.
  /// </summary>
  /// <returns>The current <see cref="AnchorBuilder"/> instance.</returns>
  public AnchorBuilder NonWordBoundary()
  {
    _expression = @"\B";
    return this;
  }

  /// <summary>
  /// Returns the regular expression pattern represented by this <see cref="AnchorBuilder"/>.
  /// </summary>
  /// <returns>The regular expression pattern.</returns>
  public override string ToString()
  {
    return _expression ?? "";
  }

}
