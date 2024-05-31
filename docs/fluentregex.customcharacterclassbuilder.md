# CustomCharacterClassBuilder

Namespace: FluentRegex

Builds a custom character class for a regular expression pattern. Inherits from [Builder](./fluentregex.builder.md).

```csharp
public class CustomCharacterClassBuilder
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CustomCharacterClassBuilder](./fluentregex.customcharacterclassbuilder.md)

## Properties

### **Pattern**

Gets or sets the pattern.

```csharp
public StringBuilder Pattern { get; set; }
```

#### Property Value

[StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder)<br>

## Constructors

### **CustomCharacterClassBuilder(CharacterClassBuilder)**

Initializes a new instance of the [CustomCharacterClassBuilder](./fluentregex.customcharacterclassbuilder.md) class.

```csharp
public CustomCharacterClassBuilder(CharacterClassBuilder characterClassBuilder)
```

#### Parameters

`characterClassBuilder` [CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

## Methods

### **Build()**

Builds the custom character class.

```csharp
public CharacterClassBuilder Build()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **AppendLiteral(String)**

Appends a literal to the custom character class.

```csharp
public CustomCharacterClassBuilder AppendLiteral(string literal)
```

#### Parameters

`literal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[CustomCharacterClassBuilder](./fluentregex.customcharacterclassbuilder.md)<br>

### **Negate()**

Appends a character to the custom character class.

```csharp
public CustomCharacterClassBuilder Negate()
```

#### Returns

[CustomCharacterClassBuilder](./fluentregex.customcharacterclassbuilder.md)<br>

### **InRange(Char, Char)**

Appends a character to the custom character class.

```csharp
public CustomCharacterClassBuilder InRange(char start, char end)
```

#### Parameters

`start` [Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>

`end` [Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>

#### Returns

[CustomCharacterClassBuilder](./fluentregex.customcharacterclassbuilder.md)<br>

### **NotInRange(Char, Char)**

Appends a character to the custom character class.

```csharp
public CustomCharacterClassBuilder NotInRange(char start, char end)
```

#### Parameters

`start` [Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>

`end` [Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>

#### Returns

[CustomCharacterClassBuilder](./fluentregex.customcharacterclassbuilder.md)<br>
