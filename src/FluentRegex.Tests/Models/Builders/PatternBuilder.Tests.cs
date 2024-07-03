using Xunit;
using FluentRegex;
using System.Text.RegularExpressions;

namespace FluentRegexTests;

public class PatternBuilderTests
{

  private PatternBuilder _patternBuilder;
  private string result;

  public PatternBuilderTests()
  {
    result = "";
    _patternBuilder = new PatternBuilder();
  }

  [Fact]
  public void TestStartGroup()
  {
    result = _patternBuilder.StartGroup()
                            .AppendLiteral("test")
                            .Build()
                            .ToString();
    Assert.Equal("(test)", result);
  }

  // [Fact(DisplayName = "PatternBuilder: Email Validation should return ")]
  // public void

  [Fact]
  public void TestCaptureGroup()
  {
    result = _patternBuilder.CaptureGroup()
                            .AppendLiteral("test")
                            .Build()
                            .ToString();
    Assert.Equal("(test)", result);
  }

  [Fact]
  public void TestNonCaptureGroup()
  {
    result = _patternBuilder.NonCaptureGroup()
                            .AppendLiteral("test")
                            .Build()
                            .ToString();
    Assert.Equal("(?:test)", result);
  }


  [Theory]
  [InlineData(NamedGroupStyle.AngleBrackets, "testGroup", "content", "(?<testGroup>content)")]
  [InlineData(NamedGroupStyle.SingleQuote, "testGroup", "content", "(?'testGroup'content)")]
  [InlineData(NamedGroupStyle.PStyle, "testGroup", "content", "(?P<testGroup>content)")]
  public void TestNamedCaptureGroup(NamedGroupStyle style, string groupName, string content, string expected)
  {
    result = _patternBuilder.NamedCaptureGroup(style, groupName)
                            .AppendLiteral(content)
                            .Build()
                            .ToString();
    Assert.Equal(expected, result);
  }


  [Fact]
  public void TestStartAnchor()
  {

    result = _patternBuilder.StartAnchor()
                            .StartOfLine()
                            .Build()
                            .ToString();
    Assert.Equal("^", result);
        _ = _patternBuilder.Pattern.Clear();

    result = _patternBuilder.StartAnchor()
                            .EndOfLine()
                            .Build()
                            .ToString();
    Assert.Equal("$", result);
        _ = _patternBuilder.Pattern.Clear();

    result = _patternBuilder.StartAnchor()
                            .StartOfWord()
                            .Build()
                            .ToString();
    Assert.Equal(@"\b", result);
        _ = _patternBuilder.Pattern.Clear();

    result = _patternBuilder.StartAnchor()
                            .EndOfWord()
                            .Build()
                            .ToString();
    Assert.Equal(@"\b", result);
        _ = _patternBuilder.Pattern.Clear();

  }

  [Fact]
  public void TestBuild()
  {
    result = _patternBuilder.AppendLiteral("test")
                    .Build()
                    .ToString();
    Assert.Equal("test", result);
  }


}