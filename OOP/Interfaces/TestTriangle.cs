using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces {
    [TestFixture]
    class TestTriangle {
        [Test]
        public void testArea() {
            Triangle tri = new Triangle();
            double sideA = 3.0;
            double sideB = 4.0;
            double sideC = 5.0;

            tri.sideA = sideA;
            tri.sideB = sideB;
            tri.sideC = sideC;

            double expectedArea = 6.0;
            double actualArea = tri.Area();
            Assert.AreEqual(expectedArea, actualArea);
        }
        [Test]
        public void testPerimeter() {
            Triangle tri = new Triangle();
            double sideA = 3.0;
            double sideB = 4.0;
            double sideC = 5.0;

            tri.sideA = sideA;
            tri.sideB = sideB;
            tri.sideC = sideC;

            double expectedPerimeter = 12.0;
            double actualPerimeter = tri.Perimeter();
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        [Test]
        public void testAreaFalse() {
            Triangle tri = new Triangle();
            double sideA = 3.0;
            double sideB = 4.0;
            double sideC = 5.0;

            tri.sideA = sideA;
            tri.sideB = sideB;
            tri.sideC = sideC;

            double expectedArea = 25.0;
            double actualArea = tri.Area();
            Assert.AreNotEqual(expectedArea, actualArea);
        }
        [Test]
        public void testPerimeterFalse() {
            Triangle tri = new Triangle();
            double sideA = 3.0;
            double sideB = 4.0;
            double sideC = 5.0;

            tri.sideA = sideA;
            tri.sideB = sideB;
            tri.sideC = sideC;

            double expectedPerimeter = 20.0;
            double actualPerimeter = tri.Perimeter();
            Assert.AreNotEqual(expectedPerimeter, actualPerimeter);
        }

    }
}
