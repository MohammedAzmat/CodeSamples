using System;
using System.Collections.Generic;
using System.Text;

namespace Beginner.Numbers
{
    class ReverseNumber
    {
        public int Reverse(int x)
        {
            if (x == int.MinValue)
                return 0;
            int y = 0;
            bool neg = (x >= 0) ? false : true;
            x = Math.Abs(x);
            while (x>0)
            {
                y = ((y>int.MaxValue/10))?0: 10 * y + x % 10;
                x /= 10;
            }
            return neg ? -1 * y : y;
        }
    }
}
