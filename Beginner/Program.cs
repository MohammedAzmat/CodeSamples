using System;



namespace Beginner
{
    class Program
    {
        static void Main(string[] args)
        {
            SubstringFunctions();
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


        #region Arrays
        #region Median of 2 sorted arrays
        private static void MedianOf2SortedArrays()
        {
            int[] a = new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37 };
            int[] b = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 14, 16 };
            int[] c = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            int[] d = new int[] { 1 };
            int[] e = new int[] { 2 };
            int[] f = new int[] { 1, 3 };

            ShowMedianof2SortedArrays(a, b);
            //ShowMedianof2SortedArrays(a, c);
            //ShowMedianof2SortedArrays(c, b);
            //ShowMedianof2SortedArrays(d, e);
            //ShowMedianof2SortedArrays(f, e);
            //ShowMedianof2SortedArrays(f, c);
            //ShowMedianof2SortedArrays(new int[] { 1,2 }, new int[] { 3, 4 });
            //ShowMedianof2SortedArrays(new int[] { 4, 5 }, new int[] { 1, 2, 3, 6, 7 });


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

        #region Largest and Second Largest Element in an array
        private static void MIA()
        {
            int[] a = new int[] { 12, 3, 43, 21, 6, 23, 76, 86, 23, 1, 3, 6, 8 };
            Arrays.MaxInArray mia = new Arrays.MaxInArray();
            mia.MaxElem(new int[] { 12, 3, 43, 21, 6,  23, 1, 3, 6, 8 });
            mia.MaxElem(new int[] { 12, 3,  1, 3, 6, 8 });
            mia.MaxElem(new int[] { 12, 3, 43, 21, 6, 23, 76, 86, 23, 1, 3, 6, 8 });
            mia.MaxElem(new int[] { 12, 3,12 });
            mia.MaxElem(new int[] {  });
        }
        #endregion

        #region Stock Matket
        //Get min before max and get max
        private static void SSM()
        {
            Arrays.BuySellStock bss = new Arrays.BuySellStock();
            bss.MaximizeProfit(new int[] { 20, 5, 2, 8, 10, 15, 7, 11, 13, 1, 2 });
            bss.MaximizeProfit(new int[] { 20, 5, 2, 8, 10, 15, 7, 11, 13, 1, 2,18 });
            bss.MaximizeProfit(new int[] { 20, 5, 2, 8, 10, 15, 7, 11, 13, 1, 18 });
            bss.MaximizeProfit(new int[] { 1,0,0,0,0,0,0,0,0,0,0,0,0 });
        }
        #endregion

        #region Sequences in Arrays
        private static void Seq()
        {
            Arrays.Sequences seq = new Arrays.Sequences();
            Console.WriteLine("\n\n\t\tLongestIncreasingSequence\n");
            //seq.LongestIncreasingSequence1(new int[] { 1, 2, 3, 5, 4, 6, 7, 8, 9, 10 });
            //seq.LongestIncreasingSequence1(new int[] { 1, 2, 3, 5, 6, 7, 8, 9, 10 });
            //seq.LongestIncreasingSequence1(new int[] { 7, 8, 9, 10,3, 2, 1, 6, 8,9,9});
            seq.LongestIncreasingSequence1(new int[] { -7, 1, -3, 4, 2, -1 });
            seq.LongestIncreasingSequence1(new int[] { 7, 8, 9, 4, 2, 1,2,3,4 });

            Console.WriteLine("\n\n\t\tLargestContigSumSimple\n");
            seq.LargestContigSumSimple(new int[] { -7, 1,-3,4,2,-1 });
            seq.LargestContigSumSimple(new int[] { -7, 4, -3, 4, 2, -1 });

            Console.WriteLine("\n\n\t\tLargestContigSumWithIndex\n");
            seq.LargestContigSumWithIndex(new int[] { -7, 1, -3, 4, 2, -1 });
            seq.LargestContigSumWithIndex(new int[] { -7, 4, -3, 4, 2, -1 });
        }
        #endregion

        #region Hanoi
        private static void TowerOfHanoi()
        {
            Arrays.Hanoi hanoi = new Arrays.Hanoi(4);
        }
        #endregion

