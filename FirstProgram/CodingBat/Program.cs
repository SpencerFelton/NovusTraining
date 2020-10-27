using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CodingBat {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(or35(12));
            Console.ReadLine();
        }

        public bool sleepIn(bool weekday, bool vacation) {
            if (weekday == false || vacation == true) {
                return true;
            }
            else {
                return false;
            }
        }

        public int diff21(int n) {
            int diff = 21 - n;
            if(diff < 0) {
                diff *= -2;
            }
            return diff;
        }

        public bool cigarParty(int cigars, bool isWeekend) {
            if (isWeekend && cigars >= 40) {
                return true;
            }
            else if(cigars >= 40 && cigars <= 60) {
                return true;
            }
            else {
                return false;
            }
        }

        public bool nearHundred(int n) {
            if(Math.Abs(100 - n) <= 10 || Math.Abs(200 - n) <= 10) {
                return true;
            }
            else {
                return false;
            }
        }

        public static String missingChar(String str, int n) {
            StringBuilder sb = new StringBuilder(str);
            sb.Remove(n, 1);
            Console.WriteLine(sb.ToString());
            Console.ReadLine();
            return sb.ToString();
        }

        public static bool posNeg(int a, int b, bool negative) {
            if (negative) {
                if(a < 0 && b < 0) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if((a >= 0 && b < 0) || (a < 0 && b >= 0)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }

        public static bool or35(int n) {
            if(n%3 == 0 || n%5 == 0) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
