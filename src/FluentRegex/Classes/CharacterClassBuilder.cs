using System.Diagnostics;
using System.Text;
namespace FluentRegex;

/// <summary>
/// Builds a character class for a regular expression pattern. Inherits from <see cref="IBuilder"/>.
/// </summary>
public class CharacterClassBuilder
{

  private readonly Builder _patternBuilder;
  private StringBuilder _characterClassPattern = new StringBuilder();

  /// <summary>
  /// Initializes a new instance of the <see cref="CharacterClassBuilder"/> class.
  /// </summary>
  public CharacterClassBuilder(dynamic builder)
  {
    _patternBuilder = builder;
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="CharacterClassBuilder"/> class.
  /// </summary>
  public CharacterClassBuilder(PatternBuilder patternBuilder)
  {
    _patternBuilder = patternBuilder;
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="CharacterClassBuilder"/> class.
  /// </summary>
  public CharacterClassBuilder(GroupBuilder groupBuilder)
  {
    _patternBuilder = groupBuilder;
  }

  /// <summary>
  /// Builds the character class.
  /// </summary>
  public IBuilder Build()
  {
    _ = _patternBuilder.Pattern.Append(_characterClassPattern.ToString()!);
    return _patternBuilder;
  }

  /// <summary>
  /// Creates and returns a new instance of the <see cref="CustomCharacterClassBuilder"/> class.
  /// </summary>
  public CustomCharacterClassBuilder StartCustomPattern()
  {
    return new CustomCharacterClassBuilder(this);
  }

  /// <summary>
  /// Appends a literal string to the character class.
  /// </summary>
  public CharacterClassBuilder AppendLiteral(string literal)
  {
    _ = _characterClassPattern.Append(literal);
    return this;
  }

  /// <summary>
  /// Appends the <see cref="CharacterClasses.WordBoundary"/> ('\b') to the character class.
  /// </summary>
  public CharacterClassBuilder StartOfWord()
  {
    _ = _characterClassPattern.Append(CharacterClasses.WordBoundary);
    return this;
  }

  /// <summary>
  /// Appends the <see cref="CharacterClasses.WordBoundary"/> ('\b') to the character class.
  /// </summary>
  public CharacterClassBuilder EndOfWord()
  {
    return StartOfWord();
  }

  /// <summary>
  /// Appends the <see cref="CharacterClasses.NonWordBoundary"/> ('\B') to the character class.
  /// </summary>
  public CharacterClassBuilder NonWordBoundary()
  {
    _ = _characterClassPattern.Append(CharacterClasses.NonWordBoundary);
    return this;
  }

  /// <summary>
  /// Appends the <see cref="CharacterClasses.NonWordBoundary"/> ('\B') to the character class.
  /// </summary>
  public CharacterClassBuilder EndOfString()
  {
    _ = _characterClassPattern.Append(CharacterClasses.EndOfString);
    return this;
  }
  /// <summary>
  /// Appends the <see cref="CharacterClasses.EndOfStringNoLineBreak"/> ('\z') to the character class.
  /// </summary>
  public CharacterClassBuilder EndOfStringNoLineBreak()
  {
    _ = _characterClassPattern.Append(CharacterClasses.EndOfStringNoLineBreak);
    return this;
  }
  /// <summary>
  /// Appends the <see cref="CharacterClasses.AnyCharacter"/> ('.') to the character class.
  /// </summary>
  public CharacterClassBuilder AnyCharacter()
  {
    _ = _characterClassPattern.Append(CharacterClasses.AnyCharacter);
    return this;
  }
  /// <summary>
  /// Appends the <see cref="CharacterClasses.Digit"/> ('\d') to the character class.
  /// </summary>
  public CharacterClassBuilder Digit()
  {
    _ = _characterClassPattern.Append(CharacterClasses.Digit);
    return this;
  }
  /// <summary>
  /// Appends the <see cref="CharacterClasses.NonDigit"/> ('\D') to the character class.
  /// </summary>
  public CharacterClassBuilder NonDigit()
  {
    _ = _characterClassPattern.Append(CharacterClasses.NonDigit);
    return this;
  }
  /// <summary>
  /// Appends the <see cref="CharacterClasses.Whitespace"/> ('\s') to the character class.
  /// </summary>
  public CharacterClassBuilder Whitespace()
  {
    _ = _characterClassPattern.Append(CharacterClasses.Whitespace);
    return this;
  }
  /// <summary>
  /// Appends the <see cref="CharacterClasses.NonWhitespace"/> ('\S') to the character class.
  /// </summary>
  public CharacterClassBuilder NonWhitespace()
  {
    _ = _characterClassPattern.Append(CharacterClasses.NonWhitespace);
    return this;
  }
  /// <summary>
  /// Appends the <see cref="CharacterClasses.Word"/> ('\w') to the character class.
  /// </summary>
  public CharacterClassBuilder Word()
  {
    _ = _characterClassPattern.Append(CharacterClasses.Word);
    return this;
  }
  /// <summary>
  /// Appends the <see cref="CharacterClasses.NonWord"/> ('\W') to the character class.
  /// </summary>
  public CharacterClassBuilder NonWord()
  {
    _ = _characterClassPattern.Append(CharacterClasses.NonWord);
    return this;
  }
  /// <summary>
  /// Appends the <see cref="CharacterClasses.Tab"/> ('\t') to the character class.
  /// </summary>
  public CharacterClassBuilder Tab()
  {
    _ = _characterClassPattern.Append(CharacterClasses.Tab);
    return this;
  }
  /// <summary>
  /// Appends the <see cref="CharacterClasses.Newline"/> ('\n') to the character class.
  /// </summary>
  public CharacterClassBuilder Newline()
  {
    _ = _characterClassPattern.Append(CharacterClasses.Newline);
    return this;
  }
  /// <summary>
  /// Appends the <see cref="CharacterClasses.LowercaseLetter"/> ('[a-z]') to the character class.
  /// </summary>
  public CharacterClassBuilder LowercaseLetter()
  {
    _ = _characterClassPattern.Append(CharacterClasses.LowercaseLetter);
    return this;
  }
  /// <summary>
  /// Appends the <see cref="CharacterClasses.UppercaseLetter"/> ('[A-Z]') to the character class.
  /// </summary>
  public CharacterClassBuilder UppercaseLetter()
  {
    _ = _characterClassPattern.Append(CharacterClasses.UppercaseLetter);
    return this;
  }
  /// <summary>
  /// Appends the <see cref="CharacterClasses.HexDigit"/> ('[0-9a-fA-F]') to the character class.
  /// </summary>
  public CharacterClassBuilder HexDigit()
  {
    _ = _characterClassPattern.Append(CharacterClasses.HexDigit);
    return this;
  }
  /// <summary>
  /// Appends the <see cref="CharacterClasses.NonHexDigit"/> ('[^0-9a-fA-F]') to the character class.
  /// </summary>
  public CharacterClassBuilder NonHexDigit()
  {
    _ = _characterClassPattern.Append(CharacterClasses.NonHexDigit);
    return this;
  }

}