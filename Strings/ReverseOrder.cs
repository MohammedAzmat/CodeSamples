using System;
using System.Collections.Generic;
using System.Text;

namespace Strings
{
    public class ReverseOrder
    {
        public string stringReverse(string str)
        {
            string rev = null;
            int end = str.Length - 1, start = end;
            for (int i = end; i >= 0; i--)
            {
                end = i;
                start = end;
                //Till space it is one word
                while (start >0 && str[i] != ' ')
                {
                    i--;
                    start--;
                }
                if(start > 0 )
                    rev += str.Substring(start+1, end - start);
                else
                    rev += str.Substring(start, end - start +1 );
                while (str[i] == ' ')
                {
                    i--;
                }
                if (start > 0)
                {
                    i++;
                    rev += ' ';
                }
            }
            return rev;
        }
    }
}
