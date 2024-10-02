using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2542
    {
        public Medium_2542()
        {

        }
        public long MaxScore(int[] nums1, int[] nums2, int k)
        {
            (int first, int second)[] pairs = new (int first, int second)[nums1.Length];
            for (int i = 0; i < nums1.Length; i++)
                pairs[i] = (nums1[i], nums2[i]);

            Array.Sort(pairs, (a, b) => b.second.CompareTo(a.second));

            PriorityQueue<int, int> prq = new PriorityQueue<int, int>();

            long sum = 0;
            for (int i = 0; i < k; i++)
            {
                sum += pairs[i].first;
                prq.Enqueue(pairs[i].first, pairs[i].first);
            }

            long solution = sum * pairs[k - 1].second;

            for (int i = k; i < nums1.Length; i++)
            {
                sum += pairs[i].first - prq.Dequeue();
                prq.Enqueue(pairs[i].first, pairs[i].first);

                solution = Math.Max(solution, sum * pairs[i].second);
            }

            return solution;
        }
    }
}
