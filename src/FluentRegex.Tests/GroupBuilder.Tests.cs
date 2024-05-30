using System;
using System.Text;
using FluentRegex;
namespace FluentRegexTests.GroupBuilderTests;

public abstract class GroupBuilderTestGroup
{
  protected GroupBuilder _groupBuilder;
  protected PatternBuilder _patternBuilder;
  protected string result;

  public GroupBuilderTestGroup()
  {
    result = "";
    _patternBuilder = new PatternBuilder();
    _groupBuilder = new GroupBuilder(_patternBuilder);
  }

  public void ClearGroupBuilderPattern()
  {
    _groupBuilder.Pattern.Clear();
  }

  public void ClearPatternBuilderPattern()
  {
    _patternBuilder.Pattern.Clear();
  }

}

[Collection("Capture Groups")]
public class CaptureGroupTests : GroupBuilderTestGroup
{
  [Fact]
  public void WhenAppendingLiteral_ShouldReturnExpectedString()
  {
    result = _patternBuilder.CaptureGroup()
                              .AppendLiteral("test")
                              .Build()
                            .ToString();
    Assert.Equal("(test)", result);
  }
}

[Collection("Non-Capture Groups")]
public class NonCaptureGroupTests : GroupBuilderTestGroup
{
  [Fact]
  public void WhenAppendingLiteral_ShouldReturnExpectedString()
  {
    result = _patternBuilder.NonCaptureGroup()
                              .AppendLiteral("test")
                              .Build()
                            .ToString();
    Assert.Equal("(?:test)", result);
  }
}

[Collection("Named Capture Groups")]
public class NamedCaptureGroupTests : GroupBuilderTestGroup
{
  [Fact(DisplayName = "Named Capture Group<Angle Brackets>: When Appending Literal, Should Return Expected String")]
  public void NamedCaptureGroup_WithAngleBrackets_WhenAppendingLiteral_ShouldReturnExpectedString()
  {
    result = _patternBuilder.NamedCaptureGroup(NamedGroupStyle.AngleBrackets, "name")
                              .AppendLiteral("test")
                              .Build()
                            .ToString();
    Assert.Equal("(?<name>test)", result);
  }

  [Fact(DisplayName = "Named Capture Group<Single Quote>: When Appending Literal, Should Return Expected String")]
  public void NamedCaptureGroup_WithSingleQuote_WhenAppendingLiteral_ShouldReturnExpectedString()
  {
    result = _patternBuilder.NamedCaptureGroup(NamedGroupStyle.SingleQuote, "name")
                              .AppendLiteral("test")
                              .Build()
                            .ToString();
    Assert.Equal("(?'name'test)", result);
  }

  [Fact(DisplayName = "Named Capture Group<P Style>: When Appending Literal, Should Return Expected String")]
  public void NamedCaptureGroup_WithPStyle_WhenAppendingLiteral_ShouldReturnExpectedString()
  {
    result = _patternBuilder.NamedCaptureGroup(NamedGroupStyle.PStyle, "name")
                              .AppendLiteral("test")
                              .Build()
                            .ToString();
    Assert.Equal("(?P<name>test)", result);
  }
}

[Collection("StartGroup Method")]
public class StartGroupTests : GroupBuilderTestGroup
{
  [Fact(DisplayName = "Capture Group: When Starting Group, Should Return Expected String")]
  public void WhenStartingGroup_ShouldReturnExpectedString()
  {
    ClearGroupBuilderPattern();
    result = _groupBuilder.StartGroup()
                          .Pattern
                          .ToString();
    Assert.Equal("(", result);
  }

  [Fact(DisplayName = "Non-Capturing Group: When Starting Group, Should Return Expected String")]
  public void NonCapturingGroup_WhenStartingGroup_ShouldReturnExpectedString()
  {
    _groupBuilder = _patternBuilder.NonCaptureGroup();
    ClearGroupBuilderPattern();
    result = _groupBuilder
                  .StartGroup()
                  .Pattern
                  .ToString();
    Assert.Equal("(?:", result);

  }

  [Fact(DisplayName = "Named Capture Group<Angle Brackets>: When Starting Group, Should Return Expected String")]
  public void NamedCaptureGroup_WithAngleBrackets_WhenStartingGroup_ShouldReturnExpectedString()
  {
    _groupBuilder = _patternBuilder.NamedCaptureGroup(NamedGroupStyle.AngleBrackets, "name");
    ClearGroupBuilderPattern();
    result = _groupBuilder
                  .StartGroup()
                  .Pattern
                  .ToString();
    Assert.Equal("(?<name>", result);
  }

  [Fact(DisplayName = "Named Capture Group<P Style>: When Starting Group, Should Return Expected String")]
  public void NamedCaptureGroup_WithPStyle_WhenStartingGroup_ShouldReturnExpectedString()
  {
    _groupBuilder = _patternBuilder.NamedCaptureGroup(NamedGroupStyle.PStyle, "name");
    ClearGroupBuilderPattern();
    result = _groupBuilder
                  .StartGroup()
                  .Pattern
                  .ToString();
    Assert.Equal("(?P<name>", result);
  }

  [Fact(DisplayName = "Named Capture Group<Single Quote>: When Starting Group, Should Return Expected String")]
  public void NamedCaptureGroup_WithSingleQuote_WhenStartingGroup_ShouldReturnExpectedString()
  {
    _groupBuilder = _patternBuilder.NamedCaptureGroup(NamedGroupStyle.SingleQuote, "name");
    ClearGroupBuilderPattern();
    result = _groupBuilder
                  .StartGroup()
                  .Pattern
                  .ToString();
    Assert.Equal("(?'name'", result);
  }



}

[Collection("NotImplemented")]
public class NotImplemented : GroupBuilderTestGroup
{

  [Fact(Skip = "Not implemented yet")]
  public void TestAtomicGroup()
  {
    // var result = _groupBuilder.AtomicGroup("test");
    Assert.Equal("(?>test)", result);
  }

  [Fact(Skip = "Not implemented yet")]
  public void TestSubpatternGroupNumberReset()
  {
    // var result = _groupBuilder.SubpatternGroupNumberReset("test");
    Assert.Equal("(?|test)", result);
  }
}