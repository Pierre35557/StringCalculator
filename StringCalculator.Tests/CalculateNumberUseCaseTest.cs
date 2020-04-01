using System;
using System.Linq;
using NUnit.Framework;
using StringCalculator.Interfaces;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class CalculateNumberUseCaseTest
    {
        CalculateNumberService calculateNumberService = new CalculateNumberService();

        //ICalculateNumberService calculateNumberService;

        //public CalculateNumberUseCaseTest(ICalculateNumberService calculateNumberService)
        //{
        //    this.calculateNumberService = calculateNumberService;
        //}

        [Test]
        public void Add_Numbers_With_Empty_String()
        {
            //Arrange
            string numbers = "";
            int expectedOutput = 0;

            //Act
            int actualOutput = calculateNumberService.Add(numbers);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Add_Numbers_With_One_Value()
        {
            //Arrange
            string numbers = "1";
            int expectedOutput = 1;

            //Act
            int actualOutput = calculateNumberService.Add(numbers);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Add_Numbers_With_Two_Values()
        {
            //Arrange
            string numbers = "1,2";
            int expectedOutput = 3;

            //Act
            int actualOutput = calculateNumberService.Add(numbers);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Add_Numbers_With_Any_Amount_Of_Values()
        {
            //Arrange
            string numbers = "1,2,5,8,10,15,6";
            int expectedOutput = 47;

            //Act
            int actualOutput = calculateNumberService.Add(numbers);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Add_Numbers_With_New_Line_Included_In_Value()
        {
            //Arrange
            string numbers = "1\n,2,3";
            int expectedOutput = 6;

            //Act
            int actualOutput = calculateNumberService.Add(numbers);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Add_Numbers_With_Delimeter_Included_In_Value()
        {
            //Arrange
            string numbers = ";\n1;2";
            int expectedOutput = 3;

            //Act
            int actualOutput = calculateNumberService.Add(numbers);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Add_Numbers_With_Values_Over_1000()
        {
            //Arrange
            string numbers = "1001, 3000, 2";
            int expectedOutput = 2;

            //Act
            int actualOutput = calculateNumberService.Add(numbers);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Add_Numbers_With_Lengthy_Delimeters()
        {
            //Arrange
            string numbers = "[***]\n1***2***3";
            int expectedOutput = 6;

            //Act
            int actualOutput = calculateNumberService.Add(numbers);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Add_Numbers_With_Multiple_Delimeters()
        {
            //Arrange
            string numbers = "[*][%]\n1*2%3";
            int expectedOutput = 6;

            //Act
            int actualOutput = calculateNumberService.Add(numbers);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Add_Numbers_With_Multiple_Lengthy_Delimeters()
        {
            //Arrange
            string numbers = "[***][%%%]\n1***2%%%3";
            int expectedOutput = 6;

            //Act
            int actualOutput = calculateNumberService.Add(numbers);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        //[Test]
        //public void Throw_Exception_When_Negative_Number()
        //{
        //    //Arrange
        //    var numbers = "-1, -10";
        //    Assert.Throws<Exception>(() => calculateNumberService.Add(numbers), "negatives not allowed");
        //}
    }
}
