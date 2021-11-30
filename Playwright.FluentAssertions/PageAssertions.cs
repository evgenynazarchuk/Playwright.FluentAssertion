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

public static class PageAssertions
{
    public static ReferenceTypeAssertion<IPage> Should(this IPage page)
    {
        return new ReferenceTypeAssertion<IPage>(page);
    }

    public static IPage HaveTitle(
        this ReferenceTypeAssertion<IPage> page,
        string expected,
        string because = "no reason given")
    {
        var actual = page.Value.Title();

        if (string.Compare(actual, expected) != 0)
        {
            throw new AssertException(@$"
HaveTitle Assert Exception
Expected:
{expected}
Actual:
{actual}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotTitle(
        this ReferenceTypeAssertion<IPage> page,
        string notExpected,
        string because = "no reason given")
    {
        var actual = page.Value.Title();

        if (string.Compare(actual, notExpected) == 0)
        {
            throw new AssertException(@$"
HaveNotTitle Assert Exception
Not expected:
{notExpected}
Actual:
{actual}
Because:
{because}
");
        }

        return page.Value;
    }

    public static IPage HaveContent(
        this ReferenceTypeAssertion<IPage> page,
        string expected,
        string because = "no reason given")
    {
        var actual = page.Value.Content();

        if (string.Compare(actual, expected) != 0)
        {
            throw new AssertException(@$"
HaveContent Assert Exception
Not expected:
{expected}
Actual:
{actual}
Because:
{because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotContent(
        this ReferenceTypeAssertion<IPage> page,
        string notExpected,
        string because = "no reason given")
    {
        var actual = page.Value.Content();

        if (string.Compare(actual, notExpected) == 0)
        {
            throw new AssertException(@$"
HaveNotContent Assert Exception
Not expected:
{notExpected}
Actual:
{actual}
Because:
{because}
");
        }

        return page.Value;
    }

    public static IPage HaveCheckedElement(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var isChecked = element.IsChecked();

        if (isChecked is false)
        {
            throw new AssertException(@$"
HaveElementChecked Assert Exception
Selector: {selector}
Expected: checked
Actual: not checked
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotCheckedElement(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var isChecked = element.IsChecked();

        if (isChecked is true)
        {
            throw new AssertException(@$"
HaveNotElementChecked Assert Exception
Selector: {selector}
Expected: not checked
Actual: checked
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveDisabledElement(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var isDisabled = element.IsDisabled();

        if (isDisabled is false)
        {
            throw new AssertException(@$"
HaveNotElementChecked Assert Exception
Selector: {selector}
Expected: disable
Actual: not disable
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotDisabledElement(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var isDisabled = element.IsDisabled();

        if (isDisabled is true)
        {
            throw new AssertException(@$"
HaveNotElementDisabled Assert Exception
Selector: {selector}
Expected: not disable
Actual: disable
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveEditableElement(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var isEditable = element.IsEditable();

        if (isEditable is false)
        {
            throw new AssertException(@$"
HaveElementEditable Assert Exception
Selector: {selector}
Expected: editable
Actual: not editable
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotEditableElement(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var isEditable = element.IsEditable();

        if (isEditable is true)
        {
            throw new AssertException(@$"
HaveElementEditable Assert Exception
Selector: {selector}
Expected: not editable
Actual: editable
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveEnabledElement(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var isEnabled = element.IsEnabled();

        if (isEnabled is false)
        {
            throw new AssertException(@$"
HaveElementEnabled Assert Exception
Selector: {selector}
Expected: enable
Actual: not enable
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotEnabledElement(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var isEnabled = element.IsEnabled();

        if (isEnabled is true)
        {
            throw new AssertException(@$"
HaveNotElementEnabled Assert Exception
Selector: {selector}
Expected: not enable
Actual: enable
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveHiddenElement(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var isHidden = element.IsHidden();

        if (isHidden is false)
        {
            throw new AssertException(@$"
HaveElementHidden Assert Exception
Selector: {selector}
Expected: hidden
Actual: not hidden
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotHiddenElement(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var isHidden = element.IsHidden();

        if (isHidden is true)
        {
            throw new AssertException(@$"
HaveNotElementHidden Assert Exception
Selector: {selector}
Expected: not hidden
Actual: hidden
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveVisibleElement(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var isVisible = element.IsVisible();

        if (isVisible is false)
        {
            throw new AssertException(@$"
HaveElementVisible Assert Exception
Selector: {selector}
Expected: visible
Actual: not visible
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotVisibleElement(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var isVisible = element.IsVisible();

        if (isVisible is true)
        {
            throw new AssertException(@$"
HaveElementVisible Assert Exception
Selector: {selector}
Expected: not visible
Actual: visible
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveElementTextContent(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string expected,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var actual = element.TextContent() ?? "";

        if (string.Compare(actual, expected) != 0)
        {
            throw new AssertException(@$"
HaveElementTextContent Assert Exception
Selector: {selector}
Expected:
{expected}
Actual:
{actual}
Because:
{because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotElementTextContent(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string notExpected,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var actual = element.TextContent() ?? "";

        if (string.Compare(actual, notExpected) == 0)
        {
            throw new AssertException(@$"
HaveNotElementTextContent Assert Exception
Selector: {selector}
Not expected:
{notExpected}
Actual:
{actual}
Because:
{because}
");
        }

        return page.Value;
    }

    public static IPage HaveElementInnerHTML(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string expected,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var actual = element.InnerHTML() ?? "";

        if (string.Compare(actual, expected) != 0)
        {
            throw new AssertException(@$"
HaveElementInnerHTML Assert Exception
Selector: {selector}
Expected:
{expected}
Actual:
{actual}
Because:
{because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotElementInnerHTML(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string notExpected,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var actual = element.InnerHTML() ?? "";

        if (string.Compare(actual, notExpected) == 0)
        {
            throw new AssertException(@$"
HaveNotElementInnerHTML Assert Exception
Selector: {selector}
Not expected:
{notExpected}
Actual:
{actual}
Because:
{because}
");
        }

        return page.Value;
    }

    public static IPage HaveElementInnerText(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string expected,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var actual = element.InnerText() ?? "";

        if (string.Compare(actual, expected) != 0)
        {
            throw new AssertException(@$"
HaveElementInnerText Assert Exception
Selector: {selector}
Expected:
{expected}
Actual:
{actual}
Because:
{because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotElementInnerText(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string notExpected,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var actual = element.InnerText() ?? "";

        if (string.Compare(actual, notExpected) == 0)
        {
            throw new AssertException(@$"
HaveNotElementInnerText Assert Exception
Selector: {selector}
Not expected:
{notExpected}
Actual:
{actual}
Because:
{because}
");
        }

        return page.Value;
    }

    public static IPage HaveElementInputValue(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string expected,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var actual = element.InputValue() ?? "";

        if (string.Compare(actual, expected) != 0)
        {
            throw new AssertException(@$"
HaveElementInputValue Assert Exception
Selector: {selector}
Expected:
{expected}
Actual:
{actual}
Because:
{because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotElementInputValue(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string notExpected,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var actual = element.InputValue() ?? "";

        if (string.Compare(actual, notExpected) == 0)
        {
            throw new AssertException(@$"
HaveNotElementInputValue Assert Exception
Selector: {selector}
Not expected:
{notExpected}
Actual:
{actual}
Because:
{because}
");
        }

        return page.Value;
    }

    public static IPage HaveElementAttribute(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string attributeName,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector: {selector}");

        try
        {
            element.GetAttribute(attributeName);
        }
        catch
        {
            throw new AssertException(@$"
HaveElementAttribute Assert Exception
Selector: {selector}
Expected attribute: {attributeName}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotElementAttribute(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string attributeName,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector: {selector}");

        try
        {
            element.GetAttribute(attributeName);
        }
        catch
        {
            return page.Value;
        }

        throw new AssertException(@$"
HaveNotElementAttribute Assert Exception
Selector: {selector}
Not expected attribute: {attributeName}
Because: {because}
");
    }

    public static IPage HaveElementAttributeValue(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string attributeName,
        string expectedAttributeValue,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector: {selector}");
        string? actualAttributeValue = null;

        try
        {
            actualAttributeValue = element.GetAttribute(attributeName) ?? "";
        }
        catch
        {
            throw new AssertException($"Attribute not found. Attibute name: {attributeName}");
        }

        if (string.Compare(actualAttributeValue, expectedAttributeValue) != 0)
        {
            throw new AssertException(@$"
HaveElementAttributeValue Assert Exception
Selector: {selector}
Expected attribute: {attributeName}
Expected attribute value: {expectedAttributeValue}
Actual attribute value: {actualAttributeValue}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveElementComputedStyle(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string styleName,
        string expectedStyleValue,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector: {selector}");
        var actualStyleValue = element.Evaluate($"e => getComputedStyle(e).{styleName}", element).ToString();

        if (actualStyleValue == "")
        {
            throw new AssertException($"Style not found. Style name: {styleName}");
        }

        if (string.Compare(actualStyleValue, expectedStyleValue) != 0)
        {
            throw new AssertException($@"
HaveComputedStyle Assert Exception
Selector: {selector}
Style name: {styleName}
Expected style value: {expectedStyleValue}
Actual style value: {actualStyleValue}
Because: {because}
");
        }

        return page.Value;
    }
}
