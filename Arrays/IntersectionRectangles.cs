using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class IntersectionRectangles
    {
        public bool Intersect(List<List<int>> points)
        {
            if (
                (
                    (points[0][0] <= points[2][0] && points[2][0] <= points[1][0]) &&
                    (points[0][1] <= points[2][1] && points[2][1] <= points[1][1])
                )
                ||
                (
                    (points[0][0] <= points[3][0] && points[3][0] <= points[1][0]) &&
                    (points[0][1] <= points[3][1] && points[3][1] <= points[1][1])
                )
                ||
                (
                    (points[0][0] <= points[2][0] && points[2][0] <= points[1][0]) &&
                    (points[0][1] <= points[3][1] && points[3][1] <= points[1][1])
                )
                ||
                (
                    (points[0][0] <= points[3][0] && points[3][0] <= points[1][0]) &&
                    (points[0][1] <= points[2][1] && points[2][1] <= points[1][1])
                )
                )
                return true;
            return false;
        }
    }
}
