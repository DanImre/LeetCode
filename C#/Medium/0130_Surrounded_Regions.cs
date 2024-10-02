using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_130
    {
        public Medium_130()
        {

        }
        public void Solve(char[][] board)
        {
            HashSet<(int, int)> staying = new HashSet<(int, int)>();
            for (int i = 0; i < board.Length; i++)
            {
                int step = board[0].Length - 1;
                if (i == 0 || i == board.Length - 1)
                    step = 1;
                for (int j = 0; j < board[i].Length; j+=step)
                {
                    if (staying.Contains((i, j)) || board[i][j] == 'X')
                        continue;

                    Queue<(int x, int y)> q = new Queue<(int x, int y)>();
                    q.Enqueue((i, j));

                    while (q.Count != 0)
                    {
                        var curr = q.Dequeue();
                        if (board[curr.x][curr.y] == 'X' || !staying.Add(curr))
                            continue;

                        if (curr.x > 0)
                            q.Enqueue((curr.x - 1, curr.y));
                        if (curr.y > 0)
                            q.Enqueue((curr.x, curr.y - 1));
                        if (curr.x < board.Length - 1)
                            q.Enqueue((curr.x + 1, curr.y));
                        if (curr.y < board[curr.x].Length - 1)
                            q.Enqueue((curr.x, curr.y + 1));
                    }
                }
            }

            for (int i = 0; i < board.Length; i++)
                for (int j = 0; j < board[i].Length; j++)
                    if (!staying.Contains((i, j)))
                        board[i][j] = 'X';
        }
    }
}
