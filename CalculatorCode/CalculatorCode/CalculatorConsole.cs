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
            IWebCalculator WebCalculator; // no need to instantiate until user decides to do webapi calc
            bool continuer = true;

            Console.WriteLine("Welcome to the Calculator Console App. Would you like to use the web api or the calculator program?:");
            Console.WriteLine("1: Web API");
            Console.WriteLine("2: Calculator Program");
            string option = Console.ReadLine().Trim();

            // Web API option
            if (option.Equals("1"))
            {
                Console.WriteLine("Please start a new instance of Calculator Web API from VS 2019 now please.");
                WebCalculator = new WebCalculator();
                while (continuer)
                {
                    printOptions();
                    string input = Console.ReadLine().Trim().ToUpper();
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("Please enter the first number:");
                            int num1Add = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter the second number:");
                            int num2Add = Int32.Parse(Console.ReadLine());

                            var addAns = WebCalculator.GetResource(1, num1Add, num2Add);
                            Console.WriteLine($"The answer is: {addAns.Result}");
                            break;
                        case "2":
                            Console.WriteLine("Please enter the first number:");
                            int num1Sub = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter the second number:");
                            int num2Sub = Int32.Parse(Console.ReadLine());

                            var subAns = WebCalculator.GetResource(2, num1Sub, num2Sub);
                            Console.WriteLine($"The answer is: {subAns.Result}");
                            break;
                        case "3":
                            Console.WriteLine("Please enter the first number:");
                            int num1Mult = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter the second number:");
                            int num2Mult = Int32.Parse(Console.ReadLine());

                            var multAns = WebCalculator.GetResource(3, num1Mult, num2Mult);
                            Console.WriteLine($"The answer is: {multAns.Result}");
                            break;
                        case "4":
                            Console.WriteLine("Please enter the first number:");
                            int num1Div = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter the second number:");
                            int num2Div = Int32.Parse(Console.ReadLine());
                            if (num2Div == 0)
                            {
                                divisionWithZero();
                                break;
                            }

                            var divAns = WebCalculator.GetResource(4, num1Div, num2Div);
                            Console.WriteLine($"The answer is: {divAns.Result}");
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

            // Calc Program Option
            if (option.Equals("2"))
            {
                calc.chooseLoggingMethod();
                
                while (continuer)
                {
                    printOptions();
                    string input = Console.ReadLine().Trim().ToUpper();
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("Please enter the first number:");
                            int num1Add = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter the second number:");
                            int num2Add = Int32.Parse(Console.ReadLine());

                            calc.Add(num1Add, num2Add);
                            break;
                        case "2":
                            Console.WriteLine("Please enter the first number:");
                            int num1Sub = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter the second number:");
                            int num2Sub = Int32.Parse(Console.ReadLine());

                            calc.Sub(num1Sub, num2Sub);
                            break;
                        case "3":
                            Console.WriteLine("Please enter the first number:");
                            int num1Mult = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter the second number:");
                            int num2Mult = Int32.Parse(Console.ReadLine());

                            calc.Mult(num1Mult, num2Mult);
                            break;
                        case "4":
                            Console.WriteLine("Please enter the first number:");
                            int num1Div = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter the second number:");
                            int num2Div = Int32.Parse(Console.ReadLine());
                            if(num2Div == 0)
                            {
                                divisionWithZero();
                                break;
                            }

                            calc.Div(num1Div, num2Div);
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

        public void printOptions()
        {
            Console.WriteLine("1: Addition");
            Console.WriteLine("2: Subtraction");
            Console.WriteLine("3: Multiplication");
            Console.WriteLine("4: Division");
            Console.WriteLine("Q: Exit the program");
            Console.WriteLine("Please enter a symbol corresponding to one of the above actions:");
        }

        public void divisionWithZero()
        {
            Console.WriteLine("You tried to divide by 0, the operation did not continue!");
        }
    }
}
