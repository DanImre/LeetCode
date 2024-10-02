using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_463
    {
        public Easy_463()
        {

        }
        public int IslandPerimeter(int[][] grid)
        {
            int solution = 0;

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 0)
                        continue;
                    //left
                    if (j == 0 || grid[i][j - 1] == 0)
                        ++solution;
                    //right
                    if (j == grid[i].Length - 1 || grid[i][j + 1] == 0)
                        ++solution;
                    //up
                    if (i == 0 || grid[i - 1][j] == 0)
                        ++solution;
                    //down
                    if (i == grid.Length - 1 || grid[i + 1][j] == 0)
                        ++solution;
                }

            return solution;
        }
    }
}
