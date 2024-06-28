using FluentRegex;
using Xunit;
using System;
using System.Text;
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

    Assert.Throws<InvalidCharacterEscapeException>(() => _builder.ValidateNoUnEscapedCharacters());
  }

  [Theory(DisplayName = "GetUnescapedCharacterCount should return correct count")]
  [InlineData('a', @"a\ab", 1)] // Single unescaped 'a'
  [InlineData('\\', @"\\", 0)] // Escaped backslash, should count as 0
  [InlineData('b', @"b\bb\b", 2)] // Two unescaped 'b's, twp escaped
  [InlineData('c', @"c\c\cc", 2)] // Two unescaped 'c's, two escaped
  [InlineData('d', @"ddd\d\d\d", 3)] // Three unescaped 'd's, three escaped
  public void GetUnescapedCharacterCount_ShouldReturnCorrectCount(char character, string pattern, int expectedCount)
  {
    _ = _builder.AppendLiteral(pattern);

    int actualCount = ((IBuilder)_builder).GetUnescapedCharacterCount(character, pattern);

    Assert.Equal(expectedCount, actualCount);
  }

  [Fact(DisplayName = "Building CustomCharacterClass from literal string in group returns expected value")]
  public void Building_CustomCharacterClass_FromLiteralString_InGroup_ReturnsExpectedValue()
  {
    var gb = new GroupBuilder(_builder);
    gb.StartCharacterClass()
      .AppendLiteral("[a-z]")
      .Build()
    .Build();
    result = _builder.ToString();
    Assert.Equal("([a-z])", result);
  }

}
