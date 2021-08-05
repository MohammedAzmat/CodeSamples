using System;
using System.Collections.Generic;
using System.Text;

namespace Strings
{
    #region Question
    /*
     * Given an input string (s) and a pattern (p), implement regular expression matching with support for '.' and '*'.

    '.' Matches any single character.
    '*' Matches zero or more of the preceding element.
    The matching should cover the entire input string (not partial).

    Note:

    s could be empty and contains only lowercase letters a-z.
    p could be empty and contains only lowercase letters a-z, and characters like . or *.
    Example 1:

    Input:
    s = "aa"
    p = "a"
    Output: false
    Explanation: "a" does not match the entire string "aa".
    Example 2:

    Input:
    s = "aa"
    p = "a*"
    Output: true
    Explanation: '*' means zero or more of the precedeng element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
    Example 3:

    Input:
    s = "ab"
    p = ".*"
    Output: true
    Explanation: ".*" means "zero or more (*) of any character (.)".
    Example 4:

    Input:
    s = "aab"
    p = "c*a*b"
    Output: true
    Explanation: c can be repeated 0 times, a can be repeated 1 time. Therefore it matches "aab".
    Example 5:

    Input:
    s = "mississippi"
    p = "mis*is*p*."
    Output: false
     */
    #endregion
    public class SimpleRegEx
    {
        public bool IsMatch(string s, string p)
        {
            if (s.Length == 0 && p.Length == 0)
                return true;
            else if ((p.Length == 0 && s.Length != 0) || (p.Length != 0 && s.Length == 0))
                return false;
            else
            {
                //Match the first character of the pattern with the string
                Boolean matchOne = ((s[0] == p[0]) || (p[0] == '.'));
                if (p.Length > 1 && p[1] == '*')
                    //return (IsMatch(s, p.Substring(2)) || (matchOne && (s.Length>1)?IsMatch(s.Substring(1), p): matchOne));
                    return (IsMatch(s, p.Substring(2)) || (matchOne && IsMatch(s.Substring(1), p)));
                else
                    return (matchOne && IsMatch(s.Substring(1), p.Substring(1)));


            }
        }
    }
}
