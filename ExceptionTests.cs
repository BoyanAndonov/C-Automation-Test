using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp.UnitTests
{
    public class ExceptionTests
    {
        private Exceptions _exceptions = null!;

        [SetUp]
        public void SetUp()
        {
            this._exceptions = new();
        }

        [Test]
        public void Test_Reverse_ValidString_ReturnsReversedString()
        {
            // Arrange
            string input = "Hello";

            // Act
            string result = this._exceptions.ArgumentNullReverse(input);

            // Assert
            Assert.That(result, Is.EqualTo("olleH"));
        }

        [Test]
        public void Test_Reverse_NullString_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.That(() => this._exceptions.ArgumentNullReverse(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
        {
            // Arrange
            decimal totalPrice = 100.0m;
            decimal discount = 20.0m;

            // Act
            decimal result = this._exceptions.ArgumentCalculateDiscount(totalPrice, discount);

            // Assert
            Assert.That(result, Is.EqualTo(80.0m));
        }

        [Test]
        public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
        {
            // Arrange
            decimal totalPrice = 100.0m;
            decimal discount = -10.0m;

            // Act & Assert
            Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
        }

        [Test]
        public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
        {
            // Arrange
            decimal totalPrice = 100.0m;
            decimal discount = 110.0m;

            // Act & Assert
            Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
        }

        [Test]
        public void Test_GetElement_ValidIndex_ReturnsElement()
        {
            // Arrange
            int[] array = { 10, 20, 30 };
            int index = 1;

            // Act
            int result = this._exceptions.IndexOutOfRangeGetElement(array, index);

            // Assert
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
        {
            // Act & Assert
            Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(new int[] { 1, 2, 3 }, -1), Throws.InstanceOf<IndexOutOfRangeException>());
        }

        [Test]
        public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
        {
            // Arrange
            int[] array = { 10, 20, 30 };
            int index = array.Length;

            // Act & Assert
            Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
        }

        [Test]
        public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
        {
            // Arrange
            int[] array = { 10, 20, 30 };
            int index = array.Length + 1;

            // Act & Assert
            Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
        }

        [Test]
        public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
        {
            // Arrange
            bool isLoggedIn = true;

            // Act
            string result = this._exceptions.InvalidOperationPerformSecureOperation(isLoggedIn);

            // Assert
            Assert.That(result, Is.EqualTo("User logged in."));
        }

        [Test]
        public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
        {
            // Act & Assert
            Assert.That(() => this._exceptions.InvalidOperationPerformSecureOperation(false), Throws.InvalidOperationException.With.Message.EqualTo("User must be logged in to perform this operation."));
        }

        [Test]
        public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
        {
            // Arrange
            string input = "123";

            // Act
            int result = this._exceptions.FormatExceptionParseInt(input);

            // Assert
            Assert.That(result, Is.EqualTo(123));
        }

        [Test]
        public void Test_ParseInt_InvalidInput_ThrowsFormatException()
        {
            // Arrange
            string input = "abc";

            // Act & Assert
            Assert.That(() => this._exceptions.FormatExceptionParseInt(input), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
        {
            // Arrange
            Dictionary<string, int> dictionary = new Dictionary<string, int> { { "key", 42 } };
            string key = "key";

            // Act
            int result = this._exceptions.KeyNotFoundFindValueByKey(dictionary, key);

            // Assert
            Assert.That(result, Is.EqualTo(42));
        }

        [Test]
        public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
        {
            // Arrange
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            string key = "nonexistent";

            // Act & Assert
            Assert.That(() => this._exceptions.KeyNotFoundFindValueByKey(dictionary, key), Throws.InstanceOf<KeyNotFoundException>());
        }

        [Test]
        public void Test_AddNumbers_NoOverflow_ReturnsSum()
        {
            // Arrange
            int a = 5, b = 3;

            // Act
            int result = this._exceptions.OverflowAddNumbers(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
        {
            // Arrange
            int a = int.MaxValue - 1, b = 2;

            // Act & Assert
            Assert.That(() => this._exceptions.OverflowAddNumbers(a, b), Throws.InstanceOf<OverflowException>());
        }

        [Test]
        public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
        {
            // Arrange
            int a = int.MinValue + 1, b = -2;

            // Act & Assert
            Assert.That(() => this._exceptions.OverflowAddNumbers(a, b), Throws.InstanceOf<OverflowException>());
        }

        [Test]
        public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
        {
            // Arrange
            int dividend = 10, divisor = 2;

            // Act
            int result = this._exceptions.DivideByZeroDivideNumbers(dividend, divisor);

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

       
    }
}
