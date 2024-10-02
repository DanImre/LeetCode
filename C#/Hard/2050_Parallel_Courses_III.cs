using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_2050
    {
        public int MinimumTime(int n, int[][] relations, int[] time)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
                graph.Add(i, new List<int>());

            int[] indegree = new int[n];
            foreach (var item in relations)
            {
                graph[item[0] - 1].Add(item[1] - 1);
                ++indegree[item[1] - 1];
            }

            Queue<int> q = new Queue<int>();

            int[] maxTime = new int[n];

            for (int i = 0; i < n; i++)
                if (indegree[i] == 0)
                {
                    q.Enqueue(i);
                    maxTime[i] = time[i];
                }

            while (q.Count != 0)
            {
                int curr = q.Dequeue();
                foreach (var item in graph[curr])
                {
                    maxTime[item] = Math.Max(maxTime[item], maxTime[curr] + time[item]);
                    indegree[item]--;
                    if (indegree[item] == 0)
                        q.Enqueue(item);
                }
            }

            return maxTime.Max();
        }
    }
}
