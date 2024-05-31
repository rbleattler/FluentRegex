# IBuilder

Namespace: FluentRegex

Interface `IBuilder` defines the methods and properties for building a regular expression pattern.

```csharp
public interface IBuilder
```

## Properties

### **Pattern**

Gets or sets the pattern.

```csharp
public abstract StringBuilder Pattern { get; set; }
```

#### Property Value

[StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder)<br>

## Methods

### **Build()**

Builds the regular expression pattern.

```csharp
object Build()
```

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **ToString()**

Returns the regular expression pattern as a string.

```csharp
string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **AppendLiteral(String)**

The `AppendLiteral` method appends a literal string to the pattern, escaping any special characters.

```csharp
object AppendLiteral(string literal)
```

#### Parameters

`literal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **Validate()**

Validates the pattern to ensure it is well-formed. Each validation method contains explicit error messages which are thrown when the validation fails. This should help the user to understand what is wrong with the pattern, rather than just throwing a generic exception. However the final validation method checks that the pattern is a valid regular expression, and throws a generic exception if it is not, bubbling up the error message from the regular expression engine.

```csharp
void Validate()
```

### **Validate(Boolean)**

Validates the pattern to ensure it does not end with any characters that would cause an exception when building the regular expression. Allows the user to skip the regular expression validation.

```csharp
void Validate(bool skipRegexValidation)
```

#### Parameters

`skipRegexValidation` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
A [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) value to skip the regular expression validation.

### **ValidateEnd()**

Validates the pattern to ensure it does not end with any characters that would cause an exception when building the regular expression.

```csharp
void ValidateEnd()
```

### **ValidateStart()**

Validates the pattern to ensure it does not start with any characters that would cause an exception when building the regular expression.

```csharp
void ValidateStart()
```

#### Exceptions

[InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)<br>

### **ValidateParenthesesPairs()**

Validates the pattern to ensure that the number of opening and closing parentheses match.

```csharp
void ValidateParenthesesPairs()
```

#### Exceptions

[InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)<br>

### **ValidateNoEmptyStructures()**

Validates the pattern to ensure it does not contain empty structures. Including empty parentheses, empty non-capturing groups, and empty named capturing groups, empty Character classes.

```csharp
void ValidateNoEmptyStructures()
```

### **ValidateNoUnEscapedCharacters()**

Validates the pattern to ensure there are no unescaped characters that are not escapable.

```csharp
void ValidateNoUnEscapedCharacters()
```

### **GetOpenCloseCharacterCounts()**

```csharp
Dictionary<char, int> GetOpenCloseCharacterCounts()
```

#### Returns

[Dictionary&lt;Char, Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)<br>

### **GetCountOfCharacter(Char, String)**

```csharp
int GetCountOfCharacter(char character, string pattern)
```

#### Parameters

`character` [Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>

`pattern` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **OpenClosingCharacterCountsMatch(String)**

```csharp
bool OpenClosingCharacterCountsMatch(string pattern)
```

#### Parameters

`pattern` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **ParenthesesCountsAreEven()**

```csharp
bool ParenthesesCountsAreEven()
```

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **SquareBracketCountsAreEven()**

```csharp
bool SquareBracketCountsAreEven()
```

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **CurlyBraceCountsAreEven()**

```csharp
bool CurlyBraceCountsAreEven()
```

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **CheckInvalidEscapedClosure(String, Char[])**

```csharp
void CheckInvalidEscapedClosure(string pattern, Char[] closingCharacters)
```

#### Parameters

`pattern` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`closingCharacters` [Char[]](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>

### **ValidatePatternRegex()**

Validates the pattern to ensure it is a valid regular expression.

```csharp
void ValidatePatternRegex()
```
