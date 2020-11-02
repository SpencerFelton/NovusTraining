using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance {
    class Circle : IShape {
        public double radius { get; set; }
        public double Area() {
            return Math.PI * Math.Pow(radius, 2);
        }

        public double Perimeter() {
            return 2 * Math.PI * radius;
        }

        public void displayDetails() {
            Console.WriteLine($"The area of the circle is {this.Area()}");
            Console.WriteLine($"The perimeter of the circle is {this.Perimeter()}");
        }
    }
}
