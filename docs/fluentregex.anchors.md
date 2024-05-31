# Anchors

Namespace: FluentRegex

Represents all* known anchors for regex.

```csharp
public static class Anchors
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Anchors](./fluentregex.anchors.md)

## Fields

### **StartOfLine**

Matches the position at the start of the string. If the Multiline option is enabled, also matches immediately after a line break character.

```csharp
public static string StartOfLine;
```

### **EndOfLine**

Matches the position at the end of the string or before the line break at the end of the string. If the Multiline option is enabled, also matches before a line break character.

```csharp
public static string EndOfLine;
```

### **StartOfWord**

Matches a word boundary position such as whitespace, punctuation, or the start/end of the string.

```csharp
public static string StartOfWord;
```

### **EndOfWord**

Matches a word boundary position such as whitespace, punctuation, or the start/end of the string.

```csharp
public static string EndOfWord;
```

### **WordBoundary**

Matches a position that is a word boundary.

```csharp
public static string WordBoundary;
```

### **NonWordBoundary**

Matches a position that is not a word boundary.

```csharp
public static string NonWordBoundary;
```

### **EndOfString**

Matches the position at the end of the string. Not satisfied by a new line character, therefor must be at the very end of the string.

```csharp
public static string EndOfString;
```

### **EndOfStringNoLineBreak**

Matches the position at the end of the string. Ignores multiline mode. Matches before a new line (\n) character, but not before a new line sequence (\r\n).

```csharp
public static string EndOfStringNoLineBreak;
```
