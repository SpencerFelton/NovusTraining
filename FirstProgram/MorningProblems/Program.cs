using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorningProblems {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(longestSequence("1,2,1,1,0,3,1,0,0,2,4,1,0,0,0,0,2,1,0,3,1,0,0,0,6,1,3,0,0,0"));
            Console.ReadLine();

            ArrayList wordsToCheck = new ArrayList();
            wordsToCheck.Add("parts");
            wordsToCheck.Add("traps");
            wordsToCheck.Add("arts");
            wordsToCheck.Add("rats");
            wordsToCheck.Add("starts");
            wordsToCheck.Add("tarts");
            wordsToCheck.Add("rat");
            wordsToCheck.Add("art");
            wordsToCheck.Add("tar");
            wordsToCheck.Add("tars");
            wordsToCheck.Add("stars");
            wordsToCheck.Add("stray");

            starAnagrams(wordsToCheck);
            Console.ReadLine();
        }


    public static int longestSequence(String sales) {
            String splitSales = sales.Replace(",", "");
            int days = 0;
            int longestDays = 0;
            for(int i = 0; i < splitSales.Length; i++) {
                if(splitSales[i].ToString().Equals("0")) {
                    days += 1;
                    if(days > longestDays) {
                        longestDays = days;
                    }
                }
                else {
                    days = 0;
                }
            }
            return longestDays;
        }

    public static ArrayList starAnagrams(ArrayList words) {
            ArrayList potentialAnagrams = new ArrayList();
            String[] wordLetters = { "s", "t", "a", "r" };

            foreach(String word in words) {
                if(word.Length == 4) {
                    potentialAnagrams.Add(word);
                }
            }
            for(int i = potentialAnagrams.Count-1; i >= 0; i--) {
                foreach(String letter in wordLetters) {
                    if (!potentialAnagrams[i].ToString().Contains(letter)) { //if the word does not contain a letter
                        potentialAnagrams.Remove(potentialAnagrams[i]);
                    }
                }
            }
            foreach(String item in potentialAnagrams) {
                Console.WriteLine(item);
            }
            return potentialAnagrams;
        }
    }
}
