namespace Playwright.FluentAssertions;

public static class PrimitiveAssertions
{
    public static ReferenceTypeAssertion<string> Should(this string content)
    {
        return new ReferenceTypeAssertion<string>(content);
    }

    public static ReferenceTypeAssertion<int> Should(this int value)
    {
        return new ReferenceTypeAssertion<int>(value);
    }

    public static ReferenceTypeAssertion<bool> Should(this bool value)
    {
        return new ReferenceTypeAssertion<bool>(value);
    }

    public static ReferenceTypeAssertion<byte[]> Should(this byte[] array)
    {
        return new ReferenceTypeAssertion<byte[]>(array);
    }

    public static void Be(this ReferenceTypeAssertion<string> actualString, string expectedString, string because = "no reason given")
    {
        if (string.Compare(actualString.Value, expectedString) != 0)
        {
            throw new AssertException($@"
Be Assert Exception
Expected string:
{expectedString}
Actual string:
{actualString.Value}
Because:
{because}
");
        }
    }

    public static void Be(this ReferenceTypeAssertion<IEnumerable<string>> actualStrings, IEnumerable<string> expectedStrings, string because = "no reason given")
    {
        if (actualStrings.Value.Count() != expectedStrings.Count())
        {
            throw new AssertException($@"
Be Assert Exception
Expected total number: {expectedStrings.Count()}
Actual total number: {actualStrings.Value.Count()}
Because: {because}
");
        }

        for (int i = 0; i < actualStrings.Value.Count(); i++)
        {
            if (string.Compare(actualStrings.Value.ElementAt(i), expectedStrings.ElementAt(i)) != 0)
            {
                throw new AssertException($@"
Be Assert Exception
Index string: {i}
Expected string:
{expectedStrings.ElementAt(i)}
Actual string:
{actualStrings.Value.ElementAt(i)}
Because:
{because}
");
            }
        }
    }

    public static void Be(this ReferenceTypeAssertion<byte[]> bytes, byte[] expectedBytes, string because = "no reason given")
    {
        if (!bytes.Value.SequenceEqual(expectedBytes))
        {
            throw new AssertException($@"
Be Assert Exception
Because: {because}
");
        }
    }

    public static void Be(this ReferenceTypeAssertion<byte[]> bytes, string filePath, string because = "no reason given")
    {
        var expectedBytes = File.ReadAllBytes(filePath);

        if (!bytes.Value.SequenceEqual(expectedBytes))
        {
            throw new AssertException($@"
Be Assert Exception
FilePath: {filePath}
Because: {because}
");
        }
    }

    public static void Be(this ReferenceTypeAssertion<int> value, int expectedValue)
    {
        if (value.Value != expectedValue)
        {
            throw new AssertException($@"
Be Assert Exception
Expected value: {expectedValue}
Actual value: {value.Value}
");
        }
    }

    public static void BeTrue(this ReferenceTypeAssertion<bool> value, string because = "no reason given")
    {
        if (value.Value is not true)
        {
            throw new AssertException($@"
BeTrue Assert Exception
Expected bool: true
Actual bool: {value.Value}
Because:{because}
");
        }
    }

    public static void BeFalse(this ReferenceTypeAssertion<bool> value, string because = "no reason given")
    {
        if (value.Value is true)
        {
            throw new AssertException($@"
BeFalse Assert Exception
Expected bool: false
Actual bool: {value.Value}
Because: {because}
");
        }
    }

    public static void BeNot(this ReferenceTypeAssertion<string> actual, string notExpected, string because = "no reason given")
    {
        if (string.Compare(actual.Value, notExpected) == 0)
        {
            throw new AssertException($@"
BeNot Assert Exception
Not expected string:
{notExpected}
Actual string:
{actual.Value}
Because:
{because}
");
        }
    }

    public static void BeNot(this ReferenceTypeAssertion<int> value, int notExpectedValue)
    {
        if (value.Value == notExpectedValue)
        {
            throw new AssertException($@"
NotBe Assert Exception
Not expected value: {notExpectedValue}
Actual value: {value.Value}
");
        }
    }

    public static void BePositive(this ReferenceTypeAssertion<int> value)
    {
        if (value.Value > 0)
        {
            throw new AssertException($@"
BePositive Assert Exception
Expected value: positive
Actual value: {value.Value}
");
        }
    }

    public static void BeNegative(this ReferenceTypeAssertion<int> value)
    {
        if (value.Value < 0)
        {
            throw new AssertException($@"
BeNegative Assert Exception
Expected value: negative
Actual value: {value.Value}
");
        }
    }

    public static void BeGreaterThan(this ReferenceTypeAssertion<int> value, int expectedValue)
    {
        if (value.Value > expectedValue)
        {
            throw new AssertException($@"
BeGreaterThan Assert Exception
Expected be greater than: {expectedValue}
Actual value: {value.Value}
");
        }
    }

    public static void BeLessThan(this ReferenceTypeAssertion<int> value, int expectedValue)
    {
        if (value.Value < expectedValue)
        {
            throw new AssertException($@"
BeLessThan Assert Exception
Expected be less than: {expectedValue}
Actual value: {value.Value}
");
        }
    }

    public static void BeGreaterThanOrEqualTo(this ReferenceTypeAssertion<int> value, int expectedValue)
    {
        if (value.Value >= expectedValue)
        {
            throw new AssertException($@"
BeGreaterThanOrEqualTo Assert Exception
Expected be greater than or equal: {expectedValue}
Actual value: {value.Value}
");
        }
    }

    public static void BeLessThanOrEqualTo(this ReferenceTypeAssertion<int> value, int expectedValue)
    {
        if (value.Value <= expectedValue)
        {
            throw new AssertException($@"
BeLessThanOrEqualTo Assert Exception
Expected be less than or equal: {expectedValue}
Actual value: {value.Value}
");
        }
    }
}
