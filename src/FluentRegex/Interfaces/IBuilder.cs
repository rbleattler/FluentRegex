using System;
using System.Text;
namespace FluentRegex;

/// <summary>
/// Interface <c>IBuilder</c> defines the methods and properties for building a regular expression pattern.
/// </summary>
public interface IBuilder
{
  internal const string _specialCharacters = @"\.^$*+?()[{|";

  /// <summary>
  /// Gets or sets the pattern.
  /// </summary>
  /// <value></value>
  public StringBuilder Pattern { get; set; }
  // public AnchorBuilder StartAnchor();
  // public GroupBuilder StartGroup();
  // public CharacterClassBuilder StartCharacterClass();

  /// <summary>
  /// Builds the regular expression pattern.
  /// </summary>
  /// <returns></returns>
  public PatternBuilder Build();

  /// <summary>
  /// Returns the regular expression pattern as a string.
  /// </summary>
  /// <returns></returns>
  public string ToString();

  /// <summary>
  /// The <c>AppendLiteral</c> method appends a literal string to the pattern, escaping any special characters.
  /// </summary>
  public IBuilder AppendLiteral(string literal)
  {
    var outLiteral = String.Empty;
    foreach (var character in literal)
    {
      if (_specialCharacters.Contains(character))
        outLiteral += @"\" + character;
      else
        outLiteral += character;
    }
    Pattern.Append(outLiteral);
    return this;
  }


  // <summary>
  // Appends a literal string to the pattern.
  // </summary>
  // public dynamic AppendLiteral(string literal);

  /// <summary>
  /// Validates the regular expression pattern to ensure it is well-formed.
  /// </summary>
  void Validate();

}