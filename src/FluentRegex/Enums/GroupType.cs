namespace FluentRegex;

/// <summary>
/// Represents the type of group in a regular expression pattern.
/// </summary>
public enum GroupType
{
  /// <summary>
  /// A non-capturing group.
  /// </summary>
  NonCapturing,
  /// <summary>
  /// A capturing group.
  /// </summary>
  Capturing,
  /// <summary>
  /// A named capturing group.
  /// </summary>
  NamedCapturing
}