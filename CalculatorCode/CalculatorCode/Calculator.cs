using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCode
{
    class Calculator : ISimpleCalculator
    {
        public int Add(int start, int amount)
        {
            return start + amount;
        }

        public int Sub(int start, int amount)
        {
            return start - amount;
        }

        public int Mult(int start, int by)
        {
            return start * by;
        }

        public int Div(int start, int by)
        {
            return start / by;
        }
    }
}
