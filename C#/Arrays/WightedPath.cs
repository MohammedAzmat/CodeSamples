using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class WightedPath
    {
        public int GetPath(int nodes, int[] From, int[] To, int[] Cost)
        {
            int[,] mat = new int[nodes + 1, nodes + 1];
            int minCost = int.MaxValue;
            for (int i = 0; i < From.Length; i++)
            {
                mat[From[i], To[i]] = Cost[i];
            }
            if (mat[1, nodes] == 0) return 1;
            HashSet<int> visited = new HashSet<int>();
            minCost = mat[1, nodes];
            for (int i = 2; i < nodes; i++)
            {
                if (minCost <= mat[1, nodes])
                {
                    visited.Add(i);
                    int hopCost = (mat[1, i] == 0) ? 1 : mat[1, i];
                    minCost = GetCost(mat, minCost, hopCost, i, nodes, visited);
                    visited.Remove(i);
                }
            }
            return minCost;
        }
        private int GetCost(int[,] mat, int minCost, int curCost, int index, int target, HashSet<int> visited)
        {
            if (mat[index, target] == 0)
                return Math.Min(minCost, curCost + 1);
            for (int i = 2; i <= target; i++)
            {
                if (i == index) continue;

                int nextHopCost = (mat[index, i] == 0) ? 1 : mat[index, i];
                if (!visited.Contains(i) && (curCost + nextHopCost) < minCost)
                {
                    visited.Add(i);
                    minCost = GetCost(mat, minCost, curCost + nextHopCost, i, target, visited);
                    visited.Remove(i);
                }
            }
            return minCost;
        }

    }
}
