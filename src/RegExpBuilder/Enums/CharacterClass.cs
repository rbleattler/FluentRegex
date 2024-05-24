namespace Builder;
/// <summary>
/// Represents a character class in a regular expression pattern.
/// </summary>
/// <remarks>
/// A character class is a set of characters that can be used to match a single character.
/// </remarks>
/// <example>
/// <code>
/// var classes = new CharacterClasses();
/// var characterClass = classes.Digit;
/// var builder = new RegExpBuilder().Add(characterClass);
/// var pattern = builder.Build();
/// Console.WriteLine(pattern);
/// // Output:
/// // \d
/// </code>
/// </example>
public enum CharacterClass
{
  /// <summary>
  /// Represents the any character class in a regular expression pattern.
  /// </summary>
  AnyCharacter,

  /// <summary>
  /// Represents a digit character class in a regular expression pattern.
  /// </summary>
  Digit,

  /// <summary>
  /// Represents the end of a line character class in a regular expression pattern.
  /// </summary>
  EndOfLine,

  /// <summary>
  /// Represents the end of a string character class in a regular expression pattern.
  /// </summary>
  EndOfString,

  /// <summary>
  /// Represents the end of a string without a line break character class in a regular expression pattern.
  /// </summary>
  EndOfStringNoLineBreak,

  /// <summary>
  /// Represents a hexadecimal digit character class in a regular expression pattern.
  /// </summary>
  HexDigit,

  /// <summary>
  /// Represents a lowercase letter character class in a regular expression pattern.
  /// </summary>
  LowercaseLetter,

  /// <summary>
  /// Represents a newline character class in a regular expression pattern.
  /// </summary>
  Newline,

  /// <summary>
  /// Represents a non-digit character class in a regular expression pattern.
  /// </summary>
  NonDigit,

  /// <summary>
  /// Represents a non-hexadecimal digit character class in a regular expression pattern.
  /// </summary>
  NonHexDigit,

  /// <summary>
  /// Represents a non-whitespace character class in a regular expression pattern.
  /// </summary>
  NonWhitespace,

  /// <summary>
  /// Represents a non-word character class in a regular expression pattern.
  /// </summary>
  NonWord,

  /// <summary>
  /// Represents a non-word boundary character class in a regular expression pattern.
  /// </summary>
  NonWordBoundary,

  /// <summary>
  /// Represents the start of a line character class in a regular expression pattern.
  /// </summary>
  StartOfLine,

  /// <summary>
  /// Represents a tab character class in a regular expression pattern.
  /// </summary>
  Tab,

  /// <summary>
  /// Represents an uppercase letter character class in a regular expression pattern.
  /// </summary>
  UppercaseLetter,

  /// <summary>
  /// Represents a whitespace character class in a regular expression pattern.
  /// </summary>
  Whitespace,

  /// <summary>
  /// Represents a word character class in a regular expression pattern.
  /// </summary>
  Word,

  /// <summary>
  /// Represents a word boundary character class in a regular expression pattern.
  /// </summary>
  WordBoundary,
}