using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Mediu_1877
    {
        public Mediu_1877()
        {

        }
        public int MinPairSum(int[] nums)
        {
            Array.Sort(nums);

            int solution = 0;
            for (int i = 0; i < nums.Length/2; i++)
                solution = Math.Max(solution, nums[i] + nums[nums.Length - 1 - i]);

            return solution;
        }
    }
}