        #region Robot to Remove obstacle from 2d array
        private static void RobotMoves()
        {
            Arrays.RobotTrenchObst rto = new Arrays.RobotTrenchObst();
            int row = 3;
            int col = 3;
            int[,] matrix = new int[3,3] { { 1,1,0},{ 1,0,0},{ 1,9,0} };
            Console.WriteLine("Obstacle Path Length: "+rto.removeObs(row, col, matrix));

        }
        #endregion

        #region Get Nearest Points
        private static void KNearestPoints()
        {
            Arrays.ShortestFirst KNP = new Arrays.ShortestFirst();
            int[,] matrix = new int[,] { { 6, 7 }, { 4, 3 }, { 3, 4 }, { -1, -1 }, { 1, 7 }, { 2, 0 }, { 1, -1 } };
            KNP.GetDeliveryPoints(matrix.GetLength(0), matrix, 4);
        }
        #endregion

        #region SubString within String
        private static void SubstringInString()
        {
            Arrays.LongestSubstring Lsub = new Arrays.LongestSubstring();
            Console.WriteLine(Lsub.GetSubstring("banana"));
        }
        #endregion
        #region Difference in Indexes
        private static void GetMaxDiffInIndexes()
        {
            Arrays.MaxDiffInIndex Lsub = new Arrays.MaxDiffInIndex();
            Lsub.PrintMaxDiffInIndexes(new int[] { 34,8,10,3,2,80,30,33,1 });
            Lsub.PrintMaxDiffInIndexes(new int[] { 35, 5, 3, 2, 20, 10, 24, 32, 34, 1 });
            Lsub.PrintMaxDiffInIndexes(new int[] { 1,2,6,4 });
            Lsub.PrintMaxDiffInIndexes(new int[] { 10, 8, 6, 4,3 });
        }
        #endregion


        #region OptimizeCost
        public static void CostOptimization()
        {
            Arrays.OptimizeCost optcost = new Arrays.OptimizeCost();
            Console.WriteLine(optcost.OptimizeMyCost());
        }
        #endregion

        #region Find Shortest path in Graph from 1 to n
        private static void ShortestPathOfGraph()
        {
            Arrays.WightedPath swp = new Arrays.WightedPath();
            Console.WriteLine(swp.GetPath(5, new int[] { 1, 1, 1, 1, 2, 3 }, new int[] { 2, 3, 4, 5, 5, 5 }, new int[] { 1, 2, 3, 4, 5, 3 }));

            Console.WriteLine(swp.GetPath(5, new int[] {1 }, new int[] { 5}, new int[] { 5}));
        }
        #endregion

        #region Find Shortest path in Graph from 1 to n
        private static void TriangleProblems()
        {
            Arrays.Triangle tri = new Arrays.Triangle();
            Console.WriteLine(tri.largestPerimeterOpt(new int[] { 10,2,5,1,8,20}));
        }
        #endregion

        #region Rotate 2D Matrix in Place

        private static void MatrixRotation()
        {
            Arrays.Rotate2DArrInplace rotate2DArrInplace = new Arrays.Rotate2DArrInplace();
            rotate2DArrInplace.LetsMakeNRotate(8);
        }

