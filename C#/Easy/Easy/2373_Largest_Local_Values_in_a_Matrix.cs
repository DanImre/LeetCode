using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_2373
    {
        public Easy_2373()
        {
            
        }
        public int[][] LargestLocal(int[][] grid)
        {
            int[][] maxLocal = new int[grid.Length - 2][];
            for (int i = 0; i < grid.Length - 2; ++i)
            {
                maxLocal[i] = new int[grid.Length - 2];
                for (int j = 0; j < grid.Length - 2; ++j)
                {
                    int max = int.MinValue;
                    for (int ik = i; ik < i + 3; ik++)
                        for (int jk = j; jk < j + 3; jk++)
                            max = Math.Max(max, grid[ik][jk]);

                    maxLocal[i][j] = max;
                }
            }

            return maxLocal;
        }
    }
}
