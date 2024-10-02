using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1514
    {
        public Medium_1514()
        {
            int[][] edges = new int[][] {
                new int[] { 0, 1 },
                new int[] { 1, 2 },
                new int[] { 0, 2 }
            };

            //double[] succProb = new double[] { 0.5, 0.5, 0.2 }; //0.25
            double[] succProb = new double[] { 0.5, 0.5, 0.3 }; //0.3

            Console.WriteLine(MaxProbability(3, edges, succProb, 0 , 2));
        }

        public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
        {
            Dictionary<int, List<(int node, double prob)>> connections = new Dictionary<int, List<(int node, double prob)>>();
            for (int i = 0; i < edges.Length; i++)
            {
                if (!connections.ContainsKey(edges[i][0]))
                    connections.Add(edges[i][0], new List<(int node, double prob)>());
                if (!connections.ContainsKey(edges[i][1]))
                    connections.Add(edges[i][1], new List<(int node, double prob)>());

                connections[edges[i][0]].Add((edges[i][1], succProb[i]));
                connections[edges[i][1]].Add((edges[i][0], succProb[i]));
            }

            if (!connections.ContainsKey(start) || !connections.ContainsKey(end))
                return 0;

            double[] bestProbAtEdge = new double[n];
            for (int i = 0; i < n; i++)
                bestProbAtEdge[i] = 0;

            Queue<(int node, double prob)> q = new Queue<(int node, double prob)>();
            q.Enqueue((start, 1));
            while (q.Count != 0)
            {
                var act = q.Dequeue();

                if (bestProbAtEdge[act.node] < act.prob)
                    bestProbAtEdge[act.node] = act.prob;
                else
                    continue;

                if (act.node == end)
                    continue;

                foreach (var item in connections[act.node])
                    q.Enqueue((item.node, item.prob * act.prob));
            }

            return bestProbAtEdge[end];
        }
    }
}
