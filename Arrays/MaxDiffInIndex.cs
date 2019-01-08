using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class MaxDiffInIndex
    {
        /*
         * arr = {35, 5, 3, 2, 20, 10, 24, 32, 34, 1}   
         * .......... Arr.Length = 10 Output : 7 (8 -1 ) ie A[8] (34)  - A[1] (5)
         */
        private int GetMaxIndexDiff(int[] arr)
        {
            int[] minIndexes = new int[arr.Length];
            int[] maxIndexes = new int[arr.Length];
            int maxDiff = int.MinValue, i, j = 0;

            minIndexes[0] = arr[0];
            int index = 0;
            for (i = 1; i < arr.Length; i++)
            {
                /*
                if (arr[i] >= arr[index])
                { minIndexes[i] = index; }
                else
                {
                    minIndexes[i] = i;
                    index = i;
                }
                */
                minIndexes[i] = (arr[i] < minIndexes[i - 1]) ? arr[i]: minIndexes[i-1];
                
            }
            index = arr.Length - 1;
            maxIndexes[index] = arr[index];
            for (i = arr.Length - 2; i >= 0; i--)
            { 
                /*
                if (arr[i] <= arr[index])
                {
                    maxIndexes[i] = index;
                }
                else
                {
                    maxIndexes[i] = i;
                    index = i;
                }
                */
                maxIndexes[i] = (arr[i] > maxIndexes[i + 1]) ? arr[i] : maxIndexes[i + 1];
            }
            i = 0;
            while (i < arr.Length && j < arr.Length)
            {
                if (minIndexes[i] < maxIndexes[j])
                {
                    maxDiff = (maxDiff < j - i) ? j - i : maxDiff;
                    j++;
                }
                else
                    i++;
            }

            return maxDiff;
        }
        public void PrintMaxDiffInIndexes(int[] arr)
        {
            if (arr != null && arr.Length > 1)
            {
                Console.Write("\nArray:");
                for (int i = 0; i < arr.Length; i++)
                    Console.Write(" " + arr[i]);
                Console.WriteLine(" MaxDiff: " + GetMaxIndexDiff(arr));
            }
        }
    }
}
