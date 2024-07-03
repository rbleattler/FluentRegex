using System.Linq;
using System.ComponentModel;

namespace FluentRegex;

/// <summary>
/// Represents all known character classes for regex.
/// </summary>
public class CharacterClasses : IToken
{
  /// <summary>
  /// Represents the digit Meta Character \d.
  /// </summary>
  [Description("Digit is not a character class, but a Meta Character")]
  public static readonly string Digit = "\\d";

  /// <summary>
  /// Represents the non-digit Meta Character \D.
  /// </summary>
  [Description("NonDigit is not a character class, but a Meta Character")]
  public static readonly string NonDigit = "\\D";

  /// <summary>
  /// Represents the word Meta Character \w.
  /// </summary>
  [Description("Word is not a character class, but a Meta Character")]
  public static readonly string Word = "\\w";

  /// <summary>
  /// Represents the non-word Meta Character \W.
  /// </summary>
  [Description("NonWord is not a character class, but a Meta Character")]
  public static readonly string NonWord = "\\W";

  /// <summary>
  /// Represents the whitespace Meta Character \s.
  /// </summary>
  [Description("Whitespace is not a character class, but a Meta Character")]
  public static readonly string Whitespace = "\\s";

  /// <summary>
  /// Represents the non-whitespace Meta Character \S.
  /// </summary>
  [Description("NonWhitespace is not a character class, but a Meta Character")]
  public static readonly string NonWhitespace = "\\S";

  /// <summary>
  /// Represents the tab Meta Character \t.
  /// </summary>
  [Description("Tab is not a character class, but a Meta Character")]
  public static readonly string Tab = "\\t";

  /// <summary>
  /// Represents the newline Meta Character \n.
  /// </summary>
  [Description("Newline is not a character class, but a General Token")]
  public static readonly string Newline = "\\n";

  /// <summary>
  /// Represents the lowercase letter character class [a-z].
  /// </summary>
  public static readonly string LowercaseLetter = "[a-z]";

  /// <summary>
  /// Represents the uppercase letter character class [A-Z].
  /// </summary>
  public static readonly string UppercaseLetter = "[A-Z]";

  /// <summary>
  /// Represents the hexadecimal digit character class [0-9a-fA-F].
  /// </summary>
  public static readonly string HexDigit = "[0-9a-fA-F]";

  /// <summary>
  /// Represents the non-hexadecimal digit character class [^0-9a-fA-F].
  /// </summary>
  public static readonly string NonHexDigit = "[^0-9a-fA-F]";

  /// <summary>
  /// Represents the any character class [\s\S].
  /// </summary>
  [Description("AnyCharacter is not a character class, but a Meta Character")]
  public static readonly string AnyCharacter = ".";

  /// <summary>
  /// Represents the start of line character class ^.
  /// </summary>
  /// <summary>
  /// Represents the start of line character class ^.
  /// </summary>
  [Description("StartOfLine is not a character class, but an anchor")]
  public static readonly string StartOfLine = Anchors.StartOfLine;

  /// <summary>
  /// Represents the end of line character class $.
  /// </summary>
  [Description("EndOfLine is not a character class, but an anchor")]
  public static readonly string EndOfLine = Anchors.EndOfLine;

  /// <summary>
  /// Represents the start or end of word character class \b.
  /// </summary>
  [Description("WordBoundary is not a character class, but an anchor")]
  public static readonly string WordBoundary = Anchors.StartOfWord;

  /// <summary>
  /// Represents a boundary that is not a word boundary \B.
  /// </summary>
  [Description("NonWordBoundary is not a character class, but an anchor")]
  public static readonly string NonWordBoundary = Anchors.NonWordBoundary;

  /// <summary>
  /// Represents the end of string character class \z.
  /// </summary>
  [Description("EndOfString is not a character class, but an anchor")]
  public static readonly string EndOfString = Anchors.EndOfString;

  /// <summary>
  /// Represents the end of string character class \Z.
  /// </summary>
  ///   [Description("EndOfString is not a character class, but an anchor")]
  public static readonly string EndOfStringNoLineBreak = Anchors.EndOfStringNoLineBreak;

}