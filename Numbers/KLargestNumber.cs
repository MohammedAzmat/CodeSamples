using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class KLargestNumber
    {
        private void Swap(int[] arr, int j, int i)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private void Print(int[] ary, int l, int h)
        {
            Console.Write("\nArray: ");
            for (int i = l; i <= h; i++)
                Console.Write(ary[i] + " ");
        }

        private int GetIndex(int[] arr, int l, int h)
        {
            for (int i = l; i < h; i++)
            {
                if (arr[i] < arr[h])
                {
                    if (i != l)
                        Swap(arr, i, l);
                    l++;
                }
            }
            Swap(arr, l, h);
            return l;
        }

        public int KLarge(int[] arr, int k)
        {
            if (k > arr.Length) return -1;
            k = arr.Length - k;
            int index, l = 0, h = arr.Length - 1;
            Print(arr, 0, h);
            while (true)
            {
                index = GetIndex(arr, l, h);
                if (index == k) break;
                if (index > k)
                    h = index - 1;
                else
                    l = index + 1;
            }
            Print(arr, 0, arr.Length-1);
            Console.Write("\nNumber is: ");
            return arr[index];
        }
    }
}
