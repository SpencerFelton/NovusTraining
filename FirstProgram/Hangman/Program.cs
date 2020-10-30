using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hangman {
    class Program {
        static void Main(string[] args) {
            hangman();
        }

        public static void hangman() {
            String word = "";
            Regex numCheck = new Regex("\\d"); //Regex to check for any digits

            while (true) { // loop until user enters a valid word
                Console.WriteLine("Enter a word - only letters from the English alphabet are accepted:");
                word = Console.ReadLine().ToLower(); // standard convert to lowercase
                if (word.Contains(" ")) {
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
            int lives = 9;

            while (correctLetters.Length != uniqueLetters.Length) { // Loop until there are the same number of correct letters as unique letters in the word
                if(lives == 0) {
                    Console.WriteLine("Out of lives! Game over! The word was: " + word);
                    Console.WriteLine("\nThe program will now exit.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                Console.WriteLine("Lives left: " + lives);
                Console.WriteLine("\nGuess a letter: ");
                String letterGuess = Console.ReadLine().ToLower(); // Standard convert to lowercase
                if (letterGuess.Length > 1) {
                    Console.WriteLine("Too long!");
                }
                else if (letterGuess.Length < 1) {
                    Console.WriteLine("Too short!");
                }
                else if (letterGuess.Length == 0) {
                    Console.WriteLine("Please enter a letter");
                }
                else if (guessedLetters.Contains(letterGuess)) {
                    Console.WriteLine("Already guessed that!");
                }
                else if (word.Contains(letterGuess)) {
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
                    lives--;
                    guessedLetters += letterGuess;
                }
            }
            Console.WriteLine("Congrats! The word was: " + word);
            Console.ReadLine();
        }

        public static String removeDupes(String word) { // removes duplicate letters from a word and returns a string
            String uniqueLetters = "";
            for (int i = 0; i < word.Length; i++) {
                if (!uniqueLetters.Contains(word[i].ToString())) {
                    uniqueLetters += word[i].ToString();
                }
            }
            return uniqueLetters;
        }
    }
}
