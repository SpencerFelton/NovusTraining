using Inheritance;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces {
    [TestFixture]
    class TestRectangle {
        [Test]
        public void areaTest() {
            Rectangle rect = new Rectangle();
            double width = 5.0;
            double height = 4.0;
            rect.width = width;
            rect.height = height;

            double expectedArea = 20.0;
            double actualArea = rect.Area();

            Assert.AreEqual(expectedArea, actualArea);
        }
        [Test]
        public void perimeterTest() {
            Rectangle rect = new Rectangle();
            double width = 5.0;
            double height = 4.0;
            rect.width = width;
            rect.height = height;

            double expectedPerimeter = 18.0;
            double actualPerimeter = rect.Perimeter();

            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }
        [Test]
        public void areaTestFalse() {
            Rectangle rect = new Rectangle();
            double width = 5.0;
            double height = 4.0;
            rect.width = width;
            rect.height = height;

            double expectedArea = 10.0;
            double actualArea = rect.Area();

            Assert.AreNotEqual(expectedArea, actualArea);
        }

        [Test]
        public void perimeterTestFalse() {
            Rectangle rect = new Rectangle();
            double width = 5.0;
            double height = 4.0;
            rect.width = width;
            rect.height = height;

            double expectedPerimeter = 3.0;
            double actualPerimeter = rect.Perimeter();

            Assert.AreNotEqual(expectedPerimeter, actualPerimeter);
        }
    }
}
