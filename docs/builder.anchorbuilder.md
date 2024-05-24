# AnchorBuilder

Namespace: Builder

Represents a builder for creating regular expression patterns with anchor constraints.

```csharp
public class AnchorBuilder : Builder
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Builder](./builder.builder.md) → [AnchorBuilder](./builder.anchorbuilder.md)

## Constructors

### **AnchorBuilder(Builder)**

Initializes a new instance of the [AnchorBuilder](./builder.anchorbuilder.md) class with the specified [Builder](./builder.builder.md).

```csharp
public AnchorBuilder(Builder Builder)
```

#### Parameters

`Builder` [Builder](./builder.builder.md)<br>
The [Builder](./builder.builder.md) to associate with this [AnchorBuilder](./builder.anchorbuilder.md).

### **AnchorBuilder()**

Initializes a new instance of the [AnchorBuilder](./builder.anchorbuilder.md) class with a new [Builder](./builder.builder.md).

```csharp
public AnchorBuilder()
```

## Methods

### **StartsWith(String, Nullable&lt;Boolean&gt;)**

Specifies that the pattern should start with the specified string.

```csharp
public AnchorBuilder StartsWith(string startsWith, Nullable<bool> nonMultiLine)
```

#### Parameters

`startsWith` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string that the pattern should start with.

`nonMultiLine` [Nullable&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
Indicates whether the pattern should match only at the start of the input, regardless of multi-line mode.

#### Returns

[AnchorBuilder](./builder.anchorbuilder.md)<br>
The current [AnchorBuilder](./builder.anchorbuilder.md) instance.

### **EndsWith(String, Nullable&lt;Boolean&gt;)**

Specifies that the pattern should end with the specified string.

```csharp
public AnchorBuilder EndsWith(string endsWith, Nullable<bool> nonMultiLine)
```

#### Parameters

`endsWith` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string that the pattern should end with.

`nonMultiLine` [Nullable&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
Indicates whether the pattern should match only at the end of the input, regardless of multi-line mode.

#### Returns

[AnchorBuilder](./builder.anchorbuilder.md)<br>
The current [AnchorBuilder](./builder.anchorbuilder.md) instance.

### **AbsoluteEndsWith(String)**

Specifies that the pattern should end with the specified string, without allowing a line terminator at the end.

```csharp
public AnchorBuilder AbsoluteEndsWith(string endsWith)
```

#### Parameters

`endsWith` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string that the pattern should end with.

#### Returns

[AnchorBuilder](./builder.anchorbuilder.md)<br>
The current [AnchorBuilder](./builder.anchorbuilder.md) instance.

### **WordBoundary()**

Specifies a word boundary in the pattern.

```csharp
public AnchorBuilder WordBoundary()
```

#### Returns

[AnchorBuilder](./builder.anchorbuilder.md)<br>
The current [AnchorBuilder](./builder.anchorbuilder.md) instance.

### **NonWordBoundary()**

Specifies a non-word boundary in the pattern.

```csharp
public AnchorBuilder NonWordBoundary()
```

#### Returns

[AnchorBuilder](./builder.anchorbuilder.md)<br>
The current [AnchorBuilder](./builder.anchorbuilder.md) instance.

### **ToString()**

Returns the regular expression pattern represented by this [AnchorBuilder](./builder.anchorbuilder.md).

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The regular expression pattern.
