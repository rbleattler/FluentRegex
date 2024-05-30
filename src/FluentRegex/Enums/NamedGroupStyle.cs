namespace FluentRegex;
/// <summary>
/// Represents the style of a named group in a regular expression pattern.
/// </summary>
/// <remarks>
/// A named group is a capturing group that can be referenced by name.
/// </remarks>
/// <example>
/// <code>
/// var namedGroupBuilder = new GroupBuilder("group", "pattern", NamedGroupStyle.AngleBrackets);
/// var builder = new FluentRegex().AddGroup(namedGroupBuilder);
/// var pattern = builder.Build();
/// Console.WriteLine(pattern);
/// // Output:
/// // (?&lt;group&gt;pattern)
/// </code>
/// </example>
public enum NamedGroupStyle
{
    /// <summary>
    /// The named group is enclosed in single quotes.
    /// </summary>
    /// <example>
    /// <code>
    /// var namedGroupBuilder = new GroupBuilder("group", "pattern", NamedGroupStyle.SingleQuote);
    /// var builder = new FluentRegex().AddGroup(namedGroupBuilder);
    /// var pattern = builder.Build();
    /// Console.WriteLine(pattern);
    /// // Output:
    /// // (?'group'pattern)
    /// </code>
    /// </example>

    SingleQuote,

    /// <summary>
    /// The named group is enclosed in angle brackets.
    /// </summary>
    /// <example>
    /// <code>
    /// var namedGroupBuilder = new GroupBuilder("group", "pattern", NamedGroupStyle.AngleBrackets);
    /// var builder = new FluentRegex().AddGroup(namedGroupBuilder);
    /// var pattern = builder.Build();
    /// Console.WriteLine(pattern);
    /// // Output:
    /// // (?&lt;group&gt;pattern)
    /// </code>
    /// </example>
    AngleBrackets,

    /// <summary>
    /// The named group is enclosed in angle brackets, preceded by a question mark and the letter 'P'.
    /// </summary>
    /// <example>
    /// <code>
    /// var namedGroupBuilder = new GroupBuilder("group", "pattern", NamedGroupStyle.PStyle);
    /// var builder = new FluentRegex().AddGroup(namedGroupBuilder);
    /// var pattern = builder.Build();
    /// Console.WriteLine(pattern);
    /// // Output:
    /// // (?P&lt;group&gt;pattern)
    /// </code>
    /// </example>
    PStyle,

}