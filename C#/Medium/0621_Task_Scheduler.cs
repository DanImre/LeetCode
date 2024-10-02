using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_621
    {
        public Medium_621()
        {

        }
        public int LeastInterval(char[] tasks, int n)
        {
            if (n == 0)
                return tasks.Length;

            int[] counts = new int[26];
            foreach (var item in tasks)
                counts[item - 'A']++;

            PriorityQueue<int, int> prq = new PriorityQueue<int, int>();
            for (int i = 0; i < counts.Length; i++)
                if (counts[i] > 0)
                    prq.Enqueue(counts[i], -counts[i]);

            int time = 0;

            while (prq.Count > 0)
            {
                List<int> store = new List<int>();
                int innerTime = 0;
                for (int i = 0; i < n + 1 && prq.Count > 0; i++)
                {
                    var curr = prq.Dequeue();
                    innerTime++;
                    if(curr > 1)
                        store.Add(curr - 1);
                }

                foreach (var item in store)
                    prq.Enqueue(item, -item);

                time += prq.Count > 0 ? n + 1 : innerTime;
            }

            return time;
        }
    }
}
