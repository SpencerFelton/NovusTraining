using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBatString3 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(sumNumbers("7 11"));
            Console.ReadLine();
        }

        public static int maxBlock(String str) {
            Dictionary<string, int> letterCount = new Dictionary<string, int>();
            for(int i = 0; i< str.Length; i++) {
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

            for(int i = 0; i < str.Length; i++) {
                if (str[i].ToString().Equals(str[str.Length-1-i].ToString())) {
                    sb.Append(str[i].ToString());
                }
                else {
                    break;
                }
            }
            return sb.ToString();
        }

        public static int sumNumbers(String str) {
            int sum = 0;
            StringBuilder current = new StringBuilder();

            for(int i = 0; i<str.Length; i++) {
                if (Char.IsDigit(str[i])) {
                    current.Append(str[i].ToString());

                    if(i == str.Length - 1) {
                        sum += Int16.Parse(current.ToString());
                        current.Clear();
                    }
                }
                else if(!Char.IsDigit(str[i]) && current.Length == 0) {
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
