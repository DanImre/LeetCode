using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1926
    {
        public Medium_1926()
        {

        }
        public int NearestExit(char[][] maze, int[] entrance)
        {
            Queue<(int x, int y)> q = new Queue<(int x, int y)>();
            maze[entrance[0]][entrance[1]] = '+';

            if (entrance[0] > 0)
                q.Enqueue((entrance[0] - 1, entrance[1]));
            if (entrance[0] < maze.Length - 1)
                q.Enqueue((entrance[0] + 1, entrance[1]));
            if (entrance[1] > 0)
                q.Enqueue((entrance[0], entrance[1] - 1));
            if (entrance[1] < maze[0].Length - 1)
                q.Enqueue((entrance[0], entrance[1] + 1));

            int solution = 0;

            while (q.Count != 0)
            {
                int qCount = q.Count;
                for (int i = 0; i < qCount; i++)
                {
                    var curr = q.Dequeue();

                    if (curr.x < 0 || curr.x >= maze.Length
                        || curr.y < 0 || curr.y >= maze[0].Length)
                        return solution;

                    if (maze[curr.x][curr.y] == '+')
                        continue;

                    maze[curr.x][curr.y] = '+';
                    q.Enqueue((curr.x - 1, curr.y));
                    q.Enqueue((curr.x + 1, curr.y));
                    q.Enqueue((curr.x, curr.y - 1));
                    q.Enqueue((curr.x, curr.y + 1));
                }
                ++solution;
            }

            return -1;
        }
    }
}
