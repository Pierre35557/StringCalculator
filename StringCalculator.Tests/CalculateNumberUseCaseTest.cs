using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class CalculateNumberUseCaseTest
    {
        [Test]
        public void GivenNumber_AndEmptyStringInValue_ShouldReturn0()
        {
            //Arrange
            string numbers = "";

            //Act
            int expected = 0;
            int actual = Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_AndOneValue_ShouldReturn1()
        {
            //Arrange
            string numbers = "1";

            //Act
            int expected = 1;
            int actual = Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_AndMultipleValues_ShouldReturn3()
        {
            //Arrange
            string numbers = "1,2";

            //Act
            int expected = 3;
            int actual = Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_AndNewLineBetweenValues_ShouldReturn6()
        {
            //Arrange
            string numbers = "1\n2,3";

            //Act
            int expected = 6;
            int actual = Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_AndCustomDelimiterInValue_ShouldReturn3()
        {
            //Arrange
            string numbers = ";\n1;2";

            //Act
            int expected = 3;
            int actual = Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_AndNegativeValues_ShouldReturnException()
        {
            //Arrange
            string numbers = "-1";

            //Assert
            Assert.Throws<Exception>(() => Add(numbers));
        }

        [Test]
        public void GivenNumber_AndValueGreaterThan1000_ShouldReturn2()
        {
            //Arrange
            string numbers = "1001,2";

            //Act
            int expected = 2;
            int actual = Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_AndDelimiterOfAnyLength_ShouldReturn6()
        {
            //Arrange
            string numbers = "[***]\n1***2***3";

            //Act
            int expected = 6;
            int actual = Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_AndMultipleDelimiters_ShouldReturn6()
        {
            //Arrange
            string numbers = "[*][%]\n1*2%3";

            //Act
            int expected = 6;
            int actual = Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        private int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var delimiters = new List<string> { ",", "\n", "[", "]" };

            var matches = Regex.Matches(numbers, @"\[([^]]*)\]").Cast<Match>().Select(x => x.Groups[1].Value).ToList();

            if (matches.Count > 0)
                delimiters.AddRange(matches);
            else if (!char.IsDigit(numbers[0]) && numbers[0] != '-')
                delimiters.Add(numbers[0].ToString());

            var sumOfNumbers = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(int.Parse);

            if (sumOfNumbers.Any(num => num < 0))
                throw new Exception($"negatives not allowed: {string.Join(",", sumOfNumbers.Where(num => num <= 0))}");

            sumOfNumbers.RemoveAll(num => num > 1000);

            return sumOfNumbers.Sum();
        }
    }
}