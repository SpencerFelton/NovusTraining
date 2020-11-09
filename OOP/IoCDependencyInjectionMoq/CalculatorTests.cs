using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCDependencyInjectionMoq {
    [TestFixture]
    class CalculatorTests {

        [Test]
        public void TestAdd() {
            //Arrange
            CalculatorTest calc = new CalculatorTest();
            int value1 = 2;
            int value2 = 7;
            int answer1 = 9;
            int answer2 = 15;
            //Act
            int sum = calc.Add(value1, value2);
            //Assert
            //Assert.AreEqual(answer2, sum); // to fail
            Assert.AreEqual(answer1, sum);
        }

        [Test]
        public void TestSubtract() {
            //Arrange
            CalculatorTest calc = new CalculatorTest();
            int value1 = 3;
            int value2 = 4;
            int answer1 = -1;
            int answer2 = 1;
            //Act
            int sub = calc.Subtract(value1, value2);
            //Assert
            //Assert.AreEqual(answer2, sub); // to fail
            Assert.AreEqual(answer1, sub);
        }
        [Test]
        public void TestMultiply() {
            //Arrange
            CalculatorTest calc = new CalculatorTest();
            int value1 = 12;
            int value2 = 9;
            int answer1 = 108;
            int answer2 = 99;
            //Act
            int sub = calc.Multiply(value1, value2);
            //Assert
            //Assert.AreEqual(answer2, sub); // to fail
            Assert.AreEqual(answer1, sub);
        }
        [Test]
        public void TestDivide() {
            //Arrange
            CalculatorTest calc = new CalculatorTest();
            int value1 = 60;
            int value2 = 12;
            int answer1 = 5;
            int answer2 = 10;
            //Act
            int sub = calc.Divide(value1, value2);
            //Assert
            //Assert.AreEqual(answer2, sub); // to fail
            Assert.AreEqual(answer1, sub);
        }
    }
}
