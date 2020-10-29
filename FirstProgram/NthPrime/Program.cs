using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NthPrime {
    class Program {
        static void Main(string[] args) {

            List<int> primes = generatePrimes(2);
            int nthPrime = primes[primes.Count - 1];
            Console.WriteLine("Nth prime is: " + nthPrime);
            Console.ReadLine();
        }

        public static List<int> generatePrimes(int n) {
            List<int> primes = new List<int>();
            int counter = 2;
            while (primes.Count != n) {
                if (isPrime(counter)) {
                    primes.Add(counter);
                }
                counter++;
            }

            return primes;
        }
        public static bool isPrime(int n) {
            int largestDivisor = (int)Math.Sqrt(n); // any non-prime number will have a factor below it's square root
            if(n == 2) { // edge case - 2 is a prime
                return true;
            }
            else if(n%2 == 0) { // ignore even numbers
                return false;
            }
            else {
                for(int i = 3; i <= largestDivisor; i += 2) { // increment from 3 (2 already covered) up to the largest divisor
                    if(n%i == 0 && i != n) {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
