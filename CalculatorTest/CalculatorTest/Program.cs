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
            int nextSumA = 10;
            int nextSumB = 14;
            int nextExpectedAns = 24;
            //Act
            int ans = calc.Add(a, b);
            int nextAns = calc.Add(nextSumA, nextSumB);
            //Assert
            //Assert.AreEqual(wrongAns, ans); //False answer to show Assert can fail
            Assert.AreEqual(expectedAns, ans);
            Assert.AreEqual(nextExpectedAns, nextAns);
        }
        [Test]
        public void testSubtract() {
            //Arrange
            Calculator calc = new Calculator();
            int a = 10;
            int b = 12;
            int expectedAns = -2; // check negatives
            int wrongAns = 2;
            int nextSubA = 20;
            int nextSubB = 24;
            int nextExpectedAns = -4;
            //Act
            int ans = calc.Subtract(a, b);
            int nextAns = calc.Subtract(nextSubA, nextSubB);
            //Assert
            //Assert.AreEqual(wrongAns, ans); //False answer to show Assert can fail
            Assert.AreEqual(expectedAns, ans);
            Assert.AreEqual(nextExpectedAns, nextAns);
        }
        [Test]
        public void testMultiply() {
            //Arrange
            Calculator calc = new Calculator();
            int a = 12;
            int b = 9;
            int expectedAns = 108; //
            int wrongAns = 22;
            int nextMulA = 15;
            int nextMulB = 14;
            int nextExptectedAns = 210;
            //Act
            int ans = calc.Multiply(a, b);
            int nextAns = calc.Multiply(nextMulA, nextMulB);
            //Assert
            //Assert.AreEqual(wrongAns, ans); //False answer to show Assert can fail
            Assert.AreEqual(expectedAns, ans);
            Assert.AreEqual(nextExptectedAns, nextAns);
        }
        [Test]
        public void testDivide() {
            //Arrange
            Calculator calc = new Calculator();
            int a = 99;
            int b = 3;
            int expectedAns = 33; // check negatives
            int wrongAns = 45;
            int nextDivA = 27;
            int nextDivB = 9;
            int nextExpectedAns = 3;
            //Act
            int ans = calc.Divide(a, b);
            int nextAns = calc.Divide(nextDivA, nextDivB);
            //Assert
            //Assert.AreEqual(wrongAns, ans); //False answer to show Assert can fail
            Assert.AreEqual(expectedAns, ans);
            Assert.AreEqual(nextExpectedAns, nextAns);
        }
    }
}
