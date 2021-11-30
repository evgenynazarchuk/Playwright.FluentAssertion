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

        if (isChecked is false)
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

        if (isChecked is true)
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

        if (isDisabled is false)
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

        if (isDisabled is true)
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

        if (isEditable is false)
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

        if (isEditable is true)
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

        if (isEnabled is false)
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

        if (isEnabled is true)
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

        if (isHidden is false)
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

        if (isHidden is true)
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

        if (isVisible is false)
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

        if (isVisible is true)
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

    public static ILocator HaveTextContent(
        this ReferenceTypeAssertion<ILocator> locator,
        string expected,
        string because = "no reason given")
    {
        var element = locator.Value;
        var actual = element.TextContent() ?? "";

        if (string.Compare(actual, expected) != 0)
        {
            throw new AssertException(@$"
BeTextContent Assert Exception
Actual:
{actual}
Expected:
{expected}
Because:
{because}
");
        }

        return element;
    }

    public static ILocator HaveNotTextContent(
        this ReferenceTypeAssertion<ILocator> locator,
        string notExpected,
        string because = "no reason given")
    {
        var element = locator.Value;
        var actual = element.TextContent() ?? "";

        if (string.Compare(actual, notExpected) == 0)
        {
            throw new AssertException(@$"
BeNotTextContent Assert Exception
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

    public static ILocator HaveInnerHTML(
        this ReferenceTypeAssertion<ILocator> locator,
        string expected,
        string because = "no reason given")
    {
        var element = locator.Value;
        var actual = element.InnerHTML() ?? "";

        if (string.Compare(actual, expected) != 0)
        {
            throw new AssertException(@$"
BeInnerHTML Assert Exception
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

    public static ILocator HaveNotInnerHTML(
        this ReferenceTypeAssertion<ILocator> locator,
        string notExpected,
        string because = "no reason given")
    {
        var element = locator.Value;
        var actual = element.InnerHTML() ?? "";

        if (string.Compare(actual, notExpected) == 0)
        {
            throw new AssertException(@$"
BeNotInnerHTML Assert Exception
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

    public static ILocator HaveInnerText(
        this ReferenceTypeAssertion<ILocator> locator,
        string expected,
        string because = "no reason given")
    {
        var element = locator.Value;
        var actual = element.InnerText() ?? "";

        if (string.Compare(actual, expected) != 0)
        {
            throw new AssertException(@$"
BeInnerText Assert Exception
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

    public static ILocator HaveNotInnerText(
        this ReferenceTypeAssertion<ILocator> locator,
        string notExpected,
        string because = "no reason given")
    {
        var element = locator.Value;
        var actual = element.InnerText() ?? "";

        if (string.Compare(actual, notExpected) == 0)
        {
            throw new AssertException(@$"
BeNotInnerText Assert Exception
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

    public static ILocator HaveInputValue(
        this ReferenceTypeAssertion<ILocator> locator,
        string expected,
        string because = "no reason given")
    {
        var element = locator.Value;
        var actual = element.InputValue() ?? "";

        if (string.Compare(actual, expected) != 0)
        {
            throw new AssertException(@$"
BeInputValue Assert Exception
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

    public static ILocator HaveNotInputValue(
        this ReferenceTypeAssertion<ILocator> locator,
        string notExpected,
        string because = "no reason given")
    {
        var element = locator.Value;
        var actual = element.InputValue() ?? "";

        if (string.Compare(actual, notExpected) == 0)
        {
            throw new AssertException(@$"
BeNotInputValue Assert Exception
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

    public static ILocator HaveAttribute(
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

    public static ILocator HaveNotAttribute(
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

    public static ILocator HaveAttributeValue(
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

    public static ILocator HaveComputedStyle(
        this ReferenceTypeAssertion<ILocator> locator,
        string styleName,
        string expectedStyleValue,
        string because = "no reason given")
    {
        var element = locator.Value;
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

        return locator.Value;
    }
}
