using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Meidum_215
    {
        public Meidum_215()
        {

        }
        public int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int, int> pr = new PriorityQueue<int, int>();
            foreach (var item in nums)
                pr.Enqueue(item, item);

            for (int i = 0; i < nums.Length - k; i++)
                pr.Dequeue();

            return pr.Dequeue();
        }
    }
}
