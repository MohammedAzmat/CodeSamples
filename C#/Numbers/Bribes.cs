using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class Bribes
    {
        public void minimumBribes(int[] q)
        {
            int n = q.Length, count = 0;
            bool chaos = false;
            while (n > 0)
            {
                int ind = getIndex(q, n);
                if (ind + 1 == n) { n--; continue; }

                if (ind == -1 || !(ind + 2 == n || ind + 3 == n))
                {
                    chaos = true; break;
                }
                else
                {
                    while (ind + 1 < n)
                    {
                        q[ind] = q[ind] + q[ind + 1];
                        q[ind + 1] = q[ind] - q[ind + 1];
                        q[ind] = q[ind] - q[ind + 1];
                        ind++;
                        count++;
                    }
                }
                n--;
            }
            if (chaos)
                Console.WriteLine("Too Chaotic");
            else
                Console.WriteLine(count);

        }
        private int getIndex(int[] a, int n)
        {
            for (int i = 0; i < a.Length; i++)
                if (a[i] == n)
                    return i;
            return -1;
        }
    }
}
