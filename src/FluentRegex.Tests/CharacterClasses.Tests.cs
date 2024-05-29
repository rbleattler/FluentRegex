using Xunit;
using FluentRegex;
namespace FluentRegexTests;

public class CharacterClassesTests
{

  [Fact]
  public void TestCharacterClasses()
  {
    Assert.Equal("[a-z]", CharacterClasses.LowercaseLetter);
    Assert.Equal("[A-Z]", CharacterClasses.UppercaseLetter);
    Assert.Equal(".", CharacterClasses.AnyCharacter);
    Assert.Equal("^", CharacterClasses.StartOfLine);
    Assert.Equal("$", CharacterClasses.EndOfLine);
    Assert.Equal("\\b", CharacterClasses.WordBoundary);
    Assert.Equal("\\B", CharacterClasses.NonWordBoundary);
    Assert.Equal("\\z", CharacterClasses.EndOfString);
    Assert.Equal("\\Z", CharacterClasses.EndOfStringNoLineBreak);
    Assert.Equal("\\d", CharacterClasses.Digit);
    Assert.Equal("\\D", CharacterClasses.NonDigit);
    Assert.Equal("\\w", CharacterClasses.Word);
    Assert.Equal("\\W", CharacterClasses.NonWord);
    Assert.Equal("\\s", CharacterClasses.Whitespace);
    Assert.Equal("\\S", CharacterClasses.NonWhitespace);
    Assert.Equal("\\t", CharacterClasses.Tab);
    Assert.Equal("\\n", CharacterClasses.Newline);
    Assert.Equal("[0-9a-fA-F]", CharacterClasses.HexDigit);
    Assert.Equal("[^0-9a-fA-F]", CharacterClasses.NonHexDigit);
    Assert.Equal(".", CharacterClasses.AnyCharacter);
    Assert.Equal("^", CharacterClasses.StartOfLine);
    Assert.Equal("$", CharacterClasses.EndOfLine);
  }
}