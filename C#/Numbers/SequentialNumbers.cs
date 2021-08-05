using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class SequentialNumbers
    {
        private List<int> GetSeqNum(int low, int high)
        {
            if (high < low)
                return null;


            int lowPower = getPower(low);
            int highPower = getPower(high);
            int[] OneOneArray = getOneOneArray(highPower);
            int mynum = low;
            int power = lowPower;
            List<int> results = new List<int>();
            while (mynum <= high)
            {
                int n = 1;
               
                int limit = Convert.ToInt32(Math.Pow(10, power+1));
                //for (int i = 0; i < 10 - power; i++)  // Here I know that the Function will run this much amount of time.
                while (mynum <= high && mynum <=limit )
                {
                    int num = OneOneArray[power] * n++;
                    for (int j = 0; j < power ; j++)
                        num += OneOneArray[j];
                    if (num % 10 == 0)
                        break;
                    if (num >= low && num <= high)
                        results.Add(num);
                    mynum = num;
                }
                power++;
            }

            return results;

        }

        private int[] getOneOneArray(int high)
        {
            //throw new NotImplementedException();
            int[] arr = new int[high+1];
            arr[0] = 1;
            for (int i = 1; i <= high; i++)
            {
                arr[i] = arr[i - 1] + (int)Math.Pow(10, i);
            }
            return arr;
        }

        private int getPower(int n)
        {
            int power = 0;
            while (n >= 10)
            {
                n /= 10;
                power++;
            }
            return power;
        }

        public void PrintSeqNum(int low, int high)
        {
            Console.WriteLine("Seq num between " + low + " and " + high);
            List<int> mylist = GetSeqNum(low,high);
            if (mylist != null)
                foreach (int i in mylist)
                    Console.Write(i + "\t");
            else
                Console.Write(0);
            Console.WriteLine();
            //throw new NotImplementedException();
        }
    }
}
