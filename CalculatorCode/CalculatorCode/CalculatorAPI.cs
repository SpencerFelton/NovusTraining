using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCode
{
    public interface ISimpleCalculator
    {
        int Add(int start, int amount);
        int Sub(int start, int amount);
        int Mult(int start, int by);
        int Div(int start, int by);
    }
}
