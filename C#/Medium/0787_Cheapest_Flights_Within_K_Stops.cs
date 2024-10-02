using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_787
    {
        public Medium_787() { }
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            int[] dist = new int[n]; //max 100
            Array.Fill(dist, int.MaxValue);

            Dictionary<int, List<(int to, int cost)>> dic = new Dictionary<int, List<(int to, int cost)>>();
            foreach (var item in flights)
                if (dic.ContainsKey(item[0]))
                    dic[item[0]].Add((item[1], item[2]));
                else
                    dic.Add(item[0], new List<(int to, int cost)>() { (item[1], item[2]) });

            Queue<(int pos, int cost, int stops)> q = new Queue<(int pos, int cost, int stops)>();
            q.Enqueue((src, 0, 0));

            while (q.Count > 0)
            {
                var curr = q.Dequeue();

                if (dist[curr.pos] <= curr.cost)
                    continue;
                dist[curr.pos] = curr.cost;

                if (curr.stops == k + 1 || !dic.ContainsKey(curr.pos))
                    continue;

                foreach (var item in dic[curr.pos])
                    q.Enqueue((item.to, curr.cost + item.cost, curr.stops + 1));
            }

            if (dist[dst] == int.MaxValue)
                return -1;
            return dist[dst];
        }
    }
}
