using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest {
    class CalculatorConsole {
        public static void Main() {
            ICalcDiagnostics calcDiag = null;
            while (true) {
                // ask user for input
                Calculator calc = new Calculator(calcDiag);
                Console.WriteLine("Welcome to Calculator, please enter the number of the operation you'd like to perform:");
                Console.WriteLine("1: Addition");
                Console.WriteLine("2: Subtraction");
                Console.WriteLine("3: Multiplication");
                Console.WriteLine("4: Division");
                Console.WriteLine("x: Exit the program");
                string userInput = Console.ReadLine(); // wait for user input
                if (userInput.ToLower().Equals("x")) {
                    Console.WriteLine("The program will now close. Press enter to exit.");
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine("Enter the numbers to be operated on/with:");
                Console.WriteLine("1st number:");
                int num1 = Int32.Parse(Console.ReadLine());
                Console.WriteLine("2nd number:");
                int num2 = Int32.Parse(Console.ReadLine());

                switch (userInput) {
                    case "1":
                        int ansAdd = calc.Add(num1, num2);
                        Console.WriteLine($"The answer is: {ansAdd}");
                        break;
                    case "2":
                        int ansSub = calc.Subtract(num1, num2);
                        Console.WriteLine($"The answer is: {ansSub}");
                        break;
                    case "3":
                        int ansMul = calc.Multiply(num1, num2);
                        Console.WriteLine($"The answer is: {ansMul}");
                        break;
                    case "4":
                        int ansDiv = calc.Divide(num1, num2);
                        Console.WriteLine($"The answer is: {ansDiv}");
                        break;
                    default:
                        break;              
                }
            }
        }
        //AutoFac Containers
        private void ConfigureContainer() {

        }
        private void ComposeObjects() {

        }
    }
}
