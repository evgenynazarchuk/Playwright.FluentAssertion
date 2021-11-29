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

public static class FrameAssertions
{
    public static ReferenceTypeAssertion<IFrame> Should(this IFrame frame)
    {
        return new ReferenceTypeAssertion<IFrame>(frame);
    }

    public static IFrame HaveTitle(
        this ReferenceTypeAssertion<IFrame> frame,
        string expecteTitle,
        string because = "no reason given")
    {
        var title = frame.Value.Title();

        if (string.Compare(title, expecteTitle) != 0)
        {
            throw new AssertException(@$"
HaveTitle Assert Exception
Actual title:\n{title}
Expected title:\n{expecteTitle}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveNotTitle(
        this ReferenceTypeAssertion<IFrame> frame,
        string regularExpression,
        string because = "no reason given")
    {
        var title = frame.Value.Title();
        var match = Regex.Match(title, regularExpression, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotTitle Assert Exception
Actual title:\n{title}
Regulat expression:\n{regularExpression}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveContent(
        this ReferenceTypeAssertion<IFrame> frame,
        string regularExpression,
        string because = "no reason given")
    {
        var content = frame.Value.Content();
        var match = Regex.Match(content, regularExpression, RegexOptions.Compiled);

        if (!match.Success)
        {
            throw new AssertException(@$"
HaveContent Assert Exception
Actual content:\n{content}
Expected pattern:\n{regularExpression}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveNotContent(
        this ReferenceTypeAssertion<IFrame> frame,
        string regularExpression,
        string because = "no reason given")
    {
        var content = frame.Value.Content();
        var match = Regex.Match(regularExpression, content, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotContent Assert Exception
Actual content:\n{content}
Regular expression:\n{regularExpression}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveCheckedElement(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var isChecked = element.IsChecked();

        if (!isChecked)
        {
            throw new AssertException(@$"
HaveElementChecked Assert Exception
Selector: {selector}
Expected: checked
Actual: not checked
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveNotCheckedElement(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
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

        return frame.Value;
    }

    public static IFrame HaveDisabledElement(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var isDisabled = element.IsDisabled();

        if (!isDisabled)
        {
            throw new AssertException(@$"
HaveElementDisabled Assert Exception
Selector: {selector}
Expected: disable
Actual: not disable
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveNotDisabledElement(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
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

        return frame.Value;
    }

    public static IFrame HaveEditableElement(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
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

        return frame.Value;
    }

    public static IFrame HaveNotEditableElement(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var isEditable = element.IsEditable();

        if (isEditable)
        {
            throw new AssertException(@$"
HaveNotElementEditable Assert Exception
Selector: {selector}
Expected: not editable
Actual: editable
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveEnabledElement(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
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

        return frame.Value;
    }

    public static IFrame HaveNotEnabledElement(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
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

        return frame.Value;
    }

    public static IFrame HaveHiddenElement(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
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

        return frame.Value;
    }

    public static IFrame HaveNotHiddenElement(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
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

        return frame.Value;
    }

    public static IFrame HaveVisibleElement(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
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

        return frame.Value;
    }

    public static IFrame HaveNotVisibleElement(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var isVisible = element.IsVisible();

        if (isVisible)
        {
            throw new AssertException(@$"
HaveNotElementVisible Assert Exception
Selector: {selector}
Expected: not visible
Actual: visible
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveElementTextContent(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string expectedTextContent,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var textContent = element.TextContent() ?? "";

        if (string.Compare(textContent, expectedTextContent) != 0)
        {
            throw new AssertException(@$"
HaveElementTextContent Assert Exception
Selector: {selector}
Actual text content:\n{textContent}
Expected text content:\n{expectedTextContent}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveNotElementTextContent(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string regularExpression,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var textContent = element.TextContent() ?? "";
        var match = Regex.Match(textContent, regularExpression, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotElementTextContent Assert Exception
Selector: {selector}
Actual text content:\n{textContent}
Regular expression:\n{regularExpression}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveElementInnerHTML(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string expectedInnerHtml,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var innerHtml = element.InnerHTML() ?? "";

        if (string.Compare(innerHtml, expectedInnerHtml) != 0)
        {
            throw new AssertException(@$"
HaveElementInnerHTML Assert Exception
Selector: {selector}
Actual inner html:\n{innerHtml}
Expected inner html:\n{expectedInnerHtml}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveNotElementInnerHTML(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string regularExpression,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var innerHtml = element.InnerHTML() ?? "";
        var match = Regex.Match(innerHtml, regularExpression, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotElementInnerHTML Assert Exception
Selector: {selector}
Actual inner html:\n{innerHtml}
Regular expression:\n{regularExpression}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveElementInnerText(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string expectedInnerText,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var innerHtml = element.InnerText() ?? "";

        if (string.Compare(innerHtml, expectedInnerText) != 0)
        {
            throw new AssertException(@$"
HaveElementInnerText Assert Exception
Selector: {selector}
Actual inner text:\n{innerHtml}
Expected inner text:\n{expectedInnerText}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveNotElementInnerText(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string regularExpression,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var innerText = element.InnerText() ?? "";
        var match = Regex.Match(innerText, regularExpression, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotElementInnerText Assert Exception
Selector: {selector}
Actual inner text:\n{innerText}
Regular expression:\n{regularExpression}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveElementInputValue(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string expectedInputValue,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var inputValue = element.InputValue() ?? "";

        if (string.Compare(inputValue, expectedInputValue) != 0)
        {
            throw new AssertException(@$"
HaveElementInputValue Assert Exception
Selector: {selector}
Actual input value:\n{inputValue}
Expected input value:\n{expectedInputValue}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveNotElementInputValue(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string regularExpression,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var inputValue = element.InputValue() ?? "";
        var match = Regex.Match(inputValue, regularExpression, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotElementInputValue Assert Exception
Selector: {selector}
Actual input value:\n{inputValue}
Regular expression:\n{regularExpression}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveElementAttribute(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string attributeName,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
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

        return frame.Value;
    }

    public static IFrame HaveNotElementAttribute(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string attributeName,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector: {selector}");

        try
        {
            element.GetAttribute(attributeName);
        }
        catch
        {
            return frame.Value;
        }

        throw new AssertException(@$"
HaveNotElementAttribute Assert Exception
Selector: {selector}
Not expected attribute: {attributeName}
Because: {because}
");
    }

    public static IFrame HaveElementAttributeValue(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string attributeName,
        string expectedAttributeValue,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
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

        return frame.Value;
    }

    public static IFrame HaveElementComputedStyle(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string styleName,
        string expectedStyleValue,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
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

        return frame.Value;
    }
}
