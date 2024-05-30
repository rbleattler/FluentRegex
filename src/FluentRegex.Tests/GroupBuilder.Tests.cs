using System;
using System.Text;
using FluentRegex;
namespace FluentRegexTests;

public class GroupBuilderTests
{

  private GroupBuilder _groupBuilder;
  private PatternBuilder _patternBuilder;
  private string result;

  public GroupBuilderTests()
  {
    result = "";
    _patternBuilder = new PatternBuilder();
    _groupBuilder = new GroupBuilder(_patternBuilder);
  }


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

  [Fact]
  public void TestNamedCaptureGroup()
  {
    // var result = _groupBuilder.NamedCaptureGroup("name", "test", NamedGroupStyle.AngleBrackets);
    result = _patternBuilder.NamedCaptureGroup(NamedGroupStyle.AngleBrackets, "name")
                              .AppendLiteral("test")
                              .Build()
                            .ToString();
    Assert.Equal("(?<name>test)", result);
  }

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

  [Fact]
  public void TestStartGroup()
  {
    Action resetBuilders = () =>
    {
      _patternBuilder = new PatternBuilder();
      _groupBuilder = new GroupBuilder(_patternBuilder);
    };
    result = _groupBuilder.StartGroup()
                          .Pattern
                          // .AppendLiteral("test")
                          // .Build()
                          .ToString();
    Assert.Equal("(", result);
    resetBuilders();
    _groupBuilder = _patternBuilder.NonCaptureGroup();
    result = _groupBuilder
                  .StartGroup()
                  .Pattern
                  .ToString();
    Assert.Equal("(?:", result);

  }

}