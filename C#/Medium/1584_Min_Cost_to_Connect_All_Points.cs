using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1584
    {
        public Medium_1584()
        {
            int[][] points = "0,0],[2,2],[3,10],[5,2],[7,0".Split("],[").Select(kk => kk.Split(',').Select(zz => int.Parse(zz)).ToArray()).ToArray();
            Console.WriteLine(MinCostConnectPoints(points));
        }
        public int MinCostConnectPoints(int[][] points)
        {
            Dictionary<int, List<(int node, int cost)>> graph = new Dictionary<int, List<(int node, int cost)>>();
            
            for (int i = 0; i < points.Length; i++)
                for (int j = i + 1; j < points.Length; j++)
                {
                    int cost = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);

                    if (!graph.ContainsKey(i))
                        graph.Add(i, new List<(int node, int cost)>());
                    if (!graph.ContainsKey(j))
                        graph.Add(j, new List<(int node, int cost)>());
                    graph[i].Add((j, cost));
                    graph[j].Add((i, cost));
                }

            HashSet<int> visited = new HashSet<int>();
            visited.Add(0);
            PriorityQueue<(int node, int cost), int> minHeap = new PriorityQueue<(int node, int cost), int>();

            int curr = 0;
            int solution = 0;
            while (visited.Count != points.Length)
            {
                foreach (var item in graph[curr])
                    minHeap.Enqueue(item, item.cost);

                var temp = minHeap.Dequeue();

                while (visited.Contains(temp.node))
                    temp = minHeap.Dequeue();

                curr = temp.node;
                solution += temp.cost;
                visited.Add(curr);
            }

            return solution;
        }
    }
}
