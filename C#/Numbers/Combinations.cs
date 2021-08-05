using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class Combinations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr">Input Array</param>
        /// <param name="r"> Size of the combination</param>
        /// <returns></returns>
        public List<int[]> GetAllCombinations(int[] arr, int r)
        {
            List<int[]> combinations = new List<int[]>();
            int[] subset = new int[r];
            GetCombinations(arr, combinations, subset, r, 0, 0);
            return combinations;
        }

        private void GetCombinations(int[] arr, List<int[]> combinations, int[] subset, int r, int index, int current)
        {
            if (r > arr.Length || r < 1) return;
            

            if (index == r)
            {
                combinations.Add((int[])subset.Clone());
                return;
            }
            if (current >= arr.Length) return;

            subset[index] = arr[current];
            GetCombinations(arr, combinations, subset, r, index + 1, current + 1);

            GetCombinations(arr, combinations, subset, r, index, current + 1);


        }
        private void Print(List<int[]> combinations)
        {
            for (int i = 0; i < combinations.Count; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < combinations[i].Length; j++)
                {
                    Console.Write(combinations[i][j] + " ");
                }
            }
        }

        public void GetCombosOfLength(int[] arr, int r)
        {
            List<int[]> combinations = GetAllCombinations(arr, r);
            if (combinations.Count > 0)
                Print(combinations);
            else
                Console.WriteLine("No Combinations were found");
        }
    }
}
