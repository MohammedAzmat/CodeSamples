using System;
using System.Collections.Generic;
using System.Text;

namespace Strings
{
    /// <summary>
    /// Longest Non Repeating Character Sub String
    /// </summary>
    public class LgstNonRptngSubString
    {
        private int lngstlen = 0, start = 0, end = 0, len;
        private char[] st;
        public int LongestNRCharSubString { get; set; }
        public LgstNonRptngSubString(string s)
        {
            Dictionary<Char, Int32> dict = new Dictionary<char, int>();
            
            st = s.ToCharArray();
            len = s.Length;
            while (start < len && end < len)
            {
                if (dict.ContainsKey(st[end]))
                {
                    //TODO: When we find something we already have
                    //start position becomes next value of the prev occrrence of current character
                    start = Math.Max(dict[st[end]] + 1,start);
                    dict[st[end]] = end;
                }
                else
                {
                    //We Got new stuff!
                    dict.Add(st[end], end);
                }
                lngstlen = Math.Max(end - start + 1, lngstlen);

                end++;
            }
            this.LongestNRCharSubString = lngstlen;
        }
    }
}
