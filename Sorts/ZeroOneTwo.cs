using System;
using System.Collections.Generic;
using System.Text;

namespace Sorts
{
    public class ZeroOneTwo
    {
        public void ZOT(int[] ary)
        {
            int i = 0, j = ary.Length - 1,k=i;
            while (i < j && i < ary.Length && k <j)
            {
                if (ary[i] > ary[j])
                {
                    swap(ary, i, j);
                    if (ary[i] == 0)
                    { i++; k = i; }
                    if (ary[j] == 2)
                        j--;
                }
                else if (ary[i] > ary[i + 1])
                {
                    swap(ary, i, i + 1);
                    if (ary[i] == 0)
                    { i++; k = i; }
                }
                else if (ary[j] < ary[j - 1])
                {
                    swap(ary, j, j - 1);
                    if (ary[j] == 2)
                        j--;
                }
                else if (ary[i] == ary[j] && i == k)
                {
                    if (ary[j] == 2)
                        j--;
                    else if (ary[i] == 0)
                        i++;
                    else
                        k++;
                }
                else if (i != k && k < j)
                {
                    if (ary[k] == ary[j])
                    {
                        if (ary[j] == 2)
                            j--;
                        else if (ary[k] == 0)
                            k++;
                        else
                            k++;
                    }
                    else if (ary[k] > ary[j])
                    {
                        swap(ary, k, j);
                        if (ary[i] == 0)
                        { i++; k = i; }
                        if (ary[j] == 2)
                            j--;
                    }
                    else if (ary[k] > ary[k + 1])
                    {
                        swap(ary, k, k + 1);
                        if (ary[i] == 0)
                        { i++; k = i; }
                    }
                    else if (ary[i] > ary[k])
                    {
                        swap(ary, i,k);
                        if (ary[i] == 0)
                        { i++; k = i; }
                    }
                    else
                        k++;
                }
                else
                {
                    if (ary[i] == 0)
                        i++;
                    if (ary[j] == 2)
                        j--;
                }

            }
            for ( i = 0; i < ary.Length; i++)
            {
                Console.Write(ary[i]+" ");
            }
        }

        public void ZOT2(int[] a)
        {
            int lo = 0;
            int hi = a.Length - 1;
            int mid = 0, temp = 0;

            while (mid <= hi)
            {
                switch (a[mid])
                {
                    case 0:
                        {
                            temp = a[lo];
                            a[lo] = a[mid];
                            a[mid] = temp;
                            lo++;
                            mid++;
                            break;
                        }
                    case 1:
                        mid++;
                        break;
                    case 2:
                        {
                            temp = a[mid];
                            a[mid] = a[hi];
                            a[hi] = temp;
                            hi--;
                            break;
                        }
                }
            }
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
        }
        /// <summary>
        /// The Program Group Sorts the entire array as [HighPriority......MediumPriority......LowPriority]
        /// </summary>
        /// <param name="productCodes"></param>
        public void OrderProductsByPriority(string[] productCodes)
        {
            if (productCodes != null && productCodes.Length > 0)
            {
                int highPriority = 0, lowPriority = productCodes.Length - 1, mediumPriority = 0;
                while (mediumPriority <= lowPriority)
                {
                    switch (GetPriority(productCodes[mediumPriority]))
                    {
                        case 1:
                            {
                                Swap(productCodes, highPriority, mediumPriority);
                                highPriority++;
                                mediumPriority++;
                                break;
                            }
                        case 2:
                            mediumPriority++;
                            break;
                        case 3:
                            {
                                Swap(productCodes, lowPriority, mediumPriority);
                                lowPriority--;
                                break;
                            }
                    }
                }
            }
        }

        private int GetPriority(string v)
        {
            throw new NotImplementedException();
        }

        private void Swap(string[] productCodes, int i, int j)
        {
            string temp = productCodes[i];
            productCodes[i] = productCodes[j];
            productCodes[j] = temp;
        }

        private void swap(int[] a, int s, int l)
        {
            int temp = a[s];
            a[s] = a[l];
            a[l] = temp;
        }
    }
}
