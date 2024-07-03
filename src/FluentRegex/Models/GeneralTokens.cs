using System.Linq;
using System.ComponentModel;

namespace FluentRegex;

/// <summary>
/// Represents all known character classes for regex.
/// </summary>
public static class GeneralTokens
{
    /// <summary>
    /// Represents the newline character class \n.
    /// </summary>
    public static readonly string Newline = "\\n";

    /// <summary>
    /// Represents the carriage return character class \n.
    /// </summary>
    public static readonly string CarriageReturn = "\\r";

    /// <summary>
    /// Represents the tab character class \t.
    /// </summary>
    public static readonly string Tab = "\\t";

    /// <summary>
    /// Represents the null character class \0.
    /// </summary>
    public static readonly string Null = "\\0";

}