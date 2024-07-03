using Xunit;
using FluentRegex;
using FluentAssertions;
namespace FluentRegexTests;

public class CharacterClassesTests
{

  [Fact(DisplayName = "Ensure Character Classes are Correct")]
  public void TestCharacterClasses()
  {
    CharacterClasses.LowercaseLetter.Should().Be("[a-z]");
    CharacterClasses.UppercaseLetter.Should().Be("[A-Z]");
    CharacterClasses.AnyCharacter.Should().Be(".");
    CharacterClasses.StartOfLine.Should().Be("^");
    CharacterClasses.EndOfLine.Should().Be("$");
    CharacterClasses.WordBoundary.Should().Be("\\b");
    CharacterClasses.NonWordBoundary.Should().Be("\\B");
    CharacterClasses.EndOfString.Should().Be("\\z");
    CharacterClasses.EndOfStringNoLineBreak.Should().Be("\\Z");
    CharacterClasses.Digit.Should().Be("\\d");
    CharacterClasses.NonDigit.Should().Be("\\D");
    CharacterClasses.Word.Should().Be("\\w");
    CharacterClasses.NonWord.Should().Be("\\W");
    CharacterClasses.Whitespace.Should().Be("\\s");
    CharacterClasses.NonWhitespace.Should().Be("\\S");
    CharacterClasses.Tab.Should().Be("\\t");
    CharacterClasses.Newline.Should().Be("\\n");
    CharacterClasses.HexDigit.Should().Be("[0-9a-fA-F]");
    CharacterClasses.NonHexDigit.Should().Be("[^0-9a-fA-F]");
    CharacterClasses.AnyCharacter.Should().Be(".");
    CharacterClasses.StartOfLine.Should().Be("^");
    CharacterClasses.EndOfLine.Should().Be("$");
  }
}