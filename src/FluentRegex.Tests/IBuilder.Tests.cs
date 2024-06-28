using FluentRegex;
using Xunit;
using System;
using FluentRegex.Exceptions;

namespace FluentRegexTests;
public class IBuilderTests
{
  private PatternBuilder _builder = new();
  private string? result = "";

  [Fact(DisplayName = "AppendLiteral appends literal string to pattern")]
  public void AppendLiteral_AppendsLiteralStringToPattern()
  {
    result = _builder.AppendLiteral("test").Pattern
                     .ToString();
    Assert.Equal("test", result);
  }

  //FIXME: The CheckInvalidEscapedClosure bug impacts this test
  [Fact(DisplayName = "AppendLiteral Appends and escapes special characters")]
  public void AppendLiteral_AppendsAndEscapesSpecialCharacters()
  {
    char[] chars = ['.', '^', '$', '*', '+', '?', '(', ')', '[', '{', '|'];
    foreach (var c in chars)
    {
      var expected = $" \\{c} ";
      _builder.AppendLiteral(" ");
      _builder.AppendLiteral(c);
      _builder.AppendLiteral(" ");
      result = _builder.ToString();
      Assert.Equal(expected, result);
      _ = _builder.Pattern.Clear();
      result = string.Empty;
    }
  }

  [Fact(DisplayName = "ValidateEnd throws exception for invalid pattern")]
  public void ValidateEnd_ThrowsExceptionForInvalidPattern()
  {
    _ = _builder.Pattern.Append('(').ToString();
    result = Record.Exception(_builder.ValidateEnd)
                    .Message;
    Assert.NotNull(result);
  }

  [Fact(DisplayName = "Validate does not throw exception for valid pattern")]
  public void Validate_DoesNotThrowExceptionForValidPattern()
  {
    _ = _builder.Pattern.Append("(test)"); // Balanced parentheses
    var exception = Record.Exception(_builder.Validate);
    Assert.Null(exception);
  }

  [Fact(DisplayName = "ValidateStart throws exception for invalid pattern")]
  public void ValidateStart_ThrowsExceptionForInvalidPattern()
  {
    _ = _builder.Pattern.Append(')').ToString();
    result = Record.Exception(_builder.ValidateStart)
                    .Message;
    Assert.NotNull(result);
  }

  [Fact(DisplayName = "ValidateParenthesesPairs throws exception for invalid pattern")]
  public void ValidateParenthesesPairs_ThrowsExceptionForInvalidPattern()
  {
    _ = _builder.Pattern.Append("(test").ToString();
    result = Record.Exception(_builder.ValidateParenthesesPairs)
                    .Message;
    Assert.NotNull(result);
  }

  [Fact(DisplayName = "ValidatePatternRegex throws exception for invalid pattern")]
  public void ValidatePatternRegex_ThrowsExceptionForInvalidPattern()
  {
    _ = _builder.Pattern.Append("[").ToString();
    result = Record.Exception(_builder.ValidatePatternRegex)
                    .Message ?? null;
    Assert.NotNull(result);
  }

  [Fact(DisplayName = "ValidateNoEmptyStructures throws exception for invalid pattern")]
  public void ValidateNoEmptyStructures_ThrowsExceptionForInvalidPattern()
  {
    _ = _builder.Pattern.Append("()").ToString();
    result = Record.Exception(_builder.ValidateNoEmptyStructures)
                    .Message;
    Assert.NotNull(result);
  }

  [Fact(DisplayName = "ValidateNoUnEscapedCharacters throws exception for invalid pattern")]
  public void ValidateNoUnEscapedCharacters_ThrowsExceptionForInvalidPattern()
  {
    _ = _builder.AppendLiteral(@"(abc\)");

    Assert.Throws<InvalidCharacterEscapeException>(_builder.ValidateNoUnEscapedCharacters);
  }


}
