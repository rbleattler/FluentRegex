using FluentRegex;
using System;
using System.Text;
using Xunit;
namespace FluentRegexTests.BuilderTests;

public class MockBuilder : Builder
{
  // internal StringBuilder _pattern { get; set; }
  public override StringBuilder Pattern { get => _pattern; set => _pattern = value; }
  public override AnchorBuilder StartAnchor() => throw new NotImplementedException();
  // public override GroupBuilder StartGroup() => throw new NotImplementedException();
  public override CharacterClassBuilder StartCharacterClass() => throw new NotImplementedException();

  public override PatternBuilder Build() => throw new NotImplementedException();

  public MockBuilder()
  {
    Pattern = new StringBuilder();
  }

}

public abstract class BuilderTestGroup
{
  protected MockBuilder _builder;
  protected PatternBuilder _patternBuilder;
  protected string result;
  protected char lastCharacter { get => _builder.Pattern.Length >= 1 ? _builder.Pattern[_builder.Pattern.Length - 1] : new char(); }

  public BuilderTestGroup()
  {
    result = "";
    _patternBuilder = new PatternBuilder();
    _builder = new MockBuilder();
  }
}

public class BuilderTests : BuilderTestGroup
{

  [Theory]
  [InlineData(-1, -1, "")]
  [InlineData(0, -1, "*")]
  [InlineData(1, -1, "+")]
  [InlineData(0, 1, "?")]
  [InlineData(2, 2, "{2}")]
  [InlineData(-1, 3, "{0,3}")]
  [InlineData(4, -1, "{4,}")]
  [InlineData(5, 6, "{5,6}")]
  public void Times_AppendsCorrectQuantifier(int minimum, int maximum, string expected)
  {
    _builder.Times(minimum, maximum);
    Assert.Equal(expected, _builder.Pattern.ToString());
  }

  [Fact]
  public void Lazy_AppendsQuestionMark()
  {
    _builder.Lazy();
    Assert.Equal('?', lastCharacter);
  }

  [Fact]
  public void OneOrMore_AppendsPlus()
  {
    _builder.OneOrMore();
    Assert.Equal('+', lastCharacter);
  }

  [Fact]
  public void ZeroOrMore_AppendsAsterisk()
  {
    _builder.ZeroOrMore();
    // Assert.EndsWith(_builder.Pattern.ToString(), "*");
    Assert.Equal('*', lastCharacter);
  }

  [Fact]
  public void ZeroOrOne_AppendsQuestionMark()
  {
    _builder.ZeroOrOne();
    Assert.Equal('?', lastCharacter);
  }

  [Fact]
  public void Or_AppendsPipe()
  {
    _builder.Or();
    Assert.Equal('|', lastCharacter);
  }

  [Fact]
  public void Validate_ThrowsNoExceptionOnValidPattern()
  {
        _ = _builder.Pattern.Append("abc");
    _builder.Validate();
  }
}

class Main
{

  public PatternBuilder builder = new PatternBuilder();
  public string output = "";
  Main()
  {
    output = builder.StartAnchor()
    .StartOfLine()
        .Build()
        .StartGroup()
    .StartGroup()
      .StartCharacterClass()
        .Word()
            .Build()
            .Or()
        .StartCharacterClass()
        .StartCustomPattern()
          .AppendLiteral("_")
            .AppendLiteral("-")
            .AppendLiteral(".")
            .AppendLiteral("+")
            .Build()
            .Build()
          .Build()
        .Times(1, -1)
      .AppendLiteral("@")
      .Times(1, 1)
      .StartGroup()
      .StartCharacterClass()
        .Word()
            .Build()
            .Or()
        .StartCharacterClass()
        .StartCustomPattern()
          .AppendLiteral("_")
            .AppendLiteral("-")
            .AppendLiteral(".")
            .Build()
            .Build()
          .Build()
        .Times(1, -1)
      .StartAnchor()
        .EndOfLine()
        .Build()
    .Build()
      .ToString();
    Console.WriteLine(output);
  }

}