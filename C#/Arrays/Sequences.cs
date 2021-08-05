using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class Sequences
    {
        public void LongestIncreasingSequence1(int[] arr)
        {
            int stIndex = 0, endIndex = 0,lstStIndex =0,lastSeqCount =int.MinValue;
            displayArray("\n\nInput Array: ", arr, 0, arr.Length);
            for (int i = 0; i < arr.Length -1; i++)
            {
                if (arr[i + 1] > arr[i])
                {
                    endIndex++;
                }
                else
                {
                    if ((endIndex - stIndex + 1) > lastSeqCount)
                    {
                        lstStIndex = stIndex;
                        lastSeqCount = endIndex - stIndex + 1;
                    }
                    stIndex = endIndex = i + 1;
                }
            }
            if ((endIndex - stIndex + 1) > lastSeqCount)
            {
                lstStIndex = stIndex;
                lastSeqCount = endIndex - stIndex + 1;
            }
            string prestr = "\nLongestn Increasing Sequence is from Index " + lstStIndex + " to Index " + (lastSeqCount + lstStIndex - 1) + "\nArray: ";
            displayArray(prestr, arr, lstStIndex, lastSeqCount + lstStIndex);
        }

        public void LargestContigSumSimple(int[] arr)
        {
            int lastLargeSum = int.MinValue, currSum = arr[0];
            displayArray("\n\nInput Array: ", arr, 0, arr.Length);
            for (int i = 1; i < arr.Length; i++)
            {
                if ((arr[i] + currSum) > arr[i])
                {
                    currSum += arr[i];
                }
                else
                {
                    currSum = arr[i];
                }
                if (currSum > lastLargeSum)
                {
                    lastLargeSum = currSum;
                }
            }
            
            string prestr = "\nLargest Contigous Count " + lastLargeSum+"\nArray: ";
            Console.WriteLine(prestr);
            //displayArray(prestr, arr, lstStIndex, lastSeqCount + lstStIndex);
        }

        public void LargestContigSumWithIndex(int[] arr)
        {
            int stIndex = 0, endIndex = 0, lstStIndex = 0, lastSeqCount = 0, lastLargeSum = int.MinValue, currSum = arr[0];
            displayArray("\n\nInput Array: ", arr, 0, arr.Length);
            for (int i = 1; i < arr.Length; i++)
            {
                if ((arr[i] + currSum) > arr[i])
                {
                    currSum += arr[i];
                    endIndex++;
                }
                else
                {
                    currSum = arr[i];
                    stIndex = endIndex = i;
                }
                if (currSum > lastLargeSum)
                {
                    lastLargeSum = currSum;
                    lstStIndex = stIndex;
                    lastSeqCount = endIndex - stIndex + 1;
                }
            }
            string prestr = "\nLargest Contigous Count is from Index " + lstStIndex + " to Index " + (lastSeqCount + lstStIndex - 1) + "\nArray: ";
            displayArray(prestr, arr, lstStIndex, (lastSeqCount + lstStIndex));
        }

        public void LongestIncreasingSubSeq(int[] arr)
        {
            int stIndex = 0, endIndex = 0, lstStIndex = 0, lastSeqCount = 0;
            
            displayArray("\n\nInput Array: ", arr, 0, arr.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i + 1] > arr[i])
                {
                    endIndex++;
                }
            }

            displayArray("\nLongest Increasing Subsequence Array: ", arr, lstStIndex, lastSeqCount + lstStIndex);
            
        }

        private void displayArray(string prestr, int[] a, int stIndex, int endIndex)
        {
            Console.Write(prestr);
            for (int i = stIndex; i < endIndex; i++)
                Console.Write(a[i] + " ");
        }
    }
}
