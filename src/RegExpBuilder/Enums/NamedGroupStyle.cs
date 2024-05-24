namespace Builder;
/// <summary>
/// Represents the style of a named group in a regular expression pattern.
/// </summary>
/// <remarks>
/// A named group is a capturing group that can be referenced by name.
/// </remarks>
/// <example>
/// <code>
/// var namedGroupBuilder = new GroupBuilder("group", "pattern", NamedGroupStyle.AngleBrackets);
/// var builder = new RegExpBuilder().AddGroup(namedGroupBuilder);
/// var pattern = builder.Build();
/// Console.WriteLine(pattern);
/// // Output:
/// // (?&lt;group&gt;pattern)
/// </code>
/// </example>
public enum NamedGroupStyle
{
    SingleQuote,
    AngleBrackets,
    PStyle,

}