        #endregion

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
        private static void LngstNRCSubString()
        {
            string s = "abcdbefg";
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

        #region Number of K size Substrings with k-1 unique elements
        private static void KSizeSubStringWithK_1Uniq()
        {
            Strings.KSubstringWithK_1Unique k_k_1 = new Strings.KSubstringWithK_1Unique();
            k_k_1.Printlist("azmat", 4);
            k_k_1.Printlist("azmat", 3);
            k_k_1.Printlist("malayalam", 4);

        }
        #endregion
        #endregion
        #region SubScenes
        private static void SubScenes()
        {
            Strings.PartitionSubScene subScenes = new Strings.PartitionSubScene();
            subScenes.PrintSubScenes(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g'});
            subScenes.PrintSubScenes(new char[] { 'a', 'b', 'a', 'c', 'd', 'a', 'e', 'f', 'g','e','f' });
            subScenes.PrintSubScenes(new char[] { 'a', 'b', 'c', 'd','a','d', 'e', 'f', 'g', 'e','a' });
            subScenes.PrintSubScenes(new char[] { 'a', 'b', 'c', 'd', 'a', 'b', 'a', 'c', 'e', 'f', 'g', 'e', 'f', 'g', 'e', 'f' });
            subScenes.PrintSubScenes(new char[] { 'a', 'b', 'c', 'd', 'a','e', 'f', 'g', 'e', 'f', 'e', 'f', 'e', 'f' });

        }
        #endregion
        #region Stacks via Brackets
        private static void BracketBalance()
        {
            Strings.Brackets brackets = new Strings.Brackets();
            string str;
            if (1 == 0)
            {
                str = "{}{}{}{}()()[][]<><>";
                Console.WriteLine("Output for string: " + str + "\t:: " + brackets.Order(str));
                str = "}{}{}{}()()[][]<><>";
                Console.WriteLine("Output for string: " + str + "\t:: " + brackets.Order(str));
                str = "{{{{{{{{}}}}}}}}";
                Console.WriteLine("Output for string: " + str + "\t:: " + brackets.Order(str));
                str = "{{{{{{{{}}}}}}}";
                Console.WriteLine("Output for string: " + str + "\t:: " + brackets.Order(str));
                str = "{[<()>]}[{(<>)}][][][][]";
                Console.WriteLine("Output for string: " + str + "\t:: " + brackets.Order(str));
            }
            #region LogestValid
            str = "))((()(())(())()())())((";
            brackets.GetLongestValidBracketLength(str);
            str = "))())((()))))(())(()())";
            brackets.GetLongestValidBracketLength(str);
            #endregion

        }

        private static void BracketCombos()
        {
            Strings.Brackets brackets = new Strings.Brackets();
            brackets.PrintBracketString(1);
            Console.WriteLine();
            brackets.PrintBracketString(2);
            Console.WriteLine();
            brackets.PrintBracketString(3);
            Console.WriteLine();
            brackets.PrintBracketString(4);
        }
        #endregion
        #region Permutations of a given string
        private static void StringPermutations()
        {
            Strings.Permutations perm = new Strings.Permutations();
            perm.PrintPerms("abc");
            perm.PrintPerms("abcd");
            perm.PrintPerms("abcde");
            perm.PrintPerms("xy");
            Console.WriteLine("\n------------------------------------------------------\n");
            perm.PrintPerms("aa");
            perm.PrintPerms("aba");
            perm.PrintPerms("abca");

        }
        #endregion

        #region Substrings
        private static void SubstringFunctions()
        {
            Strings.SubStrings subStrings = new Strings.SubStrings();
            //subStrings.Execute("abc");
            subStrings.Execute("abc",new char[] { 'a','b'});
            subStrings.Execute("abc", new char[] { 'a', 'x' });
        }
        #endregion
        #region Reverse Strings
        private static void StringReverse()
        {
            Strings.ReverseString reverseString = new Strings.ReverseString();
            Console.WriteLine(reverseString.ReverseStringWords("perfect makes practice"));
            char[] c = new char[] { 'p','e','r','f','e','c','t',' ','m','a','k','e','s',' ','p','r','a','c','t','i','c','e' };
            reverseString.ReverseCharArrayWords(c);
        }
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

        #region GCD
        private static void GCD()
        {
            int[] arr = { 2, 4, 6, 8, 16 };
            int n = arr.Length;
            Numbers.GCD gcd = new Numbers.GCD();
            Console.Write(gcd.findGCD(arr, n));
        }
        #endregion

        #region Active InActive HOuses
        private static void ActInActHouse()
        {
            Numbers.HouseActiveInActive houses = new Numbers.HouseActiveInActive();
            houses.Initiate(new int[] { 0, 1, 0 }, 1);
            houses.Initiate(new int[] { 0, 1, 0 }, 2);
            houses.Initiate(new int[] { 0, 1, 0 }, 3);

        }

        private static void NumbersCoins()
        {
            Numbers.Coins coins = new Numbers.Coins();
            //coins.PrintCoins(-5);
            //coins.PrintCoins(0);
            //coins.PrintCoins(25);
            //coins.PrintCoins(30);
            coins.PrintCoins(10);
        }
        #endregion

        #region Lonely Int
        private static void LonelyInt()
        {
            Numbers.LonelyInt lint = new Numbers.LonelyInt();
            Console.WriteLine(lint.GetOutLonelyInt(new int[] { 0, 1, 2, 1, 0 }));
            Console.WriteLine(lint.GetOutLonelyInt(new int[] { 0, 1, 2, 1, 0,2,4,4,7 }));
        }
        #endregion

        #region PairedSocks
        private static void getPairedSocks()
        {
            Numbers.PairedSocks ps = new Numbers.PairedSocks();
            Console.WriteLine(ps.GetPairedSocks(10, new int[] { 1, 1, 3, 1, 2, 1, 3, 3, 3, 3 }));
        }
        #endregion

        #region Sequential Numbers  :: 1234, 2345 .....
        private static void SeqNum()
        {
            Numbers.SequentialNumbers seqnum = new Numbers.SequentialNumbers();
            seqnum.PrintSeqNum(1000, 13000);
            seqnum.PrintSeqNum(9, 100);
            seqnum.PrintSeqNum(300, 100);
            seqnum.PrintSeqNum(100, 300);
        }
        #endregion

        #region Bribes
        private static void bribes()
        {
            Numbers.Bribes bribe = new Numbers.Bribes();
            bribe.minimumBribes(new int[] { 2, 1, 5, 3, 4 });
        }
        #endregion

        #region  MinSwaps
        private static void MinSwap()
        {
            Numbers.MinSwaps minswp = new Numbers.MinSwaps();
            //Console.WriteLine(minswp.MinSwap(new int[] { 7, 1, 3, 2, 4, 5, 6 }));
            Console.WriteLine(minswp.MinSwap(new int[] { 2, 3, 4, 1, 5 }));

        }
        #endregion


        #region  KSmallest / KLargest
        private static void KSmallest()
        {
            Numbers.KthSmallestNumber ksml = new Numbers.KthSmallestNumber();
            //Console.WriteLine(minswp.MinSwap(new int[] { 7, 1, 3, 2, 4, 5, 6 }));
            Console.WriteLine(ksml.Ksmall(new int[] {0,3,8,2,5,3,1,8,4,7 },4));

        }
        private static void KLargest()
        {
            Numbers.KLargestNumber ksml = new Numbers.KLargestNumber();
            //Console.WriteLine(minswp.MinSwap(new int[] { 7, 1, 3, 2, 4, 5, 6 }));
            Console.WriteLine(ksml.KLarge(new int[] { 0, 3, 8, 2, 5, 3, 1, 8, 4, 7 }, 4));

        }
        #endregion

        #region Jump Numbers 121,123,210,212...
        private static void JumpNum()
        {
            Numbers.JumpingNumbers ksml = new Numbers.JumpingNumbers();
            ksml.PrintJumpingNumbers(7);
            ksml.PrintJumpingNumbers(15);
            ksml.PrintJumpingNumbers(150);
            ksml.PrintJumpingNumbers(1500);


        }
        #endregion


        #region  Cordinate geometry
        private static void LineSegments()
        {
            Numbers.CordinateGeometry lineSeg = new Numbers.CordinateGeometry();
            lineSeg.Intersect(0,0,1,1,2,2,3,3);
            lineSeg.Intersect(0, 0, 1, 1, -1, 0, 0, 1);
            lineSeg.Intersect(0, 0, 1, 1, 1, 0, 0, 1);

        }
        #endregion

        #region  Cordinate geometry
        private static void SmlDiff()
        {
            Numbers.SmallestDifference.In2ElementsOf2Arrays(new int[] { 1, 3, 11, 17, 2, 234 }, new int[] { 23, 127, 235, 19, 8 });
            Numbers.SmallestDifference.In2ElementsOf2Arrays(new int[] { 135, 11, 17, 234 }, new int[] { 23, 127, 235, 19, 8 });
            Numbers.SmallestDifference.In2ElementsOf2Arrays(new int[] { 15,175 }, new int[] { 23, 127, 235, 19, 8 });

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
            int[] ary = new int[] { 7, 1, 3, 2, 4, 5, 6 };
            Console.WriteLine("\nTotal Swaps: "+qs.Qsort(ary, 0, ary.Length - 1,0));
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

        #region Topological Sort
        private static void TopoSort()
        {
            Sorts.TopologicalSort ts = new Sorts.TopologicalSort(6);
            Console.WriteLine();
            Sorts.TopologicalSort ts1 = new Sorts.TopologicalSort(new string[] { "baa", "abcd", "abca", "cab", "cad" }, 4);

        }
        #endregion

        #endregion

        #region Trees
        private static void Plant()
        {
            Trees.EarliestCommonAncestor test = new Trees.EarliestCommonAncestor();
            test.Test();
        }

        private static void PathInTree()
        {
            Trees.PathBetween2Nodes pb2n = new Trees.PathBetween2Nodes();
            Trees.Node root = pb2n.MakeBSTFromArray(new int[] {5,6,3,1,2,4 });
            pb2n.InOrderTraversal(root);
            pb2n.TestPathDistanceBetweenNodesBST(root, 2, 4);
            pb2n.TestPathDistanceBetweenNodesBST(root, 1, 4);
            pb2n.TestPathDistanceBetweenNodesBST(root, 2, 5);
            pb2n.TestPathDistanceBetweenNodesBST(root, 2, 7);
        }

        private static void BinaryTree2BinarySearchTree()
        {
            Trees.BTtoBST btToBST = new Trees.BTtoBST();
        }
        

        #region Duplicate Sub trees
        private static void DupSubTrees()
        {
            Trees.Node root = null;
            root = new Trees.Node(1);
            root.left = new Trees.Node(2);
            root.right = new Trees.Node(3);
            root.left.left = new Trees.Node(4);
            root.right.left = new Trees.Node(2);
            root.right.left.left = new Trees.Node(4);
            root.right.right = new Trees.Node(4);
            Trees.DupSubArr dupSubArr = new Trees.DupSubArr();
            dupSubArr.DupSubTree(root);
        }
        #endregion

        #region Duplicate Sub trees
        private static void CommonParent()
        {
            Trees.Node root = null;
            root = new Trees.Node(50);
            root.left = new Trees.Node(30);
            root.right = new Trees.Node(37);
            root.left.left = new Trees.Node(10);
            root.left.right = new Trees.Node(35);
            root.right.left = new Trees.Node(60);
            root.left.left.right = new Trees.Node(15);
            root.left.right.left = new Trees.Node(32);
            root.left.right.right = new Trees.Node(45);
            
            Trees.PathBetween2Nodes pb2n = new Trees.PathBetween2Nodes();
            pb2n.GetCommonParent(root, 15, 45);
        }
        #endregion

        #region Second Largest Element of BST 
        private static void SecondLargestInBST()
        {
            Trees.PathBetween2Nodes pb2n = new Trees.PathBetween2Nodes();
            pb2n.GetSecondLargestElemOfBST(new int[] { });
            pb2n.GetSecondLargestElemOfBST(new int[] {5 });
            pb2n.GetSecondLargestElemOfBST(new int[] { 5,6});
            pb2n.GetSecondLargestElemOfBST(new int[] { 5,3});
            pb2n.GetSecondLargestElemOfBST(new int[] { 5,3,1});
            pb2n.GetSecondLargestElemOfBST(new int[] { 9,3,1,4,5,6,7,8});
            pb2n.GetSecondLargestElemOfBST(new int[] { 5,3,1,4,6,7,8,9,0});
        }
        #endregion
        #endregion

        #region LinkedList
        private static void LRUCache()
        {
            LinkedLists.LRUCache lRUCache = new LinkedLists.LRUCache(3);
            lRUCache.Process(new int[] { 1, 2, 3, 4, 5, 1, 2, 1, 5, 2, 3, 4, 2, 1, 4 });
           
        }
        #endregion
    }
}
