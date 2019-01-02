using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class LongestSubstring
    {
        public string GetSubstring(string str)
        {
            Console.WriteLine(str);
            int index = 0, subLen = 0, n = str.Length;
            int[,] Results = new int[n + 1, n + 1];
            for (int i = 1; i <= n; i++)
            {
                for (int j = i+1; j <= n; j++)
                {
                    if (str[i - 1] == str[j - 1] && (j - 1) > Results[i - 1, j - 1])
                    {
                        Results[i, j] = Results[i - 1, j - 1] + 1;
                        if (Results[i, j] > subLen)
                        {
                            subLen = Results[i, j];
                            index = Math.Max(i, index);
                        }
                    }
                    else
                        Results[i, j] = 0;

                }
            }
            Console.WriteLine(str.Substring(index-subLen, index-1));
            return str.Substring(index - subLen, index - 1);
        }
    }
}
