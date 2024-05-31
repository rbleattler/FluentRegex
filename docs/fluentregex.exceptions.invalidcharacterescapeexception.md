# InvalidCharacterEscapeException

Namespace: FluentRegex.Exceptions

A custom exception thrown when an invalid character escape sequence is detected.

```csharp
public class InvalidCharacterEscapeException : System.Exception, System.Runtime.Serialization.ISerializable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception) → [InvalidCharacterEscapeException](./fluentregex.exceptions.invalidcharacterescapeexception.md)<br>
Implements [ISerializable](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.iserializable)

**Remarks:**

Initializes a new instance of the [InvalidCharacterEscapeException](./fluentregex.exceptions.invalidcharacterescapeexception.md) class.

## Properties

### **TargetSite**

```csharp
public MethodBase TargetSite { get; }
```

#### Property Value

[MethodBase](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.methodbase)<br>

### **Message**

```csharp
public string Message { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Data**

```csharp
public IDictionary Data { get; }
```

#### Property Value

[IDictionary](https://docs.microsoft.com/en-us/dotnet/api/system.collections.idictionary)<br>

### **InnerException**

```csharp
public Exception InnerException { get; }
```

#### Property Value

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **HelpLink**

```csharp
public string HelpLink { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Source**

```csharp
public string Source { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **HResult**

```csharp
public int HResult { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **StackTrace**

```csharp
public string StackTrace { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **InvalidCharacterEscapeException(Char, String, Int32, String)**

A custom exception thrown when an invalid character escape sequence is detected.

```csharp
public InvalidCharacterEscapeException(char targetCharacter, string pattern, int indexOfCharacter, string escapeSequence)
```

#### Parameters

`targetCharacter` [Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>
The character that was attempted to be escaped.

`pattern` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The pattern that the character was found in.

`indexOfCharacter` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The index of the character in the pattern.

`escapeSequence` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The escape sequence that was used.

#### Exceptions

[InvalidCharacterEscapeException](./fluentregex.exceptions.invalidcharacterescapeexception.md)<br>
Thrown when an invalid character escape sequence is detected.

**Remarks:**

Initializes a new instance of the [InvalidCharacterEscapeException](./fluentregex.exceptions.invalidcharacterescapeexception.md) class.
