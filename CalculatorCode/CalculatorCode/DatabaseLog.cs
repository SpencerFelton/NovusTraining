using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCode
{
    class DatabaseLog : IDBLog
    {
        public void LogString(string message)
        {
            string s = ConfigurationManager.ConnectionStrings["CalculatorLogging"].ConnectionString;
            SqlConnection con = new SqlConnection(s);

            // Get the max ID from the table to increment for the log message
            int ID = 0;
            string sqlString = "select MAX(ID) from Logs";
            SqlCommand cmd = new SqlCommand(sqlString, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) // reading the result of the sql query
            {
                ID = dr.GetInt32(0); // works only if there is already 1 piece of data in the database
            }
            dr.Close();

            // Insert the log message direct to the database
            string sqlString2 = $"insert into Logs values(@ID, @message)";
            SqlCommand cmd2 = new SqlCommand(sqlString2, con);
            cmd2.Parameters.AddWithValue("@ID", ID+1);
            cmd2.Parameters.AddWithValue("@message", message);
            cmd2.ExecuteNonQuery();

            con.Close();

            Console.WriteLine("Log Received");
        }
    }
}
