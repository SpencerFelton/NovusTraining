using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest {
    [TestFixture]
    class Program {
        [Test]
        public void testAdd() {
            //Arrange
            Calculator calc = new Calculator();
            int a = 5;
            int b = 7;
            int expectedAns = 12;
            int wrongAns = 89;
            //Act
            int ans = calc.Add(a, b);
            //Assert
            //Assert.AreEqual(wrongAns, ans); //False answer to show Assert can fail
            Assert.AreEqual(expectedAns, ans);
        }
        [Test]
        public void testSubtract() {
            //Arrange
            Calculator calc = new Calculator();
            int a = 10;
            int b = 12;
            int expectedAns = -2; // check negatives
            int wrongAns = 2;
            //Act
            int ans = calc.Subtract(a, b);
            //Assert
            //Assert.AreEqual(wrongAns, ans); //False answer to show Assert can fail
            Assert.AreEqual(expectedAns, ans);
        }
        [Test]
        public void testMultiply() {
            //Arrange
            Calculator calc = new Calculator();
            int a = 12;
            int b = 9;
            int expectedAns = 108; //
            int wrongAns = 22;
            //Act
            int ans = calc.Multiply(a, b);
            //Assert
            //Assert.AreEqual(wrongAns, ans); //False answer to show Assert can fail
            Assert.AreEqual(expectedAns, ans);
        }
        [Test]
        public void testDivide() {
            //Arrange
            Calculator calc = new Calculator();
            int a = 99;
            int b = 3;
            int expectedAns = 33; // check negatives
            int wrongAns = 45;
            //Act
            int ans = calc.Divide(a, b);
            //Assert
            //Assert.AreEqual(wrongAns, ans); //False answer to show Assert can fail
            Assert.AreEqual(expectedAns, ans);
        }
    }
}
