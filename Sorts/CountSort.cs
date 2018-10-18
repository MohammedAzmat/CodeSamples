using System;
using System.Collections.Generic;
using System.Text;

namespace Sorts
{
    public class CountSort
    {
        public int[] CntSort(int[] ary)
        {
            int max = int.MinValue,min = int.MaxValue, total = 0;
            int[] output = new int[ary.Length];
            Dictionary<int, int> Counts = new Dictionary<int, int>();
            for (int i = 0; i < ary.Length; i++)
            {
                if (Counts.ContainsKey(ary[i]))
                    Counts[ary[i]] += 1;
                else
                    Counts.Add(ary[i], 1);
                if (max < ary[i])
                    max = ary[i];
                if (min > ary[i])
                    min = ary[i];
            }
            //Get Start Indexes of each keys
            for (int i = min; i <= max; i++)
            {
                //Weather Key exists
                if (Counts.ContainsKey(i))
                {
                    int oldC = Counts[i];
                    Counts[i] = total;
                    total += oldC;
                }
            }

            for (int i = 0; i < ary.Length; i++)
            {
                output[Counts[ary[i]]] = ary[i];
                Counts[ary[i]] += 1;
            }
            return output;

        }

        public void printArray(int[] ary)
        {
            Console.Write("Out Array: ");
            foreach (int x in ary)
                Console.Write(x + ", ");
        }
    }
}
