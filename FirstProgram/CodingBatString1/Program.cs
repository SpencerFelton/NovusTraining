using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBatString1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(hasBad("xbadxx"));
            Console.ReadLine();
        }

        public static String helloName(String s) {
            String greeting = "Hello ";
            String ending = "!";

            String finalString = greeting + s + ending;
            return finalString;
        }

        public static String makeOutWord(String box, String word) {
            StringBuilder sb = new StringBuilder();
            sb.Append(box.Substring(0, 2) + word + box.Substring(2));

            return sb.ToString();
        }

        public static String nTwice(String str, int n) {
            StringBuilder sb = new StringBuilder();
            sb.Append(str.Substring(0, n) + str.Substring(str.Length - n));

            return sb.ToString();
        }

        public static String seeColour(String str) {
            if(str.Substring(0,3) == "red") {
                return str.Substring(0, 3);
            }
            else if (str.Substring(0,4) == "blue") {
                return str.Substring(0, 4);
            }
            else {
                return "";
            }
        }

        public static String withoutX2(String str) {
            StringBuilder newStr = new StringBuilder();
            newStr.Append(str.Substring(0, 2));
            newStr.Replace("x", "");
            newStr.Append(str.Substring(2));
            return newStr.ToString();
        }

        public static Boolean hasBad(String str) {
            if(str.Length < 4) {
                char whitespace = ' ';
                String space = new String(whitespace, 4 - str.Length);
                str += space;
            }
            if(str.Substring(0, 4).Contains("bad")) {
                return true; 
            }
            else {
                return false;
            }
        }
    }
}
