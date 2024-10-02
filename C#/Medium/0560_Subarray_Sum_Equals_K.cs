using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_560
    {
        public Medium_560()
        {

        }
        public int SubarraySum(int[] nums, int k)
        {
            int[] sums = new int[nums.Length + 1];
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                sums[i + 1] = sum;
            }

            int solution = 0;
            for (int i = 0; i < nums.Length; i++)
                for (int j = i + 1; j <= nums.Length; j++)
                    if ((sums[j] - sums[i]) == k)
                        solution++;

            return solution;
        }
    }
}
