using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Playwright.Synchronous;

namespace Playwright.FluentAssertions.Tests;

public class PageTests : PageTest
{
    [SetUp]
    public void SetUp()
    {
        Page.SetContent(@"
<html>
    <body style='color:#F3F3F3;font-family:monospace'>
        <div disable></div>
    </body>
</html>
");
    }

    [Test]
    public void HaveElementAttributeWhenCorrect()
    {
        Page.Should().HaveElementAttribute("div", "disable");
    }

    [Test]
    public void HaveElementAttributeWhenNotFoundElement()
    {
        var ex = Assert.Catch(() =>
        {
            Page.Should().HaveElementAttribute("#notfound", "enable");
        });

        Assert.AreEqual("Element not found. Selector: #notfound", ex?.Message);
    }

    [Test]
    public void HaveElementAttributeWhenIncorrectValue()
    {
        var ex = Assert.Catch(() =>
        {
            Page.Should().HaveElementAttribute("div", "enable");
        });

        Assert.AreEqual(@"
HaveElementAttribute Assert Exception
Selector: div
Expected attribute: enable
Because: no reason given
", ex?.Message);
    }

    [Test]
    public void HaveNotElementAttributeWhenCorrect()
    {
        Page.Should().HaveNotElementAttribute("div", "enable");
    }

    [Test]
    public void HaveNotElementAttributeWhenIncorrectValue()
    {
        var ex = Assert.Catch(() =>
        {
            Page.Should().HaveNotElementAttribute("div", "disable");
        });

        Assert.AreEqual(@"
HaveNotElementAttribute Assert Exception
Selector: div
Not expected attribute: disable
Because: no reason given
", ex?.Message);
    }

    [Test]
    public void HaveNotElementAttributeWhenElementNotFound()
    {
        var ex = Assert.Catch(() =>
        {
            Page.Should().HaveNotElementAttribute("#notfound", "");
        });

        Assert.AreEqual(@"Element not found. Selector: #notfound", ex?.Message);
    }

    [Test]
    public void HaveElementAttributeValueWhenCorrectEmptyValue()
    {
        Page.Should().HaveElementAttributeValue("div", "disable", "");
    }

    [Test]
    public void HaveElementAttributeValueWhenCorrectValue()
    {
        Page.Should().HaveElementAttributeValue("body", "style", "color:#F3F3F3;font-family:monospace");
    }

    [Test]
    public void HaveElementAttributeValueWhenElementNotFound()
    {
        var ex = Assert.Catch(() =>
        {
            Page.Should().HaveElementAttributeValue("#notfound", "disable", "");
        });

        Assert.AreEqual("Element not found. Selector: #notfound", ex?.Message);
    }

    [Test]
    public void HaveElementAttributeValueWhenAttributeNotFound()
    {
        var ex = Assert.Catch(() =>
        {
            Page.Should().HaveElementAttributeValue("div", "enable", "");
        });

        Assert.AreEqual("Attribute not found. Attibute name: enable", ex?.Message);
    }

    [Test]
    public void HaveElementAttributeValueWhenIncorrectValue()
    {
        var ex = Assert.Catch(() =>
        {
            Page.Should().HaveElementAttributeValue("body", "style", "color:black");
        });

        Assert.AreEqual(@"
HaveElementAttributeValue Assert Exception
Selector: body
Expected attribute: style
Expected attribute value: color:black
Actual attribute value: color:#F3F3F3;font-family:monospace
Because: no reason given
", ex?.Message);
    }

    [Test]
    public void HaveElementComputedStyleWhenCorrect()
    {
        Page.Should().HaveElementComputedStyle("body", "color", "rgb(243, 243, 243)");
    }

    [Test]
    public void HaveElementComputedStyleWhenIncorrectValue()
    {
        var ex = Assert.Catch(() =>
        {
            Page.Should().HaveElementComputedStyle("body", "color", "rgb(60, 60, 60)");
        });

        Assert.AreEqual(@"
HaveComputedStyle Assert Exception
Selector: body
Style name: color
Expected style value: rgb(60, 60, 60)
Actual style value: rgb(243, 243, 243)
Because: no reason given
", ex?.Message);
    }

    [Test]
    public void HaveElementComputedStyleWhenNotFoundElement()
    {
        var ex = Assert.Catch(() =>
        {
            Page.Should().HaveElementComputedStyle("#notfound", "color", "rgb(243, 243, 243)");
        });

        Assert.AreEqual("Element not found. Selector: #notfound", ex?.Message);
    }

    [Test]
    public void HaveElementComputedStyleWhenNotFoundStyle()
    {
        var ex = Assert.Catch(() =>
        {
            Page.Should().HaveElementComputedStyle("body", "center", "");
        });

        Assert.AreEqual("Style not found. Style name: center", ex?.Message);
    }
}