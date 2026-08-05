using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class _3310_Remove_Methods_From_Project
    {
        public IList<int> RemainingMethods(int n, int k, int[][] invocations)
        {
            Dictionary<int, List<int>> graph = invocations
                .GroupBy(x => x[0])
                .ToDictionary(x => x.Key, x => x.Select(y => y[1])
                .ToList());

            HashSet<int> suspiciousMethods = [];

            Queue<int> q = new();
            q.Enqueue(k);

            while (q.Count != 0)
            {
                var curr = q.Dequeue();

                if (!suspiciousMethods.Add(curr))
                    continue;

                List<int> neighbours = graph.TryGetValue(curr, out var list) ? list : [];
                foreach (var item in neighbours)
                    q.Enqueue(item);
            }

            foreach (var connection in invocations)
            {
                // A not suspicious -> suspicious 
                if (!suspiciousMethods.Contains(connection[0])
                    && suspiciousMethods.Contains(connection[1]))
                {
                    suspiciousMethods = [];
                    break;
                }
            }

            return Enumerable.Range(0, n)
                .Except(suspiciousMethods)
                .ToList();
        }
    }
}
