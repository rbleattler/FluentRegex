using Xunit;
using FluentRegex;
using System.Text.RegularExpressions;

namespace FluentRegexTests;

public class CustomCharacterClassBuilderTests
{
  private CharacterClassBuilder _characterClassBuilder;
  private CustomCharacterClassBuilder _customCharacterClassBuilder;
  private string? result;

  public CustomCharacterClassBuilderTests()
  {
    result = "";
    _characterClassBuilder = new CharacterClassBuilder(new PatternBuilder());
    _customCharacterClassBuilder = new CustomCharacterClassBuilder(_characterClassBuilder);
  }

  [Fact]
  public void TestAppendLiteral()
  {
    result = _customCharacterClassBuilder.AppendLiteral("test")
                                         .Build() // Build the CustomCharacterClassBuilder
                                         .Build() // Build the CharacterClassBuilder
                                         .ToString();
    Assert.Equal("[test]", result);
  }

  [Fact]
  public void TestInRange()
  {
    result = _customCharacterClassBuilder.InRange('a', 'z')
                                         .Build() // Build the CustomCharacterClassBuilder
                                         .Build() // Build the CharacterClassBuilder
                                         .ToString();
    Assert.Equal("[a-z]", result);
  }

  [Fact]
  public void TestNegate()
  {
    result = _customCharacterClassBuilder.AppendLiteral("test")
                                         .Negate()
                                         .Build() // Build the CustomCharacterClassBuilder
                                         .Build() // Build the CharacterClassBuilder
                                         .ToString();
    Assert.Equal("[^test]", result);
  }

  [Fact]
  public void TestBuild()
  {
    result = _customCharacterClassBuilder.AppendLiteral("test")
                                         .InRange('a', 'z')
                                         .Negate()
                                         .Build() // Build the CustomCharacterClassBuilder
                                         .Build() // Build the CharacterClassBuilder
                                         .ToString();
    Assert.Equal("[^testa-z]", result);
  }
}