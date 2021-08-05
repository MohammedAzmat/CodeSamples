using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class Rotate2DArrInplace
    {
        private int[,] Rotate(int[,] mat)
        {
            //each square in the matrix going in a diagnal
            int squares = Decimal.ToInt32(Math.Ceiling((decimal)mat.GetLength(0) / 2));
            int length = mat.GetLength(0)-1;
            for (int i = 0; i < squares; i++)
            {
                for (int j = i; j < length - i; j++)
                {
                    int temp = mat[i, j];
                    mat[i, j] = mat[length-j, i];
                    mat[length - j, i] = mat[length -i, length - j];
                    mat[length - i, length - j] = mat[j, length - i];
                    mat[j, length - i] = temp;
                }
                //length -= 2;
            }
            return mat;
        }

        private int[,] MakeMatrix(int n)
        {
            int v = 1;
            int[,] mat = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    mat[i, j] = v++;
            return mat;
        }

        private void Display(int[,] mat)
        {
            int n = mat.GetLength(0);
            Console.Write("Matrix\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(mat[i, j] + "\t");
                Console.Write("\n");
            }
        }

        public void LetsMakeNRotate(int n)
        {
            int[,] mat = MakeMatrix(n);
            Display(mat);
            Console.WriteLine("After Rotating ");
            Display(Rotate(mat));
        }

    }
}
