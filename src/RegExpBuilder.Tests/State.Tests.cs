using Xunit;
using Builder;
using System.Text.RegularExpressions;

namespace RegExpBuilderTests;

public class StateTests
{
  [Fact]
  public void Constructor_Sets_Default_Values()
  {
    var state = new State();

    Assert.False(state.Some);
    Assert.False(state.ZeroOrOne);
    Assert.Equal(-1, state.MinimumOf);
    Assert.Equal(-1, state.MaximumOf);
    Assert.Equal(new RegexOptions(), state.Options);
    Assert.False(state.Or);
    Assert.False(state.MultiLine);
  }

  [Fact]
  public void SetSome_Updates_Some()
  {
    var state = new State();
    state.SetSome(true);

    Assert.True(state.Some);
  }

  [Fact]
  public void SetZeroOrOne_Updates_ZeroOrOne()
  {
    var state = new State();
    state.SetZeroOrOne(true);

    Assert.True(state.ZeroOrOne);
  }

  [Fact]
  public void SetMinimumOf_Updates_MinimumOf()
  {
    var state = new State();
    state.SetMinimumOf(5);

    Assert.Equal(5, state.MinimumOf);
  }

  [Fact]
  public void SetMaximumOf_Updates_MaximumOf()
  {
    var state = new State();
    state.SetMaximumOf(10);

    Assert.Equal(10, state.MaximumOf);
  }

  [Fact]
  public void SetOptions_Updates_Options()
  {
    var state = new State();
    state.SetOptions(RegexOptions.IgnoreCase);

    Assert.Equal(RegexOptions.IgnoreCase, state.Options);
  }

  [Fact]
  public void SetOr_Updates_Or()
  {
    var state = new State();
    state.SetOr(true);

    Assert.True(state.Or);
  }

  [Fact]
  public void SetMultiLine_Updates_MultiLine()
  {
    var state = new State();
    state.SetMultiLine(true);

    Assert.True(state.MultiLine);
  }

  [Fact]
  public void Reset_Resets_All_Properties()
  {
    var state = new State();
    state.SetSome(true);
    state.SetZeroOrOne(true);
    state.SetMinimumOf(5);
    state.SetMaximumOf(10);
    state.SetOptions(RegexOptions.IgnoreCase);
    state.SetOr(true);
    state.SetMultiLine(true);

    state.Reset();

    Assert.False(state.Some);
    Assert.False(state.ZeroOrOne);
    Assert.Equal(-1, state.MinimumOf);
    Assert.Equal(-1, state.MaximumOf);
    Assert.IsType<RegexOptions>(state.Options);
    Assert.False(state.Or);
    Assert.False(state.MultiLine);
  }
}
