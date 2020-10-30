using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams {
    class Program {
        static void Main(string[] args) {
            List<string> wordsToCheck = new List<string>();
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

        public static List<string> starAnagrams(List<string> words) {
            List<string> potentialAnagrams = new List<string>(); // words with equal length as the anagram word
            String[] wordLetters = { "s", "t", "a", "r" };

            foreach (String word in words) {
                if (word.Length == 4) {
                    potentialAnagrams.Add(word);
                }
            }
            for (int i = potentialAnagrams.Count - 1; i >= 0; i--) { // loop backwards through all words with equal number of letters
                foreach (String letter in wordLetters) {
                    if (!potentialAnagrams[i].ToString().Contains(letter)) { //if the word does not contain a letter
                        potentialAnagrams.Remove(potentialAnagrams[i]);
                    }
                }
            }

            Console.WriteLine("The words which are anagrams of the word 'star' are: ");
            potentialAnagrams.ForEach(Console.WriteLine);
            return potentialAnagrams;
        }
    }
}
