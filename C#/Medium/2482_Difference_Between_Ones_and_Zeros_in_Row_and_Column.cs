using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2482
    {
        public int[][] OnesMinusZeros(int[][] grid)
        {
            int[] onesInRows = new int[grid.Length];
            int[] onesInColumns = new int[grid[0].Length];

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[i].Length; j++)
                    if (grid[i][j] == 1)
                    {
                        ++onesInColumns[j];
                        ++onesInRows[i];
                    }

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[i].Length; j++)
                    grid[i][j] = onesInRows[i] + onesInColumns[j] - (grid.Length - onesInRows[i]) - (grid[0].Length - onesInColumns[j]);

            return grid;
        }
    }
}
