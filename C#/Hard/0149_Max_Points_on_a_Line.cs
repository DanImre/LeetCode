using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Hard
{
    public class Hard_149
    {
        public Hard_149()
        {
            int[][] points = new int[][]
            {
                new int[] { 2, 2 },
                new int[] { 4, 4 }
            };
            /*
            (int x, int y) vector = (points[1][0] - points[0][0], points[1][1] - points[0][1]);
            Func<int[], bool> func = (kk => vector.y * kk[0] - vector.x * kk[1] == vector.y * points[0][0] - vector.x * points[0][1]);

            Console.WriteLine(func(new int[] { 3, 3 }));
            Console.WriteLine(func(new int[] { 3000, 3001 }));
            */
            Console.WriteLine(MaxPoints(points));
        }
        //somehow wrong
        public int MaxPointsWrong(int[][] points)
        {
            if (points.Length == 1)
                return 1;

            int max = 2;
            HashSet<Func<int[], bool>>[] usedLinesPerPoints = new HashSet<Func<int[], bool>>[points.Length];
            for (int i = 0; i < points.Length; i++)
                usedLinesPerPoints[i] = new HashSet<Func<int[], bool>>();

            Dictionary<Func<int[], bool>, int> lines = new Dictionary<Func<int[], bool>, int>();

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    bool onTheSameLine = false;
                    foreach (var item in lines.Keys)
                        if (item(points[j]) && usedLinesPerPoints[j].Add(item))
                        {
                            max = Math.Max(max, ++lines[item]);
                            onTheSameLine |= usedLinesPerPoints[i].Contains(item);
                        }

                    if (onTheSameLine)
                        continue;

                    (int x, int y) vector = (points[j][0] - points[i][0], points[j][1] - points[i][1]);
                    Func<int[], bool> func = (kk => vector.y * kk[0] - vector.x * kk[1] == vector.y * points[i][0] - vector.x * points[i][1]);
                    lines.Add(func, 2);
                    usedLinesPerPoints[i].Add(func);
                    usedLinesPerPoints[j].Add(func);
                }
            }

            return max;
        }
        //greedy //TLE but close
        public int MaxPointsTLE1(int[][] points)
        {
            if (points.Length == 1)
                return 1;

            int max = 2;

            Dictionary<Func<int[], bool>, int> lines = new Dictionary<Func<int[], bool>, int>();

            for (int i = 0; i < points.Length; i++)
                for (int j = i + 1; j < points.Length; j++)
                {
                    if (lines.Keys.Any(kk => kk(points[i]) && kk(points[j]))) //they are on the same line
                        continue;

                    (int x, int y) vector = (points[j][0] - points[i][0], points[j][1] - points[i][1]);
                    int rightside = vector.y * points[i][0] - vector.x * points[i][1];

                    Func<int[], bool> func = (kk => vector.y * kk[0] - vector.x * kk[1] == rightside);
                    lines.Add(func, 0);
                }

            foreach (int[] p in points)
                foreach (Func<int[], bool> f in lines.Keys)
                    if (f(p))
                        max = Math.Max(max, ++lines[f]);

            return max;
        }
        //angle from each point, if the angle is the same, its on the same line
        public int MaxPoints(int[][] points)
        {
            if (points.Length == 1)
                return 1;

            int max = 2;

            for (int i = 0; i < points.Length; i++)
            {
                Dictionary<double, int> angles = new Dictionary<double, int>();
                for (int j = 0; j < points.Length; j++)
                {
                    if (j == i)
                        continue;

                    double curr = Math.Atan2(points[j][1] - points[i][1], points[j][0] - points[i][0]);

                    if (!angles.TryAdd(curr, 2))
                        ++angles[curr];

                    max = Math.Max(max, angles[curr]);
                }
            }

            return max;
        }
    }
}
