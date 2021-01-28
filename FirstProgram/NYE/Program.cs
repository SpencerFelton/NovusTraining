using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NYE
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = new DateTime(); // a discard variable
            DateTime currentDate = DateTime.Now;
            _ = new DateTime();
            string date = "1/1/2021 0:00:01 AM";
            DateTime newYears = DateTime.Parse(date);
            if (currentDate.Date.DayOfYear == newYears.DayOfYear)
            {
                Console.WriteLine("Happy New Year!");
            }
            else
            {
                Console.WriteLine("Come back on New Years Day!");
            }
            Console.ReadLine();
        }
    }
}
