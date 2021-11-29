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
using System.Text.RegularExpressions;

namespace Playwright.FluentAssertions;

public static class PageAssertions
{
    public static ReferenceTypeAssertion<IPage> Should(this IPage page)
    {
        return new ReferenceTypeAssertion<IPage>(page);
    }

    public static IPage HaveTitle(
        this ReferenceTypeAssertion<IPage> page,
        string expectedTitle,
        string because = "no reason given")
    {
        var title = page.Value.Title();

        if (string.Compare(title, expectedTitle) != 0)
        {
            throw new AssertException(@$"
HaveTitle Assert Exception
Expected title:
{title}
Actual title:
{expectedTitle}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotTitle(
        this ReferenceTypeAssertion<IPage> page,
        string regularExpression,
        string because = "no reason given")
    {
        var title = page.Value.Title();
        var match = Regex.Match(title, regularExpression, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotTitle Assert Exception
Actual title:
{title}
Regular expression:
{regularExpression}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveContent(
        this ReferenceTypeAssertion<IPage> page,
        string regularExpression,
        string because = "no reason given")
    {
        var content = page.Value.Content();
        var match = Regex.Match(content, regularExpression, RegexOptions.Compiled);

        if (!match.Success)
        {
            throw new AssertException(@$"
HaveContent Assert Exception
Actual content:
{content}
Regular expression:
{regularExpression}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotContent(
        this ReferenceTypeAssertion<IPage> page,
        string pattern,
        string because = "no reason given")
    {
        var content = page.Value.Content();
        var match = Regex.Match(content, pattern, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotContent Assert Exception
Actual content:
{content}
Not expected pattern:
{pattern}
Because: {because}
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

        if (isChecked)
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

        if (!isDisabled)
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

        if (isDisabled)
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

        if (!isEditable)
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

        if (isEditable)
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

        if (!isEnabled)
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

        if (isEnabled)
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

        if (!isHidden)
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

        if (isHidden)
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

        if (!isVisible)
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

        if (isVisible)
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
        string expectedTextContent,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var textContent = element.TextContent() ?? "";

        if (string.Compare(textContent, expectedTextContent) != 0)
        {
            throw new AssertException(@$"
HaveElementTextContent Assert Exception
Selector: {selector}
Actual text content:
{textContent}
Expected text content:
{expectedTextContent}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotElementTextContent(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string regularExpression,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var textContent = element.TextContent() ?? "";
        var match = Regex.Match(textContent, regularExpression, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotElementTextContent Assert Exception
Selector: {selector}
Actual text content:
{textContent}
Regular expression:
{regularExpression}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveElementInnerHTML(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string expectedInnerHtml,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var innerHtml = element.InnerHTML() ?? "";

        if (string.Compare(innerHtml, expectedInnerHtml) != 0)
        {
            throw new AssertException(@$"
HaveElementInnerHTML Assert Exception
Selector: {selector}
Actual inner html:
{innerHtml}
Expected inner html:
{expectedInnerHtml}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotElementInnerHTML(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string regularExpression,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var innerHtml = element.InnerHTML() ?? "";
        var match = Regex.Match(innerHtml, regularExpression, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotElementInnerHTML Assert Exception
Selector: {selector}
Actual inner html:
{innerHtml}
Regular expression:
{regularExpression}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveElementInnerText(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string expectedInnerText,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var innerText = element.InnerText() ?? "";

        if (string.Compare(innerText, expectedInnerText) != 0)
        {
            throw new AssertException(@$"
HaveElementInnerText Assert Exception
Selector: {selector}
Actual inner text:
{innerText}
Expected inner text:
{expectedInnerText}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotElementInnerText(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string regularExpression,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var innerText = element.InnerText() ?? "";
        var match = Regex.Match(innerText, regularExpression, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotElementInnerText Assert Exception
Selector: {selector}
Actual inner text:
{innerText}
Regular expression:
{regularExpression}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveElementInputValue(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string expectedInputValue,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var inputValue = element.InputValue() ?? "";

        if (string.Compare(inputValue, expectedInputValue) != 0)
        {
            throw new AssertException(@$"
HaveElementInputValue Assert Exception
Selector: {selector}
Actual input value:
{inputValue}
Expected input value:
{expectedInputValue}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotElementInputValue(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string regularExpression,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var inputValue = element.InputValue() ?? "";
        var match = Regex.Match(inputValue, regularExpression, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotElementInputValue Assert Exception
Selector: {selector}
Actual input value:
{inputValue}
Regular expression:
{regularExpression}
Because: {because}
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
