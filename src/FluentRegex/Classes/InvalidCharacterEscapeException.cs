using System;
using System.Runtime.Serialization;
using System.Text;

namespace FluentRegex.Exceptions;

/// <summary>
/// A custom exception thrown when an invalid character escape sequence is detected.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="InvalidCharacterEscapeException"/> class.
/// </remarks>
/// <param name="targetCharacter">The character that was attempted to be escaped.</param>
/// <param name="pattern">The pattern that the character was found in.</param>
/// <param name="indexOfCharacter">The index of the character in the pattern.</param>
/// <param name="escapeSequence">The escape sequence that was used.</param>
/// <exception cref="InvalidCharacterEscapeException">Thrown when an invalid character escape sequence is detected.</exception>

public class InvalidCharacterEscapeException(char targetCharacter, string pattern, int indexOfCharacter, string escapeSequence) : Exception($"Invalid escape sequence '{escapeSequence}' for character '{targetCharacter}' at index {indexOfCharacter} in pattern '{pattern}' (pattern: {pattern} | index: {indexOfCharacter} | escape sequence: {escapeSequence} | target character: {targetCharacter})")
{
}
