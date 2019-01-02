using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class MinSwaps
    {
        /*       public int MinSwap(int[] arr)
               {
                   int count = 0;
                   for (int i = 0; i < arr.Length; i++)
                   {
                       Print(arr);
                       int j = i + 1;
                       for (; j + 1 < arr.Length; j++)
                       {
                           if (arr[i] > arr[j])
                           {
                               if (arr[j] < arr[j + 1] && arr[i] > arr[j])
                                   continue;
                               else if (arr[j] > arr[j + 1])
                               {
                                   count = Swap(arr, i, j + 1, count);
                                   i--;
                                   break;
                               }
                               else if (arr[i] < arr[j + 1])
                               {
                                   count = Swap(arr, i, j, count);
                                   //i--;
                                   break;
                               }
                           }
                           else
                           {
                               if (arr[i] < arr[j])
                               {
                                   continue;
                               }

                           }
                           if (j + 1 == arr.Length && arr[i] > arr[i+1])
                               count = Swap(arr, i, i + 1,count);
                       }
                   }
                   return count;
               }
       */
        public int MinSwap(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                Print(arr);
                int j = i + 1;
                for (; j + 1 < arr.Length; j++)
                {
                    if (arr[i] > arr[j] && arr[j] < arr[j + 1])
                    {
                        if (arr[i] < arr[j + 1])
                        {
                            count = Swap(arr, i, j, count);
                            break;
                        }
                        else
                            continue;
                    }
                    else if (arr[i] > arr[j] && arr[j] > arr[j + 1])
                    {
                        count = Swap(arr, i, j + 1, count);
                        i--;
                        break;
                    }
                    else if (arr[i] < arr[j] && arr[j] < arr[j+1])
                    {
                        continue;
                    }
                    else if (arr[i] < arr[j] && arr[j] > arr[j+1])
                    {
                        count = Swap(arr, j, j + 1, count);
                        j = i + 1;
                    }
                }
                if (j + 1 == arr.Length && arr[i] > arr[i + 1])
                {
                    count = Swap(arr, i, i + 1, count);
                    j = i + 1;
                }
            }
            return count;
        }

        private void Print(int[] arr)
        {
            //throw new NotImplementedException();
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        private int Swap(int[] arr, int i, int j, int count)
        {
            //throw new NotImplementedException();
            arr[i] += arr[j];
            arr[j] = arr[i] - arr[j];
            arr[i] = arr[i] - arr[j];
            return count+1;


        }
    }
}
