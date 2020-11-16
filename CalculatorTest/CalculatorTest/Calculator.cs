using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace CalculatorTest {
    class Calculator : ISimpleCalculator {
        public ICalcDiagnostics calcDiag = null;
        public Calculator(ICalcDiagnostics calcDiag) {
            this.calcDiag = calcDiag;
        }
        public int Add(int a, int b) {
            return a + b;
        }
        public int Subtract(int a, int b) {
            return a - b;
        }
        public int Multiply(int a, int b) {
            return a * b;
        }
        public int Divide(int a, int b) {
            return a / b;
        }
    }
}
