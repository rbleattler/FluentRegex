# GroupBuilder

Namespace: FluentRegex

Class `GroupBuilder` builds groups for a regular expression pattern. Inherits from [Builder](./fluentregex.builder.md).

```csharp
public class GroupBuilder : Builder, IBuilder
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Builder](./fluentregex.builder.md) → [GroupBuilder](./fluentregex.groupbuilder.md)<br>
Implements [IBuilder](./fluentregex.ibuilder.md)

## Properties

### **Pattern**

Gets or sets the pattern.

```csharp
public StringBuilder Pattern { get; set; }
```

#### Property Value

[StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder)<br>

### **GroupName**

The name of the named capture group when [GroupBuilder.GroupType](./fluentregex.groupbuilder.md#grouptype) is [GroupType.NamedCapturing](./fluentregex.grouptype.md#namedcapturing).

```csharp
public string GroupName { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **GroupType**

The [GroupType](./fluentregex.grouptype.md) of the group.

```csharp
public GroupType GroupType { get; }
```

#### Property Value

[GroupType](./fluentregex.grouptype.md)<br>

### **GroupStyle**

The [NamedGroupStyle](./fluentregex.namedgroupstyle.md) of the group.

```csharp
public Nullable<NamedGroupStyle> GroupStyle { get; }
```

#### Property Value

[Nullable&lt;NamedGroupStyle&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

## Constructors

### **GroupBuilder(Builder, NamedGroupStyle, String)**

Initializes a new instance of the [GroupBuilder](./fluentregex.groupbuilder.md) class with a [PatternBuilder](./fluentregex.patternbuilder.md), and the declared [NamedGroupStyle](./fluentregex.namedgroupstyle.md) and [GroupBuilder.GroupName](./fluentregex.groupbuilder.md#groupname).

```csharp
public GroupBuilder(Builder patternBuilder, NamedGroupStyle namedGroupStyle, string groupName)
```

#### Parameters

`patternBuilder` [Builder](./fluentregex.builder.md)<br>

`namedGroupStyle` [NamedGroupStyle](./fluentregex.namedgroupstyle.md)<br>

`groupName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **GroupBuilder(Builder, GroupType)**

Initializes a new instance of the [GroupBuilder](./fluentregex.groupbuilder.md) class with a [PatternBuilder](./fluentregex.patternbuilder.md), and the declared [GroupBuilder.GroupType](./fluentregex.groupbuilder.md#grouptype).

```csharp
public GroupBuilder(Builder patternBuilder, GroupType groupType)
```

#### Parameters

`patternBuilder` [Builder](./fluentregex.builder.md)<br>

`groupType` [GroupType](./fluentregex.grouptype.md)<br>

### **GroupBuilder(Builder)**

Initializes a new instance of the [GroupBuilder](./fluentregex.groupbuilder.md) class with a [PatternBuilder](./fluentregex.patternbuilder.md).

```csharp
public GroupBuilder(Builder patternBuilder)
```

#### Parameters

`patternBuilder` [Builder](./fluentregex.builder.md)<br>

## Methods

### **Build()**

Builds the group.

```csharp
public object Build()
```

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The [PatternBuilder](./fluentregex.patternbuilder.md).

### **StartCharacterClass()**

Initializes a new instance of the [CharacterClassBuilder](./fluentregex.characterclassbuilder.md) class which is used to build a character class inline.

```csharp
public CharacterClassBuilder StartCharacterClass()
```

#### Returns

[CharacterClassBuilder](./fluentregex.characterclassbuilder.md)<br>

### **Start_Group()**

Starts building the group by adding an opening parenthesis to the pattern. Depending on the [GroupBuilder.GroupType](./fluentregex.groupbuilder.md#grouptype), the method will add the appropriate syntax to the pattern.

```csharp
internal GroupBuilder Start_Group()
```

#### Returns

[GroupBuilder](./fluentregex.groupbuilder.md)<br>
A new instance of the [GroupBuilder](./fluentregex.groupbuilder.md) class.

### **StartAnchor()**

Initializes a new instance of the [AnchorBuilder](./fluentregex.anchorbuilder.md) class which is used to build an anchor inline.

```csharp
public AnchorBuilder StartAnchor()
```

#### Returns

[AnchorBuilder](./fluentregex.anchorbuilder.md)<br>
A new instance of the [AnchorBuilder](./fluentregex.anchorbuilder.md) class.

### **AppendLiteral(String)**

The `AppendLiteral` method appends a string to the pattern. This hides the [IBuilder.AppendLiteral(String)](./fluentregex.ibuilder.md#appendliteralstring) method from the base class.

```csharp
public GroupBuilder AppendLiteral(string literal)
```

#### Parameters

`literal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[GroupBuilder](./fluentregex.groupbuilder.md)<br>
[GroupBuilder](./fluentregex.groupbuilder.md)

### **EndGroup()**

```csharp
internal GroupBuilder EndGroup()
```

#### Returns

[GroupBuilder](./fluentregex.groupbuilder.md)<br>

### **Validate()**

```csharp
internal void Validate()
```
