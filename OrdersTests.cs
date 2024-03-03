using System;
using NUnit.Framework;
namespace TestApp.Tests;

public class OrdersTests
{
    [Test]
    public void Test_Order_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] products = new string[] { };

        // Act
        string result = ("");

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    // TODO: finish test
    [Test]
    public void Test_Order_WithMultipleOrders_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new string[]
        {
        "apple 1.99 3",
        "banana 0.75 5",
        "orange 0.99 2"
        };

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.AreEqual($"apple -> 5.97{Environment.NewLine}banana -> 3.75{Environment.NewLine}orange -> 1.98", result);


        
    }


    [Test]
    public void Test_Order_WithRoundedPrices_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new string[]
        {
        "apple 1.99 3",
        "banana 0.75 5",
        "orange 0.99 2"
        };

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.AreEqual($"apple -> 5.97{Environment.NewLine}banana -> 3.75{Environment.NewLine}orange -> 1.98", result);
    }



    [Test]
    public void Test_Order_WithDecimalQuantities_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new string[]
        {
        "apple 1.99 3.5",
        "banana 0.75 2.5",
        "orange 0.99 1.5"
        };

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.AreEqual($"apple -> 6.97{Environment.NewLine}banana -> 1.88{Environment.NewLine}orange -> 1.49", result);
    }
}
