using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class Triangle
    {
        public int largestPerimeter(int[] A)
        {
            int maxPerimeter = -1;
            for (int i = 0; (i + 2)< A.Length; i++)
            {
                for (int j = i + 1; j + 1 < A.Length; j++)
                    for (int k = j + 1; k < A.Length; k++)
                        if ((A[i] < (A[j] + A[k])) && (A[j] < (A[i] + A[k])) && (A[k] < (A[j] + A[i])) && maxPerimeter < (A[i] + A[j] + A[k]))
                            maxPerimeter = (A[i] + A[j] + A[k]);
            }
            return maxPerimeter;
        }

        public int largestPerimeterOpt(int[] A)
        {
            QSort(A, 0, A.Length - 1);
            int maxPerimeter = -1;
            for (int i = A.Length - 1; i >= 2; i--)
            {
                //check if biggest value is smaller than sum of the previous two
                if ((A[i] < (A[i - 1] + A[i - 2])) && maxPerimeter < (A[i] + A[i - 1] + A[i - 2]))
                    maxPerimeter = A[i] + A[i - 1] + A[i - 2];
            }
            return maxPerimeter;
        }

        public int pairWithSameValue(int[] A)
        {
            Dictionary<int, int> myDict = new Dictionary<int, int>();
            int pairs = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (myDict.ContainsKey(A[i]))
                    myDict[A[i]] += 1;
                else
                    myDict.Add(A[i], 1);
            }
            foreach (int key in myDict.Keys)
            {
                if (myDict[key] > 1)
                {
                    pairs += myDict[key] * (myDict[key] - 1) / 2;
                }
            }
            return pairs;
        }

        private int GetPivot(int[] A, int low, int high)
        {
            int low_index = low;
            for (int i = low; i < high; i++)
            {
                if (A[i] < A[high])
                {
                    //Swap ith with Current Low
                    A[low_index] = A[low_index] + A[i];
                    A[i] = A[low_index] - A[i];
                    A[low_index] = A[low_index] - A[i];
                    low_index += 1;
                }

            }
            //Swap High with Pivot and return Pivot
            A[low_index] = A[low_index] + A[high];
            A[high] = A[low_index] - A[high];
            A[low_index] = A[low_index] - A[high];
            return low_index;
        }

        private void QSort(int[] A, int low, int high)
        {
            if (low < high)
            {
                int pivot = GetPivot(A, low, high);
                QSort(A, low, pivot - 1);
                QSort(A, pivot + 1, high);
            }
        }
    }
}
