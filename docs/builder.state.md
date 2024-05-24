# State

Namespace: Builder

```csharp
public class State : System.IEquatable`1[[Builder.State, RegExpBuilder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [State](./builder.state.md)<br>
Implements [IEquatable&lt;State&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)

## Properties

### **Some**

Gets or sets a value indicating whether the state represents "some" occurrence.

```csharp
public bool Some { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **ZeroOrOne**

Gets or sets a value indicating whether the state represents "zero or one" occurrence.

```csharp
public bool ZeroOrOne { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **MinimumOf**

Gets or sets the minimum number of occurrences for the state.

```csharp
public int MinimumOf { get; private set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **MaximumOf**

Gets or sets the maximum number of occurrences for the state.

```csharp
public int MaximumOf { get; private set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Options**

Gets or sets the regular expression options for the state.

```csharp
public RegexOptions Options { get; private set; }
```

#### Property Value

RegexOptions<br>

### **Or**

Gets or sets a value indicating whether the state represents an "or" condition.

```csharp
public bool Or { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **MultiLine**

Gets or sets a value indicating whether the state represents a multi-line condition.

```csharp
public bool MultiLine { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Constructors

### **State(Boolean, Boolean, Int32, Int32, RegexOptions, Boolean, Boolean)**

```csharp
public State(bool Some, bool ZeroOrOne, int MinimumOf, int MaximumOf, RegexOptions Options, bool Or, bool MultiLine)
```

#### Parameters

`Some` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

`ZeroOrOne` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

`MinimumOf` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`MaximumOf` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`Options` RegexOptions<br>

`Or` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

`MultiLine` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **State()**

```csharp
public State()
```

## Methods

### **SetSome(Boolean)**

Sets the value indicating whether the state represents "some" occurrence.

```csharp
public void SetSome(bool value)
```

#### Parameters

`value` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
The value indicating whether the state represents "some" occurrence.

### **SetZeroOrOne(Boolean)**

Sets the value indicating whether the state represents "zero or one" occurrence.

```csharp
public void SetZeroOrOne(bool value)
```

#### Parameters

`value` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
The value indicating whether the state represents "zero or one" occurrence.

### **SetMinimumOf(Int32)**

Sets the minimum number of occurrences for the state.

```csharp
public void SetMinimumOf(int value)
```

#### Parameters

`value` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The minimum number of occurrences for the state.

### **SetMaximumOf(Int32)**

Sets the maximum number of occurrences for the state.

```csharp
public void SetMaximumOf(int value)
```

#### Parameters

`value` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The maximum number of occurrences for the state.

### **SetOptions(RegexOptions)**

Sets the regular expression options for the state.

```csharp
public void SetOptions(RegexOptions options)
```

#### Parameters

`options` RegexOptions<br>
The regular expression options for the state.

### **SetOr(Boolean)**

Sets the value indicating whether the state represents an "or" condition.

```csharp
public void SetOr(bool value)
```

#### Parameters

`value` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
The value indicating whether the state represents an "or" condition.

### **SetMultiLine(Boolean)**

Sets the value indicating whether the state represents a multi-line condition.

```csharp
public void SetMultiLine(bool value)
```

#### Parameters

`value` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
The value indicating whether the state represents a multi-line condition.

### **Reset()**

Resets the state to its default values.

```csharp
public void Reset()
```

### **ToString()**

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PrintMembers(StringBuilder)**

```csharp
protected bool PrintMembers(StringBuilder builder)
```

#### Parameters

`builder` [StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **GetHashCode()**

```csharp
public int GetHashCode()
```

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Equals(Object)**

```csharp
public bool Equals(object obj)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Equals(State)**

```csharp
public bool Equals(State other)
```

#### Parameters

`other` [State](./builder.state.md)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **&lt;Clone&gt;$()**

```csharp
public State <Clone>$()
```

#### Returns

[State](./builder.state.md)<br>

### **Deconstruct(Boolean&, Boolean&, Int32&, Int32&, RegexOptions&, Boolean&, Boolean&)**

```csharp
public void Deconstruct(Boolean& Some, Boolean& ZeroOrOne, Int32& MinimumOf, Int32& MaximumOf, RegexOptions& Options, Boolean& Or, Boolean& MultiLine)
```

#### Parameters

`Some` [Boolean&](https://docs.microsoft.com/en-us/dotnet/api/system.boolean&)<br>

`ZeroOrOne` [Boolean&](https://docs.microsoft.com/en-us/dotnet/api/system.boolean&)<br>

`MinimumOf` [Int32&](https://docs.microsoft.com/en-us/dotnet/api/system.int32&)<br>

`MaximumOf` [Int32&](https://docs.microsoft.com/en-us/dotnet/api/system.int32&)<br>

`Options` RegexOptions&<br>

`Or` [Boolean&](https://docs.microsoft.com/en-us/dotnet/api/system.boolean&)<br>

`MultiLine` [Boolean&](https://docs.microsoft.com/en-us/dotnet/api/system.boolean&)<br>
