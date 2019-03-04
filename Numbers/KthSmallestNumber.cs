using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class KthSmallestNumber
    {
        public int Ksmall(int[] arr, int k)
        {
            int low = 0, high = arr.Length - 1;
            if (arr.Length < k) return -1;
            //print(arr, low, high);
            while (true)
            {
                
                int ret_index = PutElemInPlace(arr, low, high);
                
                if (ret_index == k - 1) break;
                if (ret_index > k - 1)
                    high = ret_index - 1;
                else
                    low = ret_index + 1;
                //Console.Write("Return Index: " + ret_index + " Low: " + low + " High: " + high + "\n");
                //print(arr, low, high);
            }
            print(arr, 0, arr.Length - 1);
            Console.Write("\nNumber is: ");
            return arr[k-1];
        }
        private int PutElemInPlace(int[] arr, int low, int high)
        {
            int pivot = arr[low], temp_high = high;
            for (int i = high; i > low; i--)
            {
                if (arr[i] > pivot)
                {
                    if(temp_high != i)
                        Swap(arr, temp_high, i);
                    temp_high -= 1;
                }
            }

            Swap(arr, low, temp_high);
            return temp_high;
        }

        private void Swap(int[] arr, int low, int i)
        {
            //throw new NotImplementedException();
            int temp = arr[i];
            arr[i] = arr[low];
            arr[low] = temp;
        }

        private void print(int[] ary, int l, int h)
        {
            Console.Write("\nArray: ");
            for (int i = l; i <= h; i++)
                Console.Write(ary[i] + " ");
        }
    }
}
