using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCode
{
    interface IWebCalculator
    {
        Task<string> GetResource(int service, int a, int b);
    }
}
