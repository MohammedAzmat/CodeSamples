using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class ReverseString
    {
        public string ReverseStringWords(string s)
        {
            //string[] stringArray = s.Split(' ');
            return String.Join(" ", s.Split(' ').Reverse());
        }

        public void ReverseCharArrayWords(char[] arr)
        {
            
            //Print Input arr
            int i, j = arr.Length - 1,last_i,last_j;
            Console.Write("\nInput Char Array: ");
            for (i = 0; i < arr.Length; i++)
                Console.Write(arr[i]);
            Console.WriteLine();
            
            i = 0;
            last_i = i;
            last_j = j;
            
            while (i < j)
            {
                while (arr[i + 1] != ' ') i++;
                while (arr[j - 1] != ' ') j--;

                int len_i = i - last_i + 1;
                int len_j = last_j - j + 1;
                if (len_i < len_j)
                {
                    //back word is bigger
                }
                else if (len_i > len_j)
                {
                    //fore word is bigger
                }
                else
                {
                    //equal size
                }
            }

            

        }
    }
}
