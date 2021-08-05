using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    /// <summary>
    /// Assuming arrays are sorted. Find the median, keep time complixity nore more than Olog(m+n)
    /// </summary>
    public class MedianOfArrays
    {
        public double Median { get; set; }
        private bool debug;// = { -1, -1 };
        public MedianOfArrays(int[] nums1, int[] nums2)
        {
            //int l1 = nums1.Length;
            //int l2 = nums2.Length;
            //int mid1 = (int)Math.Ceiling((double)l1 / 2);
            //int mid2 = (int)Math.Ceiling((double)l2 / 2);
            //int mid1 = GetMid(l1);
            //int mid2 = GetMid(l2);

            this.debug = false;


            //this.Median = RecFuncMedianOfAry(nums1, nums2, GetMid(nums1.Length), GetMid(nums2.Length), 0, nums1.Length - 1, 0, nums2.Length - 1);
            //this.Median = GetMedianValue(nums1, nums2, GetMid(nums1.Length), GetMid(nums2.Length), 0, nums1.Length - 1, 0, nums2.Length - 1);
            if(nums1.Length != 0 && nums2.Length != 0)
                this.Median = MedianOf2SortedAry(nums1, nums2, GetMid(nums1.Length), 0, nums1.Length - 1, GetMid(nums2.Length), 0, nums2.Length - 1);
            else
                if (nums1.Length == 0)
                    this.Median =  NonEmptyAry(nums2);
                else
                    this.Median =  NonEmptyAry(nums1);
        }

        private double NonEmptyAry(int[] nums)
        {
            return (nums.Length % 2 == 0) ? (double)(nums[(nums.Length) / 2] + nums[nums.Length / 2 - 1]) / 2 : nums[(nums.Length) / 2];
        }

        private string PrintArrayAsString(int[] a, int s, int e)
        {
            string result = "";
            for(int i = s; i<=e;i++)
                result += a[i].ToString() + ", ";
            return result.Substring(0, result.Length - 2);
        }

        private void PrintArrayAsString(int[] a, int s, int e, int mid)
        {
            ConsoleColor orginalFGColor = Console.ForegroundColor;
            ConsoleColor sectionFGColor = ConsoleColor.Green;
            ConsoleColor medianFGColor = ConsoleColor.Red;
            for (int i = 0; i < a.Length; i++)
            {
                if (i >= s && i <= e)
                {
                    Console.ForegroundColor = sectionFGColor;
                    if (i == mid)
                        Console.ForegroundColor = medianFGColor;

                }
                else
                    Console.ForegroundColor = orginalFGColor;
                if (i != (a.Length - 1))
                    Console.Write(a[i].ToString() + ", ");
                else
                    Console.WriteLine(a[i].ToString());
            }
            Console.ForegroundColor = orginalFGColor;
            //return result.Substring(0, result.Length - 2);
        }

        private double MedianOf2SortedAry(int[] a, int[] b, int mid_a, int sa, int ea, int mid_b, int sb, int eb)
        {
            if (this.debug)
            {
                Console.WriteLine("\n\nArrays and Info");
                Console.WriteLine("ArraySize : " + (ea - sa + 1) + "\nArray : " + PrintArrayAsString(a,sa,ea) + "\nCurrent Median Index: " + mid_a + "\tCurrent Median Value: " + a[mid_a]);
                PrintArrayAsString(a, sa, ea, mid_a);
                Console.WriteLine("ArraySize : " + (eb - sb + 1) + "\nArray : " + PrintArrayAsString(b, sb, eb) + "\nCurrent Median Index: " + mid_b + "\tCurrent Median Value: " + b[mid_b]);
                PrintArrayAsString(b, sb, eb, mid_b);
                Console.WriteLine("------------------------------------------------------------------------------------");
            }
            //Exit Condition...
            if (sa == ea || sb == eb)
            {
                if ((a.Length + b.Length) % 2 != 0)
                {
                    return (a[mid_a] >= b[mid_b]) ? a[mid_a] : b[mid_b];
                }
                else
                {
                    if (a[mid_a] >= b[mid_b])
                    {
                        return (double)(a[mid_a] + GetOtherMedian(a, b, mid_a, mid_b))/2;
                    }
                    else
                    {
                        return (double)(b[mid_b] + GetOtherMedian(b, a, mid_b, mid_a))/2;
                    }
                }
            }
            else
            {
                if (a[mid_a] >= b[mid_b])
                {
                    //B is smaller and all elements till b[mid_b] will precede a[mid_a]
                    ea -= mid_b; // Discard big elements on the right
                    mid_a = GetBigMid(sa, ea);

                    sb = mid_b + 1;
                    mid_b = GetBigMid(sb, eb);

                }
                else
                {
                    eb -= mid_a;
                    mid_b = GetBigMid(sb, eb);

                    sa = mid_a + 1;
                    mid_a = GetBigMid(sa, ea);
                }
                return MedianOf2SortedAry(a, b, mid_a, sa, ea, mid_b, sb, eb);
            }
        }

        private int GetOtherMedian(int[] FirstMedianAry, int[] OtherArray, int medianIndex, int otherIndex)
        {
            if (medianIndex < otherIndex)
                return OtherArray[otherIndex];
            else
                if ((FirstMedianAry.Length) > (medianIndex + 1))
                    return (FirstMedianAry[medianIndex + 1] >= OtherArray[otherIndex]) ? FirstMedianAry[medianIndex + 1] : OtherArray[otherIndex];
                else
                    return OtherArray[otherIndex];
        }

        private int GetBigMid(int start, int end)
        {
            return (end - start) / 2 + start;
        }


        #region OLD Private Methods
        private double GetMedianValue(int[] nums1, int[] nums2, int mid1, int mid2, int s1, int e1, int s2, int e2)
        {
            int l1 = e1 - s1 + 1;
            int l2 = e2 - s2 + 1;
            double med = int.MinValue, med2 = int.MinValue, minusInfinity = int.MinValue;

            if (l1 == 1 || l2 == 1)
            {
                //Exit condition
                //Return Median
                med = ((nums1[mid1] > nums2[mid2]) ? nums1[mid1] : nums2[mid2]);
                //TODO: Check for even odd


                return med;
            }
            else
            {
                //DO recursion
                if (nums1[mid1] > nums2[mid2])
                {
                    //Mid Value of A1 is bigger than Mid Value of A2
                    //This means that all elements in A2 upto mid are smaller than A1
                    s2 = GetNewStartPos(mid2, nums2.Length - 1);
                    e2 = nums2.Length - 1;
                    int new_mid = GetNewMidIndex(s2, e2);
                    mid1 = mid1 - new_mid + mid2;
                    mid2 = new_mid;
                    s1 = mid1 / 2;
                    e1 = mid1 * 2;

                }
                else if (nums1[mid1] < nums2[mid2])
                {
                    //Mid value of A1 is smaller that Mid of A2
                    s1 = GetNewStartPos(mid1, nums1.Length - 1);
                    e1 = nums1.Length - 1;
                    int new_mid = GetNewMidIndex(s1, e1);
                    mid2 = mid2 - new_mid + mid1; 
                    mid1 = new_mid;
                    s2 = mid2 / 2;
                    e2 = mid2 * 2;

                }
                else
                {
                    //Both Values are equal
                }
                return GetMedianValue(nums1, nums2, mid1, mid2, s1, e1, s2, e2);
            }
        }

        private int GetNewStartPos(int prev_mid, int last_index)
        {
            return (last_index == prev_mid) ? prev_mid : prev_mid + 1;
        }

        private int GetNewMidIndex(int s, int e)
        {
            return (e - s) / 2 + s;
            //throw new NotImplementedException();
        }

        private double RecFuncMedianOfAry(int[] nums1, int[] nums2, int mid1, int mid2, int s1, int e1, int s2, int e2)
        { 
            int l1 = e1-s1+1;
            int l2 = e2-s2+1;
            double med = int.MinValue, med2 = int.MinValue, minusInfinity = int.MinValue;

            if (l1 == 1 || l2 == 1)
            {
                //Return Median
                med = ((nums1[mid1] > nums2[mid2]) ? nums1[mid1] : nums2[mid2]);
                //Find 2nd median if avalable, when sum of lengths of arrays is even
                if ((nums1.Length + nums2.Length) % 2 == 0)
                {
                    //Odd Index of Median 1
                    if ((mid1 + mid2) > (nums1.Length + nums2.Length -2) / 2)
                    {
                        if (med == nums1[mid1])
                            med2 = (mid1 - 1 >= 0) ? (nums1[mid1 - 1] > nums2[mid2]) ? nums1[mid1 - 1] : nums2[mid2] : nums2[mid2];
                        else
                            med2 = (mid2 - 1 >= 0) ? (nums1[mid1] > nums2[mid2 - 1]) ? nums1[mid1] : nums2[mid2 - 1] : nums1[mid1];
                    }
                    //Even Index of Median 1
                    else
                    {
                        if (med == nums1[mid1])
                            med2 = (mid1 + 1 < l1) ? (nums1[mid1 + 1] > nums2[mid2]) ? nums1[mid1 + 1] : nums2[mid2] : nums2[mid2];
                        else
                            med2 = (mid2 + 1 < l2) ? (nums1[mid1] > nums2[mid2 + 1]) ? nums1[mid1] : nums2[mid2 + 1] : nums1[mid1];
                    }



                }

                if (med2 != minusInfinity)
                    return (med + med2) / 2;
                else
                    return med;
            }
            else
            {
                if ((nums1[mid1] > nums2[mid2]))
                {
                    //Find New median of the remaing nums2
                    s2 = mid2 + 1;
                    l2 = e2 - s2 + 1;
                    
                    mid2 = GetMid(l2,s2);
                    mid1 = AdjustMid(mid1, mid2, s2);
                    
                }
                else
                {
                    s1 = mid1 + 1;
                    l1 = e1 - s1 + 1;
                    mid1 = GetMid(l1,s1);
                    mid2 = AdjustMid(mid2, mid2, s1);
                }
                return RecFuncMedianOfAry(nums1, nums2, mid1, mid2, s1,e1,s2, e2);
                
            }

        }

        private int GetMid(int end, int start = 0)
        {
            return ((end / 2 > 0) ? (end % 2 == 0) ? end / 2 - 1 : end / 2 : 0) + start;
        }

       
        private int AdjustMid(int midToAdjust, int midToAdjustwith, int start)
        {
            return ((midToAdjust - (midToAdjustwith - start + 1)) < 0 ? 0 : (midToAdjust - (midToAdjustwith - start + 1)));
        }

        private double RecFuncMedianOfAry(int[] nums1, int[] nums2, int mid1, int mid2, int s1, int s2)
        {
            int l1 = nums1.Length - s1;
            int l2 = nums2.Length - s2;
            double med = int.MinValue, med2 = int.MinValue, minusInfinity = int.MinValue;


            if (l1 == 1 || l2 == 1)
            {
                //Return Median
                med = ((nums1[mid1] > nums2[mid2]) ? nums1[mid1] : nums2[mid2]);
                //Find 2nd median if avalable, when sum of lengths of arrays is even
                if ((nums1.Length + nums2.Length) % 2 == 0)
                {
                    //Odd Index of Median 1
                    if ((mid1 + mid2) > (nums1.Length + nums2.Length - 2) / 2)
                    {
                        if (med == nums1[mid1])
                            med2 = (mid1 - 1 >= 0) ? (nums1[mid1 - 1] > nums2[mid2]) ? nums1[mid1 - 1] : nums2[mid2] : nums2[mid2];
                        else
                            med2 = (mid2 - 1 >= 0) ? (nums1[mid1] > nums2[mid2 - 1]) ? nums1[mid1] : nums2[mid2 - 1] : nums1[mid1];
                    }
                    //Even Index of Median 1
                    else
                    {
                        if (med == nums1[mid1])
                            med2 = (mid1 + 1 < l1) ? (nums1[mid1 + 1] > nums2[mid2]) ? nums1[mid1 + 1] : nums2[mid2] : nums2[mid2];
                        else
                            med2 = (mid2 + 1 < l2) ? (nums1[mid1] > nums2[mid2 + 1]) ? nums1[mid1] : nums2[mid2 + 1] : nums1[mid1];
                    }



                }

                if (med2 != minusInfinity)
                    return (med + med2) / 2;
                else
                    return med;
            }
            else
            {
                if ((nums1[mid1] > nums2[mid2]))
                {
                    //Find New median of the remaing nums2
                    s2 = mid2 + 1;
                    l2 = nums2.Length - s2;
                    mid2 = GetMid(l2, s2);
                    mid1 = AdjustMid(mid1, mid2, s2);

                }
                else
                {
                    s1 = mid1 + 1;
                    l1 = nums1.Length - s2;
                    mid1 = GetMid(l1, s1);
                    mid2 = AdjustMid(mid2, mid2, s1);
                }
                return RecFuncMedianOfAry(nums1, nums2, mid1, mid2, s1, s2);

            }

        }

        #endregion

    }
}
