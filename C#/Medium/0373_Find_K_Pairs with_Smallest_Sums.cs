using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_373
    {
        public Medium_373()
        {
            int[] nums1 = new int[] { 1, 1, 2 };
            int[] nums2 = new int[] { 1, 2, 3 };
            int k = 6;
            /*
            nums1 = new int[] { 1, 2 };
            nums2 = new int[] { 3 };
            k = 3;
            
            nums1 = new int[] { 1, 7, 11 };
            nums2 = new int[] { 2, 4, 6 };
            k = 3;*/

            var a = KSmallestPairs(nums1, nums2, k);
            foreach (var item in a)
                Console.Write("(" +item[0] + ", " + item[1] + ") ; ");
            Console.WriteLine();
        }

        public IList<IList<int>> KSmallestPairs2(int[] nums1, int[] nums2, int k)
        {
            IList<IList<int>> solution = new List<IList<int>>();

            int fromNumberOne = 1;
            int fromNumberTwo = 1;
            while (k > fromNumberOne * fromNumberTwo && fromNumberOne < nums1.Length && fromNumberTwo < nums2.Length)
            {
                if (nums1[fromNumberOne] <= nums2[fromNumberTwo])
                    ++fromNumberOne;
                else
                    ++fromNumberTwo;
            }

            while (k > fromNumberOne * fromNumberTwo && fromNumberOne < nums1.Length)
                ++fromNumberOne;
            while (k > fromNumberOne * fromNumberTwo && fromNumberTwo < nums2.Length)
                ++fromNumberTwo;

            PriorityQueue<List<int>, int> prq = new PriorityQueue<List<int>, int>();
            for (int i = fromNumberOne-1; i >= 0; i--)
                for (int j = fromNumberTwo-1; j >= 0; j--)
                    prq.Enqueue(new List<int>() { nums1[i], nums2[j] }, nums1[i] + nums2[j]);

            //Close one

            for (int i = 0; i < k && prq.Count > 0; i++)
                solution.Add(prq.Dequeue());

            return solution;
        }

        //Solution
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            IList<IList<int>> solution = new List<IList<int>>();

            PriorityQueue<(int,int),int> prq = new PriorityQueue<(int, int), int>();
            prq.Enqueue((0, 0), nums1[0] + nums2[0]);

            var visited = new HashSet<(int, int)>();

            while (prq.Count > 0 && solution.Count < k)
            {
                var cur = prq.Dequeue();

                int x = cur.Item1;
                int y = cur.Item2;

                solution.Add(new List<int> { nums1[x], nums2[y] });
                visited.Add((x, y));

                if (x + 1 < nums1.Length && y < nums2.Length && !visited.Contains((x + 1, y)))
                {
                    prq.Enqueue((x + 1, y), nums1[x + 1] + nums2[y]);
                    visited.Add((x + 1, y));
                }

                if (x < nums1.Length && y + 1 < nums2.Length && !visited.Contains((x, y + 1)))
                {
                    prq.Enqueue((x, y + 1), nums1[x] + nums2[y + 1]);
                    visited.Add((x, y + 1));
                }
            }

            return solution;
        }
    }
}
