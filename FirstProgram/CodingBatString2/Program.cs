using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBatString2 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(sameStarChar("*xa*az"));
            Console.ReadLine();
        }

        public static String doubleChar(String str) {
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < str.Length; i++) {
                sb.Append(str[i].ToString() + str[i].ToString());
            }
            return sb.ToString();
        }

        public static String repeatEnd(String str, int n) {
            String subString = str.Substring(str.Length - n);
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i<n; i++) {
                sb.Append(subString);
            }
            return sb.ToString();
        }

        public static bool sameStarChar(String str) {
            for(int i = 0; i<str.Length; i++) {
                if(str[i].ToString() == "*" && i!=0 && i != str.Length - 1) {
                    if (!str[i - 1].ToString().Equals(str[i + 1].ToString())) {
                        return false;
                    }
                }
            }
            return true;

        }
    }
}
