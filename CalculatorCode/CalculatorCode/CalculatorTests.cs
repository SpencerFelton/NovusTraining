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
        [TestCase(1,2,3)]
        public void TestAdd(int a, int b, int expected)
        {
            //Arrange
            Calculator calc = CreateCalculator();

            //Act
            int actualAns = calc.Add(a, b);

            //Assert
            Assert.AreEqual(expected, actualAns); // Passing Test

            _mockIDiag.Verify(x => x.LogString(It.IsAny<string>()), Times.Once); // Test the LogString method is called once

        }

        [Test]
        [TestCase(4,5,-1)]
        [TestCase(-4,-5,1)]
        public void TestSub(int a, int b, int expected)
        {
            //Arrange
            Calculator calc = CreateCalculator();

            //Act
            int actualAns = calc.Sub(a, b);

            //Assert
            Assert.AreEqual(expected, actualAns); // Passing Test
            _mockIDiag.Verify(x => x.LogString(It.IsAny<string>()), Times.Once); // Test the LogString method is called once
        }
        [Test]
        [TestCase(2,2,4)]
        [TestCase(76,0,0)]
        public void TestMult(int a, int b, int expected)
        {
            //Arrange
            Calculator calc = CreateCalculator();

            //Act
            int actualAns = calc.Mult(a, b);

            //Assert
            Assert.AreEqual(expected, actualAns); // Passing Test
            _mockIDiag.Verify(x => x.LogString(It.IsAny<string>()), Times.Once); // Test the LogString method is called once
        }
        [Test]
        [TestCase(4,2,2)]
        [TestCase(7,3,2)]
        public void TestDiv(int a, int b, int expected)
        {
            //Arrange
            Calculator calc = CreateCalculator();

            //Act
            int actualAns = calc.Div(a, b);

            //Assert
            Assert.AreEqual(expected, actualAns); // Passing Test
            _mockIDiag.Verify(x => x.LogString(It.IsAny<string>()), Times.Once); // Test the LogString method is called once
        }

        public Calculator CreateCalculator()
        {
            _mockIDiag = new Mock<IDiagnostics>();
            _mockIDiag.Setup(x => x.LogString(It.IsAny<string>()));
            _mockDBLog = new Mock<IDBLog>();
            _mockDBLog.Setup(x => x.LogString(It.IsAny<string>()));

            Calculator calc = new Calculator(_mockIDiag.Object, _mockDBLog.Object);
            calc.setLoggingChoice("0"); // not "1" "2" or "3" so no logging made to databases, only to console
            return calc;
        }
    }
}
