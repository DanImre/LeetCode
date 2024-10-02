using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_1425
    {
        public Hard_1425()
        {

        }
        public int ConstrainedSubsetSum(int[] nums, int k)
        {
            int solution = nums[0];
            PriorityQueue<(int value, int index), int> prq = new PriorityQueue<(int value, int index), int>();
            prq.Enqueue((nums[0], 0), -nums[0]);

            for (int i = 1; i < nums.Length; i++)
            {
                while (i - prq.Peek().index > k)
                    prq.Dequeue();

                int curr = Math.Max(0, prq.Peek().value) + nums[i];
                solution = Math.Max(solution, curr);
                prq.Enqueue((curr, i), -curr);
            }
            return solution;
        }
    }
}
