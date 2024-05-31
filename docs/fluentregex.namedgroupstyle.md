# NamedGroupStyle

Namespace: FluentRegex

Represents the style of a named group in a regular expression pattern.

```csharp
public enum NamedGroupStyle
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) → [Enum](https://docs.microsoft.com/en-us/dotnet/api/system.enum) → [NamedGroupStyle](./fluentregex.namedgroupstyle.md)<br>
Implements [IComparable](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable), [ISpanFormattable](https://docs.microsoft.com/en-us/dotnet/api/system.ispanformattable), [IFormattable](https://docs.microsoft.com/en-us/dotnet/api/system.iformattable), [IConvertible](https://docs.microsoft.com/en-us/dotnet/api/system.iconvertible)

**Remarks:**

A named group is a capturing group that can be referenced by name.

## Fields

| Name | Value | Description |
| --- | --: | --- |
| SingleQuote | 0 | The named group is enclosed in single quotes. |
| AngleBrackets | 1 | The named group is enclosed in angle brackets. |
| PStyle | 2 | The named group is enclosed in angle brackets, preceded by a question mark and the letter 'P'. |
