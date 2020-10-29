using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EquationAsString {
    class Program {
        static void Main(string[] args) {
            String work = "5*3+3-12*8+25-6+8";
            work = checkOperation(work, '/');
            work = checkOperation(work, '*');
            work = checkOperation(work, '-'); //subtraction should come last, however add/sub are associative so can be done in either order - doing sub 1st replaces all "--" and allows add to work
            work = checkOperation(work, '+');

            Console.WriteLine("Fin, answer is: " + Int32.Parse(work));
            Console.ReadLine();
        }

        /*
         * working: String - the string representing the whole equation
         * operation: char - the symbol corresponding to the mathematical operation
         * 
         * Returns the whole working string;
         */
        public static String checkOperation(String working, char operation) {
            Console.WriteLine(operation); // what operation we're on
            while (working.Contains(operation)) {
                int lastIndex = 0;
                int operatorCount = 0;

                //replace symbols before operating on the string
                working = replaceDoubleNeg(working); // replace any "--" with "+" to avoid confusing findPrevNum
                working = replacePosNeg(working); //replace any "+-" with "+" to avoid confusion findPrevNum

                for (int i = 0; i < working.Length; i++) { // loop through working string to find the last occurence of the mathematical operator and count how many there are
                    if (working[i].Equals(operation)) {
                        operatorCount++;
                    }
                    if (working[i].Equals(operation) && i > lastIndex) { // update last index with the last currently seen index
                        lastIndex = i;
                    }
                }
                if(operation.Equals('-') && operatorCount == 1 && working[0].Equals('-')) { // ignore the first symbol if it's '-'
                    break;
                }
                working = doOperator(working, operation, lastIndex);
                Console.WriteLine(working); // step by step working
                Console.ReadLine();
            }

            return working;
        }
        /*
         * working: String - the string representing the whole equation
         * symbol: char - the symbol of the mathematical operation at the index
         * index: int - the index of the mathematical symbol
         * 
         * Returns the working string with the original equation replaced with the answer of that equation "3*2" becomes "6"
         */
        public static String doOperator(String working, char symbol, int index) { // index is the index of the 
            int[] leftNumInfo = findPrevNum(working, index); // array containing the entire number (-ve sign included) and index of leftmost symbol
            int[] rightNumInfo = findNextNum(working, index); // array containing the entire number (-ve sign included) and index of rightmost symbol
            switch (symbol) {
                case '+':
                    int added = addition(leftNumInfo[0], rightNumInfo[0]); // int of 2 numbers summed
                    String addString = replaceEquationWithAnswer(leftNumInfo[1], rightNumInfo[1], added, working);
                    return addString;
                case '-':
                    int subtracted = subtraction(leftNumInfo[0], rightNumInfo[0]); //int of 2 numbers subtracted
                    String subtractString = replaceEquationWithAnswer(leftNumInfo[1], rightNumInfo[1], subtracted, working);
                    return subtractString;
                case '*':
                    int multiplied = multiplication(leftNumInfo[0], rightNumInfo[0]); //int of 2 numbers multiplied
                    String multString = replaceEquationWithAnswer(leftNumInfo[1], rightNumInfo[1], multiplied, working);
                    return multString;
                case '/':
                    int divided = division(leftNumInfo[0], rightNumInfo[0]); //int of 2 numbers divided
                    String divString = replaceEquationWithAnswer(leftNumInfo[1], rightNumInfo[1], divided, working);
                    return divString;
                
                default:
                    return working;
            }
        }
        /*
         * symbol: char - the mathematical symbol
         * 
         * Returns true if a symbol matches typical mathematical operations, false otherwise
         */
        public static bool isOperator(char symbol) { 
            switch (symbol) {
                case '+':
                case '-':
                case '*':
                case '^':
                case '/':
                case '(':
                case ')':
                    return true;
                default:
                    return false;
            }
        }
        /*
         * workingString: String - the string representing the whole equation
         * index: int - position of the mathematical symbol in the middle of the equation being worked on, eg - "12*3", index would be the value corresponding to *
         * 
         * Returns an int array holding 2 values, first value being the number preceeding the symbol as an int, the second being the index of the first symbol in that number
         */
        public static int[] findPrevNum(String workingString, int index) { // returns an array, number as an int and the index of the initial starting symbol for that number
            int finalNumIndex = index - 1;
            int initialNumIndex = 0;
            for (int i = index - 1; i >= 0; i--) { // starting from the position 1 left of the operator symbol, work left
                if (isOperator(workingString[i])) { // come across a symbol
                    if (workingString[i].Equals('-')) { //if it's a negative sign we can take that as the first symbol
                        initialNumIndex = i;
                        break;
                    }
                    else { // come across a symbol that isnt '-' you've reached the end of the number, so the initial position is +1 to the current index
                        initialNumIndex = i + 1;
                        break;
                    }
                }
            }
            String wholeNum = workingString.Substring(initialNumIndex, finalNumIndex - initialNumIndex + 1);
            int wholeNumAsInt = Int32.Parse(wholeNum);
            int[] info = { wholeNumAsInt, initialNumIndex };

            return info;
        }

        /*
         * workingString: String - the string representing the whole equation
         * index: int - position of the mathematical symbol in the middle of the equation being worked on, eg - "12*3", index would be the value corresponding to *
         * 
         * Returns an int array holding 2 values, first value being the number proceeding the symbol as an int, the second being the index of the final symbol in that number
         */
        public static int[] findNextNum(String workingString, int index) {
            int initialNumIndex = index + 1;
            int finalNumIndex = workingString.Length - 1;
            for(int i = initialNumIndex; i < workingString.Length; i++) {
                if (isOperator(workingString[i])) {
                    if (workingString[i].Equals('-') && i == initialNumIndex) {
                        continue;
                    }
                    finalNumIndex = i - 1;
                    break;
                }
            }
            String wholeNum = workingString.Substring(initialNumIndex, finalNumIndex - initialNumIndex + 1);
            int wholeNumAsInt = Int32.Parse(wholeNum);

            int[] info = { wholeNumAsInt, finalNumIndex };
            return info;
        }

        /*
         * firstIndex: int - value of the first symbol on the left of the equation, "-3*12" would give index of '-'
         * secondIndex: int - value of the last symbol on the right of the equation, "-3*12" would give index of '2'
         * ans: int - value of the calculated equation
         * workingString: String - the string representing the whole equation
         * 
         * Returns the workingString with the substring equation (firstIndex - secondIndex) replaced with the answer
         */
        public static String replaceEquationWithAnswer(int firstIndex, int secondIndex, int ans, String workingString) {
            String substring = workingString.Substring(firstIndex, secondIndex - firstIndex + 1);
            String stringAns = ans.ToString();
            
            return workingString.Replace(substring, stringAns);
        }

        public static String replaceDoubleNeg(String workingString) {
            if (workingString.Contains("--")) {
                return workingString.Replace("--", "+");
            }
            return workingString;
        }

        public static String replacePosNeg(String workingString) {
            if (workingString.Contains("+-")) {
                return workingString.Replace("+-", "-");
            }
            return workingString;
        }

  
        // Methods for simple mathematical operations
        public static int addition(int num1, int num2) {
            return num1 + num2;
        }

        public static int subtraction(int num1, int num2) {
            return num1 - num2;
        }

        public static int multiplication(int num1, int num2) {
            return num1 * num2;
        }

        public static int division(int num1, int num2) {
            return num1 / num2;
        }


    }
}
