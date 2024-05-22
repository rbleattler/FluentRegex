using Xunit;
using Builder;

namespace RegExpBuilderTests;

public class GroupBuilderTests
{
  [Fact]
  public void TestCaptureGroup()
  {
    var builder = new GroupBuilder();
    var result = builder.CaptureGroup("test");
    Assert.Equal("(test)", result.ToString());
  }

  [Fact]
  public void TestNonCaptureGroup()
  {
    var builder = new GroupBuilder();
    var result = builder.NonCaptureGroup("test");
    Assert.Equal("(?:test)", result.ToString());
  }

  [Fact]
  public void TestNamedCaptureGroup()
  {
    var builder = new GroupBuilder();
    var result = builder.NamedCaptureGroup("name", "test", NamedGroupStyle.AngleBrackets);
    Assert.Equal("(?<name>test)", result.ToString());
  }

  [Fact]
  public void TestAtomicGroup()
  {
    var builder = new GroupBuilder();
    var result = builder.AtomicGroup("test");
    Assert.Equal("(?>test)", result.ToString());
  }

  [Fact]
  public void TestSubpatternGroupNumberReset()
  {
    var builder = new GroupBuilder();
    var result = builder.SubpatternGroupNumberReset("test");
    Assert.Equal("(?|test)", result.ToString());
  }

  // Add more tests for other methods...
}
