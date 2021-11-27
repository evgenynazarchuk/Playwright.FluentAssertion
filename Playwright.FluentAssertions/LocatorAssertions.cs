using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Playwright.Synchronous;

namespace Playwright.FluentAssertions;

public static class LocatorAssertions
{
    public static ReferenceTypeAssertion<ILocator> Should(this ILocator locator)
    {
        return new ReferenceTypeAssertion<ILocator>(locator);
    }

    public static ILocator BeChecked(
        this ReferenceTypeAssertion<ILocator> locator,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeNotChecked(
        this ReferenceTypeAssertion<ILocator> locator,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeDisabled(
        this ReferenceTypeAssertion<ILocator> locator,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeNotDisabled(
        this ReferenceTypeAssertion<ILocator> locator,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeEditable(
        this ReferenceTypeAssertion<ILocator> locator,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeNotEditable(
        this ReferenceTypeAssertion<ILocator> locator,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeEnabled(
        this ReferenceTypeAssertion<ILocator> locator,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeNotEnabled(
        this ReferenceTypeAssertion<ILocator> locator,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeHidden(
        this ReferenceTypeAssertion<ILocator> locator,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeNotHidden(
        this ReferenceTypeAssertion<ILocator> locator,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeVisible(
        this ReferenceTypeAssertion<ILocator> locator,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeNotVisible(
        this ReferenceTypeAssertion<ILocator> locator,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeTextContent(
        this ReferenceTypeAssertion<ILocator> locator,
        string pattern,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeNotTextContent(
        this ReferenceTypeAssertion<ILocator> locator,
        string pattern,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeInnerHTML(
        this ReferenceTypeAssertion<ILocator> locator,
        string pattern,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeNotInnerHTML(
        this ReferenceTypeAssertion<ILocator> locator,
        string pattern,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeInnerText(
        this ReferenceTypeAssertion<ILocator> locator,
        string pattern,
        string because = "no reason given")
    {
        var element = locator.Value;
        var innerText = element.InnerText() ?? "";
        var match = Regex.Match(innerText, pattern, RegexOptions.Compiled);

        if (!match.Success)
        {
            throw new AssertException(@$"
BeInnerText Assert Exception
Actual inner text: {innerText}
Expected pattern: {pattern}
Because: {because}
");
        }

        return element;
    }

    public static ILocator BeNotInnerText(
        this ReferenceTypeAssertion<ILocator> locator,
        string pattern,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeInputValue(
        this ReferenceTypeAssertion<ILocator> locator,
        string pattern,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeNotInputValue(
        this ReferenceTypeAssertion<ILocator> locator,
        string pattern,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeAttribute(
        this ReferenceTypeAssertion<ILocator> locator,
        string attributeName,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeNotAttribute(
        this ReferenceTypeAssertion<ILocator> locator,
        string attributeName,
        string because = "no reason given")
    {
        var element = locator.Value;
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

    public static ILocator BeAttributeValue(
        this ReferenceTypeAssertion<ILocator> locator,
        string attributeName,
        string attributeValue,
        string because = "no reason given")
    {
        var element = locator.Value;
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
