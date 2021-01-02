using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCode
{
    class AutofacContainer
    {
        public IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            //configure
            builder.RegisterType<CalculatorConsole>();
            builder.RegisterType<Diagnostics>().As<IDiagnostics>();
            builder.RegisterType<DatabaseLog>().As<IDBLog>();
            builder.RegisterType<Calculator>();
            return builder.Build();
        } 
    }
}
