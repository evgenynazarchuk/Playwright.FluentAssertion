using System;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Collections.Generic;
using Playwright.Synchronous;

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
        actual.Should().Contains("abc");
    }

    [Test]
    public void TextNotContainTest()
    {
        string actual = "abcqwerty";
        actual.Should().NotContains("123");
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