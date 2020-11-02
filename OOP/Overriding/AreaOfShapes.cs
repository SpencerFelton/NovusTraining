using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overriding {
    class AreaOfShapes : AreaOfSquare{
        public double Rectange(double a, double b) {
            return a * b;
        }
        public override double Square(double a, double b) {
            Console.WriteLine("Area of shapes called square a*b");
            return a * b;
        }
    }
}
