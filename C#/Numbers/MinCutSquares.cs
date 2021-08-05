using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class MinCutSquares
    {
        /*
         * Cut squares from given dimensions as less as possible
         */
        public int CutSquares(int len, int width)
        {
            if (len == 0 || width == 0) return 0;
            if (len == 1 && width == 1) return 1;
            if (len < width)
            {
                int temp = len;
                len = width;
                width = temp;
            }
            return CutSquares(len - width, width)+1;

        }
    }
}
