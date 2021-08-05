using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class PairedSocks
    {
        public int GetPairedSocks(int n, int[] ar)
        {
            HashSet<int> singles = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                if (singles.Contains(ar[i]))
                    singles.Remove(ar[i]);
                else
                    singles.Add(ar[i]);
            }
            return (n - singles.Count) / 2;
        }
    }
}
