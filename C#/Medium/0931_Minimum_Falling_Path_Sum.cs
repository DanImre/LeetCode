using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_931
    {
        public Medium_931()
        {

        }
        public int MinFallingPathSum(int[][] matrix)
        {
            int[][] dist = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
                dist[i] = new int[matrix.Length];

            dist[0] = matrix[0];

            for (int i = 1; i < matrix.Length; i++)
                for (int j = 0; j < matrix.Length; j++)
                {
                    int min = int.MaxValue;
                    for (int z = Math.Max(0, j - 1); z <= Math.Min(j + 1, matrix.Length - 1); z++)
                        min = Math.Min(min, dist[i - 1][z]);
                    dist[i][j] = min + matrix[i][j];
                }

            return dist[^1].Min();
        }
    }
}
