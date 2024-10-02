using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_713
    {
        public Medium_713()
        {

        }

        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k <= 1)
                return 0;

            int[] opt = new int[nums.Length];

            int solution = 0;

            int i = 0;
            int j = 0;
            int prod = 1;
            while (j < nums.Length)
            {
                prod *= nums[j++];

                while (prod >= k)
                    prod /= nums[i++];

                solution += j - i;
            }

            return solution;
        }
    }
}
