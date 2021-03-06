﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Strings
{
    public class PalindromeWithJunk
    {
        public string IsPalindrome2(string str)
        {
            int i = 0, j = str.Length - 1;
            str = str.ToLower();
            while (i < j)
            {
                if (SkipIfJunk(str[i])) i++;
                if (SkipIfJunk(str[j])) j--;
                if (str[i++] != str[j--])
                    break;
            }
            if (i < j)
                return "No";
            else
                return "Yes";
        }

        private bool SkipIfJunk(char v)
        {
            //throw new NotImplementedException();
            string pattern = @"\w|\d";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(v.ToString());
        }

        public bool IsPalindrome(string input)
        {
            input = input.ToLower();
            for (int i = 0, j = input.Length - 1; i < j; i++, j--)
            {
                if (input[i] != input[j])
                    return false;
            }
            return true;
        }
    }
}
