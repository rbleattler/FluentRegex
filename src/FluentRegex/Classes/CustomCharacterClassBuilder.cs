using System.Text;
using System.Text.RegularExpressions;
namespace FluentRegex;

/// <summary>
/// Builds a custom character class for a regular expression pattern. Inherits from <see cref="Builder"/>.
/// </summary>
public class CustomCharacterClassBuilder
{
  /// <summary>
  /// Gets or sets the pattern.
  /// </summary>
  public StringBuilder Pattern
  {
    get => _customCharacterClassPattern;
    set => _customCharacterClassPattern = value;
  }
  private readonly CharacterClassBuilder _characterClassBuilder;
  private StringBuilder _customCharacterClassPattern = new StringBuilder();

  /// <summary>
  /// Initializes a new instance of the <see cref="CustomCharacterClassBuilder"/> class.
  /// </summary>
  /// <param name="characterClassBuilder"></param>
  public CustomCharacterClassBuilder(CharacterClassBuilder characterClassBuilder)
  {
    _characterClassBuilder = characterClassBuilder;
        _ = StartPattern();
  }

  /// <summary>
  /// Builds the custom character class.
  /// </summary>
  public CharacterClassBuilder Build()
  {
        _ = EndPattern();
    Validate();
    _ = _characterClassBuilder.AppendLiteral(_customCharacterClassPattern.ToString());
    return _characterClassBuilder;
  }

  //region Private Methods
  void Validate()
  {
    if (_customCharacterClassPattern.ToString().Contains("[]"))
    {
      throw new InvalidOperationException("Character Class is empty");
    }
    if (_customCharacterClassPattern.Length == 0)
    {
      throw new InvalidOperationException("Character Class is empty");
    }
    try
    {
      _ = new Regex(_customCharacterClassPattern.ToString());
    }
    catch (ArgumentException)
    {
      throw new ArgumentException("Invalid character class");
    }
  }

  CustomCharacterClassBuilder StartPattern()
  {
    _ = _customCharacterClassPattern.Append('[');
    return this;
  }

  CustomCharacterClassBuilder EndPattern()
  {
    _ = _customCharacterClassPattern.Append(']');
    return this;
  }

  //endregion

  /// <summary>
  /// Appends a literal to the custom character class.
  /// </summary>
  public CustomCharacterClassBuilder AppendLiteral(string literal)
  {
    // If the literal is a special token of any sort, we have to escape it ('-' for example, is a special token in a character class, so we have to escape it)
    _ = _customCharacterClassPattern.Append(EscapeLiteral(literal));
    return this;
  }


  /// <summary>
  /// Appends a character to the custom character class.
  /// </summary>
  public CustomCharacterClassBuilder Negate()
  {
        _ = _customCharacterClassPattern.Insert(1, '^');
    return this;
  }

  /// <summary>
  /// Appends a character to the custom character class.
  /// </summary>
  public CustomCharacterClassBuilder InRange(char start, char end)
  {
    _ = _customCharacterClassPattern.Append(start);
    _ = _customCharacterClassPattern.Append('-');
    _ = _customCharacterClassPattern.Append(end);
    return this;
  }

  /// <summary>
  /// Appends a character to the custom character class.
  /// </summary>
  public CustomCharacterClassBuilder NotInRange(char start, char end)
  {
    _ = _customCharacterClassPattern.Append(start);
    _ = _customCharacterClassPattern.Append('-');
    _ = _customCharacterClassPattern.Append(end);
        _ = Negate();
    return this;
  }

  private string EscapeLiteral(string literal)
  {
    // If the literal is a special token of any sort, we have to escape it ('-' for example, is a special token in a character class, so we have to escape it). The RegEx.Escape method does not escape the '-' character.
    if (literal == "-")
    {
      return "\\-";
    }
    return literal;

  }
}