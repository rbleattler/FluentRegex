using System.Text;
namespace FluentRegex;

/// <summary>
/// Class <c>AnchorBuilder</c> builds anchors for a regular expression pattern.
/// </summary>
public class AnchorBuilder : IBuilder
{
  /// <summary>
  /// Gets or sets the pattern.
  /// </summary>
  /// <value></value>
  public StringBuilder Pattern
  {
    get => _pattern;
    set => _pattern = value;
  }
  internal string Anchor
  {
    get => _pattern.ToString();
    set => _pattern = _pattern.Append(value);
  }
  private readonly PatternBuilder _regexBuilder;
  internal StringBuilder _pattern = new StringBuilder();


  /// <summary>
  /// Initializes a new instance of the <see cref="AnchorBuilder"/> class.
  /// </summary>
  /// <param name="regexBuilder"></param>
  public AnchorBuilder(PatternBuilder regexBuilder)
  {
    _regexBuilder = regexBuilder;
  }

  /// <summary>
  /// Sets the anchor to <see cref="Anchors.StartOfLine"/>.
  /// </summary>
  public AnchorBuilder StartOfLine()
  {
    Anchor = Anchors.StartOfLine;
    return this;
  }

  /// <summary>
  /// Sets the anchor to <see cref="Anchors.EndOfLine"/>.
  /// </summary>
  /// <returns></returns>
  public AnchorBuilder EndOfLine()
  {
    Anchor = Anchors.EndOfLine;
    return this;
  }

  /// <summary>
  /// Sets the anchor to <see cref="Anchors.StartOfWord"/>.
  /// </summary>
  /// <returns></returns>
  public AnchorBuilder StartofWord()
  {
    Anchor = Anchors.StartOfWord;
    return this;
  }

  /// <summary>
  /// Sets the anchor to <see cref="Anchors.EndOfWord"/>.
  /// </summary>
  /// <returns></returns>
  public AnchorBuilder EndofWord()
  {
    Anchor = Anchors.EndOfWord;
    return this;
  }

  /// <summary>
  /// Sets the anchor to <see cref="Anchors.WordBoundary"/>.
  /// </summary>
  /// <returns></returns>
  public AnchorBuilder WordBoundary()
  {
    Anchor = Anchors.WordBoundary;
    return this;
  }

  /// <summary>
  /// Sets the anchor to <see cref="Anchors.NonWordBoundary"/>.
  /// </summary>
  /// <returns></returns>
  public AnchorBuilder NonWordBoundary()
  {
    Anchor = Anchors.NonWordBoundary;
    return this;
  }


  /// <summary>
  /// Sets the anchor to <see cref="Anchors.EndOfString"/>.
  /// </summary>
  /// <returns></returns>
  public AnchorBuilder EndofString()
  {
    Anchor = Anchors.EndOfString;
    return this;
  }

  /// <summary>
  /// Sets the anchor to <see cref="Anchors.EndOfStringNoLineBreak"/>.
  /// </summary>
  /// <returns></returns>
  public AnchorBuilder EndofStringNoLineBreak()
  {
    Anchor = Anchors.EndOfStringNoLineBreak;
    return this;
  }

  /// <summary>
  /// Builds the anchor.
  /// </summary>
  /// <returns>The <see cref="PatternBuilder"/> instance that the anchor was added to.</returns>
  public PatternBuilder Build()
  {
    _regexBuilder._pattern.Append(Anchor);
    // Validate(); //TODO: Is there any valid reason to add this?
    return _regexBuilder;
  }


  /// <summary>
  /// Appends a literal string to the pattern.
  /// </summary>
  /// <param name="literal"></param>
  /// <returns>This <see cref="AnchorBuilder"/> instance.</returns>
  public AnchorBuilder AppendLiteral(string literal)
  {
    ((IBuilder)_regexBuilder).AppendLiteral(literal);
    return this;
  }

  /// <summary>
  /// Not implemented.
  /// </summary>
  public void Validate()
  {
    throw new NotImplementedException();
    // ((IBuilder)_regexBuilder).Validate();
  }
}
