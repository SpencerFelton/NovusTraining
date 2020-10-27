using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace FirstProgram { 
    class Program{
        static void Main(string[] args){
            Console.WriteLine("Size of int: {0}", sizeof(int));
            Console.WriteLine("Size of long: {0}", sizeof(long));
            Console.WriteLine("Size of float: {0}", sizeof(float));
            Console.WriteLine("Size of double: {0}", sizeof(double));
            Console.WriteLine("Size of decimal: {0}", sizeof(decimal));
            Console.WriteLine("Size of Boolean: {0}", sizeof(bool));
            Console.WriteLine("Size of char: {0}", sizeof(char));
            Console.WriteLine("Size of byte: {0}", sizeof(byte));
            Console.ReadLine();

            int firstNumber = 0;
            int secondNumber = 0;
            Console.Write("Enter first number: ");
            firstNumber = Convert.ToInt16(Console.ReadLine());
            Console.Write("Enter second number: ");
            secondNumber = Convert.ToInt32(Console.ReadLine());
            if(firstNumber > secondNumber) {
                Console.WriteLine("First number is bigger than second number");
            }
            else if(firstNumber == secondNumber) {
                Console.WriteLine("First number equals second number");
            }
            else {
                Console.WriteLine("Second number is greater than first number");
            }
            Console.ReadLine();
        }
    }
}
