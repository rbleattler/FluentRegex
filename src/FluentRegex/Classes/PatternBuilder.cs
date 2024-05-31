using System;
using System.Text;
namespace FluentRegex;

/// <summary>
/// Builds a regex pattern.
/// </summary>
/// <example>
/// <para>This example shows how to build a regex pattern using the <see cref="PatternBuilder"/> class.</para>
/// <br/>
///   <code language="csharp">
///   class Program
///   {
///     static void Main()
///     {
///       var patternBuilder = new PatternBuilder();
///       var regex = patternBuilder
///           .StartAnchor().Build()
///           .StartGroup()
///               .AppendLiteral("abc")
///               .StartCharacterClass()
///                   .AppendLiteral("0-9")
///                   .Build()
///               .StartGroup()
///                   .AppendLiteral("xyz")
///                   .EndGroup()
///               .Build()
///           .EndAnchor()
///           .ToString();
///       Console.WriteLine($"Generated Regex: {regex}");
///     }
///   }
///   </code>
/// </example>
public class PatternBuilder : Builder, IBuilder
{
  /// <summary>
  /// Initializes a new instance of the <see cref="PatternBuilder"/> class.
  /// </summary>
  public override StringBuilder Pattern
  {
    get => _pattern;
    set => _pattern = value;
  }
  // internal StringBuilder _pattern = new StringBuilder();


  /// <summary>
  /// Validates, then returns the <see cref="PatternBuilder"/>.
  /// </summary>
  public override PatternBuilder Build()
  {
    Validate();
    return this;
  }


  /// <summary>
  /// Adds an <see cref="AnchorBuilder"/> to the pattern.
  /// </summary>
  /// <returns><see cref="AnchorBuilder"/></returns>
  public override AnchorBuilder StartAnchor()
  {
    return new AnchorBuilder(this);
  }

  /// <summary>
  /// Adds a <see cref="CharacterClassBuilder"/> to the pattern.
  /// </summary>
  /// <returns><see cref="CharacterClassBuilder"/></returns>
  public override CharacterClassBuilder StartCharacterClass()
  {
    return new CharacterClassBuilder(this);
  }

  /// <summary>
  /// Appends a literal string to the pattern. Implements <see cref="IBuilder.AppendLiteral(string)"/>.
  /// </summary>
  /// <param name="literal">The literal string to append.</param>
  /// <returns><see cref="PatternBuilder"/></returns>
  public PatternBuilder AppendLiteral(string literal)
  {
    return ((IBuilder)this).AppendLiteral(literal);
  }
}


