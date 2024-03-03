using NUnit.Framework;

using System;
namespace TestApp.Tests;

public class OddOccurrencesTests
{
    [Test]
    public void Test_FindOdd_WithEmptyArray_ShouldReturnEmptyString()
    {
        string[] input = Array.Empty<string>();

        // Act
        string result = OddOccurrences.FindOdd(input);

        // Assert
        Assert.That(result, Is.Empty);
    }



    // OddOccurrences.FindOdd, когато входният масив
    // не съдържа думи с нечетен брой срещания  { "the", "the" }; думите са две
    [Test]
    public void Test_FindOdd_WithNoOddOccurrences_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = new string[] { "the", "the" };

        // Act
        string result = OddOccurrences.FindOdd(input);

        // Assert
        Assert.That(result, Is.Empty);
    }


    //OddOccurrences.FindOdd правилно връща думата с нечетен брой срещания
    //във входния масив.Ако този е очакваният резултат, тестът ще бъде успешен
    //в противен случай той ще бъде неуспешен
    [Test]
    public void Test_FindOdd_WithSingleOddOccurrence_ShouldReturnTheOddWord()
    {
        // Arrange
        string[] input = new string[] { "the", "the", "the" };

        // Act
        string result = OddOccurrences.FindOdd(input);

        // Assert
        Assert.That(result, Is.EqualTo("the"));
    }



    // OddOccurrences.FindOdd правилно връща всички думи с нечетен брой срещания
    // във входния масив. Ако всички думи с нечетен брой срещания са
    // очаквания резултат, тестът ще бъде успешен;
    // в противен случай той ще бъде неуспешен
    [Test]
    public void Test_FindOdd_WithMultipleOddOccurrences_ShouldReturnAllOddWords()
    {
        // Arrange
        string[] input = new string[] { "the", "the", "the", "that", "a", "a", "a", "on", "on" };

        // Act
        string result = OddOccurrences.FindOdd(input);

        // Assert
        Assert.That(result, Is.EqualTo("the that a"));



    }
    //  теста  връща само малки букви независимо че са му подадени и големи
    // { "the", "The", "tHe", "thAt", "a", "A", "a", "on", "on" };

    // ("the that a"));
    [Test]
    public void Test_FindOdd_WithMixedCaseWords_ShouldBeCaseInsensitive()
    {
        // Подготвяне
        string[] input = new string[] { "the", "The", "tHe", "thAt", "a", "A", "a", "on", "on" };

        // Извикване на метода
        string result = OddOccurrences.FindOdd(input);

        // Проверка
        Assert.That(result, Is.EqualTo("the that a"));


    }
}
