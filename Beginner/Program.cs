using System;


namespace Beginner
{
    class Program
    {
        static void Main(string[] args)
        {
            //MedianOf2SortedArrays();
            Console.WriteLine("\n\nHello World!");
            //LngstPalinSubStr();
            //ZigZagStr();
            //RevNum();
            //SimpleRegularExp();
            //myAtoI();
            //RevStrOrdr();
            //CharsInWindow();

            //Qsorting();
            ZOTwo();
            Console.ReadKey();

        }

        #region Add 2 Numbers using Linked List
        /// <summary>
        /// Adds two numbers by converting them into linked list adding the list and then converting it back to INt
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void Add2LinkedList2(int a, int b)
        {
            Console.WriteLine(LinkedList.Add2LinkedList.ConvertLinkedList2Int_Recursion(
                LinkedList.Add2LinkedList.AddTwoNumbers(
                    LinkedList.Add2LinkedList.ConvertArray2List(LinkedList.Add2LinkedList.ConvertInt2Array(a)),
                    LinkedList.Add2LinkedList.ConvertArray2List(LinkedList.Add2LinkedList.ConvertInt2Array(b))
                    )
                )
            );
        }

        /// <summary>
        /// Adds two numbers by converting them into linked list adding the list and then converting it back to INt
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void Add2LinkedList(int a, int b)
        {

            Console.WriteLine(LinkedList.Add2LinkedList.ConvertLinkedList2Int(
                LinkedList.Add2LinkedList.AddTwoNumbers(
                    LinkedList.Add2LinkedList.ConvertArray2List(LinkedList.Add2LinkedList.ConvertInt2Array(a)),
                    LinkedList.Add2LinkedList.ConvertArray2List(LinkedList.Add2LinkedList.ConvertInt2Array(b))
                    )
                )
            );
        }

        #endregion

        #region Median of 2 sorted arrays
        private static void MedianOf2SortedArrays()
        {
            int[] a = new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37 };
            int[] b = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 14, 16 };
            int[] c = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            int[] d = new int[] { 1 };
            int[] e = new int[] { 2 };
            int[] f = new int[] { 1, 3 };

