using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class Coins
    {
        private List<int[]> CountCoins(int n)
        {
            //Arr : [0,1,2,3] => [peeny,nickle, dime, quarter] => [1,5,10,25]
            List<int[]> mylist = new List<int[]>();
            if (n <= 0)
                return null;
            
            CountCoins(mylist, n - 5, 0, 0, 0, n);
            mylist.Add(new int[] { n, 0, 0, 0 });
            return mylist;
        }

        private int Eval(int p, int n, int d, int q)
        {
            return p + 5 * n + 10 * d + 25 * q;
        }

        private void CountCoins(List<int[]> mylist, int p, int n, int d, int q, int total)
        {
            //throw new NotImplementedException();
            if (p < 0 || n < 0 || d < 0 || q < 0)
                return;
            int sum = Eval(p, n, d, q);
            if (sum > total)
                return;
            if (sum == total)
            {
                mylist.Add(new int[] { p, n, d, q });
                return;
            }
            CountCoins(mylist, p - 5, n, d, q, total);
            CountCoins(mylist, p, n+1, d, q, total);
            CountCoins(mylist, p, n, d+1, q, total);
            CountCoins(mylist, p, n, d, q+1, total);
        }

        public void PrintCoins(int n)
        {
            if (n > 0)
            {
                Console.WriteLine("\nGiven Cents: " + n);
                List<int[]> list = CountCoins(n);
                foreach (int[] arr in list)
                {
                    string str = "\t[ ";
                    foreach (int i in arr)
                        str += i + ",";
                    str = str.Substring(0, str.Length - 1);
                    str += " ]";
                    Console.Write(str + " ");
                }
            }
            else
                Console.WriteLine("\nInvalid Number of Cents please enter a positive integer > 0.\n");
        }
    }
}
