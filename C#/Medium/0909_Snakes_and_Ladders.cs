using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_909
    {
        public Medium_909()
        {
            /*
            //4
            string s = "-1,-1,-1,-1,-1,-1],[-1,-1,-1,-1,-1,-1],[-1,-1,-1,-1,-1,-1],[-1,35,-1,-1,13,-1],[-1,-1,-1,-1,-1,-1],[-1,15,-1,-1,-1,-1";
            int[][] board = s.Split("],[").Select(kk => kk.Split(",").Select(zz => int.Parse(zz)).ToArray()).ToArray();
            */
            
            //3
            string s = "-1,-1,-1,-1,48,5,-1],[12,29,13,9,-1,2,32],[-1,-1,21,7,-1,12,49],[42,37,21,40,-1,22,12],[42,-1,2,-1,-1,-1,6],[39,-1,35,-1,-1,39,-1],[-1,36,-1,-1,-1,-1,5";
            int[][] board = s.Split("],[").Select(kk => kk.Split(",").Select(zz => int.Parse(zz)).ToArray()).ToArray();

            Console.WriteLine(SnakesAndLadders(board));
        }
        public int SnakesAndLadders(int[][] board)
        {
            int n = board.Length * board.Length;
            int[] distance = new int[n];
            Array.Fill(distance, int.MaxValue);

            Queue<(int pos, int steps)> q = new Queue<(int pos, int steps)>();
            q.Enqueue((0,0));
            while (q.Count != 0)
            {
                var curr = q.Dequeue();

                int value = getValueFromPos(board, curr.pos);
                if (value != -1)
                {
                    curr.pos = value - 1;//keep it zero-based
                    if (distance[curr.pos] <= curr.steps)
                        continue;

                    distance[curr.pos] = curr.steps;
                }
                else if (distance[curr.pos] <= curr.steps)
                    continue;

                distance[curr.pos] = curr.steps;


                for (int i = Math.Min(curr.pos + 6, n - 1); i >= curr.pos + 1 && i >= 0; i--)
                    q.Enqueue((i, curr.steps + 1));
            }

            if (distance[n - 1] == int.MaxValue)
                return -1;

            return distance[n - 1];
        }
        public int getValueFromPos(int[][] board, int pos) //Pos starts from 0, not 1
        {
            int i = pos / board.Length; //From bottom

            int j = i % 2 == 0 ? pos % board.Length : board.Length - (pos % board.Length) - 1;
            i = board.Length - i - 1;

            return board[i][j];
        }
    }
}
