using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsAndDiamonds {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("How many rows of stars would you like? Only integer values are accepted.");
            int rows = Int32.Parse(Console.ReadLine());
            stars(rows);

            Console.WriteLine("How many rows deep would you like the widest part of the diamond to be? Only integer values are accepted.");
            int diaRows = Int32.Parse(Console.ReadLine());
            diamond(diaRows);
        }

        public static void diamond(int rows) {
            for (int i = 0; i < 2 * rows - 1; i++) { // double the number of rows - 1, as the argument is to the center row
                if (i < rows) { // before the midway point - same code as stars
                    String blanks = new String(' ', rows - i - 1);
                    String star = new String('*', ((i + 1) * 2) - 1);

                    Console.WriteLine(blanks + star);
                }
                else { // work backwards by taking the absolute value - ie, counting how far from the center row we are
                    int j = Math.Abs(i - (rows - 1) * 2); // how many rows from the center
                    String revBlanks = new string(' ', rows - j - 1); 
                    String revStars = new String('*', ((j + 1) * 2) - 1); 

                    Console.WriteLine(revBlanks + revStars);
                }
            }
            Console.ReadLine();
        }

        public static void stars(int rows) {
            for (int i = 0; i < rows; i++) {
                String blanks = new String(' ', rows - i - 1); // only need to generate spaces to the left of the stars - equal to the total number of rows, minus the current row - 1
                String star = new String('*', ((i + 1) * 2) - 1); // 2*rows - 1 stars for each row, +1 because we start counting from 0
                Console.WriteLine(blanks + star);
            }
            Console.ReadLine();
        }
    }
}
