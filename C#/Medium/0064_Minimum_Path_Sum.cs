using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_64
    {
        public Medium_64()
        {

        }
        public int MinPathSum(int[][] grid)
        {
            for (int i = grid.Length - 2; i >= 0; i--)
                grid[i][grid[i].Length - 1] += grid[i + 1][grid[i].Length - 1];
            for (int i = grid[grid.Length - 1].Length - 2; i >= 0; i--)
                grid[grid.Length - 1][i] += grid[grid.Length - 1][i + 1];

            for (int i = grid.Length - 2; i >= 0; i--)
                for (int j = grid[i].Length - 2; j >= 0; j--)
                    grid[i][j] += Math.Min(grid[i + 1][j], grid[i][j + 1]);

            return grid[0][0];
        }
    }
}
