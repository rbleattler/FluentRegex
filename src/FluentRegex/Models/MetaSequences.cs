using System.Linq;
using System.ComponentModel;

namespace FluentRegex;

/// <summary>
/// Represents all known character classes for regex.
/// </summary>
public class MetaSequences : IToken
{
    /// <summary>
    /// Represents the any meta sequence . (dot).
    /// Matches any character except newline.
    /// </summary>
    public static readonly string AnyCharacter = ".";

    /// <summary>
    /// Represents the digit meta sequence \d
    /// Matches any digit character (0-9)
    /// </summary>
    public static readonly string Digit = "\\d";

    /// <summary>
    /// Represents the non-digit meta sequence \D
    /// Matches any non-digit character
    /// </summary>
    public static readonly string NonDigit = "\\D";

    /// <summary>
    /// Represents the word meta sequence \w
    /// Matches any word character (alphanumeric and underscore)
    /// </summary>
    public static readonly string Word = "\\w";

    /// <summary>
    /// Represents the non-word meta sequence \W
    /// Matches any non-word character
    /// </summary>
    public static readonly string NonWord = "\\W";

    /// <summary>
    /// Represents the whitespace meta sequence \s.
    /// Matches any whitespace character
    /// </summary>
    public static readonly string Whitespace = "\\s";

    /// <summary>
    /// Represents the non-whitespace meta sequence \S.
    /// Matches any non-whitespace character
    /// </summary>
    public static readonly string NonWhitespace = "\\S";

    /// <summary>
    /// Represents the tab meta sequence \t.
    /// Matches the tab character
    /// </summary>
    public static readonly string Tab = "\\t";

    // TODO: Not supported in dotnet, it seems
    //// <summary>
    //// Represents the Any Unicode meta sequences, including line breaks. \X
    //// Matches any Unicode character, including line breaks.
    //// </summary>
    //// public static readonly string AnyUnicode = "\\X";

    /// <summary>
    /// Represents the or meta sequence |
    /// Matches the expression to the left OR the expression to the right of the operator | (pipe).
    /// </summary>
    public static readonly string Or = "|";

}