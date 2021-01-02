using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCode
{
    class Diagnostics : IDiagnostics
    {
        public void LogString(string message)
        {
            Console.WriteLine($"Logged message: {message}");
        }
    }
}
