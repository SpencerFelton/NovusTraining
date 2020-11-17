using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace CalculatorTest {
    [TestFixture]
    class Program {
        private Mock<ICalcDiagnostics> mockICalcDiag;

        private Calculator newCalc() {
            mockICalcDiag = new Mock<ICalcDiagnostics>(); // Mock in each method so we can verify
            mockICalcDiag.Setup(x => x.CalcDetail(It.IsAny<String>()));
            Calculator calc = new Calculator(mockICalcDiag.Object);
            return calc;
        }

        [Test]
        public void testAdd() {
            //Arrange
            int a = 5;
            int b = 7;
            int expectedAns = 12;
            int wrongAns = 89;
            Calculator calc = newCalc();

            //2nd Assert Arrange
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
            mockICalcDiag.Verify(x => x.CalcDetail(It.IsAny<string>()), Times.Exactly(2));
            mockICalcDiag.VerifyAll();
            
        }
        
        [Test]
        public void testSubtract() {
            //Arrange
            int a = 10;
            int b = 12;
            int expectedAns = -2; // check negatives
            int wrongAns = 2;
            Calculator calc = newCalc();

            //Arrange for 2nd assert
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
            mockICalcDiag.Verify(x => x.CalcDetail(It.IsAny<string>()), Times.Exactly(2));
            mockICalcDiag.VerifyAll();
        }
        [Test]
        public void testMultiply() {
            //Arrange
            int a = 12;
            int b = 9;
            int expectedAns = 108; //
            int wrongAns = 22;
            Calculator calc = newCalc();

            //2nd Assert Arrange
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
            mockICalcDiag.Verify(x => x.CalcDetail(It.IsAny<string>()), Times.Exactly(2));
            mockICalcDiag.VerifyAll();
        }
        [Test]
        public void testDivide() {
            //Arrange
            int a = 99;
            int b = 3;
            int expectedAns = 33; // check negatives
            int wrongAns = 45;
            Calculator calc = newCalc();

            //2nd Assert Arrange
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
            mockICalcDiag.Verify(x => x.CalcDetail(It.IsAny<string>()), Times.Exactly(2));
            mockICalcDiag.VerifyAll();
        }
 
    }
}
