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

using NUnit.Framework;
using System.Collections.Generic;

namespace Playwright.FluentAssertions.Tests;

public class PritimitivesTests
{
    [Test]
    public void ListContainTest()
    {
        List<string> list = new() { "aaa", "abc", "cba" };
        list.Should().Contains("abc");
    }

    [Test]
    public void ListNotContainTest()
    {
        List<string> list = new() { "aaa", "abc", "cba" };
        list.Should().NotContains("ccc");
    }

    [Test]
    public void TextContainTest()
    {
        string actual = "abcqwerty";
        actual.Should().Contain("abc");
    }

    [Test]
    public void TextNotContainTest()
    {
        string actual = "abcqwerty";
        actual.Should().NotContain("123");
    }

    [Test]
    public void EnumBeTest()
    {
        SampleEnumData d1 = SampleEnumData.First;
        SampleEnumData d2 = SampleEnumData.First;

        d1.Should().Be(d2);
    }

    [Test]
    public void EnumBeNotTest()
    {
        SampleEnumData d1 = SampleEnumData.First;
        SampleEnumData d2 = SampleEnumData.Second;

        d1.Should().BeNot(d2);
    }

    protected enum SampleEnumData
    {
        First,
        Second
    }
}