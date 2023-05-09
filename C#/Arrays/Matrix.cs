using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class Matrix
    {
        #region Spiral Matrix
        /*
         * Given an m x n matrix, return all elements of the matrix in spiral order.
         * Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
         * Output: [1,2,3,6,9,8,7,4,5]
         * 
         * Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
         * Output: [1,2,3,4,8,12,11,10,9,5,6,7]
         * 
         * Constraints:
            m == matrix.length
            n == matrix[i].length
            1 <= m, n <= 10
            -100 <= matrix[i][j] <= 100
         */

        public IList<int> SpiralOrder(int[][] matrix)
        {
            IList<int> output = new List<int>();
            if (matrix.Length == 1)
            {
                for (int i = 0; i < matrix[0].Length; i++)
                {
                    output.Add(matrix[0][i]);
                }
            }
            else if (matrix[0].Length == 1)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    output.Add(matrix[i][0]);
                }
            }
            else
            {
                Walk("right", matrix, 0, 0, output);
            }
            return output;
        }

        private void Walk(string direction, int[][] matrix, int row, int col, IList<int> output)
        {
            int r = row, c = col;
            if (isVisited(matrix, r, c)) return;
            while (isValid(direction, matrix, r, c))
            {
                if (isVisited(matrix, r, c)) break;

                output.Add(matrix[r][c]);
                matrix[r][c] = 500;
                Console.WriteLine("Before: " + r + " " + c);
                (r, c) = Action(direction, matrix, r, c);
                Console.WriteLine("After: " + r + " " + c);
            }
            (direction, r, c) = NextDir(direction, r, c);
            Walk(direction, matrix, r, c, output);

        }

        private bool isValid(string direction, int[][] matrix, int row, int col)
        {
            if (direction == "right") return col < matrix[0].Length;
            if (direction == "bottom") return row < matrix.Length;
            if (direction == "left") return col >= 0;
            return row >= 0;
        }

        private bool isVisited(int[][] matrix, int row, int col)
        {
            return row >= matrix.Length || col >= matrix[0].Length || row < 0 || col < 0 || matrix[row][col] == 500;
        }

        private (int, int) Action(string direction, int[][] matrix, int row, int col)
        {
            if (direction == "right") return (row, ++col);
            else if (direction == "bottom") return (++row, col);
            else if (direction == "left") return (row, --col);
            else return (--row, col);
        }

        private (string, int, int) NextDir(string direction, int r, int c)
        {
            if (direction == "right") return ("bottom", ++r, --c);
            if (direction == "bottom") return ("left", --r, --c);
            if (direction == "left") return ("up", --r, ++c);
            return ("right", ++r, ++c);

        }
        #endregion
    }
}
