using System.Text;
namespace FluentRegex;

/// <summary>
/// Class <c>GroupBuilder</c> builds groups for a regular expression pattern. Inherits from <see cref="Builder"/>.
/// </summary>
public class GroupBuilder : Builder, IBuilder
{
  /// <summary>
  /// Gets or sets the pattern.
  /// </summary>
  /// <value></value>
  public override StringBuilder Pattern
  {
    get => _pattern;
    set => _pattern = value;
  }

  /// <summary>
  /// The name of the named capture group when <see cref="GroupType"/> is <see cref="GroupType.NamedCapturing"/>.
  /// </summary>
  public string? GroupName => _groupName;

  /// <summary>
  /// The <see cref="FluentRegex.GroupType"/> of the group.
  /// </summary>
  public GroupType GroupType => _groupType;

  /// <summary>
  /// The <see cref="FluentRegex.NamedGroupStyle"/> of the group.
  /// </summary>
  public NamedGroupStyle? GroupStyle => _namedGroupStyle;

  // private new readonly StringBuilder _pattern = new StringBuilder();

  private readonly PatternBuilder _regexBuilder;
  private readonly NamedGroupStyle? _namedGroupStyle = null;
  private readonly string? _groupName = null;
  private readonly GroupType _groupType = GroupType.Capturing;

  /// <summary>
  /// Initializes a new instance of the <see cref="GroupBuilder"/> class with a <see cref="PatternBuilder"/>, and the declared <see cref="NamedGroupStyle"/> and <see cref="GroupName"/>.
  /// </summary>
  /// <param name="regexBuilder"></param>
  /// <param name="namedGroupStyle"></param>
  /// <param name="groupName"></param>
  public GroupBuilder(PatternBuilder regexBuilder, NamedGroupStyle namedGroupStyle = NamedGroupStyle.AngleBrackets, string? groupName = null)
  {
    // If the group name is null or whitespace, generate a random name.
    if (string.IsNullOrWhiteSpace(groupName))
    {
      groupName = "group" + Guid.NewGuid().ToString().Replace("-", "");
    }
    _regexBuilder = regexBuilder;
    _namedGroupStyle = namedGroupStyle;
    _groupName = groupName;
    _groupType = GroupType.NamedCapturing;
    StartGroup();
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="GroupBuilder"/> class with a <see cref="PatternBuilder"/>, and the declared <see cref="GroupType"/>.
  /// </summary>
  /// <param name="regexBuilder"></param>
  /// <param name="groupType"></param>
  public GroupBuilder(PatternBuilder regexBuilder, GroupType groupType)
  {
    _groupType = groupType;
    if (groupType == GroupType.NamedCapturing)
      throw new ArgumentException("Named capturing groups must have a name.", nameof(groupType));

    _regexBuilder = regexBuilder;
    StartGroup();
  }


  /// <summary>
  /// Initializes a new instance of the <see cref="GroupBuilder"/> class with a <see cref="PatternBuilder"/>.
  /// </summary>
  /// <param name="regexBuilder"></param>
  public GroupBuilder(PatternBuilder regexBuilder)
  {
    _regexBuilder = regexBuilder;
    StartGroup();
  }

  /// <summary>
  /// Builds the group.
  /// </summary>
  /// <returns> The <see cref="PatternBuilder"/>. </returns>

  public override PatternBuilder Build()
  {
    var outPattern = _pattern.ToString();

    if (!outPattern.EndsWith(")"))
    {
      _ = EndGroup();
      outPattern = _pattern.ToString();
    }
    _regexBuilder._pattern.Append(outPattern);
    Validate();
    return _regexBuilder;
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="CharacterClassBuilder"/> class which is used to build a character class inline.
  /// </summary>
  public override CharacterClassBuilder StartCharacterClass()
  {
    return new CharacterClassBuilder(_regexBuilder);
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="GroupBuilder"/> class which is used to build a group inline.
  /// </summary>
  /// <returns> A new instance of the <see cref="GroupBuilder"/> class. </returns>
  public override GroupBuilder StartGroup()
  {
    _pattern.Append("(");
    switch (GroupType)
    {
      case GroupType.Capturing:
        break;
      case GroupType.NonCapturing:
        _pattern.Append("?:");
        break;
      case GroupType.NamedCapturing:
        _pattern.Append("?");
        switch (GroupStyle)
        {
          case NamedGroupStyle.AngleBrackets:
            _pattern.Append("<");
            _pattern.Append(GroupName);
            _pattern.Append(">");
            break;
          case NamedGroupStyle.PStyle:
            _pattern.Append("P<");
            _pattern.Append(GroupName);
            _pattern.Append(">");
            break;
          case NamedGroupStyle.SingleQuote:
            _pattern.Append("\'");
            _pattern.Append(GroupName);
            _pattern.Append("\'");
            break;
          default:
            break;
        }
        break;
      //TODO: Add support for these group types
      // - PositiveLookahead:
      //   - pattern : "?="
      // - NegativeLookahead:
      //   - pattern : "?!"
      // - PositiveLookbehind:
      //   - pattern : "?<="
      // - NegativeLookbehind:
      //   - pattern : "?<!"
      default:
        break;
    }
    return this;
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="AnchorBuilder"/> class which is used to build an anchor inline.
  /// </summary>
  /// <returns> A new instance of the <see cref="AnchorBuilder"/> class. </returns>
  public override AnchorBuilder StartAnchor()
  {
    return new AnchorBuilder(_regexBuilder);
  }

  /// <summary>
  /// The <c>AppendLiteral</c> method appends a string to the pattern. This hides the <see cref="Builder.AppendLiteral(string)"/> method from the base class.
  /// </summary>
  /// <param name="literal"></param>
  /// <returns></returns>
  public new GroupBuilder AppendLiteral(string literal)
  {
    var outLiteral = String.Empty;
    foreach (var character in literal)
    {
      if (_specialCharacters.Contains(character))
        outLiteral += @"\" + character;
      else
        outLiteral += character;
    }
    Pattern.Append(outLiteral); return this;
  }

  internal GroupBuilder EndGroup()
  {
    _pattern.Append(")");
    return this;
  }

}
