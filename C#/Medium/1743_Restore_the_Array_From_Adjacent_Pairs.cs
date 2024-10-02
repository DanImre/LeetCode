using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1743
    {
        public Medium_1743()
        {

        }

        public int[] RestoreArray(int[][] adjacentPairs)
        {
            Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();
            foreach (var item in adjacentPairs)
            {
                if (!edges.ContainsKey(item[0]))
                    edges.Add(item[0], new List<int>());
                edges[item[0]].Add(item[1]);

                if (!edges.ContainsKey(item[1]))
                    edges.Add(item[1], new List<int>());
                edges[item[1]].Add(item[0]);
            }

            int index = 0;
            int curr = edges.Where(kk => kk.Value.Count == 1).First().Key;
            int[] solution = new int[adjacentPairs.Length + 1];
            solution[index++] = curr;


            while (index <= adjacentPairs.Length)
            {
                int next = edges[curr][0];
                edges[next].Remove(curr);

                curr = next;
                solution[index++] = curr;
            }

            return solution;
        }
    }
}
