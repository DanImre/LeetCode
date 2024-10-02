using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_684_Redundant_Connection
    {
        
        public class UnionFind
        {
            private int[] parent;
            public UnionFind(int n)
            {
                parent = new int[n];
                for (int i = 0; i < n; i++)
                    parent[i] = i;
            }

            public int Find(int i)
            {
                if (parent[i] == i)
                    return i;

                parent[i] = Find(parent[i]);
                return parent[i];
            }

            public void Union(int i, int j)
            {
                int parentOfI = Find(i);
                int parentOfJ = Find(j);

                parent[parentOfI] = parentOfJ;
            }
        }
        public int[] FindRedundantConnection(int[][] edges)
        {
            int n = edges.Length + 1;
            
            UnionFind uf = new UnionFind(n);

            foreach (var item in edges)
            {
                if (uf.Find(item[0]) == uf.Find(item[1]))
                    return item;
                uf.Union(item[0], item[1]);
            }

            return new int[0];
        }
    }
}
