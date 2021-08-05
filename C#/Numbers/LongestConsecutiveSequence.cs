using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class LongestConsecutiveSequence
    {
        public int LngstIncrsingConsecSeq(int[] arr)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int elem in arr)
            {
                if (map.ContainsKey(elem))
                    map[elem] += 1;
                else
                    map.Add(elem, 1);
            }
            int longValue = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (!map.ContainsKey(arr[i] - 1))
                {
                    int j = arr[i];
                    int value = map[j];
                    while (map.ContainsKey(j + 1))
                    {
                        j++;
                        value +=map[j];
                    }// 

                    longValue = Math.Max(longValue, value);
                }
            }
            return longValue;
        }
    }
}
