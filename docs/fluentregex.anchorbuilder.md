# AnchorBuilder

Namespace: FluentRegex

Class `AnchorBuilder` builds anchors for a regular expression pattern.

```csharp
public class AnchorBuilder : IBuilder
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [AnchorBuilder](./fluentregex.anchorbuilder.md)<br>
Implements [IBuilder](./fluentregex.ibuilder.md)

## Properties

### **Pattern**

Gets or sets the pattern.

```csharp
public StringBuilder Pattern { get; set; }
```

#### Property Value

[StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder)<br>

## Constructors

### **AnchorBuilder(Builder)**

Initializes a new instance of the [AnchorBuilder](./fluentregex.anchorbuilder.md) class.

```csharp
public AnchorBuilder(Builder patternBuilder)
```

#### Parameters

`patternBuilder` [Builder](./fluentregex.builder.md)<br>

## Methods

### **Build()**

Builds the anchor.

```csharp
public object Build()
```

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The [PatternBuilder](./fluentregex.patternbuilder.md) instance that the anchor was added to.

### **StartOfLine()**

Sets the anchor to [Anchors.StartOfLine](./fluentregex.anchors.md#startofline).

```csharp
public AnchorBuilder StartOfLine()
```

#### Returns

[AnchorBuilder](./fluentregex.anchorbuilder.md)<br>

### **EndOfLine()**

Sets the anchor to [Anchors.EndOfLine](./fluentregex.anchors.md#endofline).

```csharp
public AnchorBuilder EndOfLine()
```

#### Returns

[AnchorBuilder](./fluentregex.anchorbuilder.md)<br>

### **StartOfWord()**

Sets the anchor to [Anchors.StartOfWord](./fluentregex.anchors.md#startofword).

```csharp
public AnchorBuilder StartOfWord()
```

#### Returns

[AnchorBuilder](./fluentregex.anchorbuilder.md)<br>

### **EndOfWord()**

Sets the anchor to [Anchors.EndOfWord](./fluentregex.anchors.md#endofword).

```csharp
public AnchorBuilder EndOfWord()
```

#### Returns

[AnchorBuilder](./fluentregex.anchorbuilder.md)<br>

### **WordBoundary()**

Sets the anchor to [Anchors.WordBoundary](./fluentregex.anchors.md#wordboundary).

```csharp
public AnchorBuilder WordBoundary()
```

#### Returns

[AnchorBuilder](./fluentregex.anchorbuilder.md)<br>

### **NonWordBoundary()**

Sets the anchor to [Anchors.NonWordBoundary](./fluentregex.anchors.md#nonwordboundary).

```csharp
public AnchorBuilder NonWordBoundary()
```

#### Returns

[AnchorBuilder](./fluentregex.anchorbuilder.md)<br>

### **EndOfString()**

Sets the anchor to [Anchors.EndOfString](./fluentregex.anchors.md#endofstring).

```csharp
public AnchorBuilder EndOfString()
```

#### Returns

[AnchorBuilder](./fluentregex.anchorbuilder.md)<br>

### **EndOfStringNoLineBreak()**

Sets the anchor to [Anchors.EndOfStringNoLineBreak](./fluentregex.anchors.md#endofstringnolinebreak).

```csharp
public AnchorBuilder EndOfStringNoLineBreak()
```

#### Returns

[AnchorBuilder](./fluentregex.anchorbuilder.md)<br>

### **AppendLiteral(String)**

Appends a literal string to the pattern.

```csharp
public AnchorBuilder AppendLiteral(string literal)
```

#### Parameters

`literal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[AnchorBuilder](./fluentregex.anchorbuilder.md)<br>
This [AnchorBuilder](./fluentregex.anchorbuilder.md) instance.
