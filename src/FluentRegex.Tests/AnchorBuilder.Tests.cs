using FluentRegex;

namespace FluentRegexTests.AnchorBuilderTests;

public abstract class AnchorBuilderTestGroup
{
  protected AnchorBuilder _anchorBuilder;
  protected PatternBuilder _patternBuilder;
  protected string result;

  public AnchorBuilderTestGroup()
  {
    result = "";
    _patternBuilder = new PatternBuilder();
    _anchorBuilder = new AnchorBuilder(_patternBuilder);
  }
}

[Collection("Anchor Builder: Should Not Throw Errors")]
public class AnchorBuilderTests : AnchorBuilderTestGroup
{

  [Fact(DisplayName = "AnchorBuilder: Start of Line ShouldAppend Expected Anchor (^)")]
  public void StartOfLine_ShouldAppendStartOfLineAnchor()
  {
    result = _anchorBuilder.StartOfLine()
                              .Build()
                           .AppendLiteral("test")
                           .Build()
                           .ToString();
    Assert.Equal("^test", result);
  }

  [Fact(DisplayName = "AnchorBuilder: End of String No Line Break ShouldAppend Expected Anchor (\\Z)")]
  public void EndOfStringNoLineBreak_ShouldAppendEndOfStringNoLineBreakAnchor()
  {
    _ = _patternBuilder.AppendLiteral("test");
    result = _anchorBuilder.EndOfStringNoLineBreak()
                           .Build()
                           .ToString();

    Assert.Equal("test\\Z", result);
  }

  [Fact(DisplayName = "AnchorBuilder: End of Line ShouldAppend Expected Anchor ($)")]
  public void EndOfLine_ShouldAppendEndOfLineAnchor()
  {
    result = _anchorBuilder.AppendLiteral("test")
                           .EndOfLine()
                           .Build()
                           .ToString();

    Assert.Equal("test$", result);
  }

  [Fact(DisplayName = "AnchorBuilder: End of String ShouldAppend Expected Anchor (\\z)")]
  public void EndOfString_ShouldAppendEndOfStringAnchor()
  {
    result = _anchorBuilder.AppendLiteral("test")
                           .EndOfString()
                           .Build()
                           .ToString();

    Assert.Equal("test\\z", result);
  }

  [Fact(DisplayName = "AnchorBuilder: Non-Word Boundary ShouldAppend Expected Anchor (\\B)")]
  public void NonWordBoundary_ShouldAppendNonWordBoundaryAnchor()
  {
    result = _anchorBuilder.AppendLiteral("test")
                           .NonWordBoundary()
                           .Build()
                           .ToString();

    Assert.Equal("test\\B", result);
  }

  [Fact(DisplayName = "AnchorBuilder: Word Boundary ShouldAppend Expected Anchor (\\b)")]
  public void WordBoundary_ShouldAppendWordBoundaryAnchor()
  {
    result = _anchorBuilder.AppendLiteral("test")
                           .WordBoundary()
                           .Build()
                           .ToString();

    Assert.Equal("test\\b", result);
  }

  [Fact(DisplayName = "AnchorBuilder: Start of Word ShouldAppend Expected Anchor (\\b)")]
  public void StartOfWord_ShouldAppendStartOfWordAnchor()
  {

    result = _anchorBuilder.StartOfWord()
                            .Build()
                           .AppendLiteral("test")
                           //  .Build()
                           .ToString();

    Assert.Equal("\\btest", result);
  }

  [Fact(DisplayName = "AnchorBuilder: End of Word ShouldAppend Expected Anchor (\\b)")]
  public void EndOfWord_ShouldAppendEndOfWordAnchor()
  {
    result = _anchorBuilder.AppendLiteral("test")
                           .EndOfWord()
                           .Build()
                           .ToString();
    Assert.Equal("test\\b", result);
  }

  [Fact(DisplayName = "AnchorBuilder: Append Literal ShouldAppend Literal")]
  public void AppendLiteral_ShouldAppendLiteral()
  {
    result = _anchorBuilder.AppendLiteral("test")
                           .Build()
                           .ToString();

    Assert.Equal("test", result);
  }

  [Fact]
  public void InvokeMethod_StartOfLine_SetsCorrectPattern()
  {
    var builder = new AnchorBuilder(new PatternBuilder());
    builder.InvokeMethod("StartOfLine");
    Assert.Equal(Anchors.StartOfLine, builder.Pattern.ToString());
  }

  [Fact]
  public void InvokeMethod_EndOfLine_SetsCorrectPattern()
  {
    var builder = new AnchorBuilder(new PatternBuilder());
    builder.InvokeMethod("EndOfLine");
    Assert.Equal(Anchors.EndOfLine, builder.Pattern.ToString());
  }

  [Fact]
  public void InvokeMethod_StartOfWord_SetsCorrectPattern()
  {
    var builder = new AnchorBuilder(new PatternBuilder());
    builder.InvokeMethod("StartOfWord");
    Assert.Equal(Anchors.StartOfWord, builder.Pattern.ToString());
  }

  [Fact]
  public void InvokeMethod_EndOfWord_SetsCorrectPattern()
  {
    var builder = new AnchorBuilder(new PatternBuilder());
    builder.InvokeMethod("EndOfWord");
    Assert.Equal(Anchors.EndOfWord, builder.Pattern.ToString());
  }

  [Fact]
  public void InvokeMethod_WordBoundary_SetsCorrectPattern()
  {
    var builder = new AnchorBuilder(new PatternBuilder());
    builder.InvokeMethod("WordBoundary");
    Assert.Equal(Anchors.WordBoundary, builder.Pattern.ToString());
  }

  [Fact]
  public void InvokeMethod_NonWordBoundary_SetsCorrectPattern()
  {
    var builder = new AnchorBuilder(new PatternBuilder());
    builder.InvokeMethod("NonWordBoundary");
    Assert.Equal(Anchors.NonWordBoundary, builder.Pattern.ToString());
  }

  [Fact]
  public void InvokeMethod_EndOfString_SetsCorrectPattern()
  {
    var builder = new AnchorBuilder(new PatternBuilder());
    builder.InvokeMethod("EndOfString");
    Assert.Equal(Anchors.EndOfString, builder.Pattern.ToString());
  }

  [Fact]
  public void InvokeMethod_EndOfStringNoLineBreak_SetsCorrectPattern()
  {
    var builder = new AnchorBuilder(new PatternBuilder());
    builder.InvokeMethod("EndOfStringNoLineBreak");
    Assert.Equal(Anchors.EndOfStringNoLineBreak, builder.Pattern.ToString());
  }

  [Fact]
  public void InvokeMethod_InvalidMethod_ThrowsException()
  {
    var builder = new AnchorBuilder(new PatternBuilder());
    Assert.Throws<NullReferenceException>(() => builder.InvokeMethod("InvalidMethod"));
  }
}
