using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_332
    {
        public Hard_332()
        {

        }
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            foreach (var item in tickets)
            {
                if (!graph.ContainsKey(item[0]))
                    graph.Add(item[0], new List<string>());

                graph[item[0]].Add(item[1]);
            }

            foreach (var item in graph.Keys)
                graph[item].Sort((a,b) => a.CompareTo(b));

            List<string> solution = new List<string>();
            helper(graph, solution, "JFK");
            solution.Reverse();

            return solution;
        }
        public void helper(Dictionary<string, List<string>> graph, List<string> solution, string curr)
        {
            if (graph.ContainsKey(curr))
                while (graph[curr].Count > 0)
                {
                    var next = graph[curr][0];
                    graph[curr].RemoveAt(0);
                    helper(graph, solution, next);
                }

            solution.Add(curr);
        }
    }
}
