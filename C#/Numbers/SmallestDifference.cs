using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class SmallestDifference
    {
        public static void In2ElementsOf2Arrays(int[] a, int[] b)
        {
            Array.Sort(a);
            Array.Sort(b);
            if (a[0] < b[0])
                Console.WriteLine("Smallest diff: " + GetSmallestDiff(a, b));
            else if (a[0] > b[0])
                Console.WriteLine("Smallest diff: " + GetSmallestDiff(b, a));
            else
                Console.WriteLine("Smallest diff: 0");
        }
        private static int GetSmallestDiff(int[] a, int[] b)
        {
            //Start of A is smaller or Equal to start of B
            int i = 1, j = 0, smallestDiff = int.MaxValue,smallA=-1, smallB=-1;
            while (true)
            {
                if ((i == a.Length || j == b.Length)) break;
                while (a[i] < b[j] && i+1 < a.Length) i++;
                //while (b[j] < a[i]) j++;
                if (a[i - 1] <= b[j] && b[j] <= a[i])
                {
                    smallestDiff = Math.Min(smallestDiff, Math.Min(b[j] - a[i - 1], a[i] - b[j]));
                    if (smallestDiff == b[j] - a[i - 1])
                    { smallA = a[i - 1];smallB = b[j]; }
                    if (smallestDiff == a[i] - b[j])
                    { smallA = a[i]; smallB = b[j]; }
                    j++;
                    if (j == b.Length) continue;

                }
                if (j > 0 && (b[j - 1] <= a[i] && a[i] <= b[j]))
                {
                    smallestDiff = Math.Min(smallestDiff, Math.Min(a[i] - b[j - 1], b[j] - a[i]));
                    if (smallestDiff == b[j] - a[i])
                    { smallA = a[i]; smallB = b[j]; }
                    if (smallestDiff == a[i] - b[j-1])
                    { smallA = a[i]; smallB = b[j-1]; }
                    i++;
                    if (i == a.Length) continue;
                }
                while (b[j] < a[i] && j+1 < b.Length) j++;
            }
            Console.Write("\nPair: ("+smallA+", "+smallB+")");
            return smallestDiff;
        }
    }
}
