using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ShuntingYardAlgorithm {
    class Program {
        static void Main(string[] args) {
            StringBuilder queue = new StringBuilder(); // 
            StringBuilder stack = new StringBuilder(); //
            string workingString = "(12+45)*5^(2^-3)"; // eqn goes here
            Dictionary<char, int> operatorPrecedence = new Dictionary<char, int>(); // add operators to dictionary - assigned values in addOperators function
            addOperators('+', operatorPrecedence);
            addOperators('-', operatorPrecedence);
            addOperators('*', operatorPrecedence);
            addOperators('/', operatorPrecedence);
            addOperators('^', operatorPrecedence);
            addOperators('(', operatorPrecedence);
            addOperators(')', operatorPrecedence);

            for (int i = 0; i<workingString.Length; i++) { // for the length of the whole string
                Console.WriteLine(workingString[i]);
                Console.ReadLine();
                if (!isOperator(workingString[i])) { // not a symbol - add to the head of the queue
                    int index2 = findNextOperatorIndex(i, workingString); //for numbers > 1 digit - find the index of the final digit
                    enqueue(i, index2, queue, workingString); // push this number to the head of the queue
                    i = index2; // skip to the next symbol after the number
                }
                else if(isOperator(workingString[i])) { // is a symbol
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
                        while (j < numToRemove+1) { // +1 to include the closing bracket - loop till all symbols between ( and ) are popped from stack
                            popFromStack(stack); 
                            j++;
                        }
                    }
                    else if (operatorPrecedence[workingString[i]] > operatorPrecedence[stack[stack.Length - 1]]) { // current symbol has higher precedence than stack head
                        addToStack(workingString[i], stack);
                    }
                    else if (operatorPrecedence[workingString[i]] == operatorPrecedence[stack[stack.Length - 1]]) { // current symbol has same precedence as stack head
                        if (workingString[i].Equals('^')) { // power has right associativity - it can stay on the stack above itself
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
                Console.WriteLine("Queue: " + queue);
                Console.WriteLine("\nStack: " + stack);
                Console.ReadLine();
            }

            for(int headIdx = stack.Length -1; headIdx >= 0; headIdx--) { // after reaching the end of the string - push all elements in the stack to the end of the queue
                enqueue(headIdx, headIdx, queue, stack);
                popFromStack(stack);
            }

            Console.WriteLine("Final answer is: " + queue);
            Console.ReadLine();
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

        public static void enqueue(int index1, int index2, StringBuilder queue, string workingString) {
            queue.Append(workingString.Substring(index1, index2 - index1 + 1));
        }

        public static void enqueue(int index1, int index2, StringBuilder queue, StringBuilder workingString) {
            queue.Append(workingString.ToString().Substring(index1, index2 - index1 + 1));
        }


        public static void addToStack(char @operator, StringBuilder stack) {
            stack.Append(@operator);
        }

        public static void popFromStack(StringBuilder stack) {
            stack.Remove(stack.Length - 1, 1);
        }

        public static int findNextOperatorIndex(int stringIndex, string workingString) {
            for(int i = stringIndex; i< workingString.Length; i++) { // loop rightwards until reaching an operator or the end of the string
                if (isOperator(workingString[i])) {
                    return i-1;
                }
            }
            return workingString.Length-1; //end of the string
        }


    }
}