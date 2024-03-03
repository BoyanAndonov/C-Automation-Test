using NUnit.Framework;

using System;
namespace TestApp.Tests;

public class PlantsTests
{
    [Test]
    public void Test_GetFastestGrowing_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] plants = new string[] { };

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.AreEqual(string.Empty, result);

    }

    // TODO: finish test
    [Test]
    public void Test_GetFastestGrowing_WithSinglePlant_ShouldReturnPlant()
    {
        // Arrange
        string[] plants = new string[] { "rosses" };

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.AreEqual("Plants with 6 letters:\nrosses", result);
    }

    [Test]
    public void Test_GetFastestGrowing_WithMultiplePlants_ShouldReturnGroupedPlants()
    {
        // Arrange
        string[] plants = new string[] { "Rose", "Lily", "Fern", "Aloe", "Maple" };

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        string expected = "Plants with 4 letters:\nRose\nLily\nFern\nAloe\n" +
                          "Plants with 5 letters:\nMaple";
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetFastestGrowing_WithMixedCasePlants_ShouldBeCaseInsensitive()
    {
        
    }
}

