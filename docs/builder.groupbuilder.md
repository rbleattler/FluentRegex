# GroupBuilder

Namespace: Builder

Represents a builder for creating groups in a regular expression.

```csharp
public class GroupBuilder : Builder
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Builder](./builder.builder.md) → [GroupBuilder](./builder.groupbuilder.md)

## Constructors

### **GroupBuilder()**

Initializes a new instance of the [GroupBuilder](./builder.groupbuilder.md) class with a new [Builder](./builder.builder.md).

```csharp
public GroupBuilder()
```

### **GroupBuilder(Builder, String)**

Initializes a new instance of the [GroupBuilder](./builder.groupbuilder.md) class.

```csharp
public GroupBuilder(Builder Builder, string expression)
```

#### Parameters

`Builder` [Builder](./builder.builder.md)<br>
The parent [Builder](./builder.builder.md) instance.

`expression` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The current regular expression expression.

## Methods

### **CaptureGroup(String)**

Adds a capturing group to the regular expression pattern.

```csharp
public Builder CaptureGroup(string pattern)
```

#### Parameters

`pattern` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The pattern to capture.

#### Returns

[Builder](./builder.builder.md)<br>
A new [GroupBuilder](./builder.groupbuilder.md) instance with the updated expression.

### **CaptureGroup()**

```csharp
public Builder CaptureGroup()
```

#### Returns

[Builder](./builder.builder.md)<br>

### **NonCaptureGroup(String)**

Adds a non-capturing group to the regular expression pattern.

```csharp
public GroupBuilder NonCaptureGroup(string pattern)
```

#### Parameters

`pattern` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The pattern to include in the group.

#### Returns

[GroupBuilder](./builder.groupbuilder.md)<br>
A new [GroupBuilder](./builder.groupbuilder.md) instance with the updated expression.

### **NamedCaptureGroup(String, String, NamedGroupStyle)**

Adds a named capturing group to the regular expression pattern.

```csharp
public GroupBuilder NamedCaptureGroup(string name, string pattern, NamedGroupStyle style)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the group.

`pattern` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The pattern to capture.

`style` [NamedGroupStyle](./builder.namedgroupstyle.md)<br>
The style of the named group.

#### Returns

[GroupBuilder](./builder.groupbuilder.md)<br>
A new [GroupBuilder](./builder.groupbuilder.md) instance with the updated expression.

### **NamedCaptureGroup(String, String, String)**

Adds a named capturing group to the regular expression pattern.

```csharp
public GroupBuilder NamedCaptureGroup(string name, string pattern, string style)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the group.

`pattern` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The pattern to capture.

`style` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The style of the named group as a string.

#### Returns

[GroupBuilder](./builder.groupbuilder.md)<br>
A new [GroupBuilder](./builder.groupbuilder.md) instance with the updated expression.

### **AtomicGroup(String)**

Adds an atomic group to the regular expression pattern.

```csharp
public GroupBuilder AtomicGroup(string pattern)
```

#### Parameters

`pattern` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[GroupBuilder](./builder.groupbuilder.md)<br>
The current [GroupBuilder](./builder.groupbuilder.md) instance.

### **SubpatternGroupNumberReset(String)**

Adds a subpattern group number reset to the regular expression pattern.

```csharp
public GroupBuilder SubpatternGroupNumberReset(string pattern)
```

#### Parameters

`pattern` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The pattern to include in the group.

#### Returns

[GroupBuilder](./builder.groupbuilder.md)<br>
The current [GroupBuilder](./builder.groupbuilder.md) instance.

### **CommentGroup(String)**

Adds a comment group to the regular expression pattern.

```csharp
public GroupBuilder CommentGroup(string comment)
```

#### Parameters

`comment` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The comment to include in the group.

#### Returns

[GroupBuilder](./builder.groupbuilder.md)<br>
The current [GroupBuilder](./builder.groupbuilder.md) instance.

### **InlineModifiers(String)**

Adds inline modifiers to the regular expression pattern.

```csharp
public GroupBuilder InlineModifiers(string modifiers)
```

#### Parameters

`modifiers` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The modifiers to include.

#### Returns

[GroupBuilder](./builder.groupbuilder.md)<br>
The current [GroupBuilder](./builder.groupbuilder.md) instance.

### **LocalizedInlineModifiers(String, String)**

Adds localized inline modifiers to the regular expression pattern.

```csharp
public GroupBuilder LocalizedInlineModifiers(string modifiers, string pattern)
```

#### Parameters

`modifiers` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The modifiers to include.

`pattern` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The pattern to apply the modifiers to.

#### Returns

[GroupBuilder](./builder.groupbuilder.md)<br>
The current [GroupBuilder](./builder.groupbuilder.md) instance.

### **ConditionalStatementNumber(String, String, String)**

Adds a conditional statement to the regular expression pattern.

```csharp
public GroupBuilder ConditionalStatementNumber(string number, string yesPattern, string noPattern)
```

#### Parameters

`number` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The number to evaluate the condition against.

`yesPattern` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The pattern to match if the condition is true.

`noPattern` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The pattern to match if the condition is false.

#### Returns

[GroupBuilder](./builder.groupbuilder.md)<br>
The current [GroupBuilder](./builder.groupbuilder.md) instance.
