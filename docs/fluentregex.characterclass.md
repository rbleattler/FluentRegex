# CharacterClass

Namespace: FluentRegex

Represents a character class in a regular expression pattern.

```csharp
public enum CharacterClass
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) → [Enum](https://docs.microsoft.com/en-us/dotnet/api/system.enum) → [CharacterClass](./fluentregex.characterclass.md)<br>
Implements [IComparable](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable), [ISpanFormattable](https://docs.microsoft.com/en-us/dotnet/api/system.ispanformattable), [IFormattable](https://docs.microsoft.com/en-us/dotnet/api/system.iformattable), [IConvertible](https://docs.microsoft.com/en-us/dotnet/api/system.iconvertible)

**Remarks:**

A character class is a set of characters that can be used to match a single character.

## Fields

| Name | Value | Description |
| --- | --: | --- |
| AnyCharacter | 0 | Represents the any character class in a regular expression pattern. |
| Digit | 1 | Represents a digit character class in a regular expression pattern. |
| EndOfLine | 2 | Represents the end of a line character class in a regular expression pattern. |
| EndOfString | 3 | Represents the end of a string character class in a regular expression pattern. |
| EndOfStringNoLineBreak | 4 | Represents the end of a string without a line break character class in a regular expression pattern. |
| HexDigit | 5 | Represents a hexadecimal digit character class in a regular expression pattern. |
| LowercaseLetter | 6 | Represents a lowercase letter character class in a regular expression pattern. |
| Newline | 7 | Represents a newline character class in a regular expression pattern. |
| NonDigit | 8 | Represents a non-digit character class in a regular expression pattern. |
| NonHexDigit | 9 | Represents a non-hexadecimal digit character class in a regular expression pattern. |
| NonWhitespace | 10 | Represents a non-whitespace character class in a regular expression pattern. |
| NonWord | 11 | Represents a non-word character class in a regular expression pattern. |
| NonWordBoundary | 12 | Represents a non-word boundary character class in a regular expression pattern. |
| StartOfLine | 13 | Represents the start of a line character class in a regular expression pattern. |
| Tab | 14 | Represents a tab character class in a regular expression pattern. |
| UppercaseLetter | 15 | Represents an uppercase letter character class in a regular expression pattern. |
| Whitespace | 16 | Represents a whitespace character class in a regular expression pattern. |
| Word | 17 | Represents a word character class in a regular expression pattern. |
| WordBoundary | 18 | Represents a word boundary character class in a regular expression pattern. |
