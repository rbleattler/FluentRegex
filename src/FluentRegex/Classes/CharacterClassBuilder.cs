using System.Diagnostics;
using System.Text;
namespace FluentRegex;

public class CharacterClassBuilder
{

  private readonly Builder _patternBuilder;
  private StringBuilder _characterClassPattern = new StringBuilder();

  public CharacterClassBuilder(PatternBuilder patternBuilder)
  {
    _patternBuilder = patternBuilder;
  }

  public CharacterClassBuilder(GroupBuilder groupBuilder)
  {
    _patternBuilder = groupBuilder;
  }

  public dynamic Build()
  {
    _ = _patternBuilder.Pattern.Append(_characterClassPattern.ToString()!);
    return _patternBuilder;
  }

  public CustomCharacterClassBuilder StartCustomPattern()
  {
    return new CustomCharacterClassBuilder(this);
  }

  // public CharacterClassBuilder CharacterInRange(char start, char end)
  // {
  //   _charClassPattern.Append(start);
  //   _charClassPattern.Append('-');
  //   _charClassPattern.Append(end);
  //   return this;
  // }

  // public CharacterClassBuilder CharacterNotInRange(char start, char end)
  // {
  //   _charClassPattern.Append('[');
  //   _charClassPattern.Append('^');
  //   _charClassPattern.Append(start);
  //   _charClassPattern.Append('-');
  //   _charClassPattern.Append(end);
  //   return this;
  // }

  public CharacterClassBuilder AppendLiteral(string literal)
  {
    _characterClassPattern.Append(literal);
    return this;
  }


  public CharacterClassBuilder StartOfWord()
  {
    _characterClassPattern.Append(CharacterClasses.WordBoundary);
    return this;
  }

  public CharacterClassBuilder EndOfWord()
  {
    return StartOfWord();
  }

  public CharacterClassBuilder NonWordBoundary()
  {
    _characterClassPattern.Append(CharacterClasses.NonWordBoundary);
    return this;
  }

  public CharacterClassBuilder EndOfString()
  {
    _characterClassPattern.Append(CharacterClasses.EndOfString);
    return this;
  }

  public CharacterClassBuilder EndOfStringNoLineBreak()
  {
    _characterClassPattern.Append(CharacterClasses.EndOfStringNoLineBreak);
    return this;
  }

  public CharacterClassBuilder AnyCharacter()
  {
    _characterClassPattern.Append(CharacterClasses.AnyCharacter);
    return this;
  }

  public CharacterClassBuilder Digit()
  {
    _characterClassPattern.Append(CharacterClasses.Digit);
    return this;
  }

  public CharacterClassBuilder NonDigit()
  {
    _characterClassPattern.Append(CharacterClasses.NonDigit);
    return this;
  }

  public CharacterClassBuilder Whitespace()
  {
    _characterClassPattern.Append(CharacterClasses.Whitespace);
    return this;
  }

  public CharacterClassBuilder NonWhitespace()
  {
    _characterClassPattern.Append(CharacterClasses.NonWhitespace);
    return this;
  }

  public CharacterClassBuilder Word()
  {
    _characterClassPattern.Append(CharacterClasses.Word);
    return this;
  }

  public CharacterClassBuilder NonWord()
  {
    _characterClassPattern.Append(CharacterClasses.NonWord);
    return this;
  }

  public CharacterClassBuilder Tab()
  {
    _characterClassPattern.Append(CharacterClasses.Tab);
    return this;
  }

  public CharacterClassBuilder Newline()
  {
    _characterClassPattern.Append(CharacterClasses.Newline);
    return this;
  }

  public CharacterClassBuilder LowercaseLetter()
  {
    _characterClassPattern.Append(CharacterClasses.LowercaseLetter);
    return this;
  }

  public CharacterClassBuilder UppercaseLetter()
  {
    _characterClassPattern.Append(CharacterClasses.UppercaseLetter);
    return this;
  }

  public CharacterClassBuilder HexDigit()
  {
    _characterClassPattern.Append(CharacterClasses.HexDigit);
    return this;
  }

  public CharacterClassBuilder NonHexDigit()
  {
    _characterClassPattern.Append(CharacterClasses.NonHexDigit);
    return this;
  }

}