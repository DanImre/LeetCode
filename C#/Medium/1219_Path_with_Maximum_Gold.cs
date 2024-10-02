using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1219
    {
        public Medium_1219()
        {

        }
        public int GetMaximumGold(int[][] grid)
        {
            int solution = 0;

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[i].Length; j++)
                    solution = Math.Max(solution,DFS(i,j));


            int DFS(int i, int j)
            {
                if (i < 0 || j < 0 || i == grid.Length || j == grid[i].Length || grid[i][j] == 0)
                    return 0;

                int originalValue = grid[i][j];

                int max = 0;

                grid[i][j] = 0;

                if (i > 0)
                    max = DFS(i - 1, j);
                if (i + 1 < grid.Length)
                    max = Math.Max(max, DFS(i + 1, j));
                if (j > 0)
                    max = Math.Max(max, DFS(i, j - 1));
                if (j + 1 < grid[i].Length)
                    max = Math.Max(max, DFS(i, j + 1));

                grid[i][j] = originalValue;

                return originalValue + max;
            }

            return solution;
        }
    }
}
