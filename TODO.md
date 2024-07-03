# TODO

## Library

- [ ] Basic `Tokens` class that allows for building any type of token (CharacterClass, Anchor, MetaCharacter, etc.) and then converting it to a string, abstracting away the need to know the specific type of token being built.
- [ ] Add doc generation to CI
- [ ] Explore use of `Validate` on `Build()` in [AnchorBuilder](src\FluentRegex\Classes\AnchorBuilder.cs#L40)
- [ ] Update names of `EndOfString` and `EndOfStringNoLineBreak` to better clarify their use cases
  - [Anchors | EndOfString](src\FluentRegex\Classes\Anchors.cs#L41)
  - [Anchors | EndOfStringNoLineBreak](src\FluentRegex\Classes\Anchors.cs#L47)
- [ ] In [Builder | Build](src\FluentRegex\Classes\Builder.cs#L81), the `Times()` Method doesn't _seem_ to always return the type of the builder that called it. This should be tested and fixed if necessary. It may just be a leftover comment for an issue fixed in a previous commit.
- [ ] In [Builder | Validate](src\FluentRegex\Classes\Builder.cs#L225), a new method should be implemented to validate `PType` groups by converting them to `AngleBracket` groups prior to the validation flow. Since the only difference between the two is the `PType` group's use of `P<>` instead of `<>`, this should be a simple addition which will allow for this style to be supported despite dotnet's lack of support for it.
- [ ] In [CharacterClassBuilder](src\FluentRegex\Classes\CharacterClassBuilder.cs#26) Remove the PatternBuilder and GroupBuilder constructors or find a better way to accomplish the intended outcome with dynamic types.
- [ ] In [GroupBuilder](src\FluentRegex\Classes\GroupBuilder.cs#153) Add support for the following group types:
  - [ ] Positive Lookahead
  - [ ] Negative Lookahead
  - [ ] Positive Lookbehind
  - [ ] Negative Lookbehind

## Tests

- [ ] In [PatternBuilder.Tests.cs | TestStartAnchor](src/FluentRegex.Tests/PatternBuilder.Tests.cs#L68), update the test to a Theory using ClassData to iterate over multiple cases rather than shoe-horning multiple tests into one.
