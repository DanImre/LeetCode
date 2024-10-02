using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_310
    {
        public Medium_310() { }

        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            if (n == 1)
                return new int[] { 0 };

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            foreach (var item in edges)
            {
                if (!graph.ContainsKey(item[0]))
                    graph.Add(item[0], new List<int>());
                if (!graph.ContainsKey(item[1]))
                    graph.Add(item[1], new List<int>());

                graph[item[0]].Add(item[1]);
                graph[item[1]].Add(item[0]);
            }

            var indegree = new int[n];
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                indegree[i] = graph[i].Count;
                if (indegree[i] == 1)
                    queue.Enqueue(i);
            }

            while (n > 2)
            {
                int size = queue.Count;
                n -= size;
                for (int i = 0; i < size; i++)
                {
                    int node = queue.Dequeue();
                    foreach (var neighbor in graph[node])
                    {
                        indegree[neighbor]--;
                        if (indegree[neighbor] == 1)
                            queue.Enqueue(neighbor);
                    }
                }
            }

            List<int> result = new List<int>();
            while (queue.Count > 0)
                result.Add(queue.Dequeue());

            return result;
        }
    }
}
