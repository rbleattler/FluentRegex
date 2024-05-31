# Builder

Namespace: FluentRegex

The `Builder` class is the base class for all builders in the FluentRegex library. It contains methods for building regular expression patterns, and for validating the pattern to ensure it is well-formed.

```csharp
public abstract class Builder : IBuilder
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Builder](./fluentregex.builder.md)<br>
Implements [IBuilder](./fluentregex.ibuilder.md)

**Remarks:**

The use of @dynamic as the return type for the methods in this class allows the methods to be called from any of the derived classes without needing to cast the return value or override the method in each class.

## Properties

### **Pattern**

```csharp
public abstract StringBuilder Pattern { get; set; }
```

#### Property Value

[StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder)<br>

## Methods

### **StartAnchor()**

Adds an anchor to the pattern.

```csharp
public abstract AnchorBuilder StartAnchor()
```

#### Returns

[AnchorBuilder](./fluentregex.anchorbuilder.md)<br>

### **StartCharacterClass()**

Adds a character class to the pattern.

```csharp
public abstract CharacterClassBuilder StartCharacterClass()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **Build()**

Builds the regular expression pattern.

```csharp
public abstract object Build()
```

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **ToString()**

The `ToString` method returns the current value of the pattern as a string.

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Times(Int32, Int32)**

The `Times` method appends a quantifier to the pattern. The method can take two parameters,  and .
 If both parameters are -1, the method appends an empty string. If  is 0 and  is -1, the method appends an asterisk.
 If  is 1 and  is -1, the method appends a plus.
 If  is 0 and  is 1, the method appends a question mark.
 If  is equal to , the method appends the minimum value in curly braces.
 If  is -1 and  is not -1, the method appends the maximum value in curly braces.
 If  is -1 and  is not -1, the method appends the minimum value in curly braces.
 If both  and  are not -1, the method appends the minimum and maximum values in curly braces.

```csharp
public object Times(int minimum, int maximum)
```

#### Parameters

`minimum` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`maximum` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **Lazy()**

The `Lazy` method appends a lazy quantifier (`?`) to the pattern.

```csharp
public object Lazy()
```

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **OneOrMore()**

The `OneOrMore` method appends a one or more quantifier (`+`) to the pattern.

```csharp
public object OneOrMore()
```

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **ZeroOrMore()**

The `ZeroOrMore` method appends a zero or more quantifier (`*`) to the pattern.

```csharp
public object ZeroOrMore()
```

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **ZeroOrOne()**

The `ZeroOrOne` method appends a zero or one quantifier (`?`) to the pattern. The zero or one quantifier is equivalent to the regular expression `{0,1}`, and shares a character with the lazy quantifier.

```csharp
public object ZeroOrOne()
```

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **Or()**

The `Or` method appends an alternation operator (`|`) to the pattern.

```csharp
public object Or()
```

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **StartGroup()**

Adds a [GroupBuilder](./fluentregex.groupbuilder.md) to the pattern.

```csharp
public GroupBuilder StartGroup()
```

#### Returns

[GroupBuilder](./fluentregex.groupbuilder.md)<br>
[GroupBuilder](./fluentregex.groupbuilder.md)

### **CaptureGroup()**

Adds a [GroupBuilder](./fluentregex.groupbuilder.md) to the pattern.

```csharp
public GroupBuilder CaptureGroup()
```

#### Returns

[GroupBuilder](./fluentregex.groupbuilder.md)<br>
[GroupBuilder](./fluentregex.groupbuilder.md)

### **NonCaptureGroup()**

Adds a [GroupBuilder](./fluentregex.groupbuilder.md) to the pattern.

```csharp
public GroupBuilder NonCaptureGroup()
```

#### Returns

[GroupBuilder](./fluentregex.groupbuilder.md)<br>

### **NamedCaptureGroup(NamedGroupStyle, String)**

Adds a [GroupBuilder](./fluentregex.groupbuilder.md) to the pattern.

```csharp
public GroupBuilder NamedCaptureGroup(NamedGroupStyle namedGroupStyle, string groupName)
```

#### Parameters

`namedGroupStyle` [NamedGroupStyle](./fluentregex.namedgroupstyle.md)<br>

`groupName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[GroupBuilder](./fluentregex.groupbuilder.md)<br>

### **Validate(Boolean)**

Validates the pattern to ensure it does not end with any characters that would cause an exception when building the regular expression. Allows the user to skip the regular expression validation.

```csharp
public void Validate(bool skipRegexValidation)
```

#### Parameters

`skipRegexValidation` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
A [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) value to skip the regular expression validation.

### **Validate()**

```csharp
public void Validate()
```
