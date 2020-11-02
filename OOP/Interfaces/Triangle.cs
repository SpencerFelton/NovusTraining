using Inheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces {
    class Triangle : IShape {
        public double height{ get; set; }
        public double @base { get; set; }
        public double sideA { get; set; }
        public double sideB { get; set; }
        public double sideC { get; set; }

        public double Area() {
            double s = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
        }

        public double Perimeter() {
            return sideA + sideB + sideC;
        }

        public void displayDetails() {
            Console.WriteLine($"The area of the triangle is {this.Area()}");
            Console.WriteLine($"The perimeter of the triangle is {this.Perimeter()}");
        }
    }
}
