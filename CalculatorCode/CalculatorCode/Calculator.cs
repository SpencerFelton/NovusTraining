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
        private string loggingChoice;
        public Calculator(IDiagnostics IDiag, IDBLog DBLog)
        {
            IDiagnostics = IDiag;
            DataBaseLog = DBLog;
        }

        public int Add(int start, int amount)
        {
            string message = $"Logging {start} + {amount}: {start + amount}";
            switch (loggingChoice) // Break if any incorrect option is entered
            {
                case "1":
                    DataBaseLog.EFDBLog(message);
                    break;
                case "2":
                    DataBaseLog.LogString(message);
                    break;
                case "3":
                    DataBaseLog.StoredProcedureLog(message);
                    break;
                default:
                    Console.WriteLine("No choice chosen or incorrect option entered, no logging occured");
                    break;
            }
            IDiagnostics.LogString(message);
            return start + amount;
        }

        public int Sub(int start, int amount)
        {
            string message = $"Logging {start} - {amount}: {start - amount}";
            switch (loggingChoice)
            {
                case "1":
                    DataBaseLog.EFDBLog(message);
                    break;
                case "2":
                    DataBaseLog.LogString(message);
                    break;
                case "3":
                    DataBaseLog.StoredProcedureLog(message);
                    break;
                default:
                    Console.WriteLine("No choice chosen or incorrect option entered, no logging occured");
                    break;
            }
            IDiagnostics.LogString(message);
            return start - amount;
        }

        public int Mult(int start, int by)
        {
            string message = $"Logging {start} * {by}: {start * by}";
            switch (loggingChoice)
            {
                case "1":
                    DataBaseLog.EFDBLog(message);
                    break;
                case "2":
                    DataBaseLog.LogString(message);
                    break;
                case "3":
                    DataBaseLog.StoredProcedureLog(message);
                    break;
                default:
                    Console.WriteLine("No choice chosen or incorrect option entered, no logging occured");
                    break;
            }
            IDiagnostics.LogString($"Logging {start} * {by}: {start * by}");
            return start * by;
        }

        public int Div(int start, int by)
        {
            string message = $"Logging {start} / {by}: {start / by}";
            switch (loggingChoice)
            {
                case "1":
                    DataBaseLog.EFDBLog(message);
                    break;
                case "2":
                    DataBaseLog.LogString(message);
                    break;
                case "3":
                    DataBaseLog.StoredProcedureLog(message);
                    break;
                default:
                    Console.WriteLine("No choice chosen or incorrect option entered, no logging occured");
                    break;
            }
            IDiagnostics.LogString($"Logging {start} / {by}: {start / by}");
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

        public string getLoggingChoice()
        {
            return loggingChoice;
        }

        public void setLoggingChoice(string choice)
        {
            loggingChoice = choice;
        }

        public void chooseLoggingMethod()
        {
            Console.WriteLine("Choose a method to log to the Database:");
            Console.WriteLine("1: Entity Framework");
            Console.WriteLine("2: SQL Client");
            Console.WriteLine("3: Stored Procedure");
            loggingChoice = Console.ReadLine().Trim();
        }
    }
}
