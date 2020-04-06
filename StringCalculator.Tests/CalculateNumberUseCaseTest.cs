using System;
using System.Linq;
using NUnit.Framework;
using StringCalculator;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class CalculateNumberUseCaseTest
    {
        [Test]
        public void Should_Return_Zero_When_Empty_String()
        {
            //Arrange
            var calculateNumberService = new CalculateNumberService();
            string numbers = "";
            int expectedOutput = 0;

            //Act
            var actualOutput = calculateNumberService.Add(numbers);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Add_Numbers_With_Single_Value()
        {
            //Arrange 
            var calculateNumberService = new CalculateNumberService();
            string numbers = "1";
            int expectedOutput = 1;

            //Act
            var actualOutput = calculateNumberService.Add(numbers);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Add_Numbers_With_Multiple_Values()
        {
            //Arrange 
            var calculateNumberService = new CalculateNumberService();
            string numbers = "1,2";
            int expectedOutput = 3;

            //Act
            var actualOutput = calculateNumberService.Add(numbers);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Add_Numbers_With_New_Lines()
        {
            //Arrange 
            var calculateNumberService = new CalculateNumberService();
            string numbers = "1\n,2,3";
            int expectedOutput = 6;

            //Act
            var actualOutput = calculateNumberService.Add(numbers);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Add_Numbers_With_New_Delimeter()
        {
            //Arrange 
            var calculateNumberService = new CalculateNumberService();
            string numbers = ";\n,1,2";
            int expectedOutput = 3;

            //Act
            var actualOutput = calculateNumberService.Add(numbers);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Should_Throw_Exception_With_Negative_Numbers()
        {
            //Arrange 
            var calculateNumberService = new CalculateNumberService();
            string numbers = "-1, -2, 3";

            //Assert
            Assert.Throws<Exception>(() => calculateNumberService.Add(numbers));
        }

        [Test]
        public void Add_Numbers_With_Values_Over_1000()
        {
            //Arrange
            var calculateNumberService = new CalculateNumberService();
            string numbers = "1001, 2";
            int expectedOutput = 2;

            //Act
            int actualOutput = calculateNumberService.Add(numbers);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
