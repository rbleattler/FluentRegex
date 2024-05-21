using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Builder;
public class RegExpBuilder
{
    private List<string> _expressions;
    private State _state;

    public RegExpBuilder()
    {
        _state = new State();
        _expressions = new List<string>();
    }

    // Adds a new group to the regular expression
    public RegExpBuilder Group()
    {
        var builder = new RegExpBuilder();
        _expressions.Add(AddParenthesis(builder.ToString()));
        return this;
    }

    // Converts the regular expression to a string
    public override string ToString()
    {
        return string.Join("", _expressions);
    }

    // Converts the regular expression to a Regex object
    public Regex ToRegExp()
    {
        RegexOptions options = _state.MultiLine ? RegexOptions.Multiline : new RegexOptions();
        return new Regex(this.ToString(), options);
    }


    public AnchorBuilder AddAnchor()
    {
        return new AnchorBuilder(this);
    }

    public RegExpBuilder AddAnchor(AnchorBuilder anchor)
    {
        _expressions.Add(anchor.ToString());
        return this;
    }

    public RegExpBuilder AddAnchor(Action<AnchorBuilder> config)
    {
        var anchorBuilder = new AnchorBuilder();
        config(anchorBuilder);
        _expressions.Add(anchorBuilder.ToString());
        return this;
    }

    // Adds a start of input anchor to the regular expression
    public RegExpBuilder StartOfInput()
    {
        _expressions.Add("(?:^)");
        return this;
    }

    // Adds an end of input anchor to the regular expression
    public RegExpBuilder EndOfInput()
    {
        _expressions.Add("(?:$)");
        return this;
    }

    // Adds a start of line anchor to the regular expression
    public RegExpBuilder StartOfLine()
    {
        _state.MultiLine = true;
        StartOfInput();
        return this;
    }

    // Adds an end of line anchor to the regular expression
    public RegExpBuilder EndOfLine()
    {
        _state.MultiLine = true;
        EndOfInput();
        return this;
    }

    // Sets the state to match one or more of the next character
    public RegExpBuilder OneOrMore()
    {
        _state.Some = true;
        return this;
    }

    // Adds a digit character class to the regular expression
    public RegExpBuilder Digit()
    {
        AddExpression("d");
        return this;
    }

    // Adds a digit character class with a plus quantifier to the regular expression
    public RegExpBuilder Digits()
    {
        AddExpression("d+");
        return this;
    }

    // Sets the state to match zero or one of the next character
    public RegExpBuilder ZeroOrOne()
    {
        _state.ZeroOrOne = true;
        return this;
    }

    // Adds a letter character class to the regular expression
    public RegExpBuilder Letter()
    {
        _state.Some = false;
        AddFrom("A-Za-z");
        return this;
    }

    // Adds a letter character class with a plus quantifier to the regular expression
    public RegExpBuilder Letters()
    {
        _state.Some = true;
        AddFrom("A-Za-z");
        return this;
    }

    // Sets the state to match a minimum number of the next character
    public RegExpBuilder MinimumOf(int minimumOccurence)
    {
        _state.MinimumOf = minimumOccurence;
        return this;
    }

    // Sets the state to match an alternative pattern
    public RegExpBuilder Or()
    {
        _state.Or = true;
        return this;
    }

    // Adds an alternative pattern to the regular expression
    public RegExpBuilder OrLike(Regex RegExpression)
    {
        var lastExpression = _expressions.Last();
        _expressions.Remove(lastExpression);

        lastExpression = StripParenthesis(lastExpression);

        _expressions.Add(AddParenthesis($"{lastExpression}|(?:{RegExpression})"));

        return this;
    }

    // Removes the parenthesis from a string
    private string StripParenthesis(string literal)
    {
        return literal.Trim('(', ')');
    }

    // Adds parenthesis to a string
    private string AddParenthesis(string literal)
    {
        return literal.Length > 0 ? $"({literal})" : literal;
    }

    // Adds a character class to the regular expression
    private void AddFrom(string characterClass)
    {
        var from = $"[{characterClass}]";
        from = AddFilters(from);

        _expressions.Add(from);
    }

    // Adds filters to a string
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

    // Adds a literal to the regular expression
    private void AddExpression(string literal)
    {
        Add(@"\" + literal);
    }

    // Adds a string to the regular expression
    internal void Add(string literal)
    {
        literal = AddFilters(literal);
        literal = HandleConditions(literal);
        literal = AddParenthesis(literal);
        if (literal.Length > 0)
            _expressions.Add(literal);
    }

    // Handles the conditions for the regular expression
    private string HandleConditions(string literal)
    {
        if (_state.Or)
        {
            this.OrLike(new Regex(literal));
            literal = "";
            _state.Or = false;
        }

        return literal;
    }

    // Sets the state to match a maximum number of the next character
    public RegExpBuilder MaximumOf(int maximumOccurences)
    {
        _state.MaximumOf = maximumOccurences;
        return this;
    }

    // Sets the state to match exactly a number of the next character
    public RegExpBuilder Exactly(int occurences)
    {
        _state.MinimumOf = occurences;
        _state.MaximumOf = occurences;
        return this;
    }

    // Adds a string to match to the regular expression
    public RegExpBuilder Of(string stringToMatch)
    {
        Add(stringToMatch);
        return this;
    }
}
