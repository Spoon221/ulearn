[TestCase("''", new[] {""})]
[TestCase("", new string[0])]
[TestCase("text", new[] {"text"})]
[TestCase("hello world", new[] {"hello", "world"})]
[TestCase("hello  world", new[] {"hello", "world"})]
[TestCase(@"'a\' b'", new[] {"a' b"})]
[TestCase("b \"a'\"", new[] {"b", "a'"})]
[TestCase("\"\\\\\"", new[] {"\\"})]
[TestCase("\"\\\\'", new[] {"\\'"})]
[TestCase("' a'b", new[] {" a", "b"})]
[TestCase(" a", new[] {"a"})]
[TestCase("d '2'", new[] {"d", "2"})]
[TestCase(" a b ", new[] { "a", "b" })]
[TestCase("'\"(◕‿◕)'", new[] {"\"(◕‿◕)"})]
[TestCase(@"""\""(*¯︶¯*)""", new[] { @"""(*¯︶¯*)" })]
[TestCase("'( ´ ω ` ) ", new[] {"( ´ ω ` ) "})]
public static void RunTests(string input, string[] expectedOutput)
{
    Test(input, expectedOutput);
}