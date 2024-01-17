using NUnit.Framework;

using System;
namespace TestApp.Tests;

public class CountRealNumbersTests
{
    // празен вход 
    [Test]
    public void Test_Count_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        int[] input = Array.Empty<int>();

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }


    // масив с едно число 
    [Test]
    public void Test_Count_WithSingleNumber_ShouldReturnCountString()
    {

        int[] input = new int[] { 1 };

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo("1 -> 1"));
    }


    // колко пъти се срещат числата {1, 1, 5, 5, 5 ,7};
    //   ("1 -> 2\n5 -> 3\n7 -> 1"));
    [Test]
    public void Test_Count_WithMultipleNumbers_ShouldReturnCountString()
    {
        int[] input = new int[] {1, 1, 5, 5, 5 ,7};

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo("1 -> 2\n5 -> 3\n7 -> 1"));
    }


    //със отрицателни числа
    [Test]
    public void Test_Count_WithNegativeNumbers_ShouldReturnCountString()
    {
        int[] input = new int[] { -1, -1, -5, -5, -5, -7 };

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo("-1 -> 2\n-5 -> 3\n-7 -> 1"));
    }


    // тест с числото " 0 "     {0 ,0 ,0 ,0};
    //       ("0 -> 4"));
    [Test]
    public void Test_Count_WithZero_ShouldReturnCountString()
    {
        int[] input = new int[] {0 ,0 ,0 ,0};

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo("0 -> 4"));
    }
}
