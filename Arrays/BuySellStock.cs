using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class BuySellStock
    {
        /*
         *  Array: 20 5 2 8 10 15 7 11 13 1 2
            Buy On Day: 3 at Unit Price: 2  Sell on day: 6 for: 15

            Array: 20 5 2 8 10 15 7 11 13 1 2 18
            Buy On Day: 10 at Unit Price: 1 Sell on day: 12 for: 18

            Array: 20 5 2 8 10 15 7 11 13 1 18
            Buy On Day: 10 at Unit Price: 1 Sell on day: 11 for: 18

            Array: 1 0 0 0 0 0 0 0 0 0 0 0 0
            Optimal Solution not found
         */
        public int[] SimpleStockMarket(int[] a)
        {
            int min = a.Length - 1, max = 1,mxValue = int.MinValue,mnValue = int.MaxValue,j=0,i=1;
            while ( i < a.Length)
            {
                if (a[j] < mnValue && j < max)
                {
                    if (a[j] != 0)
                    {
                        mnValue = a[j];
                        min = j;
                    }
                    j++;
                }
                if (a[i] > mxValue)
                {
                    if (a[i] != 0)
                    {
                        mxValue = a[i];
                        max = i;
                    }
                }
                i++;
            }
            if (i == a.Length && j < a.Length - 1 && j < max)
            {
                while ( j < max)
                {
                    if (a[j] < mnValue &&  a[j] != 0)
                    {
                        mnValue = a[j];
                        min = j;
                    }
                    j++;
                }
            }
            if (a[min] < a[max])
                return new int[] { min, max };
            else
                return new int[] { 0, 0 };
        }

        public void GetBuySellDays(int[] a)
        {
            int[] b = SimpleStockMarket(a);
            if (b[0] == b[1])
            {
                Console.Write("\n\nArray: ");
                for (int i = 0; i < a.Length; i++)
                {
                    Console.Write(a[i] + " ");
                }
                Console.Write("\nOptimal Solution not found");
            }
            else
            {
                Console.Write("\n\nArray: ");
                for (int i = 0; i < a.Length; i++)
                {
                    Console.Write(a[i] + " ");
                }
                Console.Write("\nBuy On Day: " + (b[0]+1) + " at Unit Price: " + a[b[0]] + "\tSell on day: " + (b[1]+1) + " for: " + a[b[1]]);
            }
        }
    }
}
