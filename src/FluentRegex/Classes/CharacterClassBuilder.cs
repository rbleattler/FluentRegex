using System.Text;
namespace FluentRegex;

public class CharacterClassBuilder
{
  private readonly PatternBuilder _regexBuilder;
  private StringBuilder _charClassPattern = new StringBuilder();

  public CharacterClassBuilder(PatternBuilder regexBuilder)
  {
    _regexBuilder = regexBuilder;
  }

  public CharacterClassBuilder AppendLiteral(string literal)
  {
    _charClassPattern.Append(literal);
    return this;
  }


  public CharacterClassBuilder StartofWord()
  {
    _charClassPattern.Append(CharacterClasses.WordBoundary);
    return this;
  }

  public CharacterClassBuilder EndofWord()
  {
    return StartofWord();
  }

  public CharacterClassBuilder NonWordBoundary()
  {
    _charClassPattern.Append(CharacterClasses.NonWordBoundary);
    return this;
  }

  public CharacterClassBuilder EndOfString()
  {
    _charClassPattern.Append(CharacterClasses.EndOfString);
    return this;
  }

  public CharacterClassBuilder EndOfStringNoLineBreak()
  {
    _charClassPattern.Append(CharacterClasses.EndOfStringNoLineBreak);
    return this;
  }

  public CharacterClassBuilder AnyCharacter()
  {
    _charClassPattern.Append(CharacterClasses.AnyCharacter);
    return this;
  }

  public CharacterClassBuilder Digit()
  {
    _charClassPattern.Append(CharacterClasses.Digit);
    return this;
  }

  public CharacterClassBuilder NonDigit()
  {
    _charClassPattern.Append(CharacterClasses.NonDigit);
    return this;
  }

  public CharacterClassBuilder Whitespace()
  {
    _charClassPattern.Append(CharacterClasses.Whitespace);
    return this;
  }

  public CharacterClassBuilder NonWhitespace()
  {
    _charClassPattern.Append(CharacterClasses.NonWhitespace);
    return this;
  }

  public CharacterClassBuilder Word()
  {
    _charClassPattern.Append(CharacterClasses.Word);
    return this;
  }

  public CharacterClassBuilder NonWord()
  {
    _charClassPattern.Append(CharacterClasses.NonWord);
    return this;
  }

  public CharacterClassBuilder Tab()
  {
    _charClassPattern.Append(CharacterClasses.Tab);
    return this;
  }

  public CharacterClassBuilder Newline()
  {
    _charClassPattern.Append(CharacterClasses.Newline);
    return this;
  }

  public CharacterClassBuilder LowercaseLetter()
  {
    _charClassPattern.Append(CharacterClasses.LowercaseLetter);
    return this;
  }

  public CharacterClassBuilder UppercaseLetter()
  {
    _charClassPattern.Append(CharacterClasses.UppercaseLetter);
    return this;
  }

  public CharacterClassBuilder HexDigit()
  {
    _charClassPattern.Append(CharacterClasses.HexDigit);
    return this;
  }

  public CharacterClassBuilder NonHexDigit()
  {
    _charClassPattern.Append(CharacterClasses.NonHexDigit);
    return this;
  }

  public PatternBuilder Build()
  {
    _regexBuilder._pattern.Append(_charClassPattern.ToString());
    return _regexBuilder;
  }
}