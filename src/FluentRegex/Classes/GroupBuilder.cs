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

  internal dynamic _builder;
  internal NamedGroupStyle? _namedGroupStyle = null;
  internal string? _groupName = null;
  internal GroupType _groupType = GroupType.Capturing;

  /// <summary>
  /// Initializes a new instance of the <see cref="GroupBuilder"/> class with a <see cref="PatternBuilder"/>, and the declared <see cref="NamedGroupStyle"/> and <see cref="GroupName"/>.
  /// </summary>
  /// <param name="patternBuilder"></param>
  /// <param name="namedGroupStyle"></param>
  /// <param name="groupName"></param>
  public GroupBuilder(Builder patternBuilder, NamedGroupStyle namedGroupStyle, string? groupName)
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
    _ = Start_Group();
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
    _ = Start_Group();
  }


  /// <summary>
  /// Initializes a new instance of the <see cref="GroupBuilder"/> class with a <see cref="PatternBuilder"/>.
  /// </summary>
  /// <param name="patternBuilder"></param>
  public GroupBuilder(Builder patternBuilder)
  {
    _builder = patternBuilder;
    _ = Start_Group();
  }

  /// <summary>
  /// Builds the group.
  /// </summary>
  /// <returns> The <see cref="PatternBuilder"/>. </returns>

  public override dynamic Build()
  {
    // use the IBuilder validation internal methods to also account for situations where this is closing an outer group immediately after closing an inner group
    Dictionary<char, int> parenthesesCounts = ((IBuilder)this).GetOpenCloseCharacterCounts();
    if (parenthesesCounts['('] > parenthesesCounts[')'] && Pattern.ToString().EndsWith(')'))
    {
      _ = EndGroup();
    }

    if (!Pattern.ToString().EndsWith(')'))
    {
      _ = EndGroup();
      if (!Pattern.ToString().EndsWith(")"))
        throw new ArgumentException("The group is not closed.");
    }

    _ = _builder.Pattern.Append(Pattern.ToString());
    Validate();

    return _builder;
  }

  /// <summary>
  /// Builds the group. Casts the return type to the specified type.
  /// </summary>
  /// <typeparam name="T">The type to cast the return value to.</typeparam>
  public dynamic Build<T>()
  {
    // use the IBuilder validation internal methods to also account for situations where this is closing an outer group immediately after closing an inner group
    Dictionary<char, int> parenthesesCounts = ((IBuilder)this).GetOpenCloseCharacterCounts();
    if (parenthesesCounts['('] > parenthesesCounts[')'] && Pattern.ToString().EndsWith(')'))
    {
      _ = EndGroup();
    }

    if (!Pattern.ToString().EndsWith(')'))
    {
      _ = EndGroup();
      if (!Pattern.ToString().EndsWith(')'))
        throw new ArgumentException("The group is not closed.");
    }

    _ = _builder.Pattern.Append(Pattern.ToString());
    Validate();

    return (T)_builder;
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
  internal GroupBuilder Start_Group()
  {
    _ = Pattern.Append('(');
    switch (GroupType)
    {
      case GroupType.Capturing:
        break;
      case GroupType.NonCapturing:
        _ = Pattern.Append("?:");
        break;
      case GroupType.NamedCapturing:
        _ = Pattern.Append('?');
        switch (GroupStyle)
        {
          case NamedGroupStyle.AngleBrackets:
            _ = Pattern.Append('<');
            _ = Pattern.Append(GroupName);
            _ = Pattern.Append('>');
            break;
          case NamedGroupStyle.PStyle:
            _ = Pattern.Append("P<");
            _ = Pattern.Append(GroupName);
            _ = Pattern.Append('>');
            break;
          case NamedGroupStyle.SingleQuote:
            _ = Pattern.Append('\'');
            _ = Pattern.Append(GroupName);
            _ = Pattern.Append('\'');
            break;
          default:
            break;
        }
        break;
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
  }


  /// <summary>
  /// The <c>AppendLiteral</c> method appends a string to the pattern. This hides the <see cref="IBuilder.AppendLiteral(char)"/> method from the base class.
  /// </summary>
  /// <param name="literal"></param>
  /// <returns><see cref="GroupBuilder"/></returns>
  public GroupBuilder AppendLiteral(char literal)
  {
    return ((IBuilder)this).AppendLiteral(literal);
  }

  internal GroupBuilder EndGroup()
  {
    _ = Pattern.Append(')');
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
