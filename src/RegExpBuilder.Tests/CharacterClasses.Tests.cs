using Xunit;
using Builder;
namespace RegExpBuilderTests;

public class CharacterClassesTests
{
  [Fact]
  public void TestCharacterClassesProperties()
  {
    Assert.Equal("d", CharacterClasses.Digit);
    Assert.Equal("D", CharacterClasses.NonDigit);
    // Continue for all properties...
  }

  [Fact]
  public void TestGetCharacterClasses()
  {
    var classes = CharacterClasses.GetCharacterClasses();
    Assert.Contains("d", classes);
    Assert.Contains("D", classes);
    // Continue for all expected classes...
  }

  [Fact]
  public void TestGetLiteral()
  {
    Assert.Equal("[a-z]", CharacterClasses.GetLiteral(CharacterClass.LowercaseLetter));
    Assert.Equal("[A-Z]", CharacterClasses.GetLiteral(CharacterClass.UppercaseLetter));
    Assert.Equal(".", CharacterClasses.GetLiteral(CharacterClass.AnyCharacter));
    Assert.Equal("^", CharacterClasses.GetLiteral(CharacterClass.StartOfLine));
    Assert.Equal("$", CharacterClasses.GetLiteral(CharacterClass.EndOfLine));
    Assert.Equal("\\b", CharacterClasses.GetLiteral(CharacterClass.WordBoundary));
    Assert.Equal("\\B", CharacterClasses.GetLiteral(CharacterClass.NonWordBoundary));
    Assert.Equal("\\Z", CharacterClasses.GetLiteral(CharacterClass.EndOfString));
    Assert.Equal("\\z", CharacterClasses.GetLiteral(CharacterClass.EndOfStringNoLineBreak));
    Assert.Equal("\\d", CharacterClasses.GetLiteral(CharacterClass.Digit));
    Assert.Equal("\\D", CharacterClasses.GetLiteral(CharacterClass.NonDigit));
    Assert.Equal("\\w", CharacterClasses.GetLiteral(CharacterClass.Word));
    Assert.Equal("\\W", CharacterClasses.GetLiteral(CharacterClass.NonWord));
    Assert.Equal("\\s", CharacterClasses.GetLiteral(CharacterClass.Whitespace));
    Assert.Equal("\\S", CharacterClasses.GetLiteral(CharacterClass.NonWhitespace));
    Assert.Equal("\\t", CharacterClasses.GetLiteral(CharacterClass.Tab));
    Assert.Equal("\\n", CharacterClasses.GetLiteral(CharacterClass.Newline));
    Assert.Equal("[0-9a-fA-F]", CharacterClasses.GetLiteral(CharacterClass.HexDigit));
    Assert.Equal("[^0-9a-fA-F]", CharacterClasses.GetLiteral(CharacterClass.NonHexDigit));
    Assert.Equal(".", CharacterClasses.GetLiteral(CharacterClass.AnyCharacter));
    Assert.Equal("^", CharacterClasses.GetLiteral(CharacterClass.StartOfLine));
    Assert.Equal("$", CharacterClasses.GetLiteral(CharacterClass.EndOfLine));
  }
}