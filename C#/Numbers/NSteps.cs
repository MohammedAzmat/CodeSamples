using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class NSteps
    {
        /*
         Number of ways to climb n steps given you can go 1,2,3 steps at a time.
         */
        public int ways,ways2;
        private Dictionary<int, int> waysMap;
        public NSteps(int n=5)
        {
            ways = NumOfSteps(n);
            waysMap = new Dictionary<int, int>();
            waysMap.Add(0, 0);
            waysMap.Add(1, 1);
            waysMap.Add(2, 2);
            waysMap.Add(3, 4);
            ways2 = NumOfSteps(n,waysMap);
        }
        private int NumOfSteps(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 2;
            if (n == 3) return 4;

            return NumOfSteps(n - 3) + NumOfSteps(n - 2) + NumOfSteps(n - 1);
        }

        private int NumOfSteps(int n, Dictionary<int, int> waysMap)
        {

            if (waysMap.ContainsKey(n))
                return waysMap[n];

            if (!waysMap.ContainsKey(n - 3))
                waysMap.Add(n - 3, NumOfSteps(n - 3, waysMap));
            if (!waysMap.ContainsKey(n - 2))
                waysMap.Add(n - 2, NumOfSteps(n - 2, waysMap));
            if (!waysMap.ContainsKey(n - 1))
                waysMap.Add(n - 1, NumOfSteps(n - 1, waysMap));


            return waysMap[n - 3] + waysMap[n - 2] + waysMap[n - 1];
        }
    }
}
