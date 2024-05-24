# Builder

Namespace: Builder

```csharp
public abstract class Builder
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Builder](./builder.builder.md)

## Constructors

### **Builder()**

```csharp
public Builder()
```

## Methods

### **AddGroup()**

Initializes a new instance of the [GroupBuilder](./builder.groupbuilder.md) class with the specified [Builder](./builder.builder.md) and expression.

```csharp
public GroupBuilder AddGroup()
```

#### Returns

[GroupBuilder](./builder.groupbuilder.md)<br>

### **AddAnchor()**

Initializes a new instance of the [AnchorBuilder](./builder.anchorbuilder.md) class with the specified [Builder](./builder.builder.md) and expression.

```csharp
public AnchorBuilder AddAnchor()
```

#### Returns

[AnchorBuilder](./builder.anchorbuilder.md)<br>

### **StripParenthesis(String)**

Removes the parenthesis from a string.

```csharp
public string StripParenthesis(string literal)
```

#### Parameters

`literal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string literal.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string without parenthesis.

### **AddParenthesis(String)**

Adds parenthesis to a string.

```csharp
public string AddParenthesis(string literal)
```

#### Parameters

`literal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string literal.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string with added parenthesis.

### **ToString()**

Returns the regular expression pattern represented by this [Builder](./builder.builder.md).

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The regular expression pattern.

### **Build()**

Builds the regular expression pattern.

```csharp
public string Build()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The regular expression pattern.

### **AsNamedCaptureGroup(String, NamedGroupStyle)**

Takes the current expression and wraps it in a named capture group of the specified style.

```csharp
public Builder AsNamedCaptureGroup(string name, NamedGroupStyle style)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of group.

`style` [NamedGroupStyle](./builder.namedgroupstyle.md)<br>
The type of group.

#### Returns

[Builder](./builder.builder.md)<br>
The current [Builder](./builder.builder.md) instance with the updated expression.

### **AsNonCaptureGroup()**

Takes the current expression and wraps it in a non-capturing group.

```csharp
public Builder AsNonCaptureGroup()
```

#### Returns

[Builder](./builder.builder.md)<br>
The current [Builder](./builder.builder.md) instance with the updated expression.

**Remarks:**

Non-capturing groups are used to group subexpressions without capturing the matched text.

### **AsCaptureGroup()**

Takes the current expression and wraps it in an unnamed capture group.

```csharp
public Builder AsCaptureGroup()
```

#### Returns

[Builder](./builder.builder.md)<br>
The current [Builder](./builder.builder.md) instance with the updated expression.

**Remarks:**

Unnamed capture groups are used to group subexpressions and capture the matched text.

### **ToRegExp()**

Converts the regular expression to a  object.

```csharp
public Regex ToRegExp()
```

#### Returns

Regex<br>
The regular expression as a  object.

### **StartOfInput()**

Adds a start of input anchor to the regular expression.

```csharp
public Builder StartOfInput()
```

#### Returns

[Builder](./builder.builder.md)<br>
The [Builder](./builder.builder.md) instance.

### **EndOfInput()**

Adds an end of input anchor to the regular expression.

```csharp
public Builder EndOfInput()
```

#### Returns

[Builder](./builder.builder.md)<br>
The [Builder](./builder.builder.md) instance.

### **StartOfLine()**

Adds a start of line anchor to the regular expression.

```csharp
public Builder StartOfLine()
```

#### Returns

[Builder](./builder.builder.md)<br>
The [Builder](./builder.builder.md) instance.

### **EndOfLine()**

Adds an end of line anchor to the regular expression.

```csharp
public Builder EndOfLine()
```

#### Returns

[Builder](./builder.builder.md)<br>
The [Builder](./builder.builder.md) instance.

### **OneOrMore()**

Sets the state to match one or more of the next character.

```csharp
public Builder OneOrMore()
```

#### Returns

[Builder](./builder.builder.md)<br>
The [Builder](./builder.builder.md) instance.

### **Digit()**

Adds a digit character class to the regular expression.

```csharp
public Builder Digit()
```

#### Returns

[Builder](./builder.builder.md)<br>
The [Builder](./builder.builder.md) instance.

### **Digits()**

Adds a digit character class with a plus quantifier to the regular expression.

```csharp
public Builder Digits()
```

#### Returns

[Builder](./builder.builder.md)<br>
The [Builder](./builder.builder.md) instance.

### **ZeroOrOne()**

Sets the state to match zero or one of the next character.

```csharp
public Builder ZeroOrOne()
```

#### Returns

[Builder](./builder.builder.md)<br>
The [Builder](./builder.builder.md) instance.

### **Letter()**

Adds a letter character class to the regular expression.

```csharp
public Builder Letter()
```

#### Returns

[Builder](./builder.builder.md)<br>
The [Builder](./builder.builder.md) instance.

### **Letters()**

Adds a letter character class with a plus quantifier to the regular expression.

```csharp
public Builder Letters()
```

#### Returns

[Builder](./builder.builder.md)<br>
The [Builder](./builder.builder.md) instance.

### **MinimumOf(Int32)**

Sets the state to match a minimum number of the next character.

```csharp
public Builder MinimumOf(int minimumOccurrence)
```

#### Parameters

`minimumOccurrence` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The minimum number of occurrences.

#### Returns

[Builder](./builder.builder.md)<br>
The [Builder](./builder.builder.md) instance.

### **Or()**

Sets the state to match an alternative pattern.

```csharp
public Builder Or()
```

#### Returns

[Builder](./builder.builder.md)<br>
The [Builder](./builder.builder.md) instance.

### **AddFilters(String)**

Adds filters to a string.

```csharp
internal string AddFilters(string literal)
```

#### Parameters

`literal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string literal.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string with added filters.

### **GetQuantityLiteral()**

Gets the quantity literal for the state.

```csharp
internal string GetQuantityLiteral()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The quantity literal.

### **MaximumOf(Int32)**

Sets the state to match a maximum number of the next character.

```csharp
public Builder MaximumOf(int maximumOccurrences)
```

#### Parameters

`maximumOccurrences` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The maximum number of occurrences.

#### Returns

[Builder](./builder.builder.md)<br>
The [Builder](./builder.builder.md) instance.

### **Exactly(Int32)**

Sets the state to match exactly a number of the next character.

```csharp
public Builder Exactly(int occurrences)
```

#### Parameters

`occurrences` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The number of occurrences.

#### Returns

[Builder](./builder.builder.md)<br>
The [Builder](./builder.builder.md) instance.

### **Add(Object)**

Adds a target object to the regular expression.

```csharp
public Builder Add(object target)
```

#### Parameters

`target` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The target object to add. Strings are added as literals.

#### Returns

[Builder](./builder.builder.md)<br>
The [Builder](./builder.builder.md) instance.

#### Exceptions

[ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception)<br>
Thrown when the target cannot be added to the regular expression.

### **AddFrom(String)**

Adds from a character class to the regular expression.

```csharp
public Builder AddFrom(string characterClass)
```

#### Parameters

`characterClass` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The character class to add.

#### Returns

[Builder](./builder.builder.md)<br>
The [Builder](./builder.builder.md) instance.

### **HandleState(Nullable&lt;Boolean&gt;)**

Handles state changes for the regular expression.

```csharp
public void HandleState(Nullable<bool> resetState)
```

#### Parameters

`resetState` [Nullable&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **Reset()**

Resets the regular expression builder.

```csharp
public void Reset()
```
