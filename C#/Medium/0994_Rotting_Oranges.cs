using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_994
    {
        public Medium_994()
        {

        }
        public int OrangesRotting(int[][] grid)
        {
            Queue<(int x, int y)> q = new Queue<(int x, int y)>();
            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[i].Length; j++)
                    if (grid[i][j] == 2)
                        q.Enqueue((i, j));

            if (q.Count == 0)
                return grid.Any(kk => kk.Any(zz => zz == 1)) ? -1 : 0;

            int solution = -1;

            while (q.Count != 0)
            {
                ++solution;
                int qCount = q.Count;
                for (int i = 0; i < qCount; i++)
                {
                    var curr = q.Dequeue();

                    if (curr.x > 0 && grid[curr.x - 1][curr.y] == 1)
                    {
                        q.Enqueue((curr.x - 1, curr.y));
                        grid[curr.x - 1][curr.y] = 2;
                    }
                    if (curr.x < grid.Length - 1 && grid[curr.x + 1][curr.y] == 1)
                    {
                        q.Enqueue((curr.x + 1, curr.y));
                        grid[curr.x + 1][curr.y] = 2;
                    }
                    if (curr.y > 0 && grid[curr.x][curr.y - 1] == 1)
                    {
                        q.Enqueue((curr.x, curr.y - 1));
                        grid[curr.x][curr.y - 1] = 2;
                    }
                    if (curr.y < grid[0].Length - 1 && grid[curr.x][curr.y + 1] == 1)
                    {
                        q.Enqueue((curr.x, curr.y + 1));
                        grid[curr.x][curr.y + 1] = 2;
                    }
                }
            }

            return grid.Any(kk => kk.Any(zz => zz == 1)) ? -1 : solution;
        }
    }
}
