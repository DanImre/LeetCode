using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1658
    {
        public Medium_1658()
        {

        }
        public int MinOperations(int[] nums, int x)
        {
            int y = nums.Sum() - x;

            int tempSum = 0;
            int maxSubArray = -1;

            int i = 0;
            int j = 0;
            while (j < nums.Length)
            {
                tempSum += nums[j];
                ++j;
                while (i < nums.Length && tempSum > y)
                {
                    tempSum -= nums[i];
                    ++i;
                }

                if (tempSum == y)
                    maxSubArray = Math.Max(maxSubArray, j - i);
            }

            if (maxSubArray == -1)
                return -1;

            return nums.Length - maxSubArray;
        }
    }
}
