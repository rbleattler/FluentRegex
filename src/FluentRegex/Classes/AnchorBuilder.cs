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
  private readonly dynamic _patternBuilder;
  internal StringBuilder _pattern = new StringBuilder();


  /// <summary>
  /// Initializes a new instance of the <see cref="AnchorBuilder"/> class.
  /// </summary>
  /// <param name="patternBuilder"></param>
  public AnchorBuilder(Builder patternBuilder)
  {
    _patternBuilder = patternBuilder;
  }

  /// <summary>
  /// Builds the anchor.
  /// </summary>
  /// <returns>The <see cref="PatternBuilder"/> instance that the anchor was added to.</returns>
  public dynamic Build()
  {
    _ =_patternBuilder.Pattern.Append(Anchor);
    return _patternBuilder;
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
  public AnchorBuilder StartOfWord()
  {
    Anchor = Anchors.StartOfWord;
    return this;
  }

  /// <summary>
  /// Sets the anchor to <see cref="Anchors.EndOfWord"/>.
  /// </summary>
  /// <returns></returns>
  public AnchorBuilder EndOfWord()
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
  public AnchorBuilder EndOfString()
  {
    Anchor = Anchors.EndOfString;
    return this;
  }

  /// <summary>
  /// Sets the anchor to <see cref="Anchors.EndOfStringNoLineBreak"/>.
  /// </summary>
  /// <returns></returns>
  public AnchorBuilder EndOfStringNoLineBreak()
  {
    Anchor = Anchors.EndOfStringNoLineBreak;
    return this;
  }

  /// <summary>
  /// Appends a literal string to the pattern.
  /// </summary>
  /// <param name="literal"></param>
  /// <returns>This <see cref="AnchorBuilder"/> instance.</returns>
  public AnchorBuilder AppendLiteral(string literal)
  {
    ((IBuilder)_patternBuilder).AppendLiteral(literal);
    return this;
  }

  /// <summary>
  /// Not implemented.
  /// </summary>
  void IBuilder.Validate()
  {
    throw new NotImplementedException();
    // ((IBuilder)_patternBuilder).Validate();
  }

  /// <summary>
  /// Not implemented.
  /// </summary>
  void IBuilder.Validate(bool _)
  {
    throw new NotImplementedException();
    // ((IBuilder)_patternBuilder).Validate();
  }

  string IBuilder.ToString()
  {
    return Pattern.ToString();
  }
}
