using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_433
    {
        public Medium_433()
        {

        }

        //Creating a graph
        public int MinMutation(string startGene, string endGene, string[] bank)
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            foreach (var item in bank)
                graph.TryAdd(item, new List<string>());

            graph.TryAdd(startGene, new List<string>());

            foreach (var item in bank)
                foreach (var key in graph.Keys)
                    if (OnlyRequiresOnesStep(key, item))
                        graph[key].Add(item);

            Queue<(string s, int distance)> q = new Queue<(string s, int distance)>();
            q.Enqueue((startGene,0));

            int steps = 0;

            Dictionary<string, int> distance = new Dictionary<string, int>();
            foreach (var item in graph.Keys)
                distance.Add(item, int.MaxValue);

            while (q.Count != 0)
            {
                var curr = q.Dequeue();

                if (curr.s == endGene)
                    return curr.distance;

                if (!graph.ContainsKey(curr.s) || distance[curr.s] <= curr.distance)
                    continue;

                distance[curr.s] = curr.distance;

                ++steps;
                foreach (var item in graph[curr.s])
                    q.Enqueue((item,curr.distance + 1));
            }

            return -1;
        }
        public bool OnlyRequiresOnesStep(string one, string two)
        {
            int index = 0;
            while (index < 8 && one[index] == two[index])
                ++index;

            if (index == 8)
                return false; //No by loop

            ++index;

            while (index < 8 && one[index] == two[index])
                ++index;

            return index == 8;
        }
    }
}
