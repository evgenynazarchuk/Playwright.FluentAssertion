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
        string pattern,
        string because = "no reason given")
    {
        var title = page.Value.Title();
        var match = Regex.Match(title, pattern, RegexOptions.Compiled);

        if (!match.Success)
        {
            throw new AssertException(@$"
HaveTitle Assert Exception
Expected: {title}
Actual: {pattern}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveNotTitle(
        this ReferenceTypeAssertion<IPage> page,
        string pattern,
        string because = "no reason given")
    {
        var title = page.Value.Title();
        var match = Regex.Match(title, pattern, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotTitle Assert Exception
Actual: {title}
Not expected pattern: {pattern}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveContent(
        this ReferenceTypeAssertion<IPage> page,
        string pattern,
        string because = "no reason given")
    {
        var content = page.Value.Content();
        var match = Regex.Match(content, pattern, RegexOptions.Compiled);

        if (!match.Success)
        {
            throw new AssertException(@$"
HaveContent Assert Exception
Actual: {content}
Expected pattern: {pattern}
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
Actual: {content}
Not expected pattern: {pattern}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveElementChecked(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
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

        return page.Value;
    }

    public static IPage HaveNotElementChecked(
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

    public static IPage HaveElementDisabled(
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

    public static IPage HaveNotElementDisabled(
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

    public static IPage HaveElementEditable(
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

    public static IPage HaveNotElementEditable(
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

    public static IPage HaveElementEnabled(
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

    public static IPage HaveNotElementEnabled(
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

    public static IPage HaveElementHidden(
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

    public static IPage HaveNotElementHidden(
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

    public static IPage HaveElementVisible(
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

    public static IPage HaveNotElementVisible(
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
        string pattern,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
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

        return page.Value;
    }

    public static IPage HaveNotElementTextContent(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string pattern,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
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

        return page.Value;
    }

    public static IPage HaveElementInnerHTML(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string pattern,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
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

        return page.Value;
    }

    public static IPage HaveNotElementInnerHTML(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string pattern,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
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

        return page.Value;
    }

    public static IPage HaveElementInnerText(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string pattern,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
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

        return page.Value;
    }

    public static IPage HaveNotElementInnerText(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string pattern,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var innerHtml = element.InnerText() ?? "";
        var match = Regex.Match(innerHtml, pattern, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
HaveNotElementInnerText Assert Exception
Selector: {selector}
Actual inner text: {innerHtml}
Not expected pattern: {pattern}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveElementInputValue(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string pattern,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
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

        return page.Value;
    }

    public static IPage HaveNotElementInputValue(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string pattern,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
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
        if (element is null) throw new AssertException($"Element not found. Selector {selector}");

        var attribute = element.GetAttribute(attributeName);

        if (attribute is not null)
        {
            throw new AssertException(@$"
HaveNotElementAttribute Assert Exception
Selector: {selector}
Not expected attribute: {attributeName}
Because: {because}
");
        }

        return page.Value;
    }

    public static IPage HaveElementAttributeValue(
        this ReferenceTypeAssertion<IPage> page,
        string selector,
        string attributeName,
        string attributeValue,
        string because = "no reason given",
        PageQuerySelectorOptions? options = null)
    {
        var element = page.Value.QuerySelector(selector, options);
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

        return page.Value;
    }
}
