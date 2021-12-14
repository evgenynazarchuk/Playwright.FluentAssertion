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

using Microsoft.Playwright;
using Playwright.Synchronous;

namespace Playwright.FluentAssertions;

public static partial class ElementHandleAssertions
{
    public static ReferenceTypeAssertion<IElementHandle> Should(this IElementHandle elementHandle)
    {
        return new ReferenceTypeAssertion<IElementHandle>(elementHandle);
    }

    public static IElementHandle BeChecked(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var isChecked = element.IsChecked();

        if (isChecked is false)
        {
            throw new AssertException(@$"
BeChecked Assert Exception
Expected: checked
Actual: not checked
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeNotChecked(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var isChecked = element.IsChecked();

        if (isChecked is true)
        {
            throw new AssertException(@$"
BeNotChecked Assert Exception
Expected: not checked
Actual: checked
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeDisabled(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var isDisabled = element.IsDisabled();

        if (isDisabled is false)
        {
            throw new AssertException(@$"
BeDisabled Assert Exception
Expected: disabled
Actual: not disabled
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeNotDisabled(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var isDisabled = element.IsDisabled();

        if (isDisabled is true)
        {
            throw new AssertException(@$"
BeNotDisabled Assert Exception
Expected: not disabled
Actual: disabled
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeEditable(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var isEditable = element.IsEditable();

        if (isEditable is false)
        {
            throw new AssertException(@$"
BeEditable Assert Exception
Expected: editable
Actual: not editable
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeNotEditable(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var isEditable = element.IsEditable();

        if (isEditable is true)
        {
            throw new AssertException(@$"
BeNotEditable Assert Exception
Expected: not editable
Actual: editable
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeEnabled(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var isEnabled = element.IsEnabled();

        if (isEnabled is false)
        {
            throw new AssertException(@$"
BeEnabled Assert Exception
Expected: enabled
Actual: not enabled
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeNotEnabled(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var isEnabled = element.IsEnabled();

        if (isEnabled is true)
        {
            throw new AssertException(@$"
BeNotEnabled Assert Exception
Expected: not enabled
Actual: enabled
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeHidden(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var isHidden = element.IsHidden();

        if (isHidden is false)
        {
            throw new AssertException(@$"
BeHidden Assert Exception
Expected: hidden
Actual: not hidden
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeNotHidden(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var isHidden = element.IsHidden();

        if (isHidden is true)
        {
            throw new AssertException(@$"
BeNotHidden Assert Exception
Expected: not hidden
Actual: hidden
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeVisible(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var isVisible = element.IsVisible();

        if (isVisible is false)
        {
            throw new AssertException(@$"
BeVisible Assert Exception
Expected: visible
Actual: not visible
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeNotVisible(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var isVisible = element.IsVisible();

        if (isVisible is true)
        {
            throw new AssertException(@$"
BeNotVisible Assert Exception
Expected: not visible
Actual: visible
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle HaveTextContent(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string expected,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var actual = element.TextContent() ?? "";

        if (string.Compare(actual, expected) != 0)
        {
            throw new AssertException(@$"
HaveTextContent Assert Exception
Expected:
{expected}
Actual:
{actual}
Because:
{because}
");
        }

        return element;
    }

    public static IElementHandle HaveNotTextContent(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string notExpected,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var actual = element.TextContent() ?? "";

        if (string.Compare(actual, notExpected) == 0)
        {
            throw new AssertException(@$"
HaveNotTextContent Assert Exception
Not expected:
{notExpected}
Actual:
{actual}
Because:
{because}
");
        }

        return element;
    }

    public static IElementHandle HaveInnerHTML(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string expected,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var actual = element.InnerHTML();

        if (string.Compare(actual, expected) != 0)
        {
            throw new AssertException(@$"
HaveInnerHTML Assert Exception
Expected:
{expected}
Actual:
{actual}
Because:
{because}
");
        }

        return element;
    }

    public static IElementHandle HaveNotInnerHTML(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string notExpected,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var actual = element.InnerHTML();

        if (string.Compare(actual, notExpected) == 0)
        {
            throw new AssertException(@$"
HaveNotInnerHTML Assert Exception
Not expected:
{notExpected}
Actual:
{actual}
Because:
{because}
");
        }

        return element;
    }

    public static IElementHandle HaveInnerText(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string expected,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var actual = element.InnerText();

        if (string.Compare(actual, expected) != 0)
        {
            throw new AssertException(@$"
HaveInnerText Assert Exception
Expected:
{expected}
Actual:
{actual}
Because:
{because}
");
        }

        return element;
    }

    public static IElementHandle HaveNotInnerText(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string notExpected,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var actual = element.InnerText();

        if (string.Compare(actual, notExpected) == 0)
        {
            throw new AssertException(@$"
HaveNotInnerText Assert Exception
Not expected:
{notExpected}
Actual:
{actual}
Because:
{because}
");
        }

        return element;
    }

    public static IElementHandle HaveInputValue(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string expected,
        string because = "no reason given",
        ElementHandleInputValueOptions? inputOptions = null)
    {
        var element = elementHandle.Value;
        var actual = element.InputValue(inputOptions);

        if (string.Compare(actual, expected) != 0)
        {
            throw new AssertException(@$"
HaveInputValue Assert Exception
Expected:
{expected}
Actual:
{actual}
Because:
{because}
");
        }

        return element;
    }

    public static IElementHandle HaveNotInputValue(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string notExpected,
        string because = "no reason given",
        ElementHandleInputValueOptions? inputOptions = null)
    {
        var element = elementHandle.Value;
        var actual = element.InputValue(inputOptions);

        if (string.Compare(actual, notExpected) == 0)
        {
            throw new AssertException(@$"
HaveNotInputValue Assert Exception
Not expected:
{notExpected}
Actual:
{actual}
Because:
{because}
");
        }

        return element;
    }

    public static IElementHandle HaveAttribute(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string attributeName,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var value = element.GetAttribute(attributeName);

        if (value is null)
        {
            throw new AssertException(@$"
HaveAttribute Assert Exception
Expected attribute name: {attributeName}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle HaveNotAttribute(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string attributeName,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var value = element.GetAttribute(attributeName);

        if (value is not null)
        {
            throw new AssertException(@$"
HaveNotAttribute Assert Exception
Not expected attribute name: {attributeName}
Because: {because}
");
        }

        return elementHandle.Value;
    }

    public static IElementHandle HaveAttributeValue(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string attributeName,
        string attributeValue,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var value = element.GetAttribute(attributeName);

        if (value is null)
        {
            throw new AssertException($"Attribute not found. Attibute name: {attributeName}");
        }

        if (string.Compare(value, attributeValue) != 0)
        {
            throw new AssertException(@$"
HaveAttributeValue Assert Exception
Attribute name: {attributeName}
Expected attribute value: {attributeValue}
Actual attribute value: {value}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle HaveNotAttributeValue(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string attributeName,
        string attributeValue,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var value = element.GetAttribute(attributeName);

        if (value is null)
        {
            throw new AssertException($"Attribute not found. Attibute name: {attributeName}");
        }

        if (string.Compare(value, attributeValue) == 0)
        {
            throw new AssertException(@$"
HaveNotAttributeValue Assert Exception
Attribute name: {attributeName}
Not expected attribute value: {attributeValue}
Actual attribute value: {value}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle HaveComputedStyle(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string styleName,
        string styleValue,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var actual = element.Evaluate($"e => getComputedStyle(e).{styleName}", element).ToString();

        if (string.IsNullOrEmpty(actual))
        {
            throw new AssertException($"Style not found. Style name: {styleName}");
        }

        if (string.Compare(actual, styleValue) != 0)
        {
            throw new AssertException($@"
HaveComputedStyle Assert Exception
Style name: {styleName}
Expected style value: {styleValue}
Actual style value: {actual}
Because: {because}
");
        }

        return elementHandle.Value;
    }
}
