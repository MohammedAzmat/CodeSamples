﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public class Node
    {
        int val;
        Node link;
        public Node(int value)
        {
            val = value;
            link = null;
        }

        public Node Link { get { return link; } set { link = value; } }
        public int Val { get { return val; } set { val = value; } }
    }
    public class Singly
    {
        #region Inserts
        public Node Insert(Node head, int val)
        {
            if (head == null)
                return new Node(val);
            Node cur = head;
            while (cur.Link != null)
                cur = cur.Link;
            cur.Link = new Node(val);
            return head;
        }

        public Node Insert(Node head, Node node)
        {
            if (head == null)
            {
                node.Link = null;
                return node;
            }
            Node cur = head;
            while (cur.Link != null)
                cur = cur.Link;
            cur.Link = node;

            return head;
        }

        public Node InsertAt(Node head, int val, int pos)
        {
            try
            {
                Node node;
                if (head == null)
                {
                    if (pos == 0)
                        return new Node(val);
                    throw new Exception("Invalid Position given");
                }
                if (pos == 0)
                {
                    node = new Node(val);
                    node.Link = head;
                    return node;
                }

                Node cur = head;
                node = new Node(val);

                for (int i = 0; i < pos; i++)
                {
                    if (cur == null && i < pos)
                        throw new Exception("Invalid Position given, Position Exceeds List Length");
                    if (pos == i + 1)
                    {
                        node.Link = cur.Link;
                        cur.Link = node;
                        break;
                    }
                    cur = cur.Link;
                }

                return head;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public Node InsertAt(Node head, Node node, int pos)
        {
            try
            {
                if (head == null)
                {
                    if (pos == 0)
                        return node;
                    throw new Exception("Invalid Position given");
                }
                if (pos == 0)
                {
                    node.Link = head;
                    return node;
                }
                Node cur = head;
                for (int i = 0; i < pos; i++)
                {
                    if (cur == null && i < pos)
                        throw new Exception("Invalid Position given");
                    if (pos == i + 1)
                    {
                        node.Link = cur.Link;
                        cur.Link = node;
                        break;
                    }
                    cur = cur.Link;
                }
                return head;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        #endregion

        #region Deletes
        public Node Remove(Node head, Node node)
        {
            if (head == node)
                return head.Link;
            Node cur = head;
            while (cur.Link != null)
            {
                if (cur.Link == node)
                {
                    cur.Link = node.Link;
                    node.Link = null;
                    break;
                }
                cur = cur.Link;
            }
            return head;
        }

        public Node Remove(Node head, int val, bool All = false)
        {
            if (head.Val == val)
                return head.Link;
            Node cur = head;
            while (cur != null)
            {
                if (cur.Link.Val == val)
                {
                    cur.Link = cur.Link.Link;
                    if (!All)
                        break;
                }
                cur = cur.Link;
            }
            return head;
        }

        public Node RemoveAt(Node head, int pos)
        {
            try
            {
                if (head == null)
                    return null;
                if (pos == 0)
                    return head.Link;
                Node cur = head;
                for (int i = 0; i < pos; i++)
                {
                    if (cur == null && i < pos)
                        throw new Exception("Positions Exceeds List's Length");
                    if (i + 1 == pos)
                    {
                        cur.Link = cur.Link.Link;
                        break;
                    }
                }
                return head;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Node RemoveDup(Node head)
        {
            if (head == null || head.Link == null) return head;
            HashSet<int> set = new HashSet<int>();
            set.Add(head.Val);
            Node cur = head;
            while (cur.Link != null)
            {
                if (set.Contains(cur.Link.Val))
                {
                    cur.Link = cur.Link.Link;
                    continue;
                }
                else
                    set.Add(cur.Val);
                cur = cur.Link;
            }
            return head;
        }


        #endregion

        #region Updates
        public Node UpdateAt(Node head, int val, int pos)
        {
            try
            {
                if (head == null)
                    return null;
                if(pos<0)
                    throw new Exception("Invalid Position to update");

                Node cur = head;
                for (int i = 0; i < pos; i++)
                {
                    if (cur == null && i < pos)
                        throw new Exception("Invalid Position to update");
                    if (i == pos)
                    {
                        cur.Val = val;
                        break;
                    }
                }
                return head;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return head;
            }

        }
        #endregion

        private Node MakeList(int numOfNodes =5)
        {
            if (numOfNodes < 1) return null;
            Random rand = new Random();

            Node head = new Node(rand.Next(1, 10 * numOfNodes));
            Node cur = head;
            if (numOfNodes < 2) return head;
            for (int i = 1; i < numOfNodes; i++)
            {
                cur.Link = new Node(rand.Next(1, 2 * numOfNodes));
                cur = cur.Link;
            }
            return head;
        }

        private void PrintNodes(Node head)
        {
            Console.Write("\nList: ");
            while (head != null)
            {
                Console.Write(head.Val + " ");
                head = head.Link;
            }
            Console.Write("\n");
        }

        public void TestReverse(int num)
        {
            Node head = this.MakeList(num);
            PrintNodes(head);
            //Console.Write("Reverse1: ");
            //PrintNodes(Reverse(head));
            Console.Write("Reverse2: ");
            PrintNodes(Reverse2(head));
        }

        public Node Reverse(Node head)
        {
            if (head == null || head.Link == null) return head;
            Node prev = head,cur = head.Link;
            prev.Link = null;
            while (cur != null)
            {
                head = cur.Link;
                cur.Link = prev;
                prev = cur;
                cur = head;
            }
            return prev;
        }

        public Node Reverse2(Node head)
        {
            if (head == null || head.Link == null) return head;
            Node prev = null, cur = head, next = head.Link;
            while (cur.Link != null)
            {
                cur.Link = prev;
                prev = cur;
                cur = next;
                next = next.Link;
            }
            cur.Link = prev;
            return cur;

        }

        private Node SwapPairs(Node head)
        {
            /*
             * Case 1: Empty List
             * Case 2: One Node
             * Case 3: One Pair
             * Case 4: 5 or more nodes
             */
            if (head == null || head.Link == null) return head;
            Node prev = head, cur = head.Link, node = cur.Link;
            head = cur;
            cur.Link = prev;
            prev.Link = SwapPairs(node);
            return head;
        }

        private Node AddLists(Node l1, Node l2)
        {
            Node head = new Node(0);
            Node cur = head.Link;
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            int carry = 0;
            while (l1 != null && l2 != null)
            {
                int add = carry + l1.Val + l2.Val;
                carry = add / 10;
                cur = new Node(add % 10);
                cur = cur.Link;
                l1 = l1.Link;
                l2 = l2.Link;
            }
            if (l1.Link == null)
                cur.Link = l2;
            if (l2.Link == null)
                cur.Link = l1;
            return head.Link;
        }

        public void LinkedListSwaps()
        {
            int[] arr = { 0, 1, 2, 4, 7 };
            foreach (int node in arr)
            {
                Node head = MakeList(node);
                PrintNodes(head);
                head = SwapPairs(head);
                PrintNodes(head);
            }
            

        }
    }
}
