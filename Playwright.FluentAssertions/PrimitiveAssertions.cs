namespace Playwright.FluentAssertions;

public static class PrimitiveAssertions
{
    public static ReferenceTypeAssertion<string> Should(this string content)
    {
        return new ReferenceTypeAssertion<string>(content);
    }

    public static void Be(this string actualString, string expectedString, string because = "no reason given")
    {
        if (string.Compare(actualString, expectedString) != 0)
        {
            throw new AssertException($@"
Be Assert Exception
Expected string: {expectedString}
Actual string: {actualString}
Because: {because}
");
        }
    }

    public static void Be(this IEnumerable<string> actualStrings, IEnumerable<string> expectedStrings, string because = "no reason given")
    {
        if (actualStrings.Count() != expectedStrings.Count())
        {
            throw new AssertException($@"
Be Assert Exception
Expected total number: {expectedStrings.Count()}
Actual total number: {actualStrings.Count()}
Because: {because}
");
        }

        for (int i = 0; i < actualStrings.Count(); i++)
        {
            if (string.Compare(actualStrings.ElementAt(i), expectedStrings.ElementAt(i)) != 0)
            {
                throw new AssertException($@"
Be Assert Exception
Index string: {i}
Expected string: {expectedStrings.ElementAt(i)}
Actual string: {actualStrings.ElementAt(i)}
Because: {because}
");
            }
        }
    }

    public static void BeTrue(this bool value, string because = "no reason given")
    {
        if (value is not true)
        {
            throw new AssertException($@"
BeTrue Assert Exception
Expected bool: true
Actual bool: {value}
Because: {because}
");
        }
    }

    public static void BeFalse(this bool value, string because = "no reason given")
    {
        if (value is true)
        {
            throw new AssertException($@"
BeFalse Assert Exception
Expected bool: false
Actual bool: {value}
Because: {because}
");
        }
    }

    public static void Be(this byte[] bytes, byte[] expectedBytes, string because = "no reason given")
    {
        if (!bytes.SequenceEqual(expectedBytes))
        {
            throw new AssertException($@"
Be Assert Exception
Because: {because}
");
        }
    }

    public static void Be(this byte[] bytes, string filePath, string because = "no reason given")
    {
        var expectedBytes = File.ReadAllBytes(filePath);

        if (!bytes.SequenceEqual(expectedBytes))
        {
            throw new AssertException($@"
Be Assert Exception
FilePath: {filePath}
Because: {because}
");
        }
    }

    public static void Be(this int value, int expectedValue)
    {
        if (value != expectedValue)
        {
            throw new AssertException($@"
Be Assert Exception
Actual value: {value}
Expected value: {expectedValue}
");
        }
    }

    public static void NotBe(this int value, int notExpectedValue)
    {
        if (value == notExpectedValue)
        {
            throw new AssertException($@"
NotBe Assert Exception
Actual value: {value}
Not expected value: {notExpectedValue}
");
        }
    }

    public static void BePositive(this int value)
    {
        if (value > 0)
        {
            throw new AssertException($@"
BePositive Assert Exception
Actual value: {value}
Expected value: positive
");
        }
    }

    public static void BeNegative(this int value)
    {
        if (value < 0)
        {
            throw new AssertException($@"
BeNegative Assert Exception
Actual value: {value}
Expected value: negative
");
        }
    }

    public static void BeGreaterThan(this int value, int expectedValue)
    {
        if (value > expectedValue)
        {
            throw new AssertException($@"
BeGreaterThan Assert Exception
Expected be greater than: {expectedValue}
Actual value: {value}
");
        }
    }

    public static void BeLessThan(this int value, int expectedValue)
    {
        if (value < expectedValue)
        {
            throw new AssertException($@"
BeLessThan Assert Exception
Expected be less than: {expectedValue}
Actual value: {value}
");
        }
    }

    public static void BeGreaterThanOrEqualTo(this int value, int expectedValue)
    {
        if (value >= expectedValue)
        {
            throw new AssertException($@"
BeGreaterThanOrEqualTo Assert Exception
Expected be greater than or equal: {expectedValue}
Actual value: {value}
");
        }
    }

    public static void BeLessThanOrEqualTo(this int value, int expectedValue)
    {
        if (value <= expectedValue)
        {
            throw new AssertException($@"
BeLessThanOrEqualTo Assert Exception
Expected be less than or equal: {expectedValue}
Actual value: {value}
");
        }
    }
}
