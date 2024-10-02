using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2962
    {
        public Medium_2962()
        {

        }
        public long CountSubarrays(int[] nums, int k)
        {
            long solution = 0;

            int maxElement = nums.Max();

            int i = 0;
            int j = 0;

            int count = 0;
            while (j < nums.Length)
            {
                if (nums[j] == maxElement)
                    ++count;
                while (k == count)
                    if (nums[i++] == maxElement)
                        --count;

                solution += i;
                ++j;
            }

            return solution;
        }
    }
}
