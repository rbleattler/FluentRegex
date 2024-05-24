using Builder;

namespace RegExpBuilderTests;
// TODO: Add tests for each scenario on _groups_ as well
// TODO: Add complex tests for longer patterns
public class BuilderTests
{
  private Builder.Builder _builder;

  public BuilderTests()
  {
    // This constructor replaces the [TestInitialize] method
    _builder = new RegExpBuilder();
  }

  [Fact]
  public void TestStripParenthesis()
  {
    Assert.Equal("test", _builder.StripParenthesis("(test)"));
  }

  [Fact]
  public void TestAddParenthesis()
  {
    Assert.Equal("(test)", _builder.AddParenthesis("test"));
  }

  [Fact]
  public void TestBuild()
  {
    Assert.Equal(string.Empty, _builder.Build());
  }

  [Theory]
  [InlineData("groupName", "value", NamedGroupStyle.AngleBrackets, "(?<groupName>value)")]
  [InlineData("groupName", "value", NamedGroupStyle.SingleQuote, "(?'groupName'value)")]
  [InlineData("groupName", "value", NamedGroupStyle.PStyle, "(?P<groupName>value)")]

  public void TestAsNamedCaptureGroup(string groupName, string value, NamedGroupStyle style, string expected)
  {
    var result = _builder.Add(value).AsNamedCaptureGroup($"{groupName}", style).Build();
    Assert.Equal($"{expected}", result);
  }

  [Fact]
  public void TestAsNonCaptureGroup()
  {
    var result = _builder.Add("testValue").AsNonCaptureGroup().Build();
    Assert.Equal("(?:testValue)", result);
  }

  [Fact]
  public void TestAsCaptureGroup()
  {
    var result = _builder.Add("testValue").AsCaptureGroup().Build();
    Assert.Equal("(testValue)", result);
  }

  [Fact]
  public void TestStartOfInput()
  {
    var result = _builder.StartOfInput().Build();
    Assert.Equal("^", result);
  }

  [Fact]
  public void TestEndOfInput()
  {
    var result = _builder.EndOfInput().Build();
    Assert.Equal("$", result);
  }

  [Fact]
  public void TestOneOrMore()
  {
    var result = _builder.Add("x").OneOrMore().Build();
    Assert.Equal("x+", result);
  }

  [Fact]
  public void TestDigit()
  {
    var result = _builder.Digit().Build();
    Assert.Equal($"\\d", result);
  }

  [Fact]
  public void TestDigits()
  {
    var result = _builder.Digits().Build();
    Assert.Equal("\\d+", result);
  }

  [Fact]
  public void TestZeroOrOne()
  {
    var result = _builder.Add("x").ZeroOrOne().Build();
    Assert.Equal("x?", result);
  }

  [Fact]
  public void TestLetter()
  {
    var result = _builder.Letter().Build();
    Assert.Equal("[A-Za-z]", result);
  }

  [Fact]
  public void TestLetters()
  {
    var result = _builder.Letters().Build();
    Assert.Equal("[A-Za-z]+", result);
  }

  [Fact]
  public void TestMinimumOf()
  {
    var result = _builder.MinimumOf(3).Build();
    Assert.Equal("{3,}", result);
    _builder.Reset();
    result = _builder.Add("(hey)").MinimumOf(6).Build();
    Assert.Equal("(hey){6,}", result);
  }

  [Fact]
  public void TestOr()
  {
    var result = _builder.Add("this").Or().Add("that").Build();
    Assert.Equal("this|that", result);
  }

  [Fact]
  public void TestAddLiteral()
  {
    var result = _builder.Add("test").Build();
    Assert.Equal("test", result);
  }

  [Fact]
  public void TestAddFrom()
  {
    var result = _builder.AddFrom("A-Z").Build();
    Assert.Equal("[A-Z]", result);
  }
}
