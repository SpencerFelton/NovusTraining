using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace CalculatorCode
{
    class Calculator : ISimpleCalculator
    {
        IDiagnostics IDiagnostics;
        IDBLog DataBaseLog;
        public Calculator(IDiagnostics IDiag, IDBLog DBLog)
        {
            IDiagnostics = IDiag;
            DataBaseLog = DBLog;
        }

        public int Add(int start, int amount)
        {
            IDiagnostics.LogString($"Logging {start} + {amount}: {start + amount}");
            DataBaseLog.LogString($"Logging {start} + {amount}: {start + amount}");
            return start + amount;
        }

        public int Sub(int start, int amount)
        {
            IDiagnostics.LogString($"Logging {start}  {amount}: {start - amount}");
            DataBaseLog.LogString($"Logging {start} - {amount}: {start - amount}");
            return start - amount;
        }

        public int Mult(int start, int by)
        {
            IDiagnostics.LogString($"Logging {start} * {by}: {start * by}");
            DataBaseLog.LogString($"Logging {start} * {by}: {start * by}");
            return start * by;
        }

        public int Div(int start, int by)
        {
            IDiagnostics.LogString($"Logging {start} / {by}: {start / by}");
            DataBaseLog.LogString($"Logging {start} / {by}: {start / by}");
            return start / by;
        }

        public IDiagnostics getDiag()
        {
            return IDiagnostics;
        }

        public IDBLog getDBLog()
        {
            return DataBaseLog;
        }
    }
}
