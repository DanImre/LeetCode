using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_847
    {
        public Hard_847()
        {
            int[][] graph = _Program.DoubleIntArrayFromString("[[1],[0,2,4],[1,3,4],[2],[1,2]]");
            Console.WriteLine(ShortestPathLength(graph)); //4
            
            graph = _Program.DoubleIntArrayFromString("[[7],[3],[3,9],[1,2,4,5,7,11],[3],[3],[9],[3,10,8,0],[7],[11,6,2],[7],[3,9]]");
            Console.WriteLine(ShortestPathLength(graph)); //17
            
        }
        //BFS solution + Bitmasking
        public int ShortestPathLength(int[][] graph)
        {
            int allNodesAreVisited = (1 << graph.Length) - 1;

            HashSet<int> visitedStates = new HashSet<int>();
            Queue<(int collectedNodes, int currNode, int length)> q = new Queue<(int collectedNodes, int currNode, int length)>();

            for (int i = 0; i < graph.Length; i++)
                q.Enqueue((1 << i, i, 0));

            while (q.Count != 0)
            {
                var curr = q.Dequeue();

                if (curr.collectedNodes == allNodesAreVisited)
                    return curr.length;

                //have to store the collected nodes + current position:
                //there are at most 12 nodes, 12 = "1100"
                //So we make space for it, by '<< 5' so 4 more bits could be placed
                int visitedCheckNumber = (curr.collectedNodes << 5) + curr.currNode;

                if (!visitedStates.Add(visitedCheckNumber))
                    continue;

                foreach (var item in graph[curr.currNode])
                    q.Enqueue((curr.collectedNodes | (1 << item), item, curr.length + 1));
            }

            return -1;
        }

        //This is correct but TLE
        private int minLength;
        public int ShortestPathLengthTLE(int[][] graph)
        {
            this.minLength = graph.Length * 2 + 1;
            for (int i = 0; i < graph.Length; i++)
                RecursiveSolution(i, 0, graph, new HashSet<int>() { i });

            return minLength;
        }
        private void RecursiveSolution(int curr, int currLength, int[][] graph, HashSet<int> usedNodes)
        {
            if (currLength >= minLength)
                return;
            if (usedNodes.Count == graph.Length)
            {
                minLength = currLength;
                return;
            }

            foreach (var item in graph[curr])
            {
                bool haveToRemove = usedNodes.Add(item);
                RecursiveSolution(item, currLength + 1, graph, usedNodes);
                if (haveToRemove)
                    usedNodes.Remove(item);
            }
        }
    }
}
