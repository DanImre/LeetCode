using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_1970
    {
        public Hard_1970()
        {
            //3
            int row = 6;
            int col = 2;
            string s = "4,2],[6,2],[2,1],[4,1],[6,1],[3,1],[2,2],[3,2],[1,1],[5,1],[5,2],[1,2";
            int[][] cells = s.Split("],[").Select(kk => kk.Split(",").Select(zz => int.Parse(zz)).ToArray()).ToArray();

            Console.WriteLine(LatestDayToCross(row, col, cells));
        }

        //TLE
        public int LatestDayToCrossTLEbutWorks(int row, int col, int[][] cells)
        {
            int[][] lastDayToBeThere = new int[row][];
            for (int i = 0; i < row; i++)
            {
                lastDayToBeThere[i] = new int[col];
                Array.Fill(lastDayToBeThere[i], int.MaxValue);
            }

            //cords -> last day when it isnt water
            Dictionary<(int x, int y), int> toWater = new Dictionary<(int x, int y), int>();

            for (int i = 0; i < cells.Length; i++)
                toWater.Add((cells[i][0] - 1, cells[i][1] - 1), i);

            Queue<((int x, int y) pos, int day)> q = new Queue<((int x, int y) pos, int day)>();
            HashSet<(int x, int y)> visited = new HashSet<(int x, int y)>();
            for (int i = 0; i < col; i++)
            {
                if (toWater.ContainsKey((0, i)))
                    lastDayToBeThere[0][i] = toWater[(0, i)];

                q.Enqueue(((0, i), lastDayToBeThere[0][i]));
                //visited.Add((0, i));
            }

            var moves = new List<(int x, int y)>() { (1, 0), (0, 1), (-1, 0), (0, -1) };

            while (q.Count != 0)
            {
                var act = q.Dequeue();

                if (visited.Contains(act.pos) && act.day <= lastDayToBeThere[act.pos.x][act.pos.y])
                    continue;

                lastDayToBeThere[act.pos.x][act.pos.y] = act.day;

                if (act.pos.x == row - 1)
                    continue;

                foreach (var item in moves)
                {
                    (int x, int y) nextPos = (act.pos.x + item.x, act.pos.y + item.y);
                    if (nextPos.x < 0 || nextPos.x >= row || nextPos.y < 0 || nextPos.y >= col)
                        continue;

                    int nextDay = act.day;

                    if (toWater.ContainsKey(nextPos))
                        nextDay = Math.Min(nextDay, toWater[nextPos]);

                    q.Enqueue((nextPos, nextDay));
                }

                visited.Add(act.pos);
            }

            Console.WriteLine(string.Join("\n", lastDayToBeThere.Select(kk => string.Join(", ", kk))));

            return lastDayToBeThere.Last().Max();
        }

        //Intended
        public List<(int x, int y)> moves = new List<(int x, int y)>() { (0, 1), (1, 0), (0, -1), (-1, 0) };
        public int LatestDayToCross(int row, int col, int[][] cells)
        {
            //cords -> Day its becomes water
            int start = 0;
            int end = row * col;

            while (start < end)
            {
                int mid = end - ( end - start) / 2;
                if (possibleToReach(cells, mid, row, col))
                    start = mid;
                else
                    end = mid - 1;
            }

            return start;
        }

        public bool possibleToReach(int[][] cells, int startDay, int row, int col)
        {
            int[][] map = new int[row][];
            for (int i = 0; i < row; i++)
            {
                map[i] = new int[col];
                Array.Fill(map[i], 0);
            }

            for (int i = 0; i < startDay; i++)
                map[cells[i][0] - 1][cells[i][1] - 1] = 1;

            Queue<(int x, int y)> q = new Queue<(int x, int y)>();
            for (int i = 0; i < col; i++)
                if (map[0][i] == 0)
                {
                    q.Enqueue((0, i));
                    map[0][i] = -1;
                }

            while (q.Count != 0)
            {
                var act = q.Dequeue();

                if (act.x == row - 1)
                    return true;

                foreach (var item in moves)
                {
                    (int x, int y) nextPos = (act.x + item.x, act.y + item.y);
                    if (nextPos.x < 0 || nextPos.y < 0 || nextPos.x >= row || nextPos.y >= col)
                        continue;

                    if (map[nextPos.x][nextPos.y] != 0)
                        continue;

                    q.Enqueue(nextPos);
                    map[nextPos.x][nextPos.y] = -1;
                }
            }

            return false;
        }
    }
}
