using e4.ConsoleApp;
using System;
using Xunit;

namespace e4.UnitTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_ShouldReturnZero_WhenGivenEmptyString()
        {
            // Arrange
            var input = "";

            // Act
            var result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_ShouldReturnNumber_WhenGivenSingleNumber()
        {
            // Arrange
            var input = "5";

            // Act
            var result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Add_ShouldReturnSum_WhenGivenTwoNumbersSeparatedByComma()
        {
            // Arrange
            var input = "2,3";

            // Act
            var result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Add_ShouldHandleNewLinesBetweenNumbers()
        {
            // Arrange
            var input = "1\n2,3";

            // Act
            var result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_ShouldHandleCustomDelimiters()
        {
            // Arrange
            var input = "//;\n1;2";

            // Act
            var result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_ShouldThrowException_WhenGivenNegativeNumber()
        {
            // Arrange
            var input = "-1,2,-3";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => StringCalculator.Add(input));
            Assert.Equal("Negatives not allowed: -1, -3", ex.Message);
        }
    }

}