using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_1289
    {
        public Hard_1289()
        {

        }
        public int MinFallingPathSum(int[][] grid)
        {
            int[][] memo = new int[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
                memo[i] = new int[grid.Length];

            for (int col = 0; col < grid.Length; col++)
                memo[grid.Length - 1][col] = grid[grid.Length - 1][col];

            for (int row = grid.Length - 2; row >= 0; row--)
            {
                for (int col = 0; col < grid.Length; col++)
                {
                    int nextMinimum = int.MaxValue;
                    for (int nextRowCol = 0; nextRowCol < grid.Length; nextRowCol++)
                        if (nextRowCol != col)
                            nextMinimum = Math.Min(nextMinimum, memo[row + 1][nextRowCol]);

                    memo[row][col] = grid[row][col] + nextMinimum;
                }
            }

            int answer = int.MaxValue;
            for (int col = 0; col < grid.Length; col++)
                answer = Math.Min(answer, memo[0][col]);

            return answer;
        }
    }
}
