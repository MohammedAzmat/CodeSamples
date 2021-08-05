using System;
using System.Collections.Generic;
using System.Text;

namespace Sorts
{
    public class QuickSort
    {
        public void Qsort(int[] ary,int l, int h)
        {
            if (l < h)
            {
                print(ary,l, h);
                int p = getPivot(ary, l, h);
                Console.WriteLine("Low: " + l + " Partition: " + p + " High: " + h);
                Qsort(ary, l, p - 1);
                Qsort(ary, p + 1, h);
                if ((h == ary.Length - 1) && l==0)
                    print(ary, l, h);
            }
        }

        private void print(int[] ary, int l, int h)
        {
            Console.Write("\nArray: ");
            for(int i=l;i<=h;i++)
                Console.Write(ary[i] + " ");
        }

        

        private int getPivot(int[] ary, int l, int h)
        {
            int p = ary[h],temp_lo = l,temp;

            for (int i = l; i < h; i++)
            {
                if (ary[i] < p)
                {
                    temp = ary[temp_lo];
                    ary[temp_lo] = ary[i];
                    ary[i] = temp;
                    temp_lo += 1;
                }
            }
            temp = ary[temp_lo];
            ary[temp_lo] = ary[h];
            ary[h] = temp;
            return temp_lo;
        }

        public int Qsort(int[] ary, int l, int h, int c)
        {
            if (l < h)
            {
                print(ary, l, h);
                int[] p = getPivot(ary, l, h,c);
                Console.WriteLine("Low: " + l + " Partition: " + p + " High: " + h + " Swaps: " + c);
                p[1] = Qsort(ary, l, p[0] - 1,p[1]);
                p[1] = Qsort(ary, p[0] + 1, h,p[1]);
                if ((h == ary.Length - 1) && l == 0)
                    print(ary, l, h);
                return p[1];
            }
            return c;
        }

        private int[] getPivot(int[] ary, int l, int h, int c)
        {
            int p = ary[h], temp_lo = l, temp;

            for (int i = l; i < h; i++)
            {
                if (ary[i] < p)
                {
                    temp = ary[temp_lo];
                    ary[temp_lo] = ary[i];
                    ary[i] = temp;
                    temp_lo += 1;
                    c++;
                }
            }
            temp = ary[temp_lo];
            ary[temp_lo] = ary[h];
            ary[h] = temp;
            c++;
            return new int[] { temp_lo, c };
        }


    }
}
