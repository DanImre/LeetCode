using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_1575
    {
        public Hard_1575()
        {
            Console.WriteLine(CountRoutes(new int[] { 2, 3, 6, 8, 4 }, 1, 3, 5));
            Console.WriteLine(CountRoutes(new int[] { 4, 3, 1 }, 1, 0, 6));
            Console.WriteLine(CountRoutes(new int[] { 4, 3, 1 }, 1, 0, 8));
            Console.WriteLine(CountRoutes(new int[] { 1, 2, 3 }, 0, 2, 40)); //== 615088286
        }

        //recursive dp
        public int CountRoutes(int[] locations, int start, int finish, int fuel)
        {
            Dictionary<(int, int), int> dp = new Dictionary<(int, int), int>();
            Dictionary<int, List<(int index, int cost)>> canReachFromIndex = new Dictionary<int, List<(int index, int cost)>>();

            for (int i = 0; i < locations.Length; i++)
            {
                List<(int index, int cost)> temp = new List<(int index, int cost)>();
                for (int j = 0; j < locations.Length; j++)
                {
                    if (i == j)
                        continue;

                    int cost = Math.Abs(locations[i] - locations[j]);
                    if (cost > fuel) //Couldn't have ever reached it anyway
                        continue;

                    temp.Add((j, cost));
                }
                canReachFromIndex.Add(i, temp);
            }

            return CountRoutesRecursivePart(canReachFromIndex, dp, locations, start, finish, fuel);
        }

        public int CountRoutesRecursivePart(Dictionary<int, List<(int index, int cost)>> canReachFromIndex, Dictionary<(int, int), int> dp, int[] locations, int start, int finish, int fuel)
        {
            int routeCount = 0;

            if (dp.ContainsKey((start, fuel)))
                return dp[(start, fuel)] % 1000000007;

            foreach (var item in canReachFromIndex[start])
            {
                if (item.cost > fuel)
                    continue;

                routeCount += CountRoutesRecursivePart(canReachFromIndex, dp, locations, item.index, finish, fuel - item.cost);
                routeCount %= 1000000007;
            }

            dp.Add((start, fuel), routeCount);

            if (start == finish)
                dp[(start, fuel)]++;

            return dp[(start, fuel)];
        }
    }
}
