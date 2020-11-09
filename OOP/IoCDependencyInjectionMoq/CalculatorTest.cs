using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCDependencyInjectionMoq {
    class CalculatorTest : ISimpleCalculator {
        public int Add(int start, int amount) {
            return start + amount;
        }

        public int Subtract(int start, int amount) {
            return start - amount;
        }

        public int Multiply(int start, int amount) {
            return start * amount;
        }

        public int Divide(int start, int amount) {
            return start / amount;
        }
    }
}
