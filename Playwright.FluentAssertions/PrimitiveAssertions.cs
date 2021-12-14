/*
 * MIT License
 *
 * Copyright (c) Evgeny Nazarchuk.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

namespace Playwright.FluentAssertions;

public static class PrimitiveAssertions
{
    public static ReferenceTypeAssertion<string> Should(this string text)
    {
        return new ReferenceTypeAssertion<string>(text);
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

    public static ReferenceTypeAssertion<Enum> Should(this Enum e)
    {
        return new ReferenceTypeAssertion<Enum>(e);
    }

    public static ReferenceTypeAssertion<IEnumerable<string>> Should(this IEnumerable<string> list)
    {
        return new ReferenceTypeAssertion<IEnumerable<string>>(list);
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

    public static void Be(this ReferenceTypeAssertion<bool> value, bool expectedValue)
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

    public static void Be(this ReferenceTypeAssertion<Enum> value, Enum expectedValue)
    {
        if (!Enum.Equals(value.Value, expectedValue))
        {
            throw new AssertException($@"
Be Assert Exception
Expected value: {expectedValue}
Actual value: {value.Value}
");
        }
    }

    public static void BeNull(this object? obj)
    {
        if (obj is not null)
        {
            throw new AssertException(@"
BeNull Assert Exception
Expected: null
Actual: not null
");
        }
    }

    public static void BeNotNull(this object? obj)
    {
        if (obj is null)
        {
            throw new AssertException(@"
BeNotNull Assert Exception
Expected: not null
Actual: null
");
        }
    }

    public static void Contains(this ReferenceTypeAssertion<IEnumerable<string>> list, string expectedText, string because = "no reason given")
    {
        if (!list.Value.Any(x => x.Contains(expectedText)))
        {
            throw new AssertException(@$"
Contain Assert Exception
Expected value:
{expectedText}
Actual list:
{string.Join(", ", list.Value)}
Because: {because}
");
        }
    }

    public static void Contain(this ReferenceTypeAssertion<string> text, string expectedText, string because = "no reason given")
    {
        if (!text.Value.Contains(expectedText))
        {
            throw new AssertException(@$"
Contain Assert Exception
Expected value:
{expectedText}
Actual:
{expectedText}
Because: {because}
");
        }
    }

    public static void NotContains(this ReferenceTypeAssertion<IEnumerable<string>> list, string expectedText, string because = "")
    {
        if (list.Value.Any(x => x.Contains(expectedText)))
        {
            throw new AssertException(@$"
NotContain Assert Exception
Not expected: 
{expectedText}
Actual: 
{string.Join(",", list.Value)}
Because: {because}
");
        }
    }

    public static void NotContain(this ReferenceTypeAssertion<string> text, string notExpectedText, string because = "no reason given")
    {
        if (text.Value.Contains(notExpectedText))
        {
            throw new AssertException(@$"
NotContain Assert Exception
Not expected value:
{notExpectedText}
Actual:
{notExpectedText}
Because: {because}
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

    public static void BeNot(this ReferenceTypeAssertion<Enum> value, Enum notExpectedValue, string because = "no reason given")
    {
        if (Enum.Equals(value.Value, notExpectedValue))
        {
            throw new AssertException($@"
BeNot Assert Exception
Not expected: {notExpectedValue}
Actual value: {value.Value}
Because: {because}
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
