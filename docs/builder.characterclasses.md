# CharacterClasses

Namespace: Builder

Represents all known character classes for regex.

```csharp
public static class CharacterClasses
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CharacterClasses](./builder.characterclasses.md)

## Fields

### **Digit**

Represents the digit character class [0-9].

```csharp
public static string Digit;
```

### **NonDigit**

Represents the non-digit character class [^0-9].

```csharp
public static string NonDigit;
```

### **Word**

Represents the word character class [a-zA-Z0-9_].

```csharp
public static string Word;
```

### **NonWord**

Represents the non-word character class [^a-zA-Z0-9_].

```csharp
public static string NonWord;
```

### **Whitespace**

Represents the whitespace character class \s.

```csharp
public static string Whitespace;
```

### **NonWhitespace**

Represents the non-whitespace character class \S.

```csharp
public static string NonWhitespace;
```

### **Tab**

Represents the tab character class \t.

```csharp
public static string Tab;
```

### **Newline**

Represents the newline character class \n.

```csharp
public static string Newline;
```

### **LowercaseLetter**

Represents the lowercase letter character class [a-z].

```csharp
public static string LowercaseLetter;
```

### **UppercaseLetter**

Represents the uppercase letter character class [A-Z].

```csharp
public static string UppercaseLetter;
```

### **HexDigit**

Represents the hexadecimal digit character class [0-9a-fA-F].

```csharp
public static string HexDigit;
```

### **NonHexDigit**

Represents the non-hexadecimal digit character class [^0-9a-fA-F].

```csharp
public static string NonHexDigit;
```

### **AnyCharacter**

Represents the any character class [\s\S].

```csharp
public static string AnyCharacter;
```

### **StartOfLine**

Represents the start of line character class ^.

```csharp
public static string StartOfLine;
```

### **EndOfLine**

Represents the end of line character class $.

```csharp
public static string EndOfLine;
```

### **WordBoundary**

Represents the start or end of word character class \b.

```csharp
public static string WordBoundary;
```

### **NonWordBoundary**

Represents a boundary that is not a word boundary \B.

```csharp
public static string NonWordBoundary;
```

### **EndOfString**

Represents the end of string character class \Z.

```csharp
public static string EndOfString;
```

### **EndOfStringNoLineBreak**

Represents the end of string character class \z.

```csharp
public static string EndOfStringNoLineBreak;
```

## Methods

### **GetCharacterClasses()**

Gets all character classes.

```csharp
public static String[] GetCharacterClasses()
```

#### Returns

[String[]](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
An array of all character classes.

**Remarks:**

This method is useful for iterating over all character classes.

### **GetLiteral(CharacterClass)**

Gets the literal representation of a character class.

```csharp
public static string GetLiteral(CharacterClass characterClass)
```

#### Parameters

`characterClass` [CharacterClass](./builder.characterclass.md)<br>
The character class to get the literal representation of.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The literal representation of the character class.

#### Exceptions

[ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception)<br>
Thrown when the character class is not recognized.

### **GetCharacterClass(String)**

Get a character class from a literal representation.

```csharp
public static CharacterClass GetCharacterClass(string literal)
```

#### Parameters

`literal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The literal representation of the character class.

#### Returns

[CharacterClass](./builder.characterclass.md)<br>
The character class.
