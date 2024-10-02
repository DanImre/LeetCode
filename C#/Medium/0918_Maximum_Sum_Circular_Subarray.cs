using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_918
    {
        public Medium_918()
        {

        }
        public int MaxSubarraySumCircular(int[] nums)
        {
            int MaxSolution = nums[0];
            int MinSolution = nums[0];
            int totalSum = 0;

            int maxSum = 0;
            int minSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (maxSum < 0)
                    maxSum = nums[i];
                else
                    maxSum += nums[i];

                MaxSolution = Math.Max(MaxSolution, maxSum);

                //min part
                if (minSum > 0)
                    minSum = nums[i];
                else
                    minSum += nums[i];

                MinSolution = Math.Min(MinSolution, minSum);

                totalSum += nums[i];
            }

            if (totalSum == MinSolution)
                return MaxSolution;

            return Math.Max(MaxSolution, totalSum - MinSolution);
        }
    }
}
