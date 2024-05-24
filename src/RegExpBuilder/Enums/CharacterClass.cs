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
  AnyCharacter,
  Digit,
  EndOfLine,
  EndOfString,
  EndOfStringNoLineBreak,
  HexDigit,
  LowercaseLetter,
  Newline,
  NonDigit,
  NonHexDigit,
  NonWhitespace,
  NonWord,
  NonWordBoundary,
  StartOfLine,
  Tab,
  UppercaseLetter,
  Whitespace,
  Word,
  WordBoundary,
}