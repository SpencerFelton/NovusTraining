namespace CalculatorCode
{
    interface IDBLog
    {
        void LogString(string message);
        void StoredProcedureLog(string message);

        void EFDBLog(string message);
    }
}