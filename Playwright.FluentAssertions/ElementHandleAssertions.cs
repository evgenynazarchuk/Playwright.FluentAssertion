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
        string pattern,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var textContent = element.TextContent() ?? "";
        var match = Regex.Match(textContent, pattern, RegexOptions.Compiled);

        if (match.Success is false)
        {
            throw new AssertException(@$"
HaveTextContent Assert Exception
Actual text content: {textContent}
Expected pattern: {pattern}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle HaveNotTextContent(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string pattern,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var textContent = element.TextContent() ?? "";
        var match = Regex.Match(textContent, pattern, RegexOptions.Compiled);

        if (match.Success is true)
        {
            throw new AssertException(@$"
HaveNotTextContent Assert Exception
Actual text content: {textContent}
Not expected pattern: {pattern}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle HaveInnerHTML(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string pattern,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var innerHTML = element.InnerHTML() ?? "";
        var match = Regex.Match(innerHTML, pattern, RegexOptions.Compiled);

        if (match.Success is false)
        {
            throw new AssertException(@$"
HaveInnerHTML Assert Exception
Actual inner html: {innerHTML}
Expected pattern: {pattern}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle HaveNotInnerHTML(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string pattern,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var innerHTML = element.InnerHTML() ?? "";
        var match = Regex.Match(innerHTML, pattern, RegexOptions.Compiled);

        if (match.Success is true)
        {
            throw new AssertException(@$"
HaveNotInnerHTML Assert Exception
Actual inner html: {innerHTML}
Not expected pattern: {pattern}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle HaveInnerText(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string pattern,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var innerText = element.InnerText() ?? "";
        var match = Regex.Match(innerText, pattern, RegexOptions.Compiled);

        if (match.Success is false)
        {
            throw new AssertException(@$"
HaveInnerText Assert Exception
Actual inner html: {innerText}
Expected pattern: {pattern}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle HaveNotInnerText(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string pattern,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var innerText = element.InnerText() ?? "";
        var match = Regex.Match(innerText, pattern, RegexOptions.Compiled);

        if (match.Success is true)
        {
            throw new AssertException(@$"
HaveNotInnerText Assert Exception
Actual inner text: {innerText}
Not expected pattern: {pattern}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle HaveInputValue(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string pattern,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var inputValue = element.InputValue() ?? "";
        var match = Regex.Match(inputValue, pattern, RegexOptions.Compiled);

        if (match.Success is false)
        {
            throw new AssertException(@$"
HaveInputValue Assert Exception
Actual input value: {inputValue}
Expected pattern: {pattern}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle HaveNotInputValue(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string pattern,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var inputValue = element.InputValue() ?? "";
        var match = Regex.Match(inputValue, pattern, RegexOptions.Compiled);

        if (match.Success is true)
        {
            throw new AssertException(@$"
HaveNotInputValue Assert Exception
Actual input value: {inputValue}
Not expected pattern: {pattern}
Because: {because}
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

        try
        {
            element.GetAttribute(attributeName);
        }
        catch
        {
            throw new AssertException(@$"
HaveAttribute Assert Exception
Expected attribute: {attributeName}
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

        try
        {
            element.GetAttribute(attributeName);
        }
        catch 
        {
            return elementHandle.Value;
        }

        throw new AssertException(@$"
HaveNotAttribute Assert Exception
Not expected attribute: {attributeName}
Because: {because}
");
    }

    public static IElementHandle HaveAttributeValue(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string attributeName,
        string expectedAttributeValue,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
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
HaveAttributeValue Assert Exception
Attribute name: {attributeName}
Expected attribute value: {expectedAttributeValue}
Actual attribute value: {actualAttributeValue}
Because: {because}
");
        }

        return element;
    }

    public static IElementHandle HaveComputedStyle(
        this ReferenceTypeAssertion<IElementHandle> elementHandle,
        string styleName,
        string expectedStyleValue,
        string because = "no reason given")
    {
        var element = elementHandle.Value;
        var actualStyleValue = element.Evaluate($"e => getComputedStyle(e).{styleName}", element).ToString();

        if (actualStyleValue == "")
        {
            throw new AssertException($"Style not found. Style name: {styleName}");
        }

        if (string.Compare(actualStyleValue, expectedStyleValue) != 0)
        {
            throw new AssertException($@"
HaveComputedStyle Assert Exception
Style name: {styleName}
Expected style value: {expectedStyleValue}
Actual style value: {actualStyleValue}
Because: {because}
");
        }

        return elementHandle.Value;
    }
}
