using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class TwoNumbersAsSumOfGivenNumber
    {
        private List<int> Exact(int[] arr, int sum)
        {
            List<int> retVal = new List<int>();
            retVal.Add(-1);
            retVal.Add(-1);
            int max = int.MinValue;
            Dictionary<int, int> complementSum = new Dictionary<int, int>();
            for (int i = 0; i<arr.Length;i++)
            {
                int complement = sum - arr[i];
                if (complementSum.ContainsKey(complement))
                {
                    int localMax = Math.Max(arr[i], complement);
                    if (localMax > max)
                    {
                        max = localMax;
                        retVal[0] = Math.Min(i, complementSum[complement]);
                        retVal[1] = Math.Max(i, complementSum[complement]);
                    }
                    /*
                    retVal.Add(complementSum[complement]);
                    retVal.Add(i);
                    return retVal;
                    */
                }
                else
                {
                    complementSum.Add(arr[i], i);
                }
            }
            return retVal;
        }

        private Tuple<int, int> FindTwoSum(List<int> input, int number)
        {
            Dictionary<int, int> complementSum = new Dictionary<int, int>();
            for (int i = 0; i < input.Count; i++)
            {
                int complement = number - input[i];
                if (complementSum.ContainsKey(complement))
                {
                    return new Tuple<int, int>(complementSum[complement], i);
                }
                else
                {
                    complementSum.Add(input[i], i);
                }
            }
            return null;

        }

        public void Print(int[] arr, int sum)
        {
            Console.Write("\nSum: "+sum+" Array: ");
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            List<int> retval = Exact(arr, sum);
            Console.Write("Indexes: ");
            foreach (int item in retval)
                Console.Write(item + " ");
            Console.Write("Values: ");
            foreach (int item in retval)
                Console.Write(arr[item] + " ");
            Console.Write("\n");
        }
    }
}
