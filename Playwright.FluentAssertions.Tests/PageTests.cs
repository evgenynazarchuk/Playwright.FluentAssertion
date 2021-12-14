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

using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Playwright.Synchronous;

namespace Playwright.FluentAssertions.Tests;

public class PageTests : PageTest
{
    [SetUp]
    public void SetUp()
    {
        Page.SetDefaultTimeout(2000);
        Page.SetContent(@"
<html>
    <body style='color:#F3F3F3;font-family:monospace'>
        <div disabled>Hello</div>
    </body>
</html>
");
    }

    [Test]
    public void HaveElementAttributeWhenCorrect()
    {
        Page.Should().HaveElementAttribute("div", "disabled");
    }

    [Test]
    public void HaveElementAttributeWhenNotFoundElement()
    {
        var ex = Assert.Catch(() =>
        {
            Page.Should().HaveElementAttribute("#notfound", "enable");
        });

        ex?.Message.Should().Contain("Timeout 2000ms exceeded");
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
            Page.Should().HaveNotElementAttribute("div", "disabled");
        });

        Assert.AreEqual(@"
HaveNotElementAttribute Assert Exception
Selector: div
Not expected attribute: disabled
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

        ex?.Message.Should().Contain("Timeout 2000ms exceeded");
    }

    [Test]
    public void HaveElementAttributeValueWhenCorrectEmptyValue()
    {
        Page.Should().HaveElementAttributeValue("div", "disabled", "");
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
            Page.Should().HaveElementAttributeValue("#notfound", "disabled", "");
        });

        ex?.Message.Should().Contain("Timeout 2000ms exceeded");
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
HaveElementComputedStyle Assert Exception
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

        ex?.Message.Should().Contain("Timeout 2000ms exceeded");
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