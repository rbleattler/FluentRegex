using System.Text;
namespace FluentRegex;

/// <summary>
/// Class <c>GroupBuilder</c> builds groups for a regular expression pattern. Inherits from <see cref="Builder"/>.
/// </summary>
public class GroupBuilder : Builder
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

  internal Builder _builder;
  internal NamedGroupStyle? _namedGroupStyle = null;
  internal string? _groupName = null;
  internal GroupType _groupType = GroupType.Capturing;

  /// <summary>
  /// Initializes a new instance of the <see cref="GroupBuilder"/> class with a <see cref="PatternBuilder"/>, and the declared <see cref="NamedGroupStyle"/> and <see cref="GroupName"/>.
  /// </summary>
  /// <param name="patternBuilder"></param>
  /// <param name="namedGroupStyle"></param>
  /// <param name="groupName"></param>
  public GroupBuilder(Builder patternBuilder, NamedGroupStyle namedGroupStyle = NamedGroupStyle.AngleBrackets, string? groupName = null)
  {
    // If the group name is null or whitespace, generate a random name.
    if (string.IsNullOrWhiteSpace(groupName))
    {
      groupName = "group" + Guid.NewGuid().ToString().Replace("-", "");
    }
    _builder = patternBuilder;
    _namedGroupStyle = namedGroupStyle;
    _groupName = groupName;
    _groupType = GroupType.NamedCapturing;
    Start_Group();
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="GroupBuilder"/> class with a <see cref="PatternBuilder"/>, and the declared <see cref="GroupType"/>.
  /// </summary>
  /// <param name="patternBuilder"></param>
  /// <param name="groupType"></param>
  public GroupBuilder(Builder patternBuilder, GroupType groupType)
  {
    _groupType = groupType;
    if (groupType == GroupType.NamedCapturing)
      throw new ArgumentException("Named capturing groups must have a name.", nameof(groupType));

    _builder = patternBuilder;
    Start_Group();
  }


  /// <summary>
  /// Initializes a new instance of the <see cref="GroupBuilder"/> class with a <see cref="PatternBuilder"/>.
  /// </summary>
  /// <param name="patternBuilder"></param>
  public GroupBuilder(Builder patternBuilder)
  {
    _builder = patternBuilder;
    Start_Group();
  }

  /// <summary>
  /// Builds the group.
  /// </summary>
  /// <returns> The <see cref="PatternBuilder"/>. </returns>

  public override dynamic Build()
  {
    var outPattern = _pattern.ToString();

    if (!outPattern.EndsWith(")"))
    {
      _ = EndGroup();
      outPattern = _pattern.ToString();
      if (!outPattern.EndsWith(")"))
        throw new ArgumentException("The group is not closed.");
    }
    _builder._pattern.Append(outPattern);
    Validate();
    return _builder;
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="CharacterClassBuilder"/> class which is used to build a character class inline.
  /// </summary>
  public override CharacterClassBuilder StartCharacterClass()
  {
    return new CharacterClassBuilder(this);
  }

  /// <summary>
  /// Starts building the group by adding an opening parenthesis to the pattern. Depending on the <see cref="GroupType"/>, the method will add the appropriate syntax to the pattern.
  /// </summary>
  /// <returns> A new instance of the <see cref="GroupBuilder"/> class. </returns>
  // public GroupBuilder StartGroup()
  // {
  //   return new GroupBuilder(this._builder);
  // }

  /// <summary>
  /// Starts building the group by adding an opening parenthesis to the pattern. Depending on the <see cref="GroupType"/>, the method will add the appropriate syntax to the pattern.
  /// </summary>
  /// <returns> A new instance of the <see cref="GroupBuilder"/> class. </returns>
  internal GroupBuilder Start_Group()
  {
    _pattern.Append('(');
    switch (GroupType)
    {
      case GroupType.Capturing:
        break;
      case GroupType.NonCapturing:
        _pattern.Append("?:");
        break;
      case GroupType.NamedCapturing:
        _pattern.Append('?');
        switch (GroupStyle)
        {
          case NamedGroupStyle.AngleBrackets:
            _pattern.Append('<');
            _pattern.Append(GroupName);
            _pattern.Append('>');
            break;
          case NamedGroupStyle.PStyle:
            _pattern.Append("P<");
            _pattern.Append(GroupName);
            _pattern.Append('>');
            break;
          case NamedGroupStyle.SingleQuote:
            _pattern.Append('\'');
            _pattern.Append(GroupName);
            _pattern.Append('\'');
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
    return new AnchorBuilder(this);
  }

  /// <summary>
  /// The <c>AppendLiteral</c> method appends a string to the pattern. This hides the <see cref="IBuilder.AppendLiteral(string)"/> method from the base class.
  /// </summary>
  /// <param name="literal"></param>
  /// <returns><see cref="GroupBuilder"/></returns>
  public GroupBuilder AppendLiteral(string literal)
  {
    return ((IBuilder)this).AppendLiteral(literal);
    // var outLiteral = string.Empty;
    // foreach (var character in literal)
    // {
    //   if (_specialCharacters.Contains(character))
    //     outLiteral += @"\" + character;
    //   else
    //     outLiteral += character;
    // }
    // Pattern.Append(outLiteral);
    // return this;
  }

  internal GroupBuilder EndGroup()
  {
    _pattern.Append(')');
    return this;
  }

  internal new void Validate()
  {
    if (GroupStyle != NamedGroupStyle.PStyle)
      ((Builder)this).Validate();
    else
      Validate(skipRegexValidation: true);

  }

}
