namespace Builder;
// <summary>
// An abstract base class for all builders.
// Implements the common functionality for all builders.
// The class is abstract and cannot be instantiated.
// </summary>
public abstract class Builder
{
  /// <summary>
  /// The regular expression pattern.
  /// </summary>
  protected string? _expression;

  /// <summary>
  /// The regular expression builder.
  /// </summary>
  protected RegExpBuilder _regExpBuilder;

  // Default constructor
  public Builder()
  {
    _expression = string.Empty;
    _regExpBuilder = new RegExpBuilder();
  }


  /// <summary>
  /// Initializes a new instance of the <see cref="Builder"/> class with the specified <see cref="RegExpBuilder"/>.
  /// </summary>
  /// <param name="regExpBuilder">The <see cref="RegExpBuilder"/> to associate with this <see cref="Builder"/>.</param>
  protected Builder(RegExpBuilder regExpBuilder)
  {
    _regExpBuilder = regExpBuilder;
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="Builder"/> class with the specified <see cref="RegExpBuilder"/> and expression.
  /// </summary>
  /// <param name="regExpBuilder">The <see cref="RegExpBuilder"/> to associate with this <see cref="Builder"/>.</param>
  /// <param name="expression">The regular expression pattern.</param>
  protected Builder(RegExpBuilder regExpBuilder, string expression)
  {
    _regExpBuilder = regExpBuilder;
    _expression = expression;
  }

  /// <summary>
  /// Returns the regular expression pattern represented by this <see cref="Builder"/>.
  /// </summary>
  /// <returns>The regular expression pattern.</returns>
  public override string ToString()
  {
    return Build();
  }

  /// <summary>
  /// Builds the regular expression pattern.
  /// </summary>
  /// <returns>The regular expression pattern.</returns>
  public string Build()
  {
    return _expression ?? string.Empty;
  }
}