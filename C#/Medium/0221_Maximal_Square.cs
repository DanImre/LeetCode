using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_221
    {
        public Medium_221()
        {
            char[][] matrix = "\"1\",\"0\",\"1\",\"0\",\"0\"],[\"1\",\"0\",\"1\",\"1\",\"1\"],[\"1\",\"1\",\"1\",\"1\",\"1\"],[\"1\",\"0\",\"0\",\"1\",\"0\"".Split("],[").Select(kk => kk.Split(',').Select(zz => zz[1]).ToArray()).ToArray();
            Console.WriteLine(MaximalSquare(matrix));
        }
        public int MaximalSquare(char[][] matrix)
        {
            if (matrix.All(kk => kk.All(zz => zz == '0')))
                return 0;

            if (matrix.Length == 1 || matrix[0].Length == 1)
                return 1;

            char[][] newMatrix = new char[matrix.Length - 1][];
            for (int i = 1; i < matrix.Length; i++)
            {
                newMatrix[i - 1] = new char[matrix[i].Length - 1];
                for (int j = 1; j < matrix[i].Length; j++)
                {
                    if (matrix[i - 1][j - 1] == '1'
                        && matrix[i][j - 1] == '1'
                        && matrix[i - 1][j] == '1'
                        && matrix[i][j] == '1')
                        newMatrix[i - 1][j - 1] = '1';
                    else
                        newMatrix[i - 1][j - 1] = '0';
                }
            }

            return (int)Math.Pow(1 + Math.Sqrt(MaximalSquare(newMatrix)), 2);
        }
    }
}
