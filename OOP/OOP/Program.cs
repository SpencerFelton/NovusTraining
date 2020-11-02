using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP {
    class Program {
        static void Main(string[] args) {
            int x = 3;
            int y = 5;
            int sum = 0;

            Calculator calc = new Calculator();
            sum = calc.Add(x, y);

            Console.WriteLine($"Sum is {sum}", sum);
            Console.ReadLine();
        }
    }
}
