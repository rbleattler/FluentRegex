# PatternBuilder

Namespace: FluentRegex

Builds a regex pattern.

```csharp
public class PatternBuilder : Builder, IBuilder
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Builder](./fluentregex.builder.md) → [PatternBuilder](./fluentregex.patternbuilder.md)<br>
Implements [IBuilder](./fluentregex.ibuilder.md)

## Properties

### **Pattern**

Initializes a new instance of the [PatternBuilder](./fluentregex.patternbuilder.md) class.

```csharp
public StringBuilder Pattern { get; set; }
```

#### Property Value

[StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder)<br>

## Constructors

### **PatternBuilder()**

```csharp
public PatternBuilder()
```

## Methods

### **Build()**

Validates, then returns the [PatternBuilder](./fluentregex.patternbuilder.md).

```csharp
public PatternBuilder Build()
```

#### Returns

[PatternBuilder](./fluentregex.patternbuilder.md)<br>

### **StartAnchor()**

Adds an [AnchorBuilder](./fluentregex.anchorbuilder.md) to the pattern.

```csharp
public AnchorBuilder StartAnchor()
```

#### Returns

[AnchorBuilder](./fluentregex.anchorbuilder.md)<br>
[AnchorBuilder](./fluentregex.anchorbuilder.md)

### **StartCharacterClass()**

Adds a [CharacterClassBuilder](./fluentregex.characterclassbuilder.md) to the pattern.

```csharp
public CharacterClassBuilder StartCharacterClass()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>
[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)

### **AppendLiteral(String)**

Appends a literal string to the pattern. Implements [IBuilder.AppendLiteral(String)](./fluentregex.ibuilder.md#appendliteralstring).

```csharp
public PatternBuilder AppendLiteral(string literal)
```

#### Parameters

`literal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The literal string to append.

#### Returns

[PatternBuilder](./fluentregex.patternbuilder.md)<br>
[PatternBuilder](./fluentregex.patternbuilder.md)
