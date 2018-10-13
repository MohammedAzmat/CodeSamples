using System;
using System.Collections.Generic;
using System.Text;

namespace Beginner.Strings
{
    class LngstPalinSubString
    {
        /*
            Given a string s, find the longest palindromic substring in s. 
            You may assume that the maximum length of s is 1000.

            Example 1:

            Input: "babad"
            Output: "bab"
            Note: "aba" is also a valid answer.
            Example 2:
            Input: "cbbd"
            Output: "bb"
         */
        private string palinSub;
        public string PalinSubString { get { return palinSub; } }
        public LngstPalinSubString(string s)
        {
            this.palinSub = LongestPalindrome(s);
        }

        public string LongestPalindrome(string s)
        {
            //throw new NotImplementedException();
            int start=0, middle, end=start,len=1;
            bool[,] isPalin = new bool[s.Length, s.Length];
            if (s.Length < 1)
                return "";
            for (int i = 0; i < s.Length; i++)
            {
                int odd = IsPalindrom(i, i, s);
                int even = IsPalindrom(i, i + 1, s);
                int big = Math.Max(odd, even);
                if (big > (end - start))
                {
                    start = i-(big - 1) / 2;
                    end = i+big / 2;
                }
            }
            return s.Substring(start, end);
        }

        private int IsPalindrom(int s, int e, string str)
        {
            //throw new NotImplementedException();
            while (s >= 0 && e < str.Length && (str[s] == str[e]))
            {
                s--;e++;
            }
            return e - s-1;
        }
    }
}
