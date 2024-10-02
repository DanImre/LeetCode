using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1466
    {
        public Medium_1466()
        {
            Console.WriteLine(MinReorder(6, new int[][] { new int[] { 0, 1 }, new int[] { 1, 3 }, new int[] { 2, 3 }, new int[] { 4, 0 }, new int[] { 4, 5 } }));
        }
        public int MinReorder(int n, int[][] connections)
        {
            Dictionary<int, List<(int destination, bool towards)>> graph = new Dictionary<int, List<(int destination, bool towards)>>();
            foreach (var item in connections)
            {
                if (!graph.ContainsKey(item[0]))
                    graph.Add(item[0], new List<(int destination, bool towards)>());
                if (!graph.ContainsKey(item[1]))
                    graph.Add(item[1], new List<(int destination, bool towards)>());
                
                graph[item[0]].Add((item[1], true));
                graph[item[1]].Add((item[0], false));
            }

            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            HashSet<int> visited = new HashSet<int>();

            int solution = 0;
            
            while (stack.Count != 0)
            {
                int curr = stack.Pop();

                visited.Add(curr);

                foreach (var item in graph[curr])
                {
                    if (visited.Contains(item.destination))
                        continue;
                    if (item.towards)
                        ++solution;

                    stack.Push(item.destination);
                }
            }

            return solution;
        }
    }
}
