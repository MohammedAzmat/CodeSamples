using System;
using System.Collections.Generic;
using System.Text;

namespace Beginner.Strings
{
    class ZigZag
    {
        public string Convert(string s, int numRows)
        {
            int row = 0;
            string zigZagStr = "",last = "";
            if (numRows == 1)
                return s;
            if (numRows > 1)
            {
                while (row < numRows-1)
                {
                    //top and bottom row
                    if (row == 0)
                    {
                        for (int i = 0; i < s.Length; i+= (numRows - 1)* 2)
                        {
                            //
                            zigZagStr += s[i];
                            int j = ((i + numRows - 1) < s.Length) ? i + numRows - 1 : 0;
                            if (j > 0) //Bottom Hinge Exists
                            {
                                last += s[j];
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < s.Length; i+= (numRows - 1) * 2)
                        {
                            //
                            if((i+row)<s.Length)
                                zigZagStr += s[i+row];
                            int j = ((i + numRows - 1) < s.Length) ? i + numRows - 1 : 0;
                            if (j > 0 && (j + (numRows - 1) - row) <s.Length) //Bottom Hinge Exists
                            {
                                zigZagStr += s[j + (numRows-1) - row];
                            }
                        }
                    }
                    row++;
                }
            }
            return zigZagStr+last;
        }
    }
}
