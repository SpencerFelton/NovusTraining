using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CodingBat {
    //consolidated all coding bat challenges into a single file
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(or35(12));
            Console.ReadLine();
        }

        public bool sleepIn(bool weekday, bool vacation) { // returns true on weekends or if vacation
            if (!weekday || vacation) {
                return true;
            }
            else {
                return false;
            }
        }

        public int diff21(int n) { // returns the difference beteen int n and 2, if n is > 21 returns double the diff
            int diff = 21 - n;
            if(diff < 0) { // only double if diff is less than 0
                diff *= -2;
            }
            return diff;
        }

        public bool cigarParty(int cigars, bool isWeekend) { 
            if (isWeekend && cigars >= 40) { //weekend and more than 40 cigs
                return true;
            }
            else if(cigars >= 40 && cigars <= 60) { //40 - 60 cigs
                return true;
            }
            else {
                return false;
            }
        }

        public bool nearHundred(int n) {
            if(Math.Abs(100 - n) <= 10 || Math.Abs(200 - n) <= 10) { // between 90 and 210
                return true;
            }
            else {
                return false;
            }
        }

        public static String missingChar(String str, int n) { // returns string str after removing char at index n
            StringBuilder sb = new StringBuilder(str);
            sb.Remove(n, 1);
            Console.WriteLine(sb.ToString());
            Console.ReadLine();
            return sb.ToString();
        }

        public static bool posNeg(int a, int b, bool negative) { // returns true if both nums are pos or neg
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

        public static bool or35(int n) { //returns true if an int is a multiple of 3 or 5
            if(n%3 == 0 || n%5 == 0) {
                return true;
            }
            else {
                return false;
            }
        }

        public static int centeredAverage(int[] nums) {
            int smallest = nums.Min(); // time complexity n
            int largest = nums.Max(); // time complexity n
            int sum = 0; 
            bool skippedMax = false;
            bool skippedMin = false;

            for (int i = 0; i < nums.Length; i++) { // time complexity n
                if (nums[i] == smallest) {
                    if (skippedMin == false) {
                        skippedMin = true;
                    }
                    else {
                        sum += nums[i];
                    }
                }
                else if (nums[i] == largest) {
                    if (skippedMax == false) {
                        skippedMax = true;
                    }
                    else {
                        sum += nums[i];
                    }
                }
                else {
                    sum += nums[i];
                }
            }
            return sum / (nums.Length - 2);
        }

        public static String helloName(String s) { // return "Hello +" a string s
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

        public static String nTwice(String str, int n) { //double a word
            StringBuilder sb = new StringBuilder();
            sb.Append(str.Substring(0, n) + str.Substring(str.Length - n));

            return sb.ToString();
        }

        public static String seeColour(String str) { // returns the string "blue" or "red" depending which comes first in the input string
            if (str.Substring(0, 3) == "red") {
                return str.Substring(0, 3);
            }
            else if (str.Substring(0, 4) == "blue") {
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

        public static Boolean hasBad(String str) { // returns true or false depending if the word contains bad
            if (str.Length < 4) {
                char whitespace = ' ';
                String space = new String(whitespace, 4 - str.Length);
                str += space;
            }
            if (str.Substring(0, 4).Contains("bad")) {
                return true;
            }
            else {
                return false;
            }
        }
        public static String doubleChar(String str) { // double every char in a string
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++) {
                sb.Append(str[i].ToString() + str[i].ToString());
            }
            return sb.ToString();
        }

        public static String repeatEnd(String str, int n) {
            String subString = str.Substring(str.Length - n);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++) {
                sb.Append(subString);
            }
            return sb.ToString();
        }

        public static bool sameStarChar(String str) {
            for (int i = 0; i < str.Length; i++) {
                if (str[i].ToString() == "*" && i != 0 && i != str.Length - 1) {
                    if (!str[i - 1].ToString().Equals(str[i + 1].ToString())) {
                        return false;
                    }
                }
            }
            return true;

        }

        public static int maxBlock(String str) {
            Dictionary<string, int> letterCount = new Dictionary<string, int>();
            for (int i = 0; i < str.Length; i++) {
                if (letterCount.ContainsKey(str[i].ToString())) {
                    letterCount[str[i].ToString()] += 1;
                }
                else {
                    letterCount.Add(str[i].ToString(), 1);
                }
            }
            if (letterCount.Count == 0) {
                return 0;
            }
            else {
                return letterCount.Values.Max();
            }
        }

        public static String withoutString(String baseString, String remove) {
            StringBuilder sb = new StringBuilder(baseString);
            sb.Replace(remove, "");
            return sb.ToString();
        }
        public static String mirrorEnds(String str) {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++) {
                if (str[i].ToString().Equals(str[str.Length - 1 - i].ToString())) {
                    sb.Append(str[i].ToString());
                }
                else {
                    break;
                }
            }
            return sb.ToString();
        }

        public static int sumNumbers(String str) { // sum of numbers in a string
            int sum = 0;
            StringBuilder current = new StringBuilder();

            for (int i = 0; i < str.Length; i++) {
                if (Char.IsDigit(str[i])) {
                    current.Append(str[i].ToString());

                    if (i == str.Length - 1) {
                        sum += Int16.Parse(current.ToString());
                        current.Clear();
                    }
                }
                else if (!Char.IsDigit(str[i]) && current.Length == 0) {
                    continue;
                }
                else {
                    sum += Int16.Parse(current.ToString());
                    current.Clear();
                }
            }
            return sum;
        }
    }
}
