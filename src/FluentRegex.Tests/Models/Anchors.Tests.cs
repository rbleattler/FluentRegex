using FluentRegex;
using System.Text.RegularExpressions;
using Xunit;

namespace FluentRegexTests
{
  public class AnchorsTests
  {
    private Regex _regex;
    private string TestString;
    private string GoodTestString;
    private string BadTestString;

    public AnchorsTests()
    {
      TestString = "";
      GoodTestString = "";
      BadTestString = "";
      _regex = new Regex("");
    }

    [Fact(DisplayName = "StartOfLine matches at the start of a line. Does not match elsewhere.")]
    public void StartOfLine_MatchesAtStartOfLine_DoesNotMatchElsewhere()
    {
      TestString = Anchors.StartOfLine + "Hello";
      _regex = new Regex(TestString);
      GoodTestString = "Hello World";
      BadTestString = "World Hello";
      Assert.Matches(_regex, GoodTestString);
      Assert.DoesNotMatch(_regex, BadTestString);
    }

    [Fact(DisplayName = "EndOfLine matches at the end of a line. Does not match elsewhere.")]
    public void EndOfLine_MatchesAtEndOfLine_DoesNotMatchElsewhere()
    {
      TestString = "Hello" + Anchors.EndOfLine;
      _regex = new Regex(TestString);
      GoodTestString = "World Hello";
      BadTestString = "Hello World";
      Assert.Matches(_regex, GoodTestString);
      Assert.DoesNotMatch(_regex, BadTestString);
    }

    [Fact(DisplayName = "StartOfWord matches at the start of a word")]
    public void StartOfWord_MatchesAtStartOfWord_DoesNotMatchElsewhere()
    {
      TestString = Anchors.StartOfWord + "Hello";
      _regex = new Regex(TestString);
      GoodTestString = "Hello World";
      BadTestString = "WorldHello";
      Assert.Matches(_regex, GoodTestString);
      Assert.DoesNotMatch(_regex, BadTestString);
    }

    [Fact(DisplayName = "EndOfWord matches at the end of a word. Does not match elsewhere.")]
    public void EndOfWord_MatchesAtEndOfWord_DoesNotMatchElsewhere()
    {
      TestString = "Hello" + Anchors.EndOfWord;
      _regex = new Regex(TestString);
      GoodTestString = "World Hello";
      BadTestString = "HelloWorld";
      Assert.Matches(_regex, GoodTestString);
      Assert.DoesNotMatch(_regex, BadTestString);
    }

    // ... continue for other tests
    [Fact(DisplayName = "WordBoundary matches at a word boundary. Does not match elsewhere.")]
    public void WordBoundary_MatchesAtWordBoundary_DoesNotMatchElsewhere()
    {
      TestString = Anchors.WordBoundary + "World";
      _regex = new Regex(TestString);
      GoodTestString = "Hello World!";
      BadTestString = "HelloWorld!";
      Assert.Matches(_regex, GoodTestString);
      Assert.DoesNotMatch(_regex, BadTestString);
    }

    [Fact(DisplayName = "NonWordBoundary matches at a non-word boundary. Does not match elsewhere.")]
    public void NonWordBoundary_MatchesAtNonWordBoundary_DoesNotMatchElsewhere()
    {
      TestString = Anchors.NonWordBoundary + "World";
      _regex = new Regex(TestString);
      GoodTestString = "HelloWorld!";
      BadTestString = "Hello World!";
      Assert.Matches(_regex, GoodTestString);
      Assert.DoesNotMatch(_regex, BadTestString);
    }

    [Fact(DisplayName = "EndOfString matches at the end of a string, where there is not a line break; where there is not a line break; Does not match elsewhere.")]
    public void EndOfString_MatchesAtEndOfString_Where_DoesNotMatchElsewhere()
    {
      TestString = "Hello" + Anchors.EndOfString;
      _regex = new Regex(TestString);
      GoodTestString = "World Hello";
      BadTestString = "Hello World";
      Assert.Matches(_regex, GoodTestString);
      GoodTestString = "World Hello";
      Assert.Matches(_regex, GoodTestString);
      Assert.DoesNotMatch(_regex, BadTestString);
    }

    [Fact(DisplayName = "EndOfStringNoLineBreak matches at the end of a string, where there is a line break; where there is not a line break; Does not match elsewhere.")]
    public void EndOfStringNoLineBreak_MatchesAtEndOfStringNoLineBreak_DoesNotMatchElsewhere()
    {
      TestString = "Hello" + Anchors.EndOfStringNoLineBreak;
      _regex = new Regex(TestString);
      GoodTestString = "World Hello\n";
      BadTestString = "Hello World";
      Assert.Matches(_regex, GoodTestString);
      Assert.DoesNotMatch(_regex, BadTestString);
      BadTestString = "Hello World\n";
      Assert.DoesNotMatch(_regex, BadTestString);
    }
  }
}
