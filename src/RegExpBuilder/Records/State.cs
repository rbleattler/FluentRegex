


/// <param name="Some"></param>
/// <param name="ZeroOrOne"></param>
/// <param name="MinimumOf"></param>
/// <param name="MaximumOf"></param>
/// <param name="Options"></param>
/// <param name="Or"></param>
/// <param name="MultiLine"></param>/// namespace Builder;
public record State(
                    bool Some,
                    bool ZeroOrOne,
                    int MinimumOf,
                    int MaximumOf,
                    RegexOptions Options,
                    bool Or,
                    bool MultiLine
                    )
{
    public State() : this(false, false, -1, -1, new RegexOptions(), false, false) { }

    /// <summary>
    /// Gets or sets a value indicating whether the state represents "some" occurrence.
    /// </summary>
    public bool Some { get; private set; } = Some;

    /// <summary>
    /// Gets or sets a value indicating whether the state represents "zero or one" occurrence.
    /// </summary>
    public bool ZeroOrOne { get; private set; } = ZeroOrOne;

    /// <summary>
    /// Gets or sets the minimum number of occurrences for the state.
    /// </summary>
    public int MinimumOf { get; private set; } = MinimumOf;

    /// <summary>
    /// Gets or sets the maximum number of occurrences for the state.
    /// </summary>
    public int MaximumOf { get; private set; } = MaximumOf;

    /// <summary>
    /// Gets or sets the regular expression options for the state.
    /// </summary>
    public RegexOptions Options { get; private set; } = Options;

    /// <summary>
    /// Gets or sets a value indicating whether the state represents an "or" condition.
    /// </summary>
    public bool Or { get; private set; } = Or;

    /// <summary>
    /// Gets or sets a value indicating whether the state represents a multi-line condition.
    /// </summary>
    public bool MultiLine { get; private set; } = MultiLine;


    /// <summary>
    /// Sets the value indicating whether the state represents "some" occurrence.
    /// </summary>
    /// <param name="value">The value indicating whether the state represents "some" occurrence.</param>
    public void SetSome(bool value)
    {
        Some = value;
    }

    /// <summary>
    /// Sets the value indicating whether the state represents "zero or one" occurrence.
    /// </summary>
    /// <param name="value">The value indicating whether the state represents "zero or one" occurrence.</param>
    public void SetZeroOrOne(bool value)
    {
        ZeroOrOne = value;
    }

    /// <summary>
    /// Sets the minimum number of occurrences for the state.
    /// </summary>
    /// <param name="value">The minimum number of occurrences for the state.</param>
    public void SetMinimumOf(int value)
    {
        MinimumOf = value;
    }

    /// <summary>
    /// Sets the maximum number of occurrences for the state.
    /// </summary>
    /// <param name="value">The maximum number of occurrences for the state.</param>
    public void SetMaximumOf(int value)
    {
        MaximumOf = value;
    }

    /// <summary>
    /// Sets the regular expression options for the state.
    /// </summary>
    /// <param name="options">The regular expression options for the state.</param>
    public void SetOptions(RegexOptions options)
    {
        Options = options;
    }

    /// <summary>
    /// Sets the value indicating whether the state represents an "or" condition.
    /// </summary>
    /// <param name="value">The value indicating whether the state represents an "or" condition.</param>
    public void SetOr(bool value)
    {
        Or = value;
    }

    /// <summary>
    /// Sets the value indicating whether the state represents a multi-line condition.
    /// </summary>
    /// <param name="value">The value indicating whether the state represents a multi-line condition.</param>
    public void SetMultiLine(bool value)
    {
        MultiLine = value;
    }

    /// <summary>
    /// Resets the state to its default values.
    /// </summary>
    public void Reset()
    {
        Some = false;
        ZeroOrOne = false;
        MinimumOf = -1;
        MaximumOf = -1;
        Or = false;
        MultiLine = false;
    }
}
