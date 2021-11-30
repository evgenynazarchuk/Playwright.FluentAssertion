using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Playwright.Synchronous;

namespace Playwright.FluentAssertions.Tests;

public class ElementHandleTests : PageTest
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
    public void HaveAttributeWhenCorrect()
    {
        Page.QuerySelector("div")!
            .Should().HaveAttribute("disable");
    }

    [Test]
    public void HaveAttributeWhenIncorrectValue()
    {
        var ex = Assert.Catch(() =>
        {
            Page.QuerySelector("div")!
                .Should().HaveAttribute("enable");
        });

        Assert.AreEqual(@"
HaveAttribute Assert Exception
Expected attribute: enable
Because: no reason given
", ex?.Message);
    }

    [Test]
    public void HaveNotAttributeWhenCorrect()
    {
        Page.QuerySelector("div")!
            .Should().HaveNotAttribute("enable");
    }

    [Test]
    public void HaveNotAttributeWhenAttributeExist()
    {
        var ex = Assert.Catch(() =>
        {
            Page.QuerySelector("div")!
                .Should().HaveNotAttribute("disable");
        });

        Assert.AreEqual(@"
HaveNotAttribute Assert Exception
Not expected attribute: disable
Because: no reason given
", ex?.Message);
    }

    [Test]
    public void HaveAttributeValueWhenCorrectEmptyValue()
    {
        Page.QuerySelector("div")!
            .Should().HaveAttributeValue("disable", "");
    }

    [Test]
    public void HaveAttributeValueWhenCorrectValue()
    {
        Page.QuerySelector("body")!
            .Should().HaveAttributeValue("style", "color:#F3F3F3;font-family:monospace");
    }

    [Test]
    public void HaveAttributeValueWhenAttributeNotFound()
    {
        var ex = Assert.Catch(() =>
        {
            Page.QuerySelector("div")!
                .Should().HaveAttributeValue("notexist", "");
        });

        Assert.AreEqual("Attribute not found. Attibute name: notexist", ex?.Message);
    }

    [Test]
    public void HaveAttributeValueWhenIncorrectValue()
    {
        var ex = Assert.Catch(() =>
        {
            Page.QuerySelector("body")!
                .Should().HaveAttributeValue("style", "color:#F1F1F1");
        });

        Assert.AreEqual(@"
HaveAttributeValue Assert Exception
Attribute name: style
Expected attribute value: color:#F1F1F1
Actual attribute value: color:#F3F3F3;font-family:monospace
Because: no reason given
", ex?.Message);
    }

    [Test]
    public void HaveComputedStyleWhenCorrect()
    {
        Page.QuerySelector("body")!
            .Should().HaveComputedStyle("color", "rgb(243, 243, 243)")
            .Should().HaveComputedStyle("fontFamily", "monospace");
    }

    [Test]
    public void HaveComputedStyleWhenIncorrectValue()
    {
        var ex = Assert.Catch(() =>
        {
            Page.QuerySelector("body")!
                .Should().HaveComputedStyle("fontFamily", "Arial");
        });

        Assert.AreEqual(@"
HaveComputedStyle Assert Exception
Style name: fontFamily
Expected style value: Arial
Actual style value: monospace
Because: no reason given
", ex?.Message);
    }

    [Test]
    public void HaveComputedStyleWhenStyleNotFound()
    {
        var ex = Assert.Catch(() =>
        {
            Page.QuerySelector("body")!
                .Should().HaveComputedStyle("center", "");
        });

        Assert.AreEqual("Style not found. Style name: center", ex?.Message);
    }
}