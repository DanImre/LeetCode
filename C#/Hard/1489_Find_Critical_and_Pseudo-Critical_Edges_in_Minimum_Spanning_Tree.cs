using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_1489
    {
        public Hard_1489()
        {
            int[][] edges = "0,1,1],[1,2,1],[2,3,2],[0,3,2],[0,4,3],[3,4,3],[1,4,6".Split("],[").Select(kk => kk.Split(',').Select(zz => int.Parse(zz)).ToArray()).ToArray();
            FindCriticalAndPseudoCriticalEdges(5, edges);
        }
        public class UnionFind
        {
            private int[] parent;
            private int[] size;
            public int MaxSize { private set; get; }

            public UnionFind(int n)
            {
                this.parent = new int[n];
                this.size = new int[n];
                this.MaxSize = 1;
                for (int i = 0; i < n; i++)
                {
                    parent[i] = i;
                    size[i] = 1;
                }
            }

            public int Find(int x)
            {
                if(x != parent[x])
                    parent[x] = Find(parent[x]);

                return parent[x];
            }

            public bool Union(int x, int y)
            {
                int RootX = Find(x);
                int RootY = Find(y);

                if (RootX == RootY)
                    return false;

                if (size[RootX] < size[RootY])
                {
                    int temp = RootX;
                    RootX = RootY; 
                    RootY = temp;
                }

                parent[RootY] = RootX;
                size[RootX] += size[RootY];
                MaxSize = Math.Max(MaxSize, size[RootX]);

                return true;
            }
        }
        public IList<IList<int>> FindCriticalAndPseudoCriticalEdges(int n, int[][] edges)
        {
            int[][] sortedEdges = new int[edges.Length][];

            for (int i = 0; i < edges.Length; i++)
            {
                sortedEdges[i] = new int[4];
                for (int j = 0; j < 3; j++)
                    sortedEdges[i][j] = edges[i][j];

                sortedEdges[i][3] = i;
            }
            Array.Sort(sortedEdges, (a,b) => a[2].CompareTo(b[2]));

            //Find best STD
            UnionFind uf = new UnionFind(n);
            int bestWeight = 0;

            foreach (var item in sortedEdges)
                if (uf.Union(item[0], item[1]))
                    bestWeight += item[2];

            List<IList<int>> solution = new List<IList<int>>() { new List<int>(), new List<int>() };

            //Getting critical and pseudo-critical edges
            for (int i = 0; i < sortedEdges.Length; i++)
            {
                //Ignoring current edge
                UnionFind ufIgnored = new UnionFind(n);
                int ignoredWeight = 0;
                for (int j = 0; j < sortedEdges.Length; j++)
                    if (i != j && ufIgnored.Union(sortedEdges[j][0], sortedEdges[j][1]))
                        ignoredWeight += sortedEdges[j][2];

                //Edges is critical if graph is disconnected or the weight is greater
                if (ufIgnored.MaxSize < n || ignoredWeight > bestWeight)
                {
                    solution[0].Add(sortedEdges[i][3]);
                    continue;
                }
                
                //Else force the edge
                UnionFind ufForced = new UnionFind(n);
                ufForced.Union(sortedEdges[i][0], sortedEdges[i][1]);
                int forcedWeight = sortedEdges[i][2];
                for (int j = 0; j < sortedEdges.Length; j++)
                    if (i != j && ufForced.Union(sortedEdges[j][0], sortedEdges[j][1]))
                        forcedWeight += sortedEdges[j][2];

                //If the weight is the same, its a pseudo-ciritcal edge
                if (forcedWeight == bestWeight)
                    solution[1].Add(sortedEdges[i][3]);
            }

            return solution;
        }
    }
}
