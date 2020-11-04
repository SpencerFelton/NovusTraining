using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestProject {
    [TestFixture]
    class CalcTest {

        [Test]
        public void addTest() {
            Calc c = new Calc();
            double x = 4.0;
            double y = 5.0;
            double expectedValue = 9.0;
            double actualValue = c.Add(x, y);

            Assert.AreEqual(expectedValue, actualValue);
        }
        [Test]
        public void subTest() {
            Calc c = new Calc();
            double x = 4.0;
            double y = 5.0;
            double expectedValue = 1.0;
            double actualValue = c.Subtract(y, x);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void addFailTest() {
            Calc c = new Calc();
            double x = 1.0;
            double y = 2.0;
            double wrongValue = 5.0;
            double actualValue = c.Add(x, y);

            Assert.AreNotEqual(wrongValue, actualValue);
        }
    }
}
