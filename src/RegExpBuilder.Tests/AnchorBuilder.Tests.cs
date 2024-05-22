using Xunit;
using Builder;

namespace RegExpBuilderTests;
public class AnchorBuilderTests
{
  [Fact]
  public void StartsWith_NonMultiLine()
  {
    var builder = new AnchorBuilder();
    var result = builder.StartsWith("test", true).Build();

    Assert.Equal("\\Atest", result);
  }

  [Fact]
  public void StartsWith_MultiLine()
  {
    var builder = new AnchorBuilder();
    var result = builder.StartsWith("test").Build();

    Assert.Equal("^test", result);
  }

  [Fact]
  public void EndsWith_NonMultiLine()
  {
    var builder = new AnchorBuilder();
    var result = builder.EndsWith("test", true).Build();

    Assert.Equal("test\\Z", result);
  }

  [Fact]
  public void EndsWith_MultiLine()
  {
    var builder = new AnchorBuilder();
    var result = builder.EndsWith("test").Build();

    Assert.Equal("test$", result);
  }
}
