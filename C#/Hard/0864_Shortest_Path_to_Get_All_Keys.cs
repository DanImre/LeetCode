using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_864
    {
        public Hard_864()
        {
            //8
            //string[] grid = new string[] { "@.a..", "###.#", "b.A.B" };

            //6
            //string[] grid = new string[] { "@..aA", "..B#.", "....b" };

            //-1
            //string[] grid = new string[] { "@Aa" };

            //-1
            //string[] grid = new string[] { "@#b#", "..#.", "aAB." };

            //11
            //string[] grid = new string[] { "@fedcbBCDEFaA" };

            //21
            //string[] grid = new string[] { ".#........", "......#..#", ".#B#.#..#.", "##...D.#..", ".#.......#", "##.....a..", "...C.#...#", "A...#.e.E#", "c.@..#...d", "#..#.#.b.#" };

            //14
            string[] grid = new string[] { "Dd#b@", ".fE.e", "##.B.", "#.cA.", "aF.#C" };

            Console.WriteLine(ShortestPathAllKeys(grid));
        }

        //Time limit exceeded
        public int ShortestPathAllKeys2(string[] grid)
        {
            (int x, int y) startPoint = (0, 0);
            Dictionary<(int x, int y), int> keys = new Dictionary<(int x, int y), int>();

            Dictionary<int, (int x, int y)> locksToCords = new Dictionary<int, (int x, int y)>();
            Dictionary<(int x, int y), int> cordsToLocks = new Dictionary<(int x, int y), int>();

            HashSet<(int x, int y)> walls = new HashSet<(int x, int y)>();

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '.')
                        continue;

                    if (grid[i][j] == '#')
                        walls.Add((i, j));
                    else if ('A' <= grid[i][j] && grid[i][j] <= 'F')
                    {
                        locksToCords.Add(grid[i][j] - 'A', (i, j));
                        cordsToLocks.Add((i, j), grid[i][j] - 'A');
                    }
                    else if ('a' <= grid[i][j] && grid[i][j] <= 'f')
                        keys.Add((i, j), grid[i][j] - 'a');
                    else
                        startPoint = (i, j);
                }

            int ShortestPath = ShortestPathAllKeysRecursive(grid.Length, grid[0].Length, startPoint, keys, cordsToLocks, locksToCords, walls);

            return ShortestPath >= 10000 ? -1 : ShortestPath;
        }

        public int ShortestPathAllKeysRecursive(int n, int m, (int x, int y) startPos, Dictionary<(int x, int y), int> keys, Dictionary<(int x, int y), int> locks, Dictionary<int, (int x, int y)> locksToCords, HashSet<(int x, int y)> walls)
        {
            if (keys.Count == 0)
                return 0;

            int min = 10000; //30 by 30, so its impossible to step 10000 times 

            Queue<(int x, int y, int dist)> q = new Queue<(int x, int y, int dist)>();
            q.Enqueue((startPos.x, startPos.y, 0));

            HashSet<(int x, int y)> visited = new HashSet<(int x, int y)>();
            while (q.Count != 0)
            {
                var act = q.Dequeue();

                if (keys.ContainsKey((act.x, act.y)))
                {

                    int key = keys[(act.x, act.y)];
                    keys.Remove((act.x, act.y));
                    locks.Remove(locksToCords[key]);

                    min = Math.Min(min, act.dist + ShortestPathAllKeysRecursive(n, m, (act.x, act.y), keys, locks, locksToCords, walls));

                    locks.Add(locksToCords[key], key);
                    keys.Add((act.x, act.y), key);
                }

                visited.Add((act.x, act.y));

                if (walls.Contains((act.x, act.y)) || locks.ContainsKey((act.x, act.y)))
                    continue;

                if (act.x > 0 && !visited.Contains((act.x - 1, act.y)))
                    q.Enqueue((act.x - 1, act.y, act.dist + 1));
                if (act.x < n - 1 && !visited.Contains((act.x + 1, act.y)))
                    q.Enqueue((act.x + 1, act.y, act.dist + 1));
                if (act.y > 0 && !visited.Contains((act.x, act.y - 1)))
                    q.Enqueue((act.x, act.y - 1, act.dist + 1));
                if (act.y < m - 1 && !visited.Contains((act.x, act.y + 1)))
                    q.Enqueue((act.x, act.y + 1, act.dist + 1));
            }

            return min;
        }

        public int ShortestPathAllKeys(string[] grid)
        {
            (int x, int y) startPoint = (0, 0);

            int allKeyState = 0;

            HashSet<(int x, int y)> keys = new HashSet<(int x, int y)>();
            HashSet<(int x, int y)> locks = new HashSet<(int x, int y)>();

            HashSet<(int x, int y)> walls = new HashSet<(int x, int y)>();

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '.')
                        continue;

                    if (grid[i][j] == '#')
                        walls.Add((i, j));
                    else if ('A' <= grid[i][j] && grid[i][j] <= 'F')
                        locks.Add((i, j));
                    else if ('a' <= grid[i][j] && grid[i][j] <= 'f')
                    {
                        keys.Add((i, j));
                        allKeyState |= (1 << grid[i][j] - 'a');
                    }
                    else
                        startPoint = (i, j);
                }

            //keys = each key is one bit, having key 'a' and 'c' is = 000101

            //keys -> visited with those keys
            Dictionary<int, HashSet<(int x, int y)>> visited = new Dictionary<int, HashSet<(int x, int y)>>();
            visited.Add(0, new HashSet<(int x, int y)>() { startPoint });


            //moves
            (int x, int y)[] moves = new (int x, int y)[] { (1, 0), (0, 1), (-1, 0), (0, -1) };

            Queue<(int x, int y, int keys, int dist)> q = new Queue<(int x, int y, int keys, int dist)>();
            q.Enqueue((startPoint.x, startPoint.y, 0, 0));

            while (q.Count != 0)
            {
                var act = q.Dequeue();

                foreach (var item in moves)
                {
                    (int x, int y) nextPos = (act.x + item.x, act.y + item.y);
                    if (walls.Contains(nextPos) || nextPos.x < 0 || nextPos.x >= grid.Length || nextPos.y < 0 || nextPos.y >= grid[nextPos.x].Length)
                        continue;

                    if (keys.Contains(nextPos))
                    {
                        if ((act.keys & (1 << (grid[nextPos.x][nextPos.y] - 'a'))) != 0)
                            continue;

                        int newKeys = act.keys | (1 << (grid[nextPos.x][nextPos.y] - 'a'));

                        if (newKeys == allKeyState) //collected every key
                            return act.dist + 1;

                        if (!visited.ContainsKey(newKeys))
                            visited.Add(newKeys, new HashSet<(int x, int y)>());

                        visited[newKeys].Add(nextPos);

                        q.Enqueue((nextPos.x, nextPos.y, newKeys, act.dist + 1));
                    }

                    if (locks.Contains(nextPos) && (act.keys & (1 << (grid[nextPos.x][nextPos.y] - 'a'))) == 0)
                        continue;
                    else if (!visited[act.keys].Contains(nextPos))
                    {
                        visited[act.keys].Add(nextPos);
                        q.Enqueue((nextPos.x, nextPos.y, act.keys, act.dist + 1));
                    }

                }
            }

            return -1;
        }
    }
}
