namespace FluentRegex;

/// <summary>
/// Represents all* known anchors for regex.
/// </summary>
public class Anchors : IToken
{
  /// <summary>
  /// Matches the position at the start of the string. If the Multiline option is enabled, also matches immediately after a line break character.
  /// </summary>
  public const string StartOfLine = "^";

  /// <summary>
  /// Matches the position at the end of the string or before the line break at the end of the string. If the Multiline option is enabled, also matches before a line break character.
  /// </summary>
  public const string EndOfLine = "$";

  /// <summary>
  /// Matches a word boundary position such as whitespace, punctuation, or the start/end of the string.
  /// </summary>
  public const string StartOfWord = WordBoundary;

  /// <summary>
  /// Matches a word boundary position such as whitespace, punctuation, or the start/end of the string.
  /// </summary>
  public const string EndOfWord = WordBoundary;

  /// <summary>
  /// Matches a position that is a word boundary.
  /// </summary>
  public const string WordBoundary = @"\b";

  /// <summary>
  /// Matches a position that is not a word boundary.
  /// </summary>
  public const string NonWordBoundary = @"\B";

  /// <summary>
  /// Matches the position at the end of the string. Not satisfied by a new line character, therefor must be at the very end of the string.
  /// </summary>
  public const string EndOfString = @"\z";

  /// <summary>
  /// Matches the position at the end of the string. Ignores multiline mode. Matches before a new line (\n) character, but not before a new line sequence (\r\n).
  /// </summary>
  public const string EndOfStringNoLineBreak = @"\Z";
}