# RegExpBuilder

Namespace: Builder

A builder for creating regular expressions in a fluent manner.

```csharp
public class RegExpBuilder : Builder
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Builder](./builder.builder.md) → [RegExpBuilder](./builder.regexpbuilder.md)

## Constructors

### **RegExpBuilder()**

Initializes a new instance of the [RegExpBuilder](./builder.regexpbuilder.md) class.

```csharp
public RegExpBuilder()
```

## Methods

### **ToString()**

Converts the regular expression to a string.

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The regular expression as a string.

### **AddGroup(GroupBuilder)**

Adds a group builder to the regular expression.

```csharp
public RegExpBuilder AddGroup(GroupBuilder group)
```

#### Parameters

`group` [GroupBuilder](./builder.groupbuilder.md)<br>
The [GroupBuilder](./builder.groupbuilder.md) instance.

#### Returns

[RegExpBuilder](./builder.regexpbuilder.md)<br>
The [RegExpBuilder](./builder.regexpbuilder.md) instance.

### **AddGroup(Action&lt;GroupBuilder&gt;)**

Adds a group builder to the regular expression.

```csharp
public RegExpBuilder AddGroup(Action<GroupBuilder> config)
```

#### Parameters

`config` [Action&lt;GroupBuilder&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)<br>
The configuration action for the [GroupBuilder](./builder.groupbuilder.md).

#### Returns

[RegExpBuilder](./builder.regexpbuilder.md)<br>
The [RegExpBuilder](./builder.regexpbuilder.md) instance.

### **AddAnchor(AnchorBuilder)**

Adds an anchor builder to the regular expression.

```csharp
public RegExpBuilder AddAnchor(AnchorBuilder anchor)
```

#### Parameters

`anchor` [AnchorBuilder](./builder.anchorbuilder.md)<br>
The [AnchorBuilder](./builder.anchorbuilder.md) instance.

#### Returns

[RegExpBuilder](./builder.regexpbuilder.md)<br>
The [RegExpBuilder](./builder.regexpbuilder.md) instance.

### **AddAnchor(Action&lt;AnchorBuilder&gt;)**

Adds an anchor builder to the regular expression.

```csharp
public RegExpBuilder AddAnchor(Action<AnchorBuilder> config)
```

#### Parameters

`config` [Action&lt;AnchorBuilder&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)<br>
The configuration action for the [AnchorBuilder](./builder.anchorbuilder.md).

#### Returns

[RegExpBuilder](./builder.regexpbuilder.md)<br>
The [RegExpBuilder](./builder.regexpbuilder.md) instance.

### **Add(String)**

Adds a string to the regular expression.

```csharp
internal RegExpBuilder Add(string literal)
```

#### Parameters

`literal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string to add.

#### Returns

[RegExpBuilder](./builder.regexpbuilder.md)<br>

### **Add(String, Boolean)**

```csharp
internal RegExpBuilder Add(string literal, bool withParenthesis)
```

#### Parameters

`literal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`withParenthesis` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

#### Returns

[RegExpBuilder](./builder.regexpbuilder.md)<br>

### **Of(String)**

Adds a string to match to the regular expression.

```csharp
public RegExpBuilder Of(string stringToMatch)
```

#### Parameters

`stringToMatch` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string to match.

#### Returns

[RegExpBuilder](./builder.regexpbuilder.md)<br>
The [Builder](./builder.builder.md) instance.

### **OrLike(Regex)**

Adds an alternative pattern to the regular expression.

```csharp
public RegExpBuilder OrLike(Regex regExpression)
```

#### Parameters

`regExpression` Regex<br>
The alternative regular expression.

#### Returns

[RegExpBuilder](./builder.regexpbuilder.md)<br>
The [Builder](./builder.builder.md) instance.

### **OrLike(Regex, Boolean, Boolean)**

Adds an alternative pattern to the regular expression.

```csharp
public RegExpBuilder OrLike(Regex regExpression, bool stripParenthesis, bool surroundWithParenthesis)
```

#### Parameters

`regExpression` Regex<br>
The alternative regular expression.

`stripParenthesis` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Whether to strip the parenthesis.

`surroundWithParenthesis` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Whether to surround with parenthesis.

#### Returns

[RegExpBuilder](./builder.regexpbuilder.md)<br>

### **Clear()**

clear current expression

```csharp
public void Clear()
```

### **AddCurrentExpression()**

add current expression to the list of expressions

```csharp
public void AddCurrentExpression()
```

### **ToRegex()**

Converts the regular expression to a  instance.

```csharp
public Regex ToRegex()
```

#### Returns

Regex<br>
The regular expression as a  instance.
