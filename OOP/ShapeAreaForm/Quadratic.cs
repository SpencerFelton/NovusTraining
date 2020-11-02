using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaForm {
    class Quadratic {
        public double squaredTerm { get; set; }
        public double xTerm { get; set; }
        public double constant { get; set; }

        public String[] findRoots() {
            bool complex = false;
            double firstTerm = -this.xTerm;
            double secondTerm = Math.Pow(this.xTerm, 2) - 4 * this.squaredTerm * this.constant;
            double thirdTerm = 2 * this.squaredTerm;
            if (secondTerm < 0){
                complex = true;
            }

            if (complex) {
                secondTerm *= -1;

                String root1 = (firstTerm / thirdTerm).ToString() + " + " + (Math.Sqrt(secondTerm)/thirdTerm).ToString() + "i";
                String root2 = (firstTerm / thirdTerm).ToString() + " - " + (Math.Sqrt(secondTerm) / thirdTerm).ToString() + "i";
                String[] roots = { root1, root2 };
                return roots;
            }
            else {
                double root1 = (firstTerm + Math.Sqrt(secondTerm)) / thirdTerm;
                Console.WriteLine($"Root1: {root1}");
                double root2 = (firstTerm - secondTerm) / thirdTerm;
                Console.WriteLine($"Root2: {root2}");
                String[] roots = { root1.ToString(), root2.ToString() };
                return roots;
            }

        }
    }
}
