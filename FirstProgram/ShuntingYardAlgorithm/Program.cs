using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ShuntingYardAlgorithm {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Please enter the mathematical operation you'd like to perform\nNote: Equations with no solution will not be solved and will cause the program to crash");
            Console.WriteLine("\nAccepted symbols are the mathematical operators '+-*/^()' and the integers 0-9");
            string workingString = Console.ReadLine();

            List<string> queue = toRPNForm(workingString);            

            int final = RPNParser(queue);
            Console.WriteLine("The evaluated equation is equal to: " + final + "\nThe program will close now");
            Console.ReadLine();


        }
        public static string replaceOperators(string workingString) {
            workingString = workingString.Replace(" ", ""); // remove spaces
            workingString = workingString.Replace("--", "+"); // turn all negative subtractions to additions
            workingString = workingString.Replace("+-", "-"); // adding a negative is the same as subtracting
            workingString = workingString.Replace("-+", "-"); // subtracting a positive is the same as 
            workingString = workingString.Replace("*-", "*(0-1)*"); // multiplying by a negative number is the same as multiplying by -1 and a positive number -> (0-1) due to the nature of operations with numbers on both sides
            workingString = workingString.Replace("^^", "^"); // remove double powers - only deal with single powers here
            // ^- is a little more involved
            while (workingString.Contains("^-")) {
                for(int i = 0; i<workingString.Length; i++) {
                    if (workingString[i].Equals('^') && workingString[i+1].Equals('-')) {
                        int leftNumIndex = findPrevOperatorIndex(i-1, workingString); // far left of left number
                        int rightNumIndex = findNextOperatorIndex(i+2, workingString); // far right of right number
                        StringBuilder sb = new StringBuilder(workingString);
                        sb.Insert(rightNumIndex + 1, ")"); // insert closing bracket first, position of left number is not changed by inserting after it
                        sb.Insert(leftNumIndex, "1/(");

                        workingString = sb.ToString();

                        workingString = workingString.Replace("^-", "^");
                        break;
                    }
                }
            }
            return workingString;
        }

        public static List<string> toRPNForm(string workingString) {
            List<string> queue = new List<string>(); // 
            StringBuilder stack = new StringBuilder(); //

            Dictionary<char, int> operatorPrecedence = new Dictionary<char, int>(); // add operators to dictionary - assigned values in addOperators function
            addOperators('+', operatorPrecedence);
            addOperators('-', operatorPrecedence);
            addOperators('*', operatorPrecedence);
            addOperators('/', operatorPrecedence);
            addOperators('^', operatorPrecedence);
            addOperators('(', operatorPrecedence);
            addOperators(')', operatorPrecedence);
            workingString = replaceOperators(workingString);

            for (int i = 0; i < workingString.Length; i++) { // for the length of the whole string
                if (!isOperator(workingString[i])) { // not a symbol - add to the head of the queue
                    int index2 = findNextOperatorIndex(i, workingString); //for numbers > 1 digit - find the index of the final digit
                    enqueue(i, index2, queue, workingString); // push this number to the head of the queue
                    i = index2; // skip to the next symbol after the number
                }
                else if (isOperator(workingString[i])) { // is a symbol
                    if (stack.Length == 0 || workingString[i].Equals('(')) { // either empty stack or opening bracket - add to the stack
                        addToStack(workingString[i], stack);
                    }
                    else if (workingString[i].Equals(')')) { // closig bracket - start at head of stack and look down for matching '(' bracket
                        int headIndex = stack.Length - 1;
                        int numToRemove = 0; // track number of items to pop from stack - DO NOT remove when looping
                        while (!stack[headIndex].Equals('(')) { // loop until '(' found
                            enqueue(headIndex, headIndex, queue, stack); // push any symbols found to the head of the queue
                            headIndex--; // decrement head index
                            numToRemove++; // increment number of elements to remove from stack
                        }
                        int j = 0;
                        while (j < numToRemove + 1) { // +1 to include the closing bracket - loop till all symbols between ( and ) are popped from stack
                            popFromStack(stack);
                            j++;
                        }
                    }
                    else if (operatorPrecedence[workingString[i]] > operatorPrecedence[stack[stack.Length - 1]]) { // current symbol has higher precedence than stack head
                        addToStack(workingString[i], stack);
                    }
                    else if (operatorPrecedence[workingString[i]] == operatorPrecedence[stack[stack.Length - 1]]) { // current symbol has same precedence as stack head
                        if (workingString[i].Equals('^')) { // power has right associativity 2^3 is not the same as 3^2 - it can stay on the stack above itself
                            addToStack(workingString[i], stack);
                        }
                        else { // pop the current head of stack with equal precedence and push to queue, then push current token to head of stack
                            enqueue(stack.Length - 1, stack.Length - 1, queue, stack);
                            popFromStack(stack);
                            addToStack(workingString[i], stack);
                        }
                    }
                    else if (operatorPrecedence[workingString[i]] < operatorPrecedence[stack[stack.Length - 1]]) { // current symbol has lower precedence than stack head
                        int headIndex = stack.Length - 1; // start at stack head
                        int numToRemove = 0; // track elements to pop from stack
                        while (true) { // loop until all elements with larger precedence have been popped from stack
                            if (headIndex >= 0 && operatorPrecedence[stack[headIndex]] >= operatorPrecedence[workingString[i]]) { // as long as there is more than 1 element in stack with higher precedence
                                enqueue(headIndex, headIndex, queue, stack); // push to queue
                                headIndex--; //decrement and increment head/count
                                numToRemove++;
                            }
                            else {
                                break;
                            }
                        }
                        int j = 0;
                        while (j < numToRemove) { // remove all elements that were pushed to queue
                            popFromStack(stack);
                            j++;
                        }
                        addToStack(workingString[i], stack); // add the current token to the head of stack ONLY after all elements with equal/higher precedence have been popped
                    }
                }
            }

            for (int headIdx = stack.Length - 1; headIdx >= 0; headIdx--) { // after reaching the end of the string - push all elements in the stack to the end of the queue
                enqueue(headIdx, headIdx, queue, stack);
                popFromStack(stack);
            }

            Console.WriteLine("The origianal equation in Reverse Polish Notation is: ");
            queue.ForEach(Console.Write);
            Console.WriteLine("\nPlease click to continue to evaluation.");
            Console.ReadLine();

            return queue;
        }
        public static int RPNParser(List<string> RPN) {
            List<String> stack = new List<string>(); // create new stack
            for(int i = 0; i<RPN.Count; i++) { // every item in the output
                if (!isOperator(RPN[i])) { // add any non-operators to the stack
                    stack.Add(RPN[i]);
                }
                else { // otherwise, take the top 2 numbers from the stack and perform the mathematical operation dictated by the current token
                    int leftNum = Int32.Parse(stack[stack.Count - 2]);
                    int rightNum = Int32.Parse(stack[stack.Count - 1]);
                    popFromStack(stack); // remove both numbers from the head of the stack
                    popFromStack(stack);
                    int calculated = operation(RPN[i], leftNum, rightNum);
                    stack.Add(calculated.ToString());
                }
            }
            return Int32.Parse(stack[0]);
        }
        public static int operation(string @operator, int num1, int num2) {
            switch (@operator) {
                case "*":
                    return multiplication(num1, num2);
                case "+":
                    return addition(num1, num2);
                case "/":
                    return division(num1, num2);
                case "-":
                    return subtraction(num1, num2);
                case "^":
                    return power(num1, num2);
                default:
                    return 0;
            }
        }

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
            if (num2 == 0) {
                Console.WriteLine("Tried to divide by 0, program will close now");
                Console.ReadLine();
                Environment.Exit(1);
            }
            return num1 / num2;
        }

        public static int power(int num1, int num2) {
            return (int)Math.Pow(num1, num2);
        }

            public static Dictionary<char, int> addOperators(char @operator, Dictionary<char, int> dict) {
            switch (@operator) {
                case '+':
                    dict.Add(@operator, 2);
                    break;
                case '-':
                    dict.Add(@operator, 2);
                    break;
                case '/':
                    dict.Add(@operator, 3);
                    break;
                case '*':
                    dict.Add(@operator, 3);
                    break;
                case '^':
                    dict.Add(@operator, 4);
                    break;
                case '(':
                case ')':
                    dict.Add(@operator, 0);
                    break;
                default:
                    break;
            }
            return dict;
        }

        public static bool isOperator(char @operator) { 
            switch (@operator) {
                case '+':
                case '-':
                case '*':
                case '/':
                case '^':
                case '(':
                case ')':
                    return true;
                default:
                    return false;
            }
        }

        public static bool isOperator(string @operator) { //string argument where we cant guarantee a char will be used
            switch (@operator) {
                case "+":
                case "-":
                case "*":
                case "/":
                case "^":
                case "(":
                case ")":
                    return true;
                default:
                    return false;
            }
        }

        public static void enqueue(int index1, int index2, List<string> queue, string workingString) {
            queue.Add(workingString.Substring(index1, index2 - index1 + 1));
        }

        public static void enqueue(int index1, int index2, List<string> queue, StringBuilder workingString) {
            queue.Add(workingString.ToString().Substring(index1, index2 - index1 + 1));
        }


        public static void addToStack(char @operator, StringBuilder stack) {
            stack.Append(@operator);
        }

        public static void popFromStack(StringBuilder stack) {
            stack.Remove(stack.Length - 1, 1);
        }

        public static void popFromStack(List<string> stack) {  
            stack.RemoveAt(stack.Count - 1);
        }

        public static int findNextOperatorIndex(int stringIndex, string workingString) {
            for(int i = stringIndex; i< workingString.Length; i++) { // loop rightwards until reaching an operator or the end of the string
                if (isOperator(workingString[i])) { // current token is operator
                    return i-1; // number is 1 less than current index
                }
            }
            return workingString.Length-1; //end of the string
        }

        public static int findPrevOperatorIndex(int stringIndex, string workingString) {
            for (int i = stringIndex; i >= 0; i--) { // loop backwards until reaching operator or beginning of the string;
                if (isOperator(workingString[i])) {
                    return i + 1;
                }
            }
            return 0;
        }
    }
}