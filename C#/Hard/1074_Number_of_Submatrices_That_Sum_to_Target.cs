using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_1074
    {
        public Hard_1074()
        {
            //int[][] matrix = new int[][]
            //{
            //    new int[] { 0, 1, 0},
            //    new int[] { 1, 1, 1},
            //    new int[] { 0, 1, 0}
            //};
            int[][] matrix = new int[][]
            {
                new int[] { 1, -1 },
                new int[] { -1, 1 }
            };
            Console.WriteLine(NumSubmatrixSumTarget(matrix,0));
        }
        public int NumSubmatrixSumTarget(int[][] matrix, int target)
        {
            int solution = 0;

            for (int l = 0; l < matrix[0].Length; l++)
            {
                int[] sums = new int[matrix.Length];
                for (int r = l; r < matrix[0].Length; r++)
                {
                    for (int i = 0; i < matrix.Length; i++)
                        sums[i] += matrix[i][r];
                    for (int i = 0; i < matrix.Length; i++)
                    {
                        int sum = 0;
                        for (int j = i; j < matrix.Length; j++)
                        {
                            sum += sums[j];
                            if (sum == target)
                                ++solution;
                        }
                    }
                }
            }

            return solution;
        }
    }
}
