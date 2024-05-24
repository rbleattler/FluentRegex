# RegExpBuilder

RegExpBuilder is a .NET library for building regular expressions in a readable and understandable way. It's not yet available as a NuGet package as we're still adding more features.

## Table of Contents

- [What is RegExpBuilder?](#what-is-regexpbuilder)
- [Examples](#examples)
- [Usage](#usage)
- [Documentation](#documentation)
- [Feedback and Contributions](#feedback-and-contributions)

## What is RegExpBuilder?

RegExpBuilder is a library that provides a LINQ-style approach to building regular expressions in .NET. For more information, check out this related blog post: [I don't know Regex](http://ideasof.andersaberg.com/idea/17/i-dont-know-regex).

## Examples

Here are some examples of how you can use RegExpBuilder:

### Example 1: Email Validation

```csharp
var builder = new Builder.RegExpBuilder();
var r = builder
    .StartOfInput()
    .Letter() // Must start with letter a-z
    .Letters() // any number of letters
    .Or()
    .Digits() // any number of numbers
    .Exactly(1).Of("@")
    .Letters() // domain
    .Exactly(1).Of(".")
    .Letters() // top-level domain
    .EndOfInput()
    .ToRegExp();

```
<!-- TODO: Add output -->

### Example 2: Matching Specific Strings

Match either "github" or "bitbucket" (`^github|bitbucket$`):

```csharp
var builder = new Builder.RegExpBuilder();
var r = builder
    .StartOfInput()
    .Exactly(1).Of("github")
    .Or()
    .Exactly(1).Of("bitbucket")
    .EndOfInput()
    .ToRegExp();
```

### Example 3: Finding a Single Digit

Match a single digit (`\d`):

```csharp
var builder = new Builder.RegExpBuilder();
var r = builder
    .Digit()
    .ToRegExp();
```

### Example 4: Matching Exact String Repetitions

Match "a" repeated exactly 3 times (`a{3}`):

```csharp
var builder = new Builder.RegExpBuilder();
var r = builder
    .Exactly(3)
    .Of("a")
    .ToRegExp();
```

## Usage

For more examples, refer to the tests in the `RegExpBuilder.Tests` project.

## Documentation

Additional documentation is available in the `docs` folder. See the [Index](docs/Index.md) file for more information.

## Feedback and Contributions

Any feedback and contributions are appreciated. If you're not great at writing regex, your input can be especially valuable to us!
