using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2971
    {
        public Medium_2971()
        {

        }
        public long LargestPerimeter(int[] nums)
        {
            Array.Sort(nums);

            long sum = 0;
            foreach (var item in nums)
                sum += item;

            for (int i = nums.Length - 1; i >= 2; i--)
            {
                long tempSolution = sum;
                sum -= nums[i];
                if (nums[i] >= sum)
                    continue;

                return tempSolution;
            }

            return -1;
        }
    }
}
