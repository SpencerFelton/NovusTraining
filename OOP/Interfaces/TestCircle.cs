using Inheritance;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces {
    [TestFixture]
    class TestCircle {
        [Test]
        public void testArea() {
            Circle circ = new Circle();
            double radius = 1.0;
            circ.radius = radius;

            double expectedArea = Math.PI;
            double actualArea = circ.Area();

            Assert.AreEqual(expectedArea, actualArea);
        }

        [Test]
        public void testPerimeter() {
            Circle circ = new Circle();
            double radius = 1.0;
            circ.radius = radius;

            double expectedPerimeter = 2 * Math.PI;
            double actualPerimeter = circ.Perimeter();

            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        [Test]
        public void testAreaFalse() {
            Circle circ = new Circle();
            double radius = 1.0;
            circ.radius = radius;

            double expectedArea = 7.0;
            double actualArea = circ.Area();

            Assert.AreNotEqual(expectedArea, actualArea);
        }
        [Test]
        public void testPerimeterFalse() {
            Circle circ = new Circle();
            double radius = 1.0;
            circ.radius = radius;

            double expectedPerimeter = 15.0;
            double actualPerimeter = circ.Perimeter();

            Assert.AreNotEqual(expectedPerimeter, actualPerimeter);
        }
    }
}
