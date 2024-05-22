global using System;
global using System.Linq;
global using System.Collections.Generic;
global using System.Text.RegularExpressions;
namespace Builder;


/// <summary>
/// A builder for creating regular expressions in a fluent manner.
/// </summary>
public class RegExpBuilder : Builder
{
    /// <summary>
    /// Represents a builder for creating regular expressions.
    /// </summary>
    private List<string> _expressions;
    private State _state;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegExpBuilder"/> class.
    /// </summary>
    public RegExpBuilder()
    {
        _state = new State();
        _expressions = new List<string>();
    }

    /// <summary>
    /// Adds a new group to the regular expression.
    /// </summary>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder Group()
    {
        var builder = new RegExpBuilder();
        _expressions.Add(AddParenthesis(builder.ToString()));
        return this;
    }

    /// <summary>
    /// Converts the regular expression to a string.
    /// </summary>
    /// <returns>The regular expression as a string.</returns>
    public override string ToString()
    {
        return string.Join("", _expressions);
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
    /// Adds an anchor builder to the regular expression.
    /// </summary>
    /// <returns>The <see cref="AnchorBuilder"/> instance.</returns>
    public AnchorBuilder AddAnchor()
    {
        return new AnchorBuilder(this);
    }

    /// <summary>
    /// Adds an anchor builder to the regular expression.
    /// </summary>
    /// <param name="anchor">The <see cref="AnchorBuilder"/> instance.</param>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder AddAnchor(AnchorBuilder anchor)
    {
        _expressions.Add(anchor.ToString());
        return this;
    }

    /// <summary>
    /// Adds an anchor builder to the regular expression.
    /// </summary>
    /// <param name="config">The configuration action for the <see cref="AnchorBuilder"/>.</param>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder AddAnchor(Action<AnchorBuilder> config)
    {
        var anchorBuilder = new AnchorBuilder();
        config(anchorBuilder);
        _expressions.Add(anchorBuilder.ToString());
        return this;
    }

    /// <summary>
    /// Adds a start of input anchor to the regular expression.
    /// </summary>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder StartOfInput()
    {
        _expressions.Add("(?:^)");
        return this;
    }

    /// <summary>
    /// Adds an end of input anchor to the regular expression.
    /// </summary>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder EndOfInput()
    {
        _expressions.Add("(?:$)");
        return this;
    }

    /// <summary>
    /// Adds a start of line anchor to the regular expression.
    /// </summary>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder StartOfLine()
    {
        _state.SetMultiLine(true);
        StartOfInput();
        return this;
    }

    /// <summary>
    /// Adds an end of line anchor to the regular expression.
    /// </summary>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder EndOfLine()
    {
        _state.SetMultiLine(true);
        EndOfInput();
        return this;
    }

    /// <summary>
    /// Sets the state to match one or more of the next character.
    /// </summary>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder OneOrMore()
    {
        _state.SetSome(true);
        return this;
    }

    /// <summary>
    /// Adds a digit character class to the regular expression.
    /// </summary>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder Digit()
    {
        AddExpression("d");
        return this;
    }

    /// <summary>
    /// Adds a digit character class with a plus quantifier to the regular expression.
    /// </summary>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder Digits()
    {
        AddExpression("d+");
        return this;
    }

    /// <summary>
    /// Sets the state to match zero or one of the next character.
    /// </summary>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder ZeroOrOne()
    {
        _state.SetZeroOrOne(true);
        return this;
    }

    /// <summary>
    /// Adds a letter character class to the regular expression.
    /// </summary>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder Letter()
    {
        _state.SetSome(false);
        AddFrom("A-Za-z");
        return this;
    }

    /// <summary>
    /// Adds a letter character class with a plus quantifier to the regular expression.
    /// </summary>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder Letters()
    {
        _state.SetSome(true);
        AddFrom("A-Za-z");
        return this;
    }

    /// <summary>
    /// Sets the state to match a minimum number of the next character.
    /// </summary>
    /// <param name="minimumOccurrence">The minimum number of occurrences.</param>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder MinimumOf(int minimumOccurrence)
    {
        _state.SetMinimumOf(minimumOccurrence);
        return this;
    }

    /// <summary>
    /// Sets the state to match an alternative pattern.
    /// </summary>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder Or()
    {
        _state.SetOr(true);
        return this;
    }

    /// <summary>
    /// Adds an alternative pattern to the regular expression.
    /// </summary>
    /// <param name="RegExpression">The alternative regular expression.</param>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder OrLike(Regex RegExpression)
    {
        var lastExpression = _expressions.Last();
        _expressions.Remove(lastExpression);

        lastExpression = StripParenthesis(lastExpression);

        _expressions.Add(AddParenthesis($"{lastExpression}|(?:{RegExpression})"));

        return this;
    }

    /// <summary>
    /// Removes the parenthesis from a string.
    /// </summary>
    /// <param name="literal">The string literal.</param>
    /// <returns>The string without parenthesis.</returns>
    private string StripParenthesis(string literal)
    {
        return literal.Trim('(', ')');
    }

    /// <summary>
    /// Adds parenthesis to a string.
    /// </summary>
    /// <param name="literal">The string literal.</param>
    /// <returns>The string with added parenthesis.</returns>
    private string AddParenthesis(string literal)
    {
        return literal.Length > 0 ? $"({literal})" : literal;
    }

    /// <summary>
    /// Adds a character class to the regular expression.
    /// </summary>
    /// <param name="characterClass">The character class.</param>
    private void AddFrom(string characterClass)
    {
        var from = $"[{characterClass}]";
        from = AddFilters(from);

        _expressions.Add(from);
    }

    /// <summary>
    /// Adds filters to a string.
    /// </summary>
    /// <param name="literal">The string literal.</param>
    /// <returns>The string with added filters.</returns>
    private string AddFilters(string literal)
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
    private string GetQuantityLiteral()
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

        return $"{{{_state.MinimumOf},{_state.MaximumOf}}}";
    }

