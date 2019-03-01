using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{

    public class XPiecesInMatrix
    {
        class Point
        {
            public int x, y;
            public Point(int i, int j)
            {
                x = i;
                y = j;
            }
        }
        private int GetXPieces(int[,] mat)
        {
            int x = 0;
            HashSet<Point> visited = new HashSet<Point>();
            int rows = mat.GetLength(0);
            int cols = mat.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Point pt = new Point(i, j);
                    if (!visited.Contains(pt))
                    {
                        if (mat[i, j] == 'X')
                        {

                        }
                        else
                            visited.Add(pt);
                    }
                }
            }
            return x;
        }
    }
}
