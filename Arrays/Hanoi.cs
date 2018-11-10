using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class Stack
    {
        static readonly int MAX = 100;
        static readonly int NULL = -1;
        private int[] stk;
        private int top;


        public Stack()
        {
            stk = new int[MAX];
            top = -1;
        }

        public bool IsEmpty()
        {
            return (top < 0);
        }

        public bool push(int elem)
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

        public int pop()
        {
            int elem = NULL;
            if (!IsEmpty())
            {
                elem = stk[top];
                top--;
            }
            return elem;
        }

        public int seek()
        {
            int elem = NULL;
            if (!IsEmpty())
            {
                elem = stk[top];
            }
            return elem;
        }

        public int seekAt(int i)
        {
            int elem = NULL;
            if (!IsEmpty())
            {
                elem = stk[i];
            }
            return elem;
        }
        public int TopIndex
        {
            get { return top; }
        }
    }

    public class Hanoi
    {
        private Stack[] tower;
        public Hanoi(int n)
        {
            tower = new Stack[3];
            for(int i=0;i<3;i++)
                tower[i] = new Stack();
            for (int i = n; i > 0; i--)
            {
                tower[0].push(i);
            }
            Console.WriteLine("\nInital State");
            PrintTowers(tower);
            MoveDisks(n, tower[0], tower[1], tower[2]);
            Console.WriteLine("\n\nFinal State");
            PrintTowers(tower);
        }

        private void PrintTowers(Stack[] tower)
        {
            //throw new NotImplementedException();
            for(int i=0;i<3;i++)
                PrintTower(i,tower[i]);
        }

        private void PrintTower(int Index, Stack stack)
        {
            //throw new NotImplementedException();
            string name = null;
            switch (Index)
            {
                case 0: name = "Source";break;
                case 1: name = "Destination"; break;
                case 2: name = "BUffer"; break;
            }
            Console.WriteLine("\nContents of "+name+" Tower: ");
            for (int i = stack.TopIndex; i >= 0; i--)
                Console.Write("\t"+stack.seekAt(i));
        }

        private void MoveDisks(int n, Stack source, Stack destination, Stack temp)
        {
            //throw new NotImplementedException();
            if (n == 0) return;
            MoveDisks(n - 1, source, temp, destination);
            destination.push(source.pop());
            Console.WriteLine("\nIntermidiate State");
            PrintTowers(tower);
            MoveDisks(n-1,temp, destination, source);
        }
    }
}
