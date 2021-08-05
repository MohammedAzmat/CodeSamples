using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class SmallestNumberFromString
    {
       
        private class Node
        {
            public char c;
            public Node prev, next;
            public Node(char _c)
            {
                c = _c;
                prev = next = null;
            }
        }

        private class DLL
        {
            public int Count;
            public Node head, tail;
            public DLL()
            {
                head = new Node('h');
                tail = new Node('t');
                head.next = tail;
                tail.prev = head;
                Count = 0;
            }
            public void InsertBack(char c)
            {
                Node temp = new Node(c);
                temp.prev = tail.prev;
                temp.next = tail;
                tail.prev.next = temp;
                tail.prev = temp;
                Count++;
            }
            public void InsertFront(char c)
            {
                Node temp = new Node(c);
                temp.prev = head;
                temp.next = head.next;
                temp.next.prev = temp;
                head.next = temp;
                Count++;
            }

            public Node RemoveLast()
            {
                Node prevToLast = tail.prev.prev;
                Node Last = tail.prev;
                prevToLast.next = tail;
                tail.prev = prevToLast;
                Count--;
                return Last;
            }

            public Node RemoveFront()
            {
                Node front = head.next;
                Node newFront = front.next;
                head.next = newFront;
                newFront.prev = head;
                Count--;
                return front;
            }

            public Node GetLast()
            {
                return tail.prev;
            }

            public Node GetFront()
            {
                return head.next;
            }
        }

        public string GetSmallestNumber(string str, int removedigit = 0)
        {
            string result = "";
            if (removedigit == 0) return str;
            if (str != null && removedigit < str.Length)
            {
                DLL charList = new DLL();
                int i = 0;
                while (i < removedigit)
                {
                    InsertInList(charList, str[i]);
                    i++;
                }

                while (i < str.Length)
                {
                    result += charList.RemoveFront().c.ToString();
                    InsertInList(charList, str[i]);
                    i++;
                }
                result += charList.RemoveFront().c.ToString();
            }
            return result;
        }

        private void InsertInList(DLL charList, char value)
        {
            if (charList.Count == 0)
                charList.InsertBack(value);
            else
            {
                char temp = charList.GetLast().c;
                while (temp > value && charList.Count > 0)
                {
                    charList.RemoveLast();
                    if(charList.Count > 0)
                        temp = charList.GetLast().c;
                }
                charList.InsertBack(value);
            }
        }
    }
}
