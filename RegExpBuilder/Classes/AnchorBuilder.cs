namespace Builder;

public class AnchorBuilder
{
  private string? _expression;
  private RegExpBuilder _regExpBuilder;

  public AnchorBuilder(RegExpBuilder regExpBuilder)
  {
    _regExpBuilder = regExpBuilder;
  }
  public AnchorBuilder()
  {
    _regExpBuilder = new RegExpBuilder();
  }

  public AnchorBuilder StartsWith(string startsWith, bool? nonMultiLine = null)
  {
    if (nonMultiLine.HasValue && nonMultiLine.Value)
      _expression = $"\\A{startsWith}";
    else
      _expression = $"^{startsWith}";
    return this;
  }

  public AnchorBuilder EndsWith(string endsWith, bool? nonMultiLine = null)
  {
    if (nonMultiLine.HasValue && nonMultiLine.Value)
      _expression += $"{endsWith}\\Z";
    else
      _expression += $"{endsWith}$";
    return this;
  }

  public AnchorBuilder AbsoluteEndsWith(string endsWith)
  {
    _expression = $"{endsWith}\\z";
    return this;
  }

  public AnchorBuilder WordBoundary()
  {
    _expression = @"\b";
    return this;
  }

  public AnchorBuilder NonWordBoundary()
  {
    _expression = @"\B";
    return this;
  }


  public override string ToString()
  {
    return _expression ?? "";
  }

  public RegExpBuilder AddToRegExpBuilder()
  {
    _regExpBuilder.Add(_expression!);
    return _regExpBuilder;
  }
}
