using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class Stack
    {
        static readonly int MAX = 100;
        static readonly char NULL = '\0';
        private char[] stk;
        private int top;

        
        public Stack()
        {
            stk = new char[MAX];
            top = -1;
        }

        public bool IsEmpty()
        {
            return (top < 0);
        }

        public bool push(char elem)
        {
            if (top < MAX)
            {
                top++;
                stk[top] = elem;
                return true;
            }
            else
            {
                //Stack Overflow
                return false;
            }
        }

        public char pop()
        {
            char elem = NULL;
            if (!IsEmpty())
            {
                elem = stk[top];
                top--;
            }
            return elem;
        }

        public char seek()
        {
            char elem = NULL;
            if (!IsEmpty())
            {
                elem = stk[top];
            }
            return elem;
        }
    }

    public class Brackets
    {
        private Dictionary<char, char> bracketpairs;

        public Brackets()
        {
            
        }
        public int Order(string str)
        {
            bracketpairs = new Dictionary<char, char>();
            bracketpairs.Add('{', '}');
            bracketpairs.Add('(', ')');
            bracketpairs.Add('[', ']');
            bracketpairs.Add('<', '>');
            Stack stack = new Stack();
            for (int i = 0; i < str.Length; i++)
            {
                if (stack.IsEmpty())
                    stack.push(str[i]);
                else
                {
                    char top = stack.seek();
                    if (IsMatch(stack.seek(), str[i]))
                        stack.pop();
                    else
                        stack.push(str[i]);
                }
            }
            if (stack.IsEmpty())
                return 1;
            else
                return 0;
        }
        private bool IsMatch(char stkTop, char curElem)
        {
            
            return (bracketpairs.ContainsKey(stkTop) && (bracketpairs[stkTop] == curElem));
        }

        private List<string> Combos(int n)
        {
            char[] bracketString = new char[2 * n];
            List<string> myList = new List<string>();
            AddBracket(myList, n, n, 0, bracketString);
            return myList;
        }

        private void AddBracket(List<string> myList, int left, int right, int i, char[] bracketString)
        {
            //throw new NotImplementedException();
            if (left < 0 || right < 0 || right < left) return;

            if (left == 0 && right == 0)
                myList.Add(string.Join("",bracketString));
            else
            {
                bracketString[i] = '(';
                AddBracket(myList, left - 1, right, i + 1, bracketString);

                bracketString[i] = ')';
                AddBracket(myList, left, right-1, i + 1, bracketString);
            }

        }

        public void PrintBracketString(int n)
        {
            List<string> Test = Combos(n);
            Console.WriteLine("Combinations for n = " + n);
            foreach (string str in Test)
                Console.Write(str + " ");
            Console.WriteLine();
        }

        public void GetLongestValidBracketLength(string str)
        {
            Stack<char> mystack = new Stack<char>();
            int tempCount = 0, finalCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (mystack.Count > 0)
                {
                    if (str[i] == '(')
                        mystack.Push(str[i]);
                    else
                    {
                        mystack.Pop();
                        tempCount += 2;
                    }
                }
                else
                {
                    if (str[i] == '(')
                        mystack.Push(str[i]);
                    else
                    {
                        finalCount = Math.Max(finalCount, tempCount);
                        tempCount = 0;
                    }
                }
            }
            finalCount = Math.Max(finalCount, tempCount);
            Console.WriteLine("String: "+str+" Logest Valid Substring Length: " + finalCount);
        }
    }
}
