using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorningProblems {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(longestSequence("1,2,1,1,0,3,1,0,0,2,4,1,0,0,0,0,2,1,0,3,1,0,0,0,6,1,3,0,0,0"));
            Console.ReadLine();


        }


        public static int longestSequence(String sales) // return the longest string of the same number of a string of numbers separated by commas
        { 
            String splitSales = sales.Replace(",", "");
            int days = 0;
            int longestDays = 0;
            for (int i = 0; i < splitSales.Length; i++)
            {
                if (splitSales[i].ToString().Equals("0"))
                {
                    days += 1;
                    if (days > longestDays)
                    {
                        longestDays = days;
                    }
                }
                else
                {
                    days = 0;
                }
            }
            return longestDays;
        }

    }
}
