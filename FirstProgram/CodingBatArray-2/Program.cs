using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodingBatArray_2 {
    class Program {
        static void Main(string[] args) {
            hangman();
        }

        public static int centeredAverage(int[] nums) {
            int smallest = nums.Min();
            int largest = nums.Max();
            int sum = 0;
            bool skippedMax = false;
            bool skippedMin = false;

            for(int i = 0; i < nums.Length; i++) {
                if(nums[i] == smallest) {
                    if (skippedMin == false) {
                        skippedMin = true;
                    }
                    else {
                        sum += nums[i];
                    }
                }
                else if(nums[i] == largest) {
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

        public static void stars(int rows) {
            for(int i = 0; i < 2*rows-1 ; i++) {
                if(i < rows) {
                    String blanks = new String(' ', rows-i-1);
                    String star = new String('*', ((i+1)*2) - 1);

                    Console.WriteLine(blanks + star); 
                }
                else {
                    int j = Math.Abs(i - (rows - 1) * 2);
                    String revBlanks = new string(' ', Math.Abs(rows - i - 1));
                    String revStars = new String('*', ((j + 1) * 2) - 1);

                    Console.WriteLine(revBlanks + revStars);
                }
            }
            Console.ReadLine();
        }

        public static void hangman() {
            String word = "";
            Regex numCheck = new Regex("\\d"); //Regex to check for any digits

            while (true) { // loop until user enters a valid word
                Console.WriteLine("Enter a word");
                word = Console.ReadLine().ToLower(); // standard convert to lowercase
                if(word.Contains(" ")) {
                    Console.WriteLine("Single words only please");
                }
                else if (numCheck.IsMatch(word)) { 
                    Console.WriteLine("No numbers");
                }
                else {
                    break;
                }
            }
            
            String uniqueLetters = removeDupes(word); // removes duplicates from word, ie hello becomes helo, used to break out of guessing loop
            String correctLetters = ""; // String for storing all correct letters
            String guessedLetters = ""; // String for storing all guessed letters to prevent repeat guesses

            while(correctLetters.Length != uniqueLetters.Length) { // Loop until there are the same number of correct letters as unique letters in the word
                Console.WriteLine("Guess a letter: ");
                String letterGuess = Console.ReadLine().ToLower(); // Standard convert to lowercase
                if (letterGuess.Length > 1) {
                    Console.WriteLine("Too long!");
                }
                else if (letterGuess.Length < 1) {
                    Console.WriteLine("Too short!");
                }
                else if (letterGuess.Length == 0){
                    Console.WriteLine("Please enter a letter");
                }
                else if (guessedLetters.Contains(letterGuess)) {
                    Console.WriteLine("Already guessed that!");
                }
                else if(word.Contains(letterGuess)) {
                    correctLetters += letterGuess;
                    guessedLetters += letterGuess;

                    StringBuilder lettersSoFar = new StringBuilder(); // Used for printing all correct letters 

                    for (int i = 0; i < word.Length; i++) {
                        if (correctLetters.Contains(word[i].ToString())) {
                            lettersSoFar.Append(word[i].ToString());
                        }
                        else {
                            lettersSoFar.Append("_");
                        }
                    }
                    Console.WriteLine(lettersSoFar.ToString());

                }
                else {
                    guessedLetters += letterGuess;
                }
            }
            Console.WriteLine("Congrats! The word was: " + word);
            Console.ReadLine();
        }

        public static String removeDupes(String word) { // removes duplicate letters from a word and returns a string
            String uniqueLetters = "";
            for(int i = 0; i < word.Length; i++) {
                if (!uniqueLetters.Contains(word[i].ToString())){
                    uniqueLetters += word[i].ToString();
                }
            }
            return uniqueLetters;
        }
    }
}
