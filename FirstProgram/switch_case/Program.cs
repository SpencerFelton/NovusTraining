using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace switch_case {
    class Program {
        static void Main(string[] args) {
            int x = 0;
            Console.WriteLine("Enter a +ve number: ");
            x = Convert.ToInt16(Console.ReadLine());
            if (x >= 0){
                switch (x) {
                    case 0:
                        Console.WriteLine("The value is 0");
                        break;
                    case 1:
                        Console.WriteLine("The value is 1");
                        break;
                    case 2:
                        Console.WriteLine("The value is 2");
                        break;
                    default:
                        Console.WriteLine("The value is greater than 2");
                        break;
                }
            }
            else {
                Console.WriteLine("No -ve numbers");
            }
            Console.ReadLine();
        }
    }
}
