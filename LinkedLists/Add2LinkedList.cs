using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    /*
     * You are given two non-empty linked lists representing two non-negative integers. 
     * The digits are stored in reverse order and each of their nodes contain a single digit. 
     * Add the two numbers and return it as a linked list.

        You may assume the two numbers do not contain any leading zero, except the number 0 itself.

        Example

        Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
        Output: 7 -> 0 -> 8
        Explanation: 342 + 465 = 807.   
        [2,4,3]
        [5,6,4]
     */
    public static class Add2LinkedList
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int carry = 0, count = 0;
            ListNode head = null, node, prev = null;

            while (l1 != null || l2 != null)
            {
                int sum = 0;
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }
                if (carry != 0)
                    sum += carry;
                carry = sum / 10;
                node = new ListNode(sum % 10);
                if (count == 0)
                {
                    head = node;
                    prev = node;
                }
                else
                {
                    prev.next = node;
                    prev = node;
                }
                //node = node.next;
                count++;
            }
            if (carry != 0)
            {
                node = new ListNode(carry);
                prev.next = node;
                prev = node;
            }
            return head;
        }
        public static ListNode ConvertArray2List(int[] a)
        {
            ListNode head = null,tail = null;
            bool first = true;
            foreach (int x in a)
            {
                ListNode node = new ListNode(x);
                if (first)
                {
                    head = node;
                    tail = node;
                    first = !first;
                }
                else
                {
                    tail.next = node;
                    tail = node;
                }
            }

            return head;
        }
        public static int[] ConvertInt2Array(int a)
        {
            //Convert 342 to [2,4,3]
            var list = new List<int>();
            while (a > 0)
            {
                list.Add(a % 10);
                a /= 10;
            }
            return list.ToArray();
        }
        public static int ConvertLinkedList2Int(ListNode l)
        {
            //COnvert 1->2->3 to 321
            int result = 0;
            Stack<int> stack = new Stack<int>();
            while (l != null)
            {
                stack.Push(l.val);
                l = l.next;
            }
            while (stack.Count != 0)
            {
                result = 10 * result + stack.Pop();
            }
            return result;
        }
        public static int ConvertLinkedList2Int_Recursion(ListNode l)
        {
            return (l != null) ? 10 * ConvertLinkedList2Int_Recursion(l.next) + l.val : 0;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
