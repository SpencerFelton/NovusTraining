using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NthOrderPolynomial {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("What order polynomial do you want to solve? Enter an integer: ");
            double[] coefficients = new double[Int32.Parse(Console.ReadLine())+1];

            for (int i = coefficients.Length - 1; i >= 0; i--) {
                String nth = "";
                switch (i%0) {
                    case 0:
                        nth = "(constant)";
                        break;
                    case 1:
                        nth = "st";
                        break;
                    case 2:
                        nth = "nd";
                        break;
                    case 3:
                        nth = "rd";
                        break;
                    default:
                        nth = "th";
                        break;
                }
                Console.WriteLine($"{i}{nth} coefficient? Enter an integer");
                coefficients[i] = Double.Parse(Console.ReadLine());
            }

            Console.ReadLine();
            string eqn = "";
            for (int i = coefficients.Length - 1; i >= 0; i--) {
                if (i == 0) {
                    eqn += $"{coefficients[i]}";
                }
                else {
                    eqn += $"{coefficients[i]} x^{i} +";
                }
            }

            Console.WriteLine(eqn);
            Console.ReadLine();

            double r = 0.1;
            double s = 0.1;
            double epsilon = 0.01;

            double[] newCoefs = step1(coefficients, r, s);
            foreach(double value in newCoefs) {
                Console.WriteLine(value);
            }
            Console.ReadLine();
            double[] cCoefs = step2(newCoefs, r, s);
            foreach (double value in cCoefs) {
                Console.WriteLine(value);
            }
            Console.ReadLine();
            double[] newSR = step3(newCoefs, cCoefs, r, s);
            foreach (double value in newSR) {
                Console.WriteLine(value);
            }
            Console.ReadLine();
        }
        public static double[] step1(double[] originalCoefficients, double r, double s) {
            double[] newCoefficients = new double[originalCoefficients.Length];
            for(int i = originalCoefficients.Length-1; i >= 0; i--) {
                if(i == originalCoefficients.Length - 1) {
                    newCoefficients[i] = originalCoefficients[i]; 
                }
                else if(i == originalCoefficients.Length - 2) {
                    newCoefficients[i] = originalCoefficients[i] + (r * newCoefficients[i + 1]);
                }
                else {
                    newCoefficients[i] = originalCoefficients[i] + (r * newCoefficients[i + 1]) + (s * newCoefficients[i + 2]);
                }
            }
            return newCoefficients;
        }

        public static double[] step2(double[] bCoefficients, double r, double s) {
            double[] cCoefficients = new double[bCoefficients.Length - 1];
            for (int i = bCoefficients.Length - 1; i >= 1; i--) {
                if (i == bCoefficients.Length - 1) {
                    cCoefficients[i-1] = bCoefficients[i];
                }
                else if (i == bCoefficients.Length - 2) {
                    cCoefficients[i-1] = bCoefficients[i] + (r * cCoefficients[i]);
                }
                else {
                    cCoefficients[i-1] = bCoefficients[i] + (r * cCoefficients[i]) + (s * cCoefficients[i + 1]);
                }
            }
            return cCoefficients;
        }

        public static double[] step3(double[] bCoefficients, double[] cCoefficients, double r, double s) {
            double[] delta = cramerMethod(bCoefficients, cCoefficients);
            double newR = r + delta[0];
            double newS = s + delta[1];

            double[] newSR = new double[] { newR, newS };

            return newSR;
        }

        public static double[] cramerMethod(double[] bCoefficients, double[] cCoefficients) {
            for(int i = 0; i < 4; i++) {
                Console.WriteLine($"B{i}: {bCoefficients[i]} C{i}: {cCoefficients[i]}");
            }
            double d = (cCoefficients[1] * cCoefficients[1]) - (cCoefficients[0] * cCoefficients[2]);
            double d1 = (bCoefficients[0] * cCoefficients[2]) - (bCoefficients[1] * cCoefficients[1]);
            double d2 = (bCoefficients[1] * cCoefficients[0]) - (bCoefficients[0] * cCoefficients[1]);
            
            Console.WriteLine($"d: {d},  d1: {d1}, d2: {d2}");
            double deltaR = d1 / d;
            double deltaS = d2 / d;
            Console.WriteLine($"Delta r: {deltaR},  delta s: {deltaS}");

            double[] delta = new double[] { deltaR, deltaS };
            return delta;
        }
    }
}
