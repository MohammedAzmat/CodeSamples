using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class JumpingNumbers
    {
        /*
         * Valid Jumping Numbers: 1,2,3,4,5,6,7,8,9,10,12,21,23,
         *                      32..98,101,121,123,210..8987..4343456.. 
         * Invalid Jumping Numbers: 796 and 89098 etc
         */
        private List<int> JumpingNumbersTill(int n)
        {
            List<int> mylist = new List<int>();
            Queue<int> jQ = new Queue<int>(); 
            if (n > 0)
            {
                for (int i = 1; i < 10 && i < n; i++)
                    jQ.Enqueue(i);
                while (jQ.Count > 0)
                {
                    int dQ = jQ.Dequeue();
                    mylist.Add(dQ);
                    //Left Node
                    if (dQ % 10 > 0 && n >= (dQ * 10 + (dQ % 10) - 1)) 
                    {
                        jQ.Enqueue(dQ * 10 + (dQ % 10) - 1);
                    }
                    if (dQ % 10 < 9 && n>= (dQ * 10 + (dQ % 10) + 1))
                    {
                        jQ.Enqueue(dQ * 10 + (dQ % 10) + 1);
                    }
                }
            }
            return mylist;
        }
        public void PrintJumpingNumbers(int n)
        {
            List<int> mylist = JumpingNumbersTill(n);
            Console.Write("\nPrint Jump numbers till: " + n + " Numbers: ");
            foreach (int i in mylist)
                Console.Write(i + " ");
        }
    }
}
