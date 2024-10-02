using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_502
    {
        public Hard_502()
        {

        }
        public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
        {
            PriorityQueue<int, int> prq = new PriorityQueue<int, int>();

            (int capital, int profit)[] list = new (int profits, int capital)[profits.Length];
            for (int i = 0; i < profits.Length; i++)
                list[i] = (capital[i], profits[i]);
            Array.Sort(list, (a, b) => a.capital.CompareTo(b.capital));

            int index = 0;
            while (k > 0)
            {
                while (index < list.Length && list[index].capital <= w)
                {
                    prq.Enqueue(list[index].profit, -list[index].profit); //cuz its a minheap
                    ++index;
                }
                if (prq.Count == 0)
                    break;

                w += prq.Dequeue();
                --k;
            }

            return w;
        }
    }
}