    /// <summary>
    /// Adds a literal to the regular expression.
    /// </summary>
    /// <param name="literal">The literal to add.</param>
    private void AddExpression(string literal)
    {
        Add(@"\" + literal);
    }

    /// <summary>
    /// Adds a string to the regular expression.
    /// </summary>
    /// <param name="literal">The string to add.</param>
    internal void Add(string literal)
    {
        literal = AddFilters(literal);
        literal = HandleConditions(literal);
        literal = AddParenthesis(literal);
        if (literal.Length > 0)
            _expressions.Add(literal);
    }

    /// <summary>
    /// Handles the conditions for the regular expression.
    /// </summary>
    /// <param name="literal">The string literal.</param>
    /// <returns>The modified string literal.</returns>
    private string HandleConditions(string literal)
    {
        if (_state.Or)
        {
            OrLike(new Regex(literal));
            literal = "";
            _state.SetOr(false);
        }

        return literal;
    }

    /// <summary>
    /// Sets the state to match a maximum number of the next character.
    /// </summary>
    /// <param name="maximumOccurrences">The maximum number of occurrences.</param>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder MaximumOf(int maximumOccurrences)
    {
        _state.SetMaximumOf(maximumOccurrences);
        return this;
    }

    /// <summary>
    /// Sets the state to match exactly a number of the next character.
    /// </summary>
    /// <param name="Occurrences">The number of occurrences.</param>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder Exactly(int Occurrences)
    {
        _state.SetMinimumOf(Occurrences);
        _state.SetMaximumOf(Occurrences);
        return this;
    }

    /// <summary>
    /// Adds a string to match to the regular expression.
    /// </summary>
    /// <param name="stringToMatch">The string to match.</param>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder Of(string stringToMatch)
    {
        Add(stringToMatch);
        return this;
    }
}
