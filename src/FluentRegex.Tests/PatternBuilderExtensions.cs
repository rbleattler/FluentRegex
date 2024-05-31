namespace FluentRegex;

public static class PatternBuilderExtensions
{
  public static void ValidateEnd(this PatternBuilder builder)
  {
    ((IBuilder)builder).ValidateEnd();
  }

  public static void ValidateStart(this PatternBuilder builder)
  {
    ((IBuilder)builder).ValidateStart();
  }

  public static void ValidateParenthesesPairs(this PatternBuilder builder)
  {
    ((IBuilder)builder).ValidateParenthesesPairs();
  }

  public static void ValidatePatternRegex(this PatternBuilder builder)
  {
    ((IBuilder)builder).ValidatePatternRegex();
  }

  public static void ValidateNoEmptyStructures(this PatternBuilder builder)
  {
    ((IBuilder)builder).ValidateNoEmptyStructures();
  }

  public static void ValidateNoUnEscapedCharacters(this PatternBuilder builder)
  {
    ((IBuilder)builder).ValidateNoUnEscapedCharacters();
  }
}