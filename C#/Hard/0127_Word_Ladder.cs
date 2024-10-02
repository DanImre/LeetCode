using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_127
    {
        public Hard_127()
        {

        }
        //Creating a graph
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            foreach (var item in wordList)
                graph.TryAdd(item, new List<string>());

            graph.TryAdd(beginWord, new List<string>());

            foreach (var item in wordList)
                foreach (var key in graph.Keys)
                    if (OnlyRequiresOnesStep(key, item))
                        graph[key].Add(item);

            Queue<(string s, int distance)> q = new Queue<(string s, int distance)>();
            q.Enqueue((beginWord, 1));

            Dictionary<string, int> distance = new Dictionary<string, int>();
            foreach (var item in graph.Keys)
                distance.Add(item, int.MaxValue);

            while (q.Count != 0)
            {
                var curr = q.Dequeue();

                if (curr.s == endWord)
                    return curr.distance;

                if (!graph.ContainsKey(curr.s) || distance[curr.s] <= curr.distance)
                    continue;

                distance[curr.s] = curr.distance;

                foreach (var item in graph[curr.s])
                    q.Enqueue((item, curr.distance + 1));
            }

            return 0;
        }
        public bool OnlyRequiresOnesStep(string one, string two)
        {
            if(one.Length != two.Length)
                return false;

            int index = 0;
            while (index < one.Length && one[index] == two[index])
                ++index;

            if (index == 8)
                return false; //No loop

            ++index;

            while (index < one.Length && one[index] == two[index])
                ++index;

            return index == one.Length;
        }

        //Creating a graph - From Medium 433
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
            q.Enqueue((startGene, 0));

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
                    q.Enqueue((item, curr.distance + 1));
            }

            return -1;
        }
    }
}
