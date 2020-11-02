using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance {
    class Rectangle : IShape {
        public double height { get; set; }
        public double width { get; set; }
        
        public double Area() {
            return height * width;
        }

        public double Perimeter() {
            return 2 * height + 2 * width;
        }

        public void displayDetails() {
            Console.WriteLine($"The area of the rectangle is {this.Area()}");
            Console.WriteLine($"The perimeter of the rectangle is {this.Perimeter()}");
        }
    }
}
