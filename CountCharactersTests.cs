using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Tests
{
    [TestFixture]
    public class CountCharactersTests
    {
        [Test]
        public void Test_Count_WithEmptyList_ShouldReturnEmptyString()
        {
            // Arrange
            List<string> input = new List<string>();

            // Act
            string result = CountCharacters.Count(input);

            // Assert
            Assert.That(result, Is.Empty);
        }

        // списък от стрингове които са празни
        [Test]
        public void Test_Count_WithNoCharacters_ShouldReturnEmptyString()
        {
            // Arrange
            List<string> input = new List<string> { " ", " ", " ", " " };

            // Act
            string result = CountCharacters.Count(input);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Test_Count_WithSingleCharacter_ShouldReturnCountString()
        {
            // Arrange
            List<string> input = new List<string> { "aaa", "aa", "a" };

            // Act
            string result = CountCharacters.Count(input);

            // Assert
            Assert.That(result, Is.EqualTo("a -> 6"));
        }

        [Test]
        public void Test_Count_WithMultipleCharacters_ShouldReturnCountString()
        {
            // Arrange
            List<string> input = new List<string> { "aaa", "aabb", "accc" };

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("a -> 6");
            sb.AppendLine("b -> 2");
            sb.AppendLine("c -> 3");
            string expected = sb.ToString().Trim();

            // Act
            string result = CountCharacters.Count(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Count_WithSpecialCharacters_ShouldReturnCountString()
        {
            // Arrange
            List<string> input = new List<string> { "@@@", "$$@", "!!!%%" };

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("@ -> 4");
            sb.AppendLine("$ -> 2");
            sb.AppendLine("! -> 3");
            sb.AppendLine("% -> 2"); // Corrected: removed one '%' from the expected result
            string expected = sb.ToString().Trim();

            // Act
            string result = CountCharacters.Count(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
