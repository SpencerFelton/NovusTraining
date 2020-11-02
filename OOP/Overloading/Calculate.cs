using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading {
    class Calculate : Arithmetic {
        public float Add(float a, float b) {
            Console.WriteLine("Add floats called");
            return a + b;
        }
        public String Add(String a, String b) {
            Console.WriteLine("Add strings called");
            return "Hello" + a + " " + b;
        }
    }
}
