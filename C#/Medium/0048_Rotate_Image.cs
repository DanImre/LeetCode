using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;

namespace Medium
{
    public class Medium_48
    {
        public Medium_48()
        {
            /* [[7, 4, 1]
             * [8, 5, 2]
             * [9, 6, 3]] */
            int[][] matrix = new int[][]{
                new int[]{ 1,2,3 },
                new int[]{ 4,5,6 },
                new int[]{ 7,8,9 }
            };

            Rotate(matrix);

            Console.WriteLine("[" + string.Join("\n", matrix.Select(kk => "[" + string.Join(", ", kk.ToList()) + "]")) + "]");
        }
        public void Rotate(int[][] matrix)
        {
            //switching rows
            for (int i = 0; i < matrix.Length/2; i++)
            {
                var temp = matrix[i];
                matrix[i] = matrix[matrix.Length - 1 - i];
                matrix[matrix.Length - 1 - i] = temp;
            }

            //swapping along on topleft to bottomright diagonal
            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; j < i; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
        }
    }
}
