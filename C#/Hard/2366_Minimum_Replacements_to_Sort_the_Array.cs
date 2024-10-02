using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_2366
    {
        public Hard_2366()
        {
            
        }
        public long MinimumReplacement(int[] nums)
        {
            long operations = 0;

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] <= nums[i + 1])
                    continue;

                long operationsInThisIteration = (long)(nums[i] + nums[i + 1] - 1) / (long)(nums[i + 1]);

                operations += operationsInThisIteration - 1;

                nums[i] = nums[i] / (int)operationsInThisIteration;
            }

            return operations;
        }
    }
}
