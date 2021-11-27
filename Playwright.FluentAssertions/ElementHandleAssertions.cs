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

        if (!isChecked)
        {
            throw new AssertException(@$"
BeChecked Assert Exception
Actual: not checked
Expected: checked
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

        if (isChecked)
        {
            throw new AssertException(@$"
BeNotChecked Assert Exception
Actual: checked
Expected: not checked
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

        if (!isDisabled)
        {
            throw new AssertException(@$"
BeDisabled Assert Exception
Actual: not disabled
Expected: disabled
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

        if (isDisabled)
        {
            throw new AssertException(@$"
BeNotDisabled Assert Exception
Actual: disabled
Expected: not disabled
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

        if (!isEditable)
        {
            throw new AssertException(@$"
BeEditable Assert Exception
Actual: not editable
Expected: editable
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

        if (isEditable)
        {
            throw new AssertException(@$"
BeNotEditable Assert Exception
Actual: editable
Expected: not editable
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

        if (!isEnabled)
        {
            throw new AssertException(@$"
BeEnabled Assert Exception
Actual: not enabled
Expected: enabled
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

        if (isEnabled)
        {
            throw new AssertException(@$"
BeNotEnabled Assert Exception
Actual: enabled
Expected: not enabled
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

        if (!isHidden)
        {
            throw new AssertException(@$"
BeHidden Assert Exception
Actual: not hidden
Expected: hidden
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

        if (isHidden)
        {
            throw new AssertException(@$"
BeNotHidden Assert Exception
Actual: hidden
Expected: not hidden
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

        if (!isVisible)
        {
            throw new AssertException(@$"
BeVisible Assert Exception
Actual: not visible
Expected: visible
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

        if (isVisible)
        {
            throw new AssertException(@$"
BeNotVisible Assert Exception
Actual: visible
Expected: not visible
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeTextContent(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string pattern,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var textContent = element.TextContent() ?? "";
        var match = Regex.Match(textContent, pattern, RegexOptions.Compiled);

        if (!match.Success)
        {
            throw new AssertException(@$"
BeTextContent Assert Exception
Actual text content: {textContent}
Expected pattern: {pattern}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeNotTextContent(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string pattern,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var textContent = element.TextContent() ?? "";
        var match = Regex.Match(textContent, pattern, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
BeNotTextContent Assert Exception
Actual text content: {textContent}
Not expected pattern: {pattern}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeInnerHTML(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string pattern,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var innerHTML = element.InnerHTML() ?? "";
        var match = Regex.Match(innerHTML, pattern, RegexOptions.Compiled);

        if (!match.Success)
        {
            throw new AssertException(@$"
BeInnerHTML Assert Exception
Actual inner html: {innerHTML}
Expected pattern: {pattern}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeNotInnerHTML(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string pattern,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var innerHTML = element.InnerHTML() ?? "";
        var match = Regex.Match(innerHTML, pattern, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
BeNotInnerHTML Assert Exception
Actual inner html: {innerHTML}
Not expected pattern: {pattern}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeInnerText(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string pattern,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var innerText = element.InnerText() ?? "";
        var match = Regex.Match(innerText, pattern, RegexOptions.Compiled);

        if (!match.Success)
        {
            throw new AssertException(@$"
BeInnerText Assert Exception
Actual inner html: {innerText}
Expected pattern: {pattern}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeNotInnerText(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string pattern,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var innerText = element.InnerText() ?? "";
        var match = Regex.Match(innerText, pattern, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
BeNotInnerText Assert Exception
Actual inner text: {innerText}
Not expected pattern: {pattern}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeInputValue(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string pattern,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var inputValue = element.InputValue() ?? "";
        var match = Regex.Match(inputValue, pattern, RegexOptions.Compiled);

        if (!match.Success)
        {
            throw new AssertException(@$"
BeInputValue Assert Exception
Actual input value: {inputValue}
Expected pattern: {pattern}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeNotInputValue(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string pattern,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var inputValue = element.InputValue() ?? "";
        var match = Regex.Match(inputValue, pattern, RegexOptions.Compiled);

        if (match.Success)
        {
            throw new AssertException(@$"
BeNotInputValue Assert Exception
Actual input value: {inputValue}
Not expected pattern: {pattern}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeAttribute(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string attributeName,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var attribute = element.GetAttribute(attributeName);

        if (attribute is null)
        {
            throw new AssertException(@$"
BeAttribute Assert Exception
Expected attribute: {attributeName}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeNotAttribute(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string attributeName,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var attribute = element.GetAttribute(attributeName);

        if (attribute is not null)
        {
            throw new AssertException(@$"
BeNotAttribute Assert Exception
Not expected attribute: {attributeName}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle BeAttributeValue(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string attributeName,
        string attributeValue,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var attribute = element.GetAttribute(attributeName);

        if (attribute is null || string.Compare(attribute, attributeValue) != 0)
        {
            throw new AssertException(@$"
BeAttributeValue Assert Exception
Expected attribute: {attributeName}
Expected attribute value: {attributeValue}
Because: {because}
");
        }

        return element;
    }
}
