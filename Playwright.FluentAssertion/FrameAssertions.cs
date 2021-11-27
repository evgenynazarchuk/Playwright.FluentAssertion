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
        string pattern,
        string because = "no reason given")
    {
        var title = frame.Value.Title();
        var match = Regex.Match(title, pattern, RegexOptions.Compiled);

        if (!match.Success)
        {
            throw new AssertException(@$"
HaveTitle Assert Exception
Actual title: {title}
Expected pattern: {pattern}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveNotTitle(
        this ReferenceTypeAssertion<IFrame> frame,
        string pattern,
        string because = "no reason given")
    {
        var title = frame.Value.Title();
        var match = Regex.Match(title, pattern, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotTitle Assert Exception
Actual title: {title}
Not expected pattern: {pattern}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveContent(
        this ReferenceTypeAssertion<IFrame> frame,
        string pattern,
        string because = "no reason given")
    {
        var content = frame.Value.Content();
        var match = Regex.Match(content, pattern, RegexOptions.Compiled);

        if (!match.Success)
        {
            throw new AssertException(@$"
HaveContent Assert Exception
Actual content: {content}
Expected pattern: {pattern}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveNotContent(
        this ReferenceTypeAssertion<IFrame> frame,
        string pattern,
        string because = "no reason given")
    {
        var content = frame.Value.Content();
        var match = Regex.Match(pattern, content, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotContent Assert Exception
Actual content: {content}
Not expected pattern: {pattern}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveElementChecked(
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

    public static IFrame HaveNotElementChecked(
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

    public static IFrame HaveElementDisabled(
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

    public static IFrame HaveNotElementDisabled(
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

    public static IFrame HaveElementEditable(
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

    public static IFrame HaveNotElementEditable(
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

    public static IFrame HaveElementEnabled(
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

    public static IFrame HaveNotElementEnabled(
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

    public static IFrame HaveElementHidden(
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

    public static IFrame HaveNotElementHidden(
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

    public static IFrame HaveElementVisible(
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

    public static IFrame HaveNotElementVisible(
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
        string pattern,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var textContent = element.TextContent() ?? "";
        var match = Regex.Match(textContent, pattern, RegexOptions.Compiled);

        if (!match.Success)
        {
            throw new AssertException(@$"
HaveElementTextContent Assert Exception
Selector: {selector}
Actual text content: {textContent}
Expected pattern: {pattern}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveNotElementTextContent(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string pattern,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var textContent = element.TextContent() ?? "";
        var match = Regex.Match(textContent, pattern, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotElementTextContent Assert Exception
Selector: {selector}
Actual text content: {textContent}
Not expected pattern: {pattern}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveElementInnerHTML(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string pattern,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var innerHtml = element.InnerHTML() ?? "";
        var match = Regex.Match(innerHtml, pattern, RegexOptions.Compiled);

        if (!match.Success)
        {
            throw new AssertException(@$"
HaveElementInnerHTML Assert Exception
Selector: {selector}
Actual inner html: {innerHtml}
Expected pattern: {pattern}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveNotElementInnerHTML(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string pattern,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var innerHtml = element.InnerHTML() ?? "";
        var match = Regex.Match(innerHtml, pattern, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotElementInnerHTML Assert Exception
Selector: {selector}
Actual inner html: {innerHtml}
Not expected pattern: {pattern}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveElementInnerText(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string pattern,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var innerHtml = element.InnerText() ?? "";
        var match = Regex.Match(innerHtml, pattern, RegexOptions.Compiled);

        if (!match.Success)
        {
            throw new AssertException(@$"
HaveElementInnerText Assert Exception
Selector: {selector}
Actual inner text: {innerHtml}
Expected pattern: {pattern}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveNotElementInnerText(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string pattern,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var innerText = element.InnerText() ?? "";
        var match = Regex.Match(innerText, pattern, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotElementInnerText Assert Exception
Selector: {selector}
Actual inner text: {innerText}
Not expected pattern: {pattern}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveElementInputValue(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string pattern,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var inputValue = element.InputValue() ?? "";
        var match = Regex.Match(inputValue, pattern, RegexOptions.Compiled);

        if (!match.Success)
        {
            throw new AssertException(@$"
HaveElementInputValue Assert Exception
Selector: {selector}
Actual input value: {inputValue}
Expected pattern: {pattern}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveNotElementInputValue(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string pattern,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var inputValue = element.InputValue() ?? "";
        var match = Regex.Match(inputValue, pattern, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotElementInputValue Assert Exception
Selector: {selector}
Actual input value: {inputValue}
Not expected pattern: {pattern}
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
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var attribute = element.GetAttribute(attributeName);

        if (attribute is null)
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
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var attributeValue = element.GetAttribute(attributeName);

        if (attributeValue is not null)
        {
            throw new AssertException(@$"
HaveNotElementAttribute Assert Exception
Selector: {selector}
Not expected attribute: {attributeName}
Because: {because}
");
        }

        return frame.Value;
    }

    public static IFrame HaveElementAttributeValue(
        this ReferenceTypeAssertion<IFrame> frame,
        string selector,
        string attributeName,
        string attributeValue,
        string because = "no reason given",
        FrameQuerySelectorOptions? options = null)
    {
        var element = frame.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var value = element.GetAttribute(attributeName);

        if (value is null && string.Compare(value, attributeValue) != 0)
        {
            throw new AssertException(@$"
HaveElementAttributeValue Assert Exception
Selector: {selector}
Expected attribute: {attributeName}
Expected attribute value: {attributeValue}
Because: {because}
");
        }

        return frame.Value;
    }
}
