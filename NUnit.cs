using NUnit.Framework;

using System.Collections.Generic;
namespace TestApp.UnitTests;

public class MatchUrlsTests
{
    
    [Test]
    public void Test_ExtractUrls_EmptyText_ReturnsEmptyList()
    {
        // Arrange
        string text = "";

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish the test
    [Test]
    public void Test_ExtractUrls_NoUrlsInText_ReturnsEmptyList()
    {
        // Arrange
        string text = "This is a text without any URLs.";

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_ExtractUrls_SingleUrlInText_ReturnsSingleUrl()
    {
        // Arrange
        string text = "Visit my website at https://www.example.com";
        string expected = "https://www.example.com";
        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0], Is.EqualTo("https://www.example.com"));
    }

    [Test]
    public void Test_ExtractUrls_MultipleUrlsInText_ReturnsAllUrls()
    {
        // Arrange
        string text = "Check out these websites: https://www.example1.com. and http://www.example2.com";

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.That(result, Contains.Item("https://www.example1.com"));
        Assert.That(result, Contains.Item("http://www.example2.com"));
    }


    [Test]
    public void Test_ExtractUrls_UrlsInQuotationMarks_ReturnsUrlsInQuotationMarks()
    {
        // Arrange
        string text = "Links in quotes: \"https://www.example1.com\" and \"http://www.example2.com\"";

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.That(result, Contains.Item("https://www.example1.com"));
        Assert.That(result, Contains.Item("http://www.example2.com"));
    }

}
