using FluentAssertions;
using FluentRegex;
using Xunit;

namespace FluentRegexTests;

public class MetaSequenceBuilderTests
{
    // Arrange
    protected static PatternBuilder _patternBuilder = new();
    protected MetaSequenceBuilder _metaSequenceBuilder = new(_patternBuilder);
    protected object result;

    private void ClearMetaSequenceBuilderPattern()
    {
        ClearPatternBuilderPattern();
        _ = _metaSequenceBuilder.Pattern.Clear();
    }

    private void ClearPatternBuilderPattern()
    {
        _ = _patternBuilder.Pattern.Clear();
    }

    [Fact]
    public void Build_ReturnsCorrectIBuilderInstance()
    {
        ClearMetaSequenceBuilderPattern();
        // Act & Assert
        ((object)_metaSequenceBuilder.Build()).Should().BeSameAs(_patternBuilder);
    }

    [Fact]
    public void AppendLiteral_WithLiteral_AppendsLiteralCorrectly()
    {
        ClearMetaSequenceBuilderPattern();
        var literal = "test";

        // Act
        _metaSequenceBuilder.AppendLiteral(literal);

        // Assert
        ((string)_metaSequenceBuilder.Build().ToString()).Should().Be(literal);
    }

    [Fact]
    public void AnyCharacter_AppendsCorrectly()
    {
        ClearMetaSequenceBuilderPattern();

        // Act
        _metaSequenceBuilder.AnyCharacter();

        // Assert
        ((string)_metaSequenceBuilder.Build().ToString()).Should().Be(".");
    }

    [Fact]
    public void Digit_AppendsCorrectly()
    {
        ClearMetaSequenceBuilderPattern();

        // Assert
        ((string)_metaSequenceBuilder.Digit().Build().ToString()).Should().Be("\\d");
    }

    [Fact]
    public void NonDigit_AppendsCorrectly()
    {
        ClearMetaSequenceBuilderPattern();

        // Assert
        ((string)_metaSequenceBuilder.NonDigit().Build().ToString()).Should().Be("\\D");
    }

    [Fact]
    public void Whitespace_AppendsCorrectly()
    {
        ClearMetaSequenceBuilderPattern();

        // Assert
        ((string)_metaSequenceBuilder.Whitespace().Build().ToString()).Should().Be("\\s");
    }

    [Fact]
    public void NonWhitespace_AppendsCorrectly()
    {
        ClearMetaSequenceBuilderPattern();
        // Assert
        ((string)_metaSequenceBuilder.NonWhitespace().Build().ToString()).Should().Be("\\S");
    }

    [Fact]
    public void Word_AppendsCorrectly()
    {
        ClearMetaSequenceBuilderPattern();

        // Assert
        ((string)_metaSequenceBuilder.Word().Build().ToString()).Should().Be("\\w");
    }

    [Fact]
    public void NonWord_AppendsCorrectly()
    {
        ClearMetaSequenceBuilderPattern();

        // Assert
        ((string)_metaSequenceBuilder.NonWord().Build().ToString()).Should().Be("\\W");
    }

    [Fact]
    public void Tab_AppendsCorrectly()
    {
        ClearMetaSequenceBuilderPattern();

        // Assert
        ((string)_metaSequenceBuilder.Tab().Build().ToString()).Should().Be("\\t");
    }

    // [Fact]
    // public void AnyUnicode_AppendsCorrectly()
    // {
    //     ClearMetaSequenceBuilderPattern();

    //     // Assert
    //     ((string)_metaSequenceBuilder.AnyUnicode().Build().ToString()).Should().Be("\\X");
    // }

    [Fact]
    public void InvokeMethod_WithMethodNameAndArgs_InvokesMethodCorrectly()
    {
        ClearMetaSequenceBuilderPattern();
        var methodName = "AnyCharacter";

        // Assert
        ((string)_metaSequenceBuilder.InvokeMethod(methodName).Build().ToString()).Should().Be(".");
    }



}