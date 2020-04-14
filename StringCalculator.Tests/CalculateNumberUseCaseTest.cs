using NUnit.Framework;
using System;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class CalculateNumberUseCaseTest
    {
        [Test]
        public void GivenNumber_AndEmptyStringInValue_ShouldReturn0()
        {
            var calculateNumberService = new CalculateNumberService();

            //Arrange
            string numbers = "";

            //Act
            int actual = calculateNumberService.Add(numbers);
            int expected = 0;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_AndOneValue_ShouldReturn1()
        {
            var calculateNumberService = new CalculateNumberService();

            //Arrange
            string numbers = "1";

            //Act
            int actual = calculateNumberService.Add(numbers);
            int expected = 1;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_AndMultipleValues_ShouldReturn3()
        {
            var calculateNumberService = new CalculateNumberService();

            //Arrange
            string numbers = "1, 2";

            //Act
            int actual = calculateNumberService.Add(numbers);
            int expected = 3;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_AndNewLineInValue_ShouldReturn6()
        {
            var calculateNumberService = new CalculateNumberService();

            //Arrange
            string numbers = "1\n2,3";

            //Act
            int actual = calculateNumberService.Add(numbers);
            int expected = 6;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_AndCustomDelimiterInValue_ShouldReturn6()
        {
            var calculateNumberService = new CalculateNumberService();

            //Arrange
            string numbers = ";\n1;2;3";

            //Act
            int actual = calculateNumberService.Add(numbers);
            int expected = 6;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_AndNegativeValue_ShouldReturnException()
        {
            var calculateNumberService = new CalculateNumberService();

            //Arrange
            string numbers = "-1, -2, 3";

            //Assert
            Assert.Throws<Exception>(() => calculateNumberService.Add(numbers));
        }

        [Test]
        public void GivenNumber_AndValueLargerThan1000_ShouldReturn2()
        {
            var calculateNumberService = new CalculateNumberService();

            //Arrange
            string numbers = "1001, 2";

            //Act
            int actual = calculateNumberService.Add(numbers);
            int expected = 2;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_AndDelimiterOfAnyLength_ShouldReturn6()
        {
            var calculateNumberService = new CalculateNumberService();

            //Arrange
            string numbers = "[***]\n1***2***3";

            //Act
            int actual = calculateNumberService.Add(numbers);
            int expected = 6;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_AndMultipleDelimiters_ShouldReturn6()
        {
            var calculateNumberService = new CalculateNumberService();

            //Arrange
            string numbers = "[*][%]\n1*2%3";

            //Act
            int actual = calculateNumberService.Add(numbers);
            int expected = 6;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}