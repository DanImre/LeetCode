using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_289
    {
        public Medium_289()
        {
            //[[0,0,0],[1,0,1],[0,1,1],[0,1,0]]
            int[][] board = "[[0,1,0],[0,0,1],[1,1,1],[0,0,0]]".Split("],[", StringSplitOptions.RemoveEmptyEntries).Select(zz => zz.Where(kk => kk != '[' && kk != ']' && kk != ',').Select(kk => int.Parse(kk.ToString())).ToArray()).ToArray();

            //[[1,1],[1,1]]
            //int[][] board = "[[1,1],[1,0]]".Split("],[", StringSplitOptions.RemoveEmptyEntries).Select(zz => zz.Where(kk => kk != '[' && kk != ']' && kk != ',').Select(kk => int.Parse(kk.ToString())).ToArray()).ToArray();

            GameOfLife(board);

            Console.WriteLine("[" + string.Join(", ", board.Select(kk => "[" + string.Join(", ", kk) + "]")) + "]");
        }
        //O(n * m) space and O(n * m) in time
        public void GameOfLife(int[][] board)
        {
            HashSet<(int x, int y)> cellsToFlip = new HashSet<(int x, int y)>();

            for (int i = 0; i < board.Length; i++)
                for (int j = 0; j < board[i].Length; j++)
                {
                    int aliveCount = -board[i][j];

                    for (int x = Math.Max(i - 1, 0); x < Math.Min(i + 2, board.Length); x++)
                        for (int y = Math.Max(j - 1, 0); y < Math.Min(j + 2, board[i].Length); y++)
                            aliveCount += board[x][y];

                    if (board[i][j] == 0)
                    {
                        if (aliveCount == 3)
                            cellsToFlip.Add((i, j));
                        continue;
                    }


                    if (aliveCount < 2 || aliveCount > 3)
                        cellsToFlip.Add((i, j));
                }

            foreach (var item in cellsToFlip)
                board[item.x][item.y] = board[item.x][item.y] == 1 ? 0 : 1;
        }
    }
}
