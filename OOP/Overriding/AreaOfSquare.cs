using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overriding {
    class AreaOfSquare {
        public virtual double Square(double a, double b) {
            Console.WriteLine("Calcuate area of square power a^b");
            return Math.Pow(a, 2);
        }
    }
}
