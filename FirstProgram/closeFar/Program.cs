using System;

namespace closeFar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int luckySum(int a, int b, int c)
        {
            int sum = a + b + c;
            if(a == 13)
            {
                sum -= a;
            }
            if(b == 13)
            {
                sum -= 13;
            }
            if(c == 13)
            {
                sum -= 13;
            }

            return sum;
        } 
    }
}
