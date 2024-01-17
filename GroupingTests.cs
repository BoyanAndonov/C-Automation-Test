using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class GroupingTests    //тест с зетни и нечетни числа

{
    //  лист с пеазен  стринг 
    [Test]
    public void Test_GroupNumbers_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> input = new ();

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.Empty);

    }


    // тест с четни и нечетни числа   { 1, 2, 3, 4 };
    //     ("Odd numbers: 1, 3\nEven numbers: 2, 4"));
    [Test]
    public void Test_GroupNumbers_WithEvenAndOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new() { 1, 2, 3, 4 };

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.EqualTo("Odd numbers: 1, 3\nEven numbers: 2, 4"));


    }


    //само с четни числа {2, 4, 6 };
    //("Even numbers: 2, 4, 6"));
    [Test]
    public void Test_GroupNumbers_WithOnlyEvenNumbers_ShouldReturnGroupedString()
    {

        // Arrange
        List<int> input = new() {2, 4, 6 };

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.EqualTo("Even numbers: 2, 4, 6"));
    }


    // с нечетни числа { 1, 3, 5 };
    //  ("Odd numbers: 1, 3, 5"));
    [Test]
    public void Test_GroupNumbers_WithOnlyOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new() { 1, 3, 5 };

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.EqualTo("Odd numbers: 1, 3, 5"));

    }

    [Test]
    public void Test_GroupNumbers_WithNegativeNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new() {-1 ,-2 ,-3 ,-4 };

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.EqualTo("Odd numbers: -1, -3\nEven numbers: -2, -4"));
    }
}
