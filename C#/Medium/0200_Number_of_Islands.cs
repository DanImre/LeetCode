using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_200
    {
        public Medium_200()
        {
            
        }
        public int NumIslands(char[][] grid)
        {
            int solution = 0;

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '0')
                        continue;

                    ++solution;

                    Queue<(int x, int y)> q = new Queue<(int x, int y)>();
                    q.Enqueue((i, j));

                    while (q.Count != 0)
                    {
                        var curr = q.Dequeue();

                        if (grid[curr.x][curr.y] == '0')
                            continue;
                        else
                            grid[curr.x][curr.y] = '0';

                        if (curr.x > 0)
                            q.Enqueue((curr.x - 1, curr.y));
                        if (curr.y > 0)
                            q.Enqueue((curr.x, curr.y - 1));
                        if (curr.x < grid.Length - 1)
                            q.Enqueue((curr.x + 1, curr.y));
                        if (curr.y < grid[curr.x].Length - 1)
                            q.Enqueue((curr.x, curr.y + 1));
                    }
                }

            return solution;
        }
    }
}
