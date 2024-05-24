namespace Builder;
// <summary>
// An abstract base class for all builders.
// Implements the common functionality for all builders.
// The class is abstract and cannot be instantiated.
// </summary>

// TODO: Add "word" coverage for non-english languages
public abstract class Builder
{

  /// <summary>
  /// State of the regular expression.
  /// </summary>
  internal State _state;

  /// <summary>
  /// The regular expression pattern.
  /// </summary>
  internal string? _expression;

  /// <summary>
  /// The regular expression builder.
  /// </summary>
  protected Builder _Builder;

  // Default constructor
  public Builder()
  {
    _expression = string.Empty;
    _Builder = this;
    _state = new State();
  }


  /// <summary>
  /// Initializes a new instance of the <see cref="Builder"/> class with the specified <see cref="Builder"/>.
  /// </summary>
  /// <param name="Builder">The <see cref="Builder"/> to associate with this <see cref="Builder"/>.</param>
  protected Builder(Builder Builder)
  {
    _Builder = Builder;
    _expression = Builder._expression;
    _state = Builder._state;
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="Builder"/> class with the specified <see cref="Builder"/> and expression.
  /// </summary>
  /// <param name="Builder">The <see cref="Builder"/> to associate with this <see cref="Builder"/>.</param>
  /// <param name="expression">The regular expression pattern.</param>
  protected Builder(Builder Builder, string expression)
  {
    _Builder = Builder;
    _expression = expression;
    try
    {
      _state = Builder._state;
    }
    catch (Exception)
    {
      _state = new State();
    }
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="GroupBuilder"/> class with the specified <see cref="Builder"/> and expression.
  /// </summary>
  /// <returns></returns>
  public GroupBuilder AddGroup()
  {
    return new GroupBuilder();
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="AnchorBuilder"/> class with the specified <see cref="Builder"/> and expression.
  /// </summary>
  /// <returns></returns>
  public AnchorBuilder AddAnchor()
  {
    return new AnchorBuilder();
  }


  /// <summary>
  /// Removes the parenthesis from a string.
  /// </summary>
  /// <param name="literal">The string literal.</param>
  /// <returns>The string without parenthesis.</returns>
  public string StripParenthesis(string literal)
  {
    return literal.Trim('(', ')');
  }

  /// <summary>
  /// Adds parenthesis to a string.
  /// </summary>
  /// <param name="literal">The string literal.</param>
  /// <returns>The string with added parenthesis.</returns>
  public string AddParenthesis(string literal)
  {
    return literal.Length > 0 ? $"({literal})" : literal;
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

  // AsGroup
  /// <summary>
  /// Takes the current expression and wraps it in a named capture group of the specified style.
  /// </summary>
  /// <param name="style">The type of group.</param>
  /// <param name="name">The name of group.</param>
  /// <returns>The current <see cref="Builder"/> instance with the updated expression.</returns>
  ///
  public Builder AsNamedCaptureGroup(string name, NamedGroupStyle style)
  {
    return new GroupBuilder().NamedCaptureGroup(name, _expression!, style);
  }

  /// <summary>
  /// Takes the current expression and wraps it in a non-capturing group.
  /// </summary>
  /// <returns>The current <see cref="Builder"/> instance with the updated expression.</returns>
  /// <remarks>Non-capturing groups are used to group subexpressions without capturing the matched text.</remarks>
  /// <seealso href="https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference#grouping-constructs"/>
  public Builder AsNonCaptureGroup()
  {
    return new GroupBuilder().NonCaptureGroup(_expression!);
  }

  /// <summary>
  /// Takes the current expression and wraps it in an unnamed capture group.
  /// </summary>
  /// <returns>The current <see cref="Builder"/> instance with the updated expression.</returns>
  /// <remarks>Unnamed capture groups are used to group subexpressions and capture the matched text.</remarks>
  public Builder AsCaptureGroup()
  {
    var groupBuilder = new GroupBuilder().CaptureGroup(_expression!);
    _expression = groupBuilder.ToString();
    return this;
  }


  /// <summary>
  /// Converts the regular expression to a <see cref="Regex"/> object.
  /// </summary>
  /// <returns>The regular expression as a <see cref="Regex"/> object.</returns>
  public Regex ToRegExp()
  {
    RegexOptions options = _state.MultiLine ? RegexOptions.Multiline : new RegexOptions();
    return new Regex(ToString(), options);
  }

  /// <summary>
  /// Adds a start of input anchor to the regular expression.
  /// </summary>
  /// <returns>The <see cref="Builder"/> instance.</returns>
  public Builder StartOfInput()
  {
    _expression += AddAnchor().StartsWith(string.Empty, _state.MultiLine).Build();
    return this;
  }

  /// <summary>
  /// Adds an end of input anchor to the regular expression.
  /// </summary>
  /// <returns>The <see cref="Builder"/> instance.</returns>
  public Builder EndOfInput()
  {
    _expression += AddAnchor().EndsWith(string.Empty, _state.MultiLine).Build();
    return this;
  }

  /// <summary>
  /// Adds a start of line anchor to the regular expression.
  /// </summary>
  /// <returns>The <see cref="Builder"/> instance.</returns>
  public Builder StartOfLine()
  {
    _state.SetMultiLine(true);
    StartOfInput();
    HandleState();
    return this;
  }

  /// <summary>
  /// Adds an end of line anchor to the regular expression.
  /// </summary>
  /// <returns>The <see cref="Builder"/> instance.</returns>
  public Builder EndOfLine()
  {
    _state.SetMultiLine(true);
    EndOfInput();
    HandleState();
    return this;
  }

  /// <summary>
  /// Sets the state to match one or more of the next character.
  /// </summary>
  /// <returns>The <see cref="Builder"/> instance.</returns>
  public Builder OneOrMore()
  {
    _state.SetSome(true);
    HandleState();
    return this;
  }

  /// <summary>
  /// Adds a digit character class to the regular expression.
  /// </summary>
  /// <returns>The <see cref="Builder"/> instance.</returns>
  public Builder Digit()
  {
    AddLiteral(CharacterClass.Digit);
    return this;
  }

  /// <summary>
  /// Adds a digit character class with a plus quantifier to the regular expression.
  /// </summary>
  /// <returns>The <see cref="Builder"/> instance.</returns>
  public Builder Digits()
  {
    AddLiteral(CharacterClass.Digit);
    OneOrMore();
    return this;
  }

  /// <summary>
  /// Sets the state to match zero or one of the next character.
  /// </summary>
  /// <returns>The <see cref="Builder"/> instance.</returns>
  public Builder ZeroOrOne()
  {
    _state.SetZeroOrOne(true);
    HandleState();
    return this;
  }

  /// <summary>
  /// Adds a letter character class to the regular expression.
  /// </summary>
  /// <returns>The <see cref="Builder"/> instance.</returns>
  public Builder Letter()
  {
    _state.SetSome(false);
    AddFrom("A-Za-z");
    return this;
  }

  /// <summary>
  /// Adds a letter character class with a plus quantifier to the regular expression.
  /// </summary>
  /// <returns>The <see cref="Builder"/> instance.</returns>
  public Builder Letters()
  {
    _state.SetSome(true);
    AddFrom("A-Za-z");
    return this;
  }

  /// <summary>
  /// Sets the state to match a minimum number of the next character.
  /// </summary>
  /// <param name="minimumOccurrence">The minimum number of occurrences.</param>
  /// <returns>The <see cref="Builder"/> instance.</returns>
  public Builder MinimumOf(int minimumOccurrence)
  {
    _state.SetMinimumOf(minimumOccurrence);
    HandleState();
    return this;
  }

  /// <summary>
  /// Sets the state to match an alternative pattern.
  /// </summary>
  /// <returns>The <see cref="Builder"/> instance.</returns>
  public Builder Or()
  {
    _state.SetOr(true);
    HandleState();
    return this;
  }

  /// <summary>
  /// Adds filters to a string.
  /// </summary>
  /// <param name="literal">The string literal.</param>
  /// <returns>The string with added filters.</returns>
  internal string AddFilters(string literal)
  {
    var quantitySet = GetQuantityLiteral();
    literal += quantitySet;

    if (quantitySet == string.Empty)
    {
      if (_state.ZeroOrOne && !literal.EndsWith("?"))
        literal += "?";

      if (_state.Some && !literal.EndsWith("+"))
        literal += "+";
    }

    return literal;
  }

  /// <summary>
  /// Gets the quantity literal for the state.
  /// </summary>
  /// <returns>The quantity literal.</returns>
  internal string GetQuantityLiteral()
  {
    if (_state.MinimumOf == -1 && _state.MaximumOf == -1)
      return string.Empty;

    if (_state.MinimumOf == 0 && _state.MaximumOf == -1)
      return "*";

    if (_state.MinimumOf == 1 && _state.MaximumOf == -1)
      return "+";

    if (_state.MinimumOf == 0 && _state.MaximumOf == 1)
      return "?";

    if (_state.MinimumOf == _state.MaximumOf)
      return $"{{{_state.MinimumOf}}}";

    if (_state.MinimumOf == -1 && _state.MaximumOf != -1)
      return $"{{0,{_state.MaximumOf}}}";

    if (_state.MinimumOf != -1 && _state.MaximumOf == -1)
      return $"{{{_state.MinimumOf},}}";

    return $"{{{_state.MinimumOf},{_state.MaximumOf}}}";
  }

  /// <summary>
  /// Sets the state to match a maximum number of the next character.
  /// </summary>
  /// <param name="maximumOccurrences">The maximum number of occurrences.</param>
  /// <returns>The <see cref="Builder"/> instance.</returns>
  public Builder MaximumOf(int maximumOccurrences)
  {
    _state.SetMaximumOf(maximumOccurrences);
    return this;
  }

  /// <summary>
  /// Sets the state to match exactly a number of the next character.
  /// </summary>
  /// <param name="occurrences">The number of occurrences.</param>
  /// <returns>The <see cref="Builder"/> instance.</returns>
  public Builder Exactly(int occurrences)
  {
    _state.SetMinimumOf(occurrences);
    _state.SetMaximumOf(occurrences);
    return this;
  }

  /// <summary>
  /// Adds a literal to the regular expression.
  /// </summary>
  /// <param name="literal">The literal to add.</param>
  private void AddLiteral(string literal)
  {
    var classes = CharacterClasses.GetCharacterClasses();
    if (literal.Length == 1 && classes.Contains(literal))
    {
      var literalName = CharacterClasses.GetCharacterClass(literal);
      literal = AddFilters(CharacterClasses.GetLiteral(literalName));
      _expression += $"\\{literal}";
    }
    else
    {
      literal = AddFilters(literal);
      _expression += Regex.Escape(literal);
      HandleState();
    }
  }

  /// <summary>
  /// Adds a literal to the regular expression.
  /// </summary>
  /// <param name="characterClass">The character class to add the literal for.</param>
  private void AddLiteral(CharacterClass characterClass)
  {
    var literal = CharacterClasses.GetLiteral(characterClass);
    literal = AddFilters(literal);
    // _expression += Regex.Escape(literal);
    _expression += literal;
    HandleState();
  }

  /// <summary>
  /// Adds a target object to the regular expression.
  /// </summary>
  /// <param name="target">The target object to add. Strings are added as literals.</param>
  /// <returns>The <see cref="Builder"/> instance.</returns>
  /// <exception cref="ArgumentException">Thrown when the target cannot be added to the regular expression.</exception>
  public Builder Add(object target)
  {
    try
    {
      _expression += AddFilters(target.ToString()!);
      HandleState();
    }
    catch (Exception ex) when (ex is NullReferenceException || ex is FormatException)
    {
      throw new ArgumentException("Invalid target. The target must be convertible to a string.", ex);
    }
    return this;
  }

  /// <summary>
  /// Adds from a character class to the regular expression.
  /// </summary>
  /// <param name="characterClass">The character class to add.</param>
  /// <returns>The <see cref="Builder"/> instance.</returns>
  public Builder AddFrom(string characterClass)
  {
    _expression += AddFilters($"[{characterClass}]");
    return this;
  }

  /// <summary>
  /// Handles state changes for the regular expression.
  /// </summary>

  public void HandleState(bool? resetState = false)
  {
    if (_state.Or)
    {
      _expression += "|";
      _state.SetOr(false);
    }

    if (_state.ZeroOrOne)
    {
      _expression += "?";
      _state.SetZeroOrOne(false);
    }

    if (_state.Some)
    {
      _expression += "+";
      _state.SetSome(false);
    }

    if (_state.MinimumOf != -1 || _state.MaximumOf != -1)
    {
      _expression += GetQuantityLiteral();
      _state.SetMinimumOf(-1);
      _state.SetMaximumOf(-1);
    }

    if (resetState == true)
    {
      _state.Reset();
    }
  }

  /// <summary>
  /// Resets the regular expression builder.
  /// </summary>
  public void Reset()
  {
    _expression = string.Empty;
    _state.Reset();
  }
}