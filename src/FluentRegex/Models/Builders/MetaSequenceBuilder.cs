using System.Diagnostics;
using System.Text;

namespace FluentRegex;

/// <summary>
/// Builds a meta sequence for a regular expression pattern. Inherits from <see cref="IBuilder"/>.
/// </summary>
public class MetaSequenceBuilder : IBuilder
{
    /// <summary>
    /// Gets or sets the pattern.
    /// </summary>
    /// <value></value>
    public StringBuilder Pattern
    {
        get => _pattern;
        set => _pattern = value;
    }
    internal string MetaSequence
    {
        get => _pattern.ToString();
        set => _pattern = Pattern.Append(value);
    }
    private readonly dynamic _patternBuilder;
    internal StringBuilder _pattern = new();


    /// <summary>
    /// Initializes a new instance of the <see cref="MetaSequenceBuilder"/> class.
    /// </summary>
    public MetaSequenceBuilder(dynamic builder)
    {
        _patternBuilder = builder;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MetaSequenceBuilder"/> class.
    /// </summary>
    public MetaSequenceBuilder(PatternBuilder patternBuilder)
    {
        _patternBuilder = patternBuilder;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MetaSequenceBuilder"/> class.
    /// </summary>
    public MetaSequenceBuilder(GroupBuilder groupBuilder)
    {
        _patternBuilder = groupBuilder;
    }

    /// <summary>
    /// Builds the meta sequence.
    /// </summary>
    public dynamic Build()
    {
        _ = _patternBuilder.Pattern.Append(MetaSequence);
        return _patternBuilder;
    }

    /// <summary>
    /// Appends a literal string to the meta sequence.
    /// </summary>
    public MetaSequenceBuilder AppendLiteral(string literal)
    {
        ((IBuilder)_patternBuilder).AppendLiteral(literal);
        return this;
    }

    /// <summary>
    /// Appends the <see cref="MetaSequences.AnyCharacter"/> ('.') to the meta sequence.
    /// </summary>
    public MetaSequenceBuilder AnyCharacter()
    {
        MetaSequence = MetaSequences.AnyCharacter;
        return this;
    }

    /// <summary>
    /// Appends the <see cref="MetaSequences.Digit"/> ('\d') to the meta sequence.
    /// </summary>
    public MetaSequenceBuilder Digit()
    {
        MetaSequence = MetaSequences.Digit;
        return this;
    }

    /// <summary>
    /// Appends the <see cref="MetaSequences.NonDigit"/> ('\D') to the meta sequence.
    /// </summary>
    public MetaSequenceBuilder NonDigit()
    {
        MetaSequence = MetaSequences.NonDigit;
        return this;
    }

    /// <summary>
    /// Appends the <see cref="MetaSequences.Whitespace"/> ('\s') to the meta sequence.
    /// </summary>
    public MetaSequenceBuilder Whitespace()
    {
        MetaSequence = MetaSequences.Whitespace;
        return this;
    }

    /// <summary>
    /// Appends the <see cref="MetaSequences.NonWhitespace"/> ('\S') to the meta sequence.
    /// </summary>
    public MetaSequenceBuilder NonWhitespace()
    {
        MetaSequence = MetaSequences.NonWhitespace;
        return this;
    }

    /// <summary>
    /// Appends the <see cref="MetaSequences.Word"/> ('\w') to the meta sequence.
    /// </summary>
    public MetaSequenceBuilder Word()
    {
        MetaSequence = MetaSequences.Word;
        return this;
    }

    /// <summary>
    /// Appends the <see cref="MetaSequences.NonWord"/> ('\W') to the meta sequence.
    /// </summary>
    public MetaSequenceBuilder NonWord()
    {
        MetaSequence = MetaSequences.NonWord;
        return this;
    }

    /// <summary>
    /// Appends the <see cref="MetaSequences.Tab"/> ('\t') to the meta sequence.
    /// </summary>
    public MetaSequenceBuilder Tab()
    {
        MetaSequence = MetaSequences.Tab;
        return this;
    }

    //// <summary>
    //// Appends the <see cref="MetaSequences.AnyUnicode" /> ('\X') to the meta sequence.
    //// </summary>
    //// <returns> This <see cref="MetaSequenceBuilder"/> instance. </returns>
    //// public MetaSequenceBuilder AnyUnicode()
    //// {
    ////     MetaSequence = MetaSequences.AnyUnicode;
    ////     return this;
    //// }

    /// <summary>
    /// Appends the <see cref="MetaSequences.Or"/> ('|') to the meta sequence.
    /// </summary>
    public MetaSequenceBuilder Or()
    {
        MetaSequence = MetaSequences.Or;
        return this;
    }


    /// <summary>
    /// Not implemented.
    /// </summary>
    void IBuilder.Validate()
    {
        throw new NotImplementedException();
        // ((IBuilder)_patternBuilder).Validate();
    }

    /// <summary>
    /// Not implemented.
    /// </summary>
    void IBuilder.Validate(bool _)
    {
        throw new NotImplementedException();
        // ((IBuilder)_patternBuilder).Validate();
    }

    string IBuilder.ToString()
    {
        return Pattern.ToString();
    }

    /// <summary>
    /// Invokes a method by name.
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="args"></param>
    /// <returns>
    /// This <see cref="MetaSequenceBuilder"/> instance.
    /// </returns>
    public MetaSequenceBuilder InvokeMethod(string methodName, params object[] args)
    {
        var method = GetType().GetMethod(methodName);
        _ = method!.Invoke(this, args);
        return this;
    }

}