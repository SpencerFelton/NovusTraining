using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest {
    class CalcDiagnostics : ICalcDiagnostics{
        public void CalcDetail(String message) {
            Console.WriteLine(message);
        }
    }
}
