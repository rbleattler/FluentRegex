using System.ComponentModel;

namespace FluentRegex;

/// <summary>
/// Represents all known character classes for regex.
/// </summary>
public static class CharacterClasses
{
  /// <summary>
  /// Represents the digit character class [0-9].
  /// </summary>
  public static readonly string Digit = "\\d";

  /// <summary>
  /// Represents the non-digit character class [^0-9].
  /// </summary>
  public static readonly string NonDigit = "\\D";

  /// <summary>
  /// Represents the word character class [a-zA-Z0-9_].
  /// </summary>
  public static readonly string Word = "\\w";

  /// <summary>
  /// Represents the non-word character class [^a-zA-Z0-9_].
  /// </summary>
  public static readonly string NonWord = "\\W";

  /// <summary>
  /// Represents the whitespace character class \s.
  /// </summary>
  public static readonly string Whitespace = "\\s";

  /// <summary>
  /// Represents the non-whitespace character class \S.
  /// </summary>
  public static readonly string NonWhitespace = "\\S";

  /// <summary>
  /// Represents the tab character class \t.
  /// </summary>
  public static readonly string Tab = "\\t";

  /// <summary>
  /// Represents the newline character class \n.
  /// </summary>
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
  /// Represents the end of string character class \Z.
  /// </summary>
  [Description("EndOfString is not a character class, but an anchor")]
  public static readonly string EndOfString = Anchors.EndOfString;

  /// <summary>
  /// Represents the end of string character class \z.
  /// </summary>
  [Description("EndOfStringNoLineBreak is not a character class, but an anchor")]
  public static readonly string EndOfStringNoLineBreak = Anchors.EndOfStringNoLineBreak;
}