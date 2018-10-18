using System;
using System.Collections.Generic;
using System.Text;

namespace Beginner.Arrays
{
    public class MaxInArray
    {
        /*
         *  Array: 12 3 43 21 6 23 1 3 6 8
            HIGHEST ELEMENT MaxIndex: 2 IIMaxElem: 43
            SECOND HIGHEST ELEMENT IIMaxIndex: 5 IIMaxElem: 23



            Array: 12 3 1 3 6 8
            HIGHEST ELEMENT MaxIndex: 0 IIMaxElem: 12
            SECOND HIGHEST ELEMENT IIMaxIndex: 5 IIMaxElem: 8



            Array: 12 3 43 21 6 23 76 86 23 1 3 6 8
            HIGHEST ELEMENT MaxIndex: 7 IIMaxElem: 86
            SECOND HIGHEST ELEMENT IIMaxIndex: 6 IIMaxElem: 76



            Array: 12 3 12
            HIGHEST ELEMENT MaxIndex: 2 IIMaxElem: 12
            SECOND HIGHEST ELEMENT IIMaxIndex: 0 IIMaxElem: 12



            Array: 12 12
            HIGHEST ELEMENT MaxIndex: 1 IIMaxElem: 12
            SECOND HIGHEST ELEMENT IIMaxIndex: 0 IIMaxElem: 12
            


            Array:
            Empty Array
         */
        private int[] GetMax(int[] a)
        {
            int n = a.Length;
            if (n == 1 || n==0)
                return a;
            else
            {
                int[] b = (n % 2 == 0) ? new int[n / 2] : new int[n / 2 + 1];
                for (int i = 0, j = 0; i < n; i += 2, j++)
                {
                    if (i == n - 1)
                        b[j] = a[i];
                    else
                    {
                        if (a[i] > a[i + 1])
                            b[j] = a[i];
                        else
                            b[j] = a[i + 1];
                    }
                }
                return GetMax(b);

            }
        }

        private int[] GetMaxIndex(int[] a, int[] b)
        {
            int n = b.Length;
            if (n == 1 || n == 0)
                return b;
            else
            {
                int[] c = (n % 2 == 0) ? new int[n / 2] : new int[n / 2 + 1];
                for (int i = 0, j = 0; i < n; i += 2, j++)
                {
                    if (i == n - 1)
                        c[j] = b[i];
                    else
                    {
                        if (a[b[i]] > a[b[i + 1]])
                            c[j] = b[i];
                        else
                            c[j] = b[i+1];
                    }
                }
                return GetMaxIndex(a,c);
            }
        }

        private int[] GetMax2Index(int[] a, int[] b)
        {
            int n = b.Length;
            if (n == 1 || n == 0)
                return b;
            else
            {
                int[] c = (n % 2 == 0) ? new int[n / 2] : new int[n / 2 + 1];
                for (int i = 0, j = 0; i < n; i += 2, j++)
                {
                    if (i == n - 1)
                        c[j] = b[i];
                    else
                    {
                        if (a[b[i]] > a[b[i + 1]])
                            c[j] = b[i];
                        else
                            c[j] = b[i + 1];
                    }
                }
                int[] d =  GetMax2Index(a, c);
                if (d.Length == 1)
                {
                    if(d[0] == b[0])
                        return new int[] { 2*0, b[1], d[0] };
                    else
                        return new int[] { 2*1, b[0], d[0] };

                }
                else
                {
                    //We get 3 Values 0:Possible Index of Max ; 1: Max2Index; 2: MaxIndex
                    //check for ith as max
                    if (d[2] == b[d[0]])
                    {
                        if (b.Length - 1 == d[0])
                        {
                            d[0] = 2 * d[0];
                            return d;
                        }
                        else
                        {
                            if (a[d[1]] < a[b[d[0] + 1]])  //d(1) is the current max2 index
                            {
                                d[1] = b[d[0] + 1];
                            }
                            d[0] = 2 * d[0];
                            return d;
                        }
                    }
                    else
                    {
                        //if ith element is not max
                        if (a[d[1]] < a[b[d[0]]])  //Then Ith element can be max2
                        {
                            d[1] = b[d[0]];
                        }
                        d[0] = 2 * (d[0]+1);
                        return d;
                    }
                }

            }
        }

        public void MaxElem(int[] a)
        {
            if (a.Length > 0)
            {
                int[] b = new int[a.Length];
                Console.Write("\n\n\nArray: ");
                for (int i = 0; i < a.Length; i++)
                {
                    Console.Write(a[i] + " ");
                    b[i] = i;
                }
                int[] c = GetMax2Index(a, b);
                Console.Write("\nHIGHEST ELEMENT MaxIndex: " + c[2] + " IIMaxElem: " + a[c[2]] + "\n");
                Console.Write("SECOND HIGHEST ELEMENT IIMaxIndex: " + c[1] + " IIMaxElem: " + a[c[1]] + "\n");
            }
            else
            {
                Console.Write("\n\n\nArray: ");
                Console.Write("\nEmpty Array");
            }
        }
    }
}
