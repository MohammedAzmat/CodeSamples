using System;
using System.Collections.Generic;
using System.Text;

namespace Beginner.Strings
{
    public class MyA2I
    {
        public int MyAtoi(string str)
        {
            str = str.Trim();
            int i = 1;
            bool leadingZeros = false;
            if (str.Length > 0)
            {
                if (isValidNum(str[0], true))
                {
                    string retString = null;
                    if (str[0] != '0')
                        retString += str[0];
                    else
                        leadingZeros = true;
                    while (leadingZeros && i < str.Length)
                    {
                        if (str[i++] != '0')
                            leadingZeros = false;
                    }
                    if (i < str.Length)
                        i = (retString == null) ? --i : i;
                    else
                        return 0;
                    while (i < str.Length && isValidNum(str[i], false))
                    {
                        if (retString != null && retString.Length == 1 && (retString[0] == '+' || retString[0] == '-'))
                        {
                            //CHeck for leading Zeros after the symbols
                            if (str[i] == '0')
                            {
                                while (str[i++] == '0')
                                    continue;
                                i--;
                            }
                            //if(isValidNum(str[i],false))
                        }
                        if (retString!=null && retString.Length > 8)
                        {
                            if (inMinMax(retString, str[i]))
                                retString += str[i++];
                            else
                                if (retString[0] == '-')
                                return int.MinValue;
                            else
                                return int.MaxValue;
                        }
                        else
                            //if()
                            retString += str[i++];
                    }
                    if (retString.Length > 1)
                        return Convert.ToInt32(retString);
                    else
                        if (isValidNum(retString[0], false))
                        return Convert.ToInt32(retString);
                    else
                        return 0;

                }
            }
            return 0;
        }

        private bool inMinMax(string retString, char ch)
        {
            if (retString[0] == '-')
                return ((int.MinValue) / 10 < Convert.ToInt32(retString) && Convert.ToInt32(ch) < 8) ? true : false;
            else
                return ((int.MaxValue) / 10 < Convert.ToInt32(retString) && Convert.ToInt32(ch) < 7) ? true : false;
        }

        private bool isValidNum(char ch, bool first)
        {
            bool retVal = false;
            if (first)
            {
                retVal = (ch == '-' || ch == '+') ? true : false;
            }
            if (!retVal)
            {
                switch (ch)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        retVal = true;
                        break;
                    default:
                        retVal = false;
                        break;
                }
            }
            return retVal;
        }
    }
}
