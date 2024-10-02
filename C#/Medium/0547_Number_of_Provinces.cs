using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_547
    {
        public Medium_547()
        {

        }
        public int FindCircleNum(int[][] isConnected)
        {
            HashSet<int> tovisit = new HashSet<int>();
            for (int i = 0; i < isConnected.Length; i++)
                tovisit.Add(i);

            int solution = 0;
            while (tovisit.Count != 0)
            {
                ++solution;
                Queue<int> q = new Queue<int>();
                q.Enqueue(tovisit.First());
                while (q.Count != 0)
                {
                    var curr = q.Dequeue();
                    if (!tovisit.Remove(curr))
                        continue;

                    for (int i = 0; i < isConnected.Length; i++)
                        if (isConnected[curr][i] == 1)
                            q.Enqueue(i);
                }
            }

            return solution;
        }
    }
}
