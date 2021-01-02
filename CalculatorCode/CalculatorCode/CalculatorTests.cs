using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCode
{
    [TestFixture]
    class CalculatorTests
    {

        private Mock<IDiagnostics>_mockIDiag;
        private Mock<IDBLog> _mockDBLog;
        [Test]
        public void TestAdd()
        {
            //Arrange
            Calculator calc = CreateCalculator();

            int val1 = 10;
            int val2 = 23;
            int expectedAns = 33;
            int wrongAns = 4;

            //Act
            int actualAns = calc.Add(val1, val2);

            //Assert
            //Assert.AreEqual(wrongAns, actualAns); //Failing Test
            Assert.AreEqual(expectedAns, actualAns); // Passing Test

            _mockIDiag.Verify(x => x.LogString(It.IsAny<string>()), Times.Once); // Test the LogString method is called once

        }
        [Test]
        public void TestSub()
        {
            //Arrange
            Calculator calc = CreateCalculator();
            int val1 = 7777;
            int val2 = 6666;
            int expectedAns = 1111;
            int wrongAns = 2222;

            //Act
            int actualAns = calc.Sub(val1, val2);

            //Assert
            //Assert.AreEqual(wrongAns, actualAns); //Failing Test
            Assert.AreEqual(expectedAns, actualAns); // Passing Test
            _mockIDiag.Verify(x => x.LogString(It.IsAny<string>()), Times.Once); // Test the LogString method is called once
        }
        [Test]
        public void TestMult()
        {
            //Arrange
            Calculator calc = CreateCalculator();
            int val1 = 12;
            int val2 = 8;
            int expectedAns = 96;
            int wrongAns = 20;

            //Act
            int actualAns = calc.Mult(val1, val2);

            //Assert
            //Assert.AreEqual(wrongAns, actualAns); //Failing Test
            Assert.AreEqual(expectedAns, actualAns); // Passing Test
            _mockIDiag.Verify(x => x.LogString(It.IsAny<string>()), Times.Once); // Test the LogString method is called once
        }
        [Test]
        public void TestDiv()
        {
            //Arrange
            Calculator calc = CreateCalculator();
            int val1 = 100;
            int val2 = 20;
            int expectedAns = 5;
            int wrongAns = 12;

            //Act
            int actualAns = calc.Div(val1, val2);

            //Assert
            //Assert.AreEqual(wrongAns, actualAns); //Failing Test
            Assert.AreEqual(expectedAns, actualAns); // Passing Test
            _mockIDiag.Verify(x => x.LogString(It.IsAny<string>()), Times.Once); // Test the LogString method is called once
        }

        public Calculator CreateCalculator()
        {
            _mockIDiag = new Mock<IDiagnostics>();
            _mockIDiag.Setup(x => x.LogString(It.IsAny<string>()));
            _mockDBLog = new Mock<IDBLog>();
            _mockDBLog.Setup(x => x.LogString(It.IsAny<string>()));

            Calculator calc = new Calculator(_mockIDiag.Object, _mockDBLog.Object);
            return calc;
        }
    }
}