            //ShowMedianof2SortedArrays(a, b);
            //ShowMedianof2SortedArrays(a, c);
            //ShowMedianof2SortedArrays(c, b);
            //ShowMedianof2SortedArrays(d, e);
            //ShowMedianof2SortedArrays(f, e);
            //ShowMedianof2SortedArrays(f, c);
            //ShowMedianof2SortedArrays(new int[] { 1,2 }, new int[] { 3, 4 });
            ShowMedianof2SortedArrays(new int[] { 4, 5 }, new int[] { 1, 2, 3, 6, 7 });


        }

        private static void ShowMedianof2SortedArrays(int[] a, int[] b)
        {
            Arrays.MedianOfArrays moa = new Arrays.MedianOfArrays(a, b);
            Console.WriteLine("\n------------------------------------------------------------------\n");
            Console.WriteLine("Array: " + string.Join(", ", a));
            Console.WriteLine("Array: " + string.Join(", ", b));
            Console.WriteLine("Expected Array: ");
            CombineArrays(a, b);
            Console.WriteLine("Reported Median : " + moa.Median.ToString());
        }

        private static void CombineArrays(int[] a, int[] b)
        {
            //throw new NotImplementedException();
            int i = 0, j = 0, med1, med2 = int.MinValue;
            ConsoleColor orginalFGColor = Console.ForegroundColor;
            ConsoleColor medianFGColor = ConsoleColor.Red;
            med1 = (a.Length + b.Length) / 2;
            if ((a.Length + b.Length) % 2 == 0)
                med2 = med1 - 1;
            while (i < a.Length && j < b.Length)
            {
                if ((i + j) == med1 || (i + j) == med2)
                    Console.ForegroundColor = medianFGColor;
                else
                    Console.ForegroundColor = orginalFGColor;
                if (a[i] <= b[j])
                {
                    if ((i + j) == a.Length + b.Length - 1)
                        Console.WriteLine(a[i++]);
                    else
                        Console.Write(a[i++] + ", ");
                }
                else
                {
                    if ((i + j) == a.Length + b.Length - 1)
                        Console.WriteLine(b[j++]);
                    else
                        Console.Write(b[j++] + ", ");
                }


            }
            if (i == a.Length)
            {
                while (j < b.Length)
                {
                    if ((i + j) == med1 || (i + j) == med2)
                        Console.ForegroundColor = medianFGColor;
                    else
                        Console.ForegroundColor = orginalFGColor;

                    if ((i + j) == a.Length + b.Length - 1)
                        Console.WriteLine(b[j++]);
                    else
                        Console.Write(b[j++] + ", ");
                }
            }
            else
            {
                while (i < a.Length)
                {
                    if ((i + j) == med1 || (i + j) == med2)
                        Console.ForegroundColor = medianFGColor;
                    else
                        Console.ForegroundColor = orginalFGColor;

                    if ((i + j) == a.Length + b.Length - 1)
                        Console.WriteLine(a[i++]);
                    else
                        Console.Write(a[i++] + ", ");
                }
            }

            Console.ForegroundColor = orginalFGColor;
        }
        #endregion

        #region Strings

        #region Longest Palindromic Substring
        private static void LngstPalinSubStr()
        {
            Strings.LngstPalinSubString lpss = new Strings.LngstPalinSubString("eabcb");
            Console.WriteLine(lpss.PalinSubString);
        }
        #endregion
        #region ZigZag String
        private static void ZigZagStr()
        {
            Strings.ZigZag zz = new Strings.ZigZag();
            Console.WriteLine(zz.Convert("azmatisbadasscodetypingmaniac", 5));
            Console.WriteLine(zz.Convert("abcd", 3));
        }
        #endregion
        #region Longest Non Repeating Character substring
        private static void LngstNRCSubString(string s)
        {
            Strings.LgstNonRptngSubString l1 = new Strings.LgstNonRptngSubString(s);
            Console.WriteLine(s + ": " + l1.LongestNRCharSubString);
        }

        #endregion
        #region SimpleRegEx
        private static void SimpleRegularExp()
        {
            SRE("aaaa", "a*");
            SRE("ab", ".*c");
            SRE("a", ".*..a*");
        }
        private static void SRE(string s, string p)
        {
            Strings.SimpleRegEx sre = new Strings.SimpleRegEx();
            Console.WriteLine("String: " + s + "\tPattern: " + p + "\tMatch: " + sre.IsMatch(s, p));

        }
        #endregion
        #region MYA2I
        private static void myAtoI()
        {
            Strings.MyA2I myA2I = new Strings.MyA2I();
            Console.WriteLine("Max_Int: " + int.MaxValue + "\tMin_int: " + int.MinValue);
            Console.WriteLine("\n\nInput: 42\nOutput: " + myA2I.MyAtoi("42"));
            Console.WriteLine("\n\nInput: +42\nOutput: " + myA2I.MyAtoi("+42"));
            Console.WriteLine("\n\nInput: -42\nOutput: " + myA2I.MyAtoi("-42"));
            Console.WriteLine("\n\nInput:     42\nOutput: " + myA2I.MyAtoi("    42"));
            Console.WriteLine("\n\nInput: 42 also has words \nOutput: " + myA2I.MyAtoi("42 also has words "));
            Console.WriteLine("\n\nInput: Words come first 42\nOutput: " + myA2I.MyAtoi("Words come first 42"));
            Console.WriteLine("\n\nInput: 4242424242424242\nOutput: " + myA2I.MyAtoi("4242424242424242"));
            Console.WriteLine("\n\nInput: -4242424242424242\nOutput: " + myA2I.MyAtoi("-4242424242424242"));
            Console.WriteLine("\n\nInput: +4242424242424242\nOutput: " + myA2I.MyAtoi("+4242424242424242"));
            Console.WriteLine("\n\nInput: \nOutput: " + myA2I.MyAtoi("+0a32"));
            Console.WriteLine("\n\nInput:     0000000000000   \nOutput: " + myA2I.MyAtoi("    0000000000000   "));
            Console.WriteLine("\n\nInput:   0000000000012345678\nOutput: " + myA2I.MyAtoi("  0000000000012345678"));//
        }
        #endregion
        #region Reverse String Order
        //Eg: I am Ironman ==> Ironman am I
        private static void RevStrOrdr()
        {
            Strings.ReverseOrder rso = new Strings.ReverseOrder();
            Console.Write("Enter a String : ");
            Console.WriteLine("\nReversed String: " + rso.stringReverse(Console.ReadLine()));
        }
        #endregion
        #region Sliding Window Problems
        #region Count of Chars in a String within a window
        private static void CharsInWindow()
        {
            Strings.SumOfCharsInRange abc = new Strings.SumOfCharsInRange();
            abc.slidingWindowForCount("favere favere fakkal dikhana aa gayaa faala", 10);
        }
        #endregion
        #endregion
        #endregion

        #region Numbers

        #region Reverse Number
        private static void RevNum()
        {
            Numbers.ReverseNumber rn = new Numbers.ReverseNumber();
            Console.WriteLine(rn.Reverse(-2147483648));
            Console.WriteLine(rn.Reverse(int.MaxValue));
        }

        #endregion



        #endregion

        #region Sorts
        #region Count Sort
        private static void CSort()
        {
            Sorts.CountSort csrt = new Sorts.CountSort();
            int[] oput = csrt.CntSort(new int[] { 1, 2, 0, 1, 2, 0 });
            csrt.printArray(oput);

        }

        #endregion

        #region Quick Sort
        private static void Qsorting()
        {
            Sorts.QuickSort qs = new Sorts.QuickSort();
            int[] ary = new int[] { 1, 7, 3, 4, 2, 5, 9, 6, 8, 0 };
            qs.Qsort(ary, 0, ary.Length - 1);
        }
        #endregion

        #region Zero One Two Sort
        private static void ZOTwo()
        {
            Sorts.ZeroOneTwo zeroOneTwo = new Sorts.ZeroOneTwo();
            //zeroOneTwo.ZOT(new int[] { 1, 2, 0, 1, 2, 0, 2,1,0,0,1,2 });
            zeroOneTwo.ZOT2(new int[] { 1, 2, 0, 1, 2, 0, 2, 1, 0, 0, 1, 2,2, 1,0,0,1,2, 1, 2, 0, 2, 1, 0, 0, 1, 2, 2 });
        }
        #endregion
        #endregion



    }
}
