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

        public class Point
        {
            public int x, y;
            public Point(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
        }
        public bool Overlap(List<List<int>> points)
        {
            Point l1 = new Point(points[0][0], points[0][1]);
            Point r1 = new Point(points[1][0], points[1][1]);
            Point l2 = new Point(points[2][0], points[2][1]);
            Point r2 = new Point(points[3][0], points[3][1]);

            if (l1.x >= r2.x || l2.x >= r1.x)
                return false;
            if (r1.y > l2.y || r2.y >= l1.y)
                return false;
            return true;
        }
    }
}
