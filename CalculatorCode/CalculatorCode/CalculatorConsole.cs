using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCode
{
    class CalculatorConsole
    {
        public void RunCalculatorConsole(Calculator calc)
        {
            IDiagnostics IDiag; //= new Diagnostics(); // Diagnostics 
            IDiagnostics INull; //= new NullDiagnostics(); // Null Diagnostics
            IDiagnostics DBLog; //= new DatabaseLog();
            bool continuer = true;

            Console.WriteLine("Welcome to the Calculator Console App. Here are your operations:");
            Console.WriteLine("1: Addition");
            Console.WriteLine("2: Subtraction");
            Console.WriteLine("3: Multiplication");
            Console.WriteLine("4: Division");
            Console.WriteLine("Q: Exit the program");
            while (continuer)
            {
                Console.WriteLine("Please enter a symbol corresponding to one of the above actions:");
                string input = Console.ReadLine().Trim().ToUpper();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Please enter the first number:");
                        int num1Add = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the second number:");
                        int num2Add = Int32.Parse(Console.ReadLine());

                        int AddAns = calc.Add(num1Add, num2Add);
                        break;
                    case "2":
                        Console.WriteLine("Please enter the first number:");
                        int num1Sub = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the second number:");
                        int num2Sub = Int32.Parse(Console.ReadLine());

                        int SubAns = calc.Sub(num1Sub, num2Sub);
                        break;
                    case "3":
                        Console.WriteLine("Please enter the first number:");
                        int num1Mult = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the second number:");
                        int num2Mult = Int32.Parse(Console.ReadLine());

                        int MultAns = calc.Mult(num1Mult, num2Mult);
                        break;
                    case "4":
                        Console.WriteLine("Please enter the first number:");
                        int num1Div = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the second number:");
                        int num2Div = Int32.Parse(Console.ReadLine());

                        int DivAns = calc.Div(num1Div, num2Div);
                        break;
                    case "Q":
                        Console.WriteLine("Goodbye");
                        Console.WriteLine("Press Enter");
                        Console.ReadLine();
                        continuer = false;
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}
