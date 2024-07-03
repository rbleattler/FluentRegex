using Xunit;
using FluentRegex;
using System.Collections;

namespace FluentRegexTests;




public class CharacterClassBuilderTests
{
  private PatternBuilder _patternBuilder;
  private CharacterClassBuilder _characterClassBuilder;
  private string? result;

  /// <summary>
  /// ClassData for CharacterClassBuilderTests. This will iterate over all the fields in CharacterClasses and return the name of the field and the value of the field if the name of the field is also a method in CharacterClassBuilder
  /// </summary>
  public class CharacterClassData : IEnumerable<object[]>
  {
    public IEnumerator<object[]> GetEnumerator()
    {
      var characterClassFields = typeof(CharacterClasses).GetFields();
      foreach (var field in characterClassFields)
      {
        var valueOfField = field?.GetValue(null)?.ToString();
        // Check if this is the name of a method in CharacterClassBuilder, if so, return the name of the method and the value of the field
        if (typeof(CharacterClassBuilder).GetMethod(field!.Name) != null)
          yield return new object[] { field!.Name, valueOfField! };
      }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }

  public CharacterClassBuilderTests()
  {
    result = "";
    _patternBuilder = new PatternBuilder();
    _characterClassBuilder = new CharacterClassBuilder(_patternBuilder);
  }

  [Theory(DisplayName = "Test CharacterClassBuilder With Valid Input")]
  [ClassData(typeof(CharacterClassData))]
  public void CharacterClassBuilder_WithValidInput_ShouldReturnExpectedOutput(string propertyName, string expectedValue)
  {
    var methodInfo = typeof(CharacterClassBuilder).GetMethod(propertyName);
    _ = (methodInfo?.Invoke(_characterClassBuilder, null));

    result = _characterClassBuilder.Build().Pattern.ToString();

    Assert.NotNull(result);
    Assert.Equal(expectedValue, result);
  }

  [Theory(DisplayName = "InvokeMethod_ShouldInvokeCorrectMethod")]
  [InlineData("AppendLiteral", "test", "test")]
  [InlineData("StartOfWord", null, @"\b")]
  [InlineData("EndOfWord", null, @"\b")]
  [InlineData("NonWordBoundary", null, @"\B")]
  [InlineData("EndOfString", null, @"\z")]
  [InlineData("EndOfStringNoLineBreak", null, @"\Z")]
  [InlineData("AnyCharacter", null, ".")]
  [InlineData("Digit", null, @"\d")]
  [InlineData("NonDigit", null, @"\D")]
  [InlineData("Whitespace", null, @"\s")]
  [InlineData("NonWhitespace", null, @"\S")]
  [InlineData("Word", null, @"\w")]
  [InlineData("NonWord", null, @"\W")]
  [InlineData("Tab", null, @"\t")]
  [InlineData("Newline", null, @"\n")]
  [InlineData("LowercaseLetter", null, "[a-z]")]
  [InlineData("UppercaseLetter", null, "[A-Z]")]
  [InlineData("HexDigit", null, "[0-9a-fA-F]")]
  [InlineData("NonHexDigit", null, "[^0-9a-fA-F]")]
  public void InvokeMethod_ShouldInvokeCorrectMethod(string methodName, string argument, string expectedPattern)
  {
    // Arrange
    var builder = new CharacterClassBuilder(new PatternBuilder());
    object[] args = argument != null ? [argument] : [];

    // Act
    builder.InvokeMethod(methodName, args);

    // Assert
    var resultPattern = builder.Build().ToString();
    Assert.Contains(expectedPattern, resultPattern);
  }

}
