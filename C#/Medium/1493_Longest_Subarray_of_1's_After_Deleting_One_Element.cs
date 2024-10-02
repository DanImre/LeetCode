using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1493
    {
        public Medium_1493()
        {

        }
        public int LongestSubarray(int[] nums)
        {
            int max = 0;
            int i = 0;
            int j = 0;

            int lastZero = -1;
            while (j < nums.Length)
            {
                if (nums[j] == 0)
                {
                    max = Math.Max(max, j - i - 1);

                    i = lastZero + 1;
                    lastZero = j;
                }
                ++j;
            }

            max = Math.Max(max, j - i - 1);

            return max;
        }
    }
}
