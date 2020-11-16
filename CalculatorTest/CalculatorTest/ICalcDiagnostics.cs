using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest {
    public interface ICalcDiagnostics {
        void CalcDetail(String message);
    }
}
