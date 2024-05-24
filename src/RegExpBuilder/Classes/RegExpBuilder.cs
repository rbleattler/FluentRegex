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
    /// The current expression.
    /// </summary>
    private List<string> _expressions;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegExpBuilder"/> class.
    /// </summary>
    public RegExpBuilder()
    {
        _state = new State(false, false, -1, -1, new RegexOptions(), false, false);
        _expressions = new List<string>();
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
    /// Adds a group builder to the regular expression.
    /// </summary>
    /// <param name="group">The <see cref="GroupBuilder"/> instance.</param>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    ///
    public RegExpBuilder AddGroup(GroupBuilder group)
    {
        _expressions.Add(group.ToString());
        return this;
    }

    /// <summary>
    /// Adds a group builder to the regular expression.
    /// </summary>
    /// <param name="config">The configuration action for the <see cref="GroupBuilder"/>.</param>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder AddGroup(Action<GroupBuilder> config)
    {
        var groupBuilder = new GroupBuilder();
        config(groupBuilder);
        _expression = groupBuilder.ToString();
        AddCurrentExpression();
        return this;
    }


    /// <summary>
    /// Adds an anchor builder to the regular expression.
    /// </summary>
    /// <param name="anchor">The <see cref="AnchorBuilder"/> instance.</param>
    /// <returns>The <see cref="RegExpBuilder"/> instance.</returns>
    public RegExpBuilder AddAnchor(AnchorBuilder anchor)
    {
        _expression = anchor.ToString();
        AddCurrentExpression();
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
        _expression = anchorBuilder.ToString();
        AddCurrentExpression();
        return this;
    }

    /// <summary>
    /// Adds a string to the regular expression.
    /// </summary>
    /// <param name="literal">The string to add.</param>
    internal RegExpBuilder Add(string literal)
    {
        literal = AddFilters(literal);
        literal = HandleConditions(literal);
        // literal = AddParenthesis(literal);
        if (literal.Length > 0)
            _expressions.Add(literal);
        return this;
    }

    internal RegExpBuilder Add(string literal, bool withParenthesis = false)
    {
        literal = AddFilters(literal);
        literal = HandleConditions(literal);
        if (withParenthesis)
            literal = AddParenthesis(literal);
        if (literal.Length > 0)
            _expressions.Add(literal);
        return this;
    }

    /// <summary>
    /// Adds a string to match to the regular expression.
    /// </summary>
    /// <param name="stringToMatch">The string to match.</param>
    /// <returns>The <see cref="Builder"/> instance.</returns>
    public RegExpBuilder Of(string stringToMatch)
    {
        Add(stringToMatch);
        return this;
    }

    /// <summary>
    /// Adds an alternative pattern to the regular expression.
    /// </summary>
    /// <param name="regExpression">The alternative regular expression.</param>
    /// <returns>The <see cref="Builder"/> instance.</returns>
    public RegExpBuilder OrLike(Regex regExpression)
    {
        OrLike(regExpression, false, false);
        return this;
    }

    /// <summary>
    /// Adds an alternative pattern to the regular expression.
    /// </summary>
    /// <param name="regExpression">The alternative regular expression.</param>
    /// <param name="stripParenthesis">Whether to strip the parenthesis.</param>
    /// <param name="surroundWithParenthesis">Whether to surround with parenthesis.</param>
    public RegExpBuilder OrLike(Regex regExpression, bool stripParenthesis = true, bool surroundWithParenthesis = true)
    {
        var lastExpression = _expressions.Last();
        string _output;
        _expressions.Remove(lastExpression);

        if (stripParenthesis)
            lastExpression = StripParenthesis(lastExpression);

        if (surroundWithParenthesis)
            _output = AddParenthesis($"{lastExpression}|{regExpression}");
        else
            _output = $"{lastExpression}|{regExpression}";

        _expressions.Add(_output);

        return this;
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
    /// clear current expression
    /// </summary>
    public void Clear()
    {
        _expression = "";
    }

    /// <summary>
    /// add current expression to the list of expressions
    /// </summary>
    public void AddCurrentExpression()
    {
        _expressions.Add(_expression!);
        Clear();
    }

    /// <summary>
    /// Converts the regular expression to a <see cref="Regex"/> instance.
    /// </summary>
    /// <returns>The regular expression as a <see cref="Regex"/> instance.</returns>
    public Regex ToRegex()
    {
        return new Regex(ToString(), _state.Options);
    }

}
