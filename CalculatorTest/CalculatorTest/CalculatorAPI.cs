using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest {
    //Calculator Interface + Method signatures
    public interface ISimpleCalculator {
        int Add(int start, int amount);
        int Subtract(int start, int amount);
        int Multiply(int start, int amount);
        int Divide(int start, int amount);
    }
}
