using System.Collections;
using System.Text.RegularExpressions;
using Builder;
namespace RegExpBuilderTests;
public class TestThreeGroupRegexWithQuantifiersData : IEnumerable<object[]>
{
  public IEnumerator<object[]> GetEnumerator()
  {
    var state1 = new State(Some: true, ZeroOrOne: false, MinimumOf: 3, MaximumOf: -1, Options: new RegexOptions(), Or: false, MultiLine: false);
    var state2 = new State(Some: false, ZeroOrOne: false, MinimumOf: 3, MaximumOf: 5, Options: new RegexOptions(), Or: false, MultiLine: false);
    var state3 = new State(Some: false, ZeroOrOne: false, MinimumOf: 1, MaximumOf: -1, Options: new RegexOptions(), Or: false, MultiLine: false);
    var state4 = new State(Some: false, ZeroOrOne: true, MinimumOf: 0, MaximumOf: 1, Options: new RegexOptions(), Or: false, MultiLine: false);
    var state5 = new State(Some: false, ZeroOrOne: true, MinimumOf: -1, MaximumOf: 1, Options: new RegexOptions(), Or: false, MultiLine: false);
    yield return new object[] {
      "group1",
      state1,
      "group2",
      state2,
      "group3",
      state3,
      "(group1){3,}(group2){3,5}(group3)+",
      };
    yield return new object[] {
      "group2",
      state2,
      "group4",
      state4,
      "group1",
      state1,
      "(group2){3,5}(group4)?(group1){3,}"
      };
    yield return new object[] {
      "group3",
      state3,
      "group5",
      state5,
      "group4",
      state4,
      "(group3)+(group5)?(group4)?",
      };
    yield return new object[] {
      "group4",
      state4,
      "group1",
      state1,
      "group5",
      state5,
      "(group4)?(group1){3,}(group5)?",
      };
    yield return new object[] {
      "group5",
      state5,
      "group3",
      state3,
      "group2",
      state2,
      "(group5)?(group3)+(group2){3,5}",
      };
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}
