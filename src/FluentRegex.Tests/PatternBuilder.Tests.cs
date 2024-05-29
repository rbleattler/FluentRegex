using Xunit;
using FluentRegex;
using System.Text.RegularExpressions;

namespace FluentRegexTests;

public class PatternBuilderTests
{

  private PatternBuilder _patternBuilder;

  public PatternBuilderTests()
  {
    _patternBuilder = new PatternBuilder();
  }

  [Fact]
  public void TestStartGroup()
  {
    _patternBuilder
    .StartGroup()
      .AppendLiteral("test")
      .Build();
    Assert.Equal("(test)", _patternBuilder.ToString());
  }

  [Fact]
  public void TestCaptureGroup()
  {
    _patternBuilder.CaptureGroup().AppendLiteral("test").Build();
    Assert.Equal("(test)", _patternBuilder.ToString());
  }

  [Fact]
  public void TestNonCaptureGroup()
  {
    _patternBuilder.NonCaptureGroup().AppendLiteral("test").Build();
    Assert.Equal("(?:test)", _patternBuilder.ToString());
  }


  [Theory]
  [InlineData(NamedGroupStyle.AngleBrackets, "testGroup", "content", "(?<testGroup>test)")]
  [InlineData(NamedGroupStyle.SingleQuote, "testGroup", "content", "(?'testGroup'test)")]
  [InlineData(NamedGroupStyle.PStyle, "testGroup", "content", "(?P<testGroup>test)")]
  public void TestNamedCaptureGroup(NamedGroupStyle style, string groupName, string content, string expected)
  {
    _patternBuilder.NamedCaptureGroup(style, groupName).AppendLiteral(content).Build();
    Assert.Equal(expected, _patternBuilder.ToString());
  }


  [Fact]
  public void TestStartAnchor()
  {
    //TODO: Can I do this with class data iteratively?

    _patternBuilder.StartAnchor().StartOfLine().Build();
    Assert.Equal("^", _patternBuilder.ToString());
    _patternBuilder.Pattern.Clear();

    _patternBuilder.StartAnchor().EndOfLine().Build();
    Assert.Equal("$", _patternBuilder.ToString());
    _patternBuilder.Pattern.Clear();

    _patternBuilder.StartAnchor().StartofWord().Build();
    Assert.Equal(@"\b", _patternBuilder.ToString());
    _patternBuilder.Pattern.Clear();

    _patternBuilder.StartAnchor().EndofWord().Build();
    Assert.Equal(@"\B", _patternBuilder.ToString());
    _patternBuilder.Pattern.Clear();

  }

  [Fact]
  public void TestBuild()
  {
    ((IBuilder)_patternBuilder).AppendLiteral("test").Build();
    Assert.Equal("test", _patternBuilder.ToString());
  }


}