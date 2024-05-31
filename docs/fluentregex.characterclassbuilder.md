# CharacterClassBuilder

Namespace: FluentRegex

```csharp
public class CharacterClassBuilder
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CharacterClassBuilder](./fluentregex.characterclassbuilder.md)

## Constructors

### **CharacterClassBuilder(PatternBuilder)**

```csharp
public CharacterClassBuilder(PatternBuilder patternBuilder)
```

#### Parameters

`patternBuilder` [PatternBuilder](./fluentregex.patternbuilder.md)<br>

### **CharacterClassBuilder(GroupBuilder)**

```csharp
public CharacterClassBuilder(GroupBuilder groupBuilder)
```

#### Parameters

`groupBuilder` [GroupBuilder](./fluentregex.groupbuilder.md)<br>

## Methods

### **Build()**

```csharp
public object Build()
```

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **StartCustomPattern()**

```csharp
public CustomCharacterClassBuilder StartCustomPattern()
```

#### Returns

[CustomCharacterClassBuilder](./fluentregex.customcharacterclassbuilder.md)<br>

### **AppendLiteral(String)**

```csharp
public CharacterClassBuilder AppendLiteral(string literal)
```

#### Parameters

`literal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **StartOfWord()**

```csharp
public CharacterClassBuilder StartOfWord()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **EndOfWord()**

```csharp
public CharacterClassBuilder EndOfWord()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **NonWordBoundary()**

```csharp
public CharacterClassBuilder NonWordBoundary()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **EndOfString()**

```csharp
public CharacterClassBuilder EndOfString()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **EndOfStringNoLineBreak()**

```csharp
public CharacterClassBuilder EndOfStringNoLineBreak()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **AnyCharacter()**

```csharp
public CharacterClassBuilder AnyCharacter()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **Digit()**

```csharp
public CharacterClassBuilder Digit()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **NonDigit()**

```csharp
public CharacterClassBuilder NonDigit()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **Whitespace()**

```csharp
public CharacterClassBuilder Whitespace()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **NonWhitespace()**

```csharp
public CharacterClassBuilder NonWhitespace()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **Word()**

```csharp
public CharacterClassBuilder Word()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **NonWord()**

```csharp
public CharacterClassBuilder NonWord()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **Tab()**

```csharp
public CharacterClassBuilder Tab()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **Newline()**

```csharp
public CharacterClassBuilder Newline()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **LowercaseLetter()**

```csharp
public CharacterClassBuilder LowercaseLetter()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **UppercaseLetter()**

```csharp
public CharacterClassBuilder UppercaseLetter()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **HexDigit()**

```csharp
public CharacterClassBuilder HexDigit()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **NonHexDigit()**

```csharp
public CharacterClassBuilder NonHexDigit()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>
