# FluentRegex

FluentRegex is a .NET library for building regular expressions in a readable and understandable way. It adopts the [Builder Pattern](https://en.wikipedia.org/wiki/Builder_pattern#:~:text=The%20builder%20pattern%20is%20a,Gang%20of%20Four%20design%20patterns.). This library is intended to make it easier to write and understand regular expressions, especially for those who are not familiar with them.

| Build Status | Test Status (main)|
|--------------| ------------------|
|[![Build Status](https://rableattler.visualstudio.com/PublicProjects/_apis/build/status%2Frbleattler.FluentRegex?repoName=rbleattler%2FFluentRegex&branchName=main)](https://rableattler.visualstudio.com/PublicProjects/_build/latest?definitionId=4&repoName=rbleattler%2FFluentRegex&branchName=main)|![Azure DevOps tests (branch)](https://img.shields.io/azure-devops/tests/rableattler/PublicProjects/4/main)|

## Table of Contents

- [About](#about)
- [Examples](#examples)
- [Usage](#usage)
- [Documentation](#documentation)
- [Feedback and Contributions](#feedback-and-contributions)

## About

I originally started working on this alone, and after getting through the first couple of iterations, I found some similar projects that seemed to be accomplishing a lot of what I had set out to do. This compelled me to fork from [Anders Åberg's](https://github.com/abergs) project, and eventually re-write the library completely. Given their impact on my work, I felt it would only be right to share links to their projects here:

- [abergs/RegExpBuilder](https://github.com/abergs/RegExpBuilder)
- [bcwood/FluentRegex](https://github.com/bcwood/FluentRegex)

## Examples

Here are some examples of how you can use FluentRegex:

### Example 1: Email Validation

> Note: This is _not_ the most efficient way to validate an email address. It is only an example of how to use FluentRegex.

```csharp

class Main
{

  public PatternBuilder builder = new PatternBuilder();
  public string output = "";
  Main()
  {
    output = builder.StartAnchor()
    .StartOfLine()
        .Build()
        .StartGroup()
    .StartGroup()
      .StartCharacterClass()
        .Word()
        .Build()
      .Or()
      .StartCharacterClass()
        .StartCustomPattern()
          .AppendLiteral("_")
          .AppendLiteral("-")
          .AppendLiteral(".")
          .AppendLiteral("+")
          .Build()
      .Build()
    .Build()
    .Times(1, -1)
    .AppendLiteral("@")
    .Times(1, 1)
    .StartGroup()
      .StartCharacterClass()
        .Word()
        .Build()
      .Or()
      .StartCharacterClass()
        .StartCustomPattern()
        .AppendLiteral("_")
        .AppendLiteral("-")
        .AppendLiteral(".")
        .Build()
      .Build()
    .Build()
    .Times(1, -1)
    .StartAnchor()
      .EndOfLine()
      .Build()
  .Build()
    .ToString();
    Console.WriteLine(output);
  }
}
// Output: ^((\w|[_\-.+])+@{1}(\w|[_\-.])+$)

```

### Example 2: Matching Specific Strings

Match either "github" or "bitbucket" (`^github|bitbucket$`):

```csharp
class Main
{
  public PatternBuilder builder = new PatternBuilder();
  public string output = "";
  Main()
  {
    output = builder.StartAnchor()
                        .StartOfLine()
                        .Build()
                    .StartGroup()
                        .AppendLiteral("github")
                        .Or()
                        .AppendLiteral("bitbucket")
                        .Build()
                    .StartAnchor()
                        .EndOfLine()
                        .Build()
                    .ToString();
    Console.WriteLine(output);
  }
}
```

## Usage

For more examples, refer to the tests in the `FluentRegex.Tests` project.

## Documentation

Additional documentation is available in the `docs` folder. See the [Index](docs/index.md) file for more information.

## Feedback and Contributions

Any feedback and contributions are appreciated. If you're not great at writing regex, your input can be especially valuable to us!
