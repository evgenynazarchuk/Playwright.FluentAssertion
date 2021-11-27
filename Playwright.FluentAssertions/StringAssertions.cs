namespace Playwright.FluentAssertions;

public static class StringAssertions
{
    public static ReferenceTypeAssertion<string> Should(this string content)
    {
        return new ReferenceTypeAssertion<string>(content);
    }

    public static void BeEquals(this string actualString, string expectedString)
    {
        if (string.Compare(actualString, expectedString) != 0)
        {
            throw new AssertException($@"
BeEquals Assert Exception
Expected string: {expectedString}
Actual string: {actualString}
");
        }
    }

    public static void BeEquals(this IEnumerable<string> actualStrings, IEnumerable<string> expectedStrings)
    {
        if (actualStrings.Count() != expectedStrings.Count())
        {
            throw new AssertException($@"
BeEquals Assert Exception
Expected total number: {expectedStrings.Count()}
Actual total number: {actualStrings.Count()}
");
        }

        for (int i = 0; i < actualStrings.Count(); i++)
        {
            if (string.Compare(actualStrings.ElementAt(i), expectedStrings.ElementAt(i)) != 0)
            {
                throw new AssertException($@"
BeEquals Assert Exception
Index string: {i}
Expected string: {expectedStrings.ElementAt(i)}
Actual string: {actualStrings.ElementAt(i)}

");
            }
        }
    }
}
