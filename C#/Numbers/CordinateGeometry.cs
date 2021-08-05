using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class CordinateGeometry
    {
        public void Intersect(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            //find tan's
            double m1, m2, c1, c2;
            m1 = (double)((y2 - y1) / (x2 - x1));
            m2 = (double)((y4 - y3) / (x4 - x3));
            c1 = y1 - x1 * m1;
            c2 = y3 - x3 * m2;
            if (m1 == m2)
            {
                if (c1 == c2)
                    Console.WriteLine("Same line");
                else
                    Console.WriteLine("Parallel lines");
            }
            else
            {
                double y, x;
                y = (c1 / m1 - c2 / m2) / (1 / m1 - 1 / m2);
                x = -1 * (c1 - c2) / (m1 - m2);
                Console.WriteLine("Intersection Lines, y: " + y+ " x: " + x);
            }
        }
    }
}
