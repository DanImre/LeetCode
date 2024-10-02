using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2812
    {
        public Medium_2812()
        {

        }
        public int MaximumSafenessFactor(IList<IList<int>> grid)
        {
            Queue<(int y, int x, int value)> q = new Queue<(int y, int x, int value)>();
            for (int i = 0; i < grid.Count; i++)
                for (int j = 0; j < grid[i].Count; j++)
                    if (grid[i][j] == 1)
                    {
                        q.Enqueue((i, j, 1));
                        grid[i][j] = 0;
                    }
                    else
                        grid[i][j] = -1;

            while (q.Count > 0)
            {
                int qCount = q.Count;
                while (qCount-- > 0)
                {
                    var curr = q.Dequeue();
                    if (curr.y > 0 && grid[curr.y - 1][curr.x] == -1)
                    {
                        grid[curr.y - 1][curr.x] = curr.value;
                        q.Enqueue((curr.y - 1, curr.x, curr.value + 1));
                    }
                    if (curr.y < grid.Count - 1 && grid[curr.y + 1][curr.x] == -1)
                    {
                        grid[curr.y + 1][curr.x] = curr.value;
                        q.Enqueue((curr.y + 1, curr.x, curr.value + 1));
                    }
                    if (curr.x > 0 && grid[curr.y][curr.x - 1] == -1)
                    {
                        grid[curr.y][curr.x - 1] = curr.value;
                        q.Enqueue((curr.y, curr.x - 1, curr.value + 1));
                    }
                    if (curr.x < grid[curr.y].Count - 1 && grid[curr.y][curr.x + 1] == -1)
                    {
                        grid[curr.y][curr.x + 1] = curr.value;
                        q.Enqueue((curr.y, curr.x + 1, curr.value + 1));
                    }
                }
            }

            int bactrackBFS(int y, int x)
            {
                if (grid[y][x] == 0)
                    return 0;

                int prevCell = grid[y][x];
                if (y == grid.Count - 1 && x == grid[y].Count - 1)
                    return prevCell;

                grid[y][x] = 0;

                int max = int.MinValue;
                if (y > 0)
                    max = bactrackBFS(y - 1, x);
                if (y < grid.Count - 1)
                    max = Math.Max(max, bactrackBFS(y + 1, x));
                if (x > 0)
                    max = Math.Max(max, bactrackBFS(y, x - 1));
                if (x < grid[y].Count - 1)
                    max = Math.Max(max, bactrackBFS(y, x + 1));

                grid[y][x] = prevCell;
                int currentSafeness = Math.Min(prevCell, max);

                return currentSafeness;
            }


            return bactrackBFS(0, 0);
        }
    }
}
