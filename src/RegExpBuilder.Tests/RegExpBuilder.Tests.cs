using Xunit;
using Builder;
using System.Text.RegularExpressions;

namespace RegExpBuilderTests;
public class RegExpBuilderTests
{
  [Fact]
  public void TestAddGroup()
  {
    var regExpBuilder = new RegExpBuilder();
    var groupBuilder = new GroupBuilder();
    groupBuilder.Add("test").AsCaptureGroup();
    regExpBuilder.AddGroup(groupBuilder);
    Assert.Equal("(test)", regExpBuilder.ToString());
  }

  [Fact]
  public void TestAddGroupWithConfig()
  {
    var regExpBuilder = new RegExpBuilder();
    regExpBuilder.AddGroup(groupBuilder => groupBuilder.Add("test")).AsCaptureGroup();
    Assert.Equal("(test)", regExpBuilder.ToString());
  }

  [Fact]
  public void TestAddAnchor()
  {
    var regExpBuilder = new RegExpBuilder();
    var anchorBuilder = new AnchorBuilder();
    anchorBuilder.StartsWith("");
    regExpBuilder.AddAnchor(anchorBuilder);
    Assert.Equal("^", regExpBuilder.ToString());
  }

  [Fact]
  public void TestAddAnchorWithConfig()
  {
    var regExpBuilder = new RegExpBuilder();
    regExpBuilder.AddAnchor(anchorBuilder => anchorBuilder.StartsWith(""));
    Assert.Equal("^", regExpBuilder.ToString());
  }

  [Fact]
  public void TestOf()
  {
    var regExpBuilder = new RegExpBuilder();
    regExpBuilder.Of("test");
    Assert.Equal("test", regExpBuilder.ToString());
  }

  [Fact]
  public void TestOrLike()
  {
    var regExpBuilder = new RegExpBuilder();
    regExpBuilder.Of("test").Add(new Regex("abc"));
    Assert.Equal("(test)|(abc)", regExpBuilder.ToString());
  }

  [Fact]
  public void TestToRegex()
  {
    var regExpBuilder = new RegExpBuilder();
    regExpBuilder.Of("test");
    var regex = regExpBuilder.ToRegex();
    Assert.Matches("test", regex.Match("test").Value);
  }
}