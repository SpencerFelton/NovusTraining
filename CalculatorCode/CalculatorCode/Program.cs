using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCode
{
    class Program
    {
        static void Main(string[] args)
        {
            AutofacContainer afc = new AutofacContainer();
            var container = afc.BuildContainer();
            
            
            using (var scope = container.BeginLifetimeScope())
            {
                var calc = scope.Resolve<CalculatorConsole>();
                calc.RunCalculatorConsole(scope.Resolve<Calculator>());
            }
        }
    }
}
