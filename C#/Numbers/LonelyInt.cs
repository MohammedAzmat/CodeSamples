using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class LonelyInt
    {
        public int GetOutLonelyInt(int[] a)
        {
            int x=0;
            for (int i = 0; i < a.Length; i++)
            {
                x ^= a[i];
            }
            return x;
        }
    }
}
