using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    class Find2LonerInASeaOfPairs
    {
        public void Find2NonPairs(int[] arr)
        {
            //int[] arr = { 3, 5, 4, 6, 1, 2, 3, 4, 5, 6 };
            int XOR = arr[0];
            for (int i = 1; i < arr.Length; i++)
                XOR ^= arr[i];
            Console.WriteLine("1: " + XOR);
            Console.WriteLine("1a: " + ~XOR);
            int set_bit_no = XOR & ~(XOR - 1);
            Console.WriteLine("2: " + set_bit_no);
            int x = 0, y = 0;

            // Initialize missing numbers 
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("3[" + i + "]: " + arr[i] + " & " + set_bit_no + " = " + (arr[i] & set_bit_no) + "\tx=" + x + " y=" + y);
                if ((arr[i] & set_bit_no) > 0)
                    // XOR of first set in arr[] 
                    x = x ^ arr[i];
                else
                    // XOR of second set in arr[] 
                    y = y ^ arr[i];
            }
            Console.WriteLine("4: x=" + x + " y=" + y);
        }
    }
}
