namespace Builder;

/// <summary>
/// Represents all known character classes for regex.
/// </summary>
public static class CharacterClasses
{
  /// <summary>
  /// Represents the digit character class [0-9].
  /// </summary>
  public static readonly string Digit = "d";

  /// <summary>
  /// Represents the non-digit character class [^0-9].
  /// </summary>
  public static readonly string NonDigit = "D";

  /// <summary>
  /// Represents the word character class [a-zA-Z0-9_].
  /// </summary>
  public static readonly string Word = "w";

  /// <summary>
  /// Represents the non-word character class [^a-zA-Z0-9_].
  /// </summary>
  public static readonly string NonWord = "W";

  /// <summary>
  /// Represents the whitespace character class \s.
  /// </summary>
  public static readonly string Whitespace = @"s";

  /// <summary>
  /// Represents the non-whitespace character class \S.
  /// </summary>
  public static readonly string NonWhitespace = @"S";

  /// <summary>
  /// Represents the tab character class \t.
  /// </summary>
  public static readonly string Tab = @"t";

  /// <summary>
  /// Represents the newline character class \n.
  /// </summary>
  public static readonly string Newline = @"n";

  /// <summary>
  /// Represents the lowercase letter character class [a-z].
  /// </summary>
  public static readonly string LowercaseLetter = "a-z";

  /// <summary>
  /// Represents the uppercase letter character class [A-Z].
  /// </summary>
  public static readonly string UppercaseLetter = "A-Z";

  /// <summary>
  /// Represents the hexadecimal digit character class [0-9a-fA-F].
  /// </summary>
  public static readonly string HexDigit = "0-9a-fA-F";

  /// <summary>
  /// Represents the non-hexadecimal digit character class [^0-9a-fA-F].
  /// </summary>
  public static readonly string NonHexDigit = "^0-9a-fA-F";

  /// <summary>
  /// Represents the any character class [\s\S].
  /// </summary>
  public static readonly string AnyCharacter = @".";

  /// <summary>
  /// Represents the start of line character class ^.
  /// </summary>
  public static readonly string StartOfLine = "^";

  /// <summary>
  /// Represents the end of line character class $.
  /// </summary>
  public static readonly string EndOfLine = "$";

  /// <summary>
  /// Represents the start or end of word character class \b.
  /// </summary>
  public static readonly string WordBoundary = @"b";

  /// <summary>
  /// Represents a boundary that is not a word boundary \B.
  /// </summary>
  public static readonly string NonWordBoundary = @"B";

  /// <summary>
  /// Represents the end of string character class \Z.
  /// </summary>
  public static readonly string EndOfString = @"Z";

  /// <summary>
  /// Represents the end of string character class \z.
  /// </summary>
  public static readonly string EndOfStringNoLineBreak = @"z";

  /// <summary>
  /// Gets all character classes.
  /// </summary>
  /// <returns>An array of all character classes.</returns>
  /// <remarks>
  /// This method is useful for iterating over all character classes.
  /// </remarks>
  public static string[] GetCharacterClasses() =>
  [
    Digit,
    NonDigit,
    Word,
    NonWord,
    Whitespace,
    NonWhitespace,
    Tab,
    Newline,
    LowercaseLetter,
    UppercaseLetter,
    HexDigit,
    NonHexDigit,
    AnyCharacter,
    StartOfLine,
    EndOfLine,
    WordBoundary,
    NonWordBoundary,
    EndOfString,
    EndOfStringNoLineBreak
  ];

  /// <summary>
  /// Gets the literal representation of a character class.
  /// </summary>
  /// <param name="characterClass">The character class to get the literal representation of.</param>
  /// <returns>The literal representation of the character class.</returns>
  /// <exception cref="ArgumentException">Thrown when the character class is not recognized.</exception>
  public static string GetLiteral(CharacterClass characterClass) =>

    characterClass switch
    {
      CharacterClass.AnyCharacter => AnyCharacter,
      CharacterClass.Digit => $"\\{Digit}",
      CharacterClass.EndOfLine => EndOfLine,
      CharacterClass.EndOfString => $"\\{EndOfString}",
      CharacterClass.EndOfStringNoLineBreak => $"\\{EndOfStringNoLineBreak}",
      CharacterClass.HexDigit => $"[{HexDigit}]",
      CharacterClass.LowercaseLetter => $"[{LowercaseLetter}]",
      CharacterClass.Newline => $"\\{Newline}",
      CharacterClass.NonDigit => $"\\{NonDigit}",
      CharacterClass.NonHexDigit => $"[{NonHexDigit}]",
      CharacterClass.NonWhitespace => $"\\{NonWhitespace}",
      CharacterClass.NonWord => $"\\{NonWord}",
      CharacterClass.NonWordBoundary => $"\\{NonWordBoundary}",
      CharacterClass.StartOfLine => StartOfLine,
      CharacterClass.Tab => $"\\{Tab}",
      CharacterClass.UppercaseLetter => $"[{UppercaseLetter}]",
      CharacterClass.Whitespace => $"\\{Whitespace}",
      CharacterClass.Word => $"\\{Word}",
      CharacterClass.WordBoundary => $"\\{WordBoundary}",

      _ => throw new ArgumentException("The character class is not recognized.", nameof(characterClass))
    };

  /// <summary>
  /// Get a character class from a literal representation.
  /// </summary>
  /// <param name="literal">The literal representation of the character class.</param>
  /// <returns>The character class.</returns>

  public static CharacterClass GetCharacterClass(string literal)
  {
    return literal switch
    {
      var x when x == $"[{LowercaseLetter}]" => CharacterClass.LowercaseLetter,
      var x when x == $"[{UppercaseLetter}]" => CharacterClass.UppercaseLetter,
      var x when x == AnyCharacter => CharacterClass.AnyCharacter,
      var x when x == Digit => CharacterClass.Digit,
      var x when x == EndOfLine => CharacterClass.EndOfLine,
      var x when x == EndOfString => CharacterClass.EndOfString,
      var x when x == EndOfStringNoLineBreak => CharacterClass.EndOfStringNoLineBreak,
      var x when x == HexDigit => CharacterClass.HexDigit,
      var x when x == Newline => CharacterClass.Newline,
      var x when x == NonDigit => CharacterClass.NonDigit,
      var x when x == NonWhitespace => CharacterClass.NonWhitespace,
      var x when x == NonWord => CharacterClass.NonWord,
      var x when x == NonWordBoundary => CharacterClass.NonWordBoundary,
      var x when x == StartOfLine => CharacterClass.StartOfLine,
      var x when x == Tab => CharacterClass.Tab,
      var x when x == UppercaseLetter => CharacterClass.UppercaseLetter,
      var x when x == Whitespace => CharacterClass.Whitespace,
      var x when x == Word => CharacterClass.Word,
      var x when x == WordBoundary => CharacterClass.WordBoundary,
      _ => throw new ArgumentException("The character class is not recognized.", nameof(literal))
    };
  }
}