using FluentRegex;

namespace FluentRegexTests;
public class AnchorBuilderTests
{

  private AnchorBuilder _anchorBuilder;
  private PatternBuilder _patternBuilder;
  private string result;

  public AnchorBuilderTests()
  {
    result = "";
    _patternBuilder = new PatternBuilder();
    _anchorBuilder = new AnchorBuilder(_patternBuilder);
  }

  [Fact]
  public void StartOfLine()
  {
    result = _anchorBuilder.StartOfLine()
                              .Build()
                           .AppendLiteral("test")
                           .Build()
                           .ToString();
    Assert.Equal("^test", result);
  }

  [Fact]
  public void EndOfString_NoLineBreak()
  {
    _patternBuilder.AppendLiteral("test");
    result = _anchorBuilder.EndOfStringNoLineBreak()
                           .Build()
                           .ToString();

    Assert.Equal("test\\Z", result);
  }

  [Fact]
  public void EndOfLine()
  {
    result = _anchorBuilder.AppendLiteral("test")
                           .EndOfLine()
                           .Build()
                           .ToString();

    Assert.Equal("test$", result);
  }

  [Fact]
  public void EndOfString()
  {
    result = _anchorBuilder.AppendLiteral("test")
                           .EndOfString()
                           .Build()
                           .ToString();

    Assert.Equal("test\\z", result);
  }

  [Fact]
  public void NonWordBoundary()
  {
    result = _anchorBuilder.AppendLiteral("test")
                           .NonWordBoundary()
                           .Build()
                           .ToString();

    Assert.Equal("test\\B", result);
  }

  [Fact]
  public void WordBoundary()
  {
    result = _anchorBuilder.AppendLiteral("test")
                           .WordBoundary()
                           .Build()
                           .ToString();

    Assert.Equal("test\\b", result);
  }

  [Fact]
  public void StartOfWord()
  {

    result = _anchorBuilder.StartOfWord()
                            .Build()
                           .AppendLiteral("test")
                          //  .Build()
                           .ToString();

    Assert.Equal("\\btest", result);
  }

  [Fact]
  public void EndOfWord()
  {
    result = _anchorBuilder.AppendLiteral("test")
                           .EndOfWord()
                           .Build()
                           .ToString();

    Assert.Equal("test\\b", result);
  }

  [Fact]
  public void AppendLiteral()
  {
    result = _anchorBuilder.AppendLiteral("test")
                           .Build()
                           .ToString();

    Assert.Equal("test", result);
  }



}