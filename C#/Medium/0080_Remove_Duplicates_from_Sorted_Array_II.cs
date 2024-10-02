using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_80
    {
        public Medium_80()
        {

        }
        public int RemoveDuplicates(int[] nums)
        {
            int i = 2;

            if (nums.Length <= i)
                return nums.Length;

            for (int j = 2; j < nums.Length; j++)
            {
                if (nums[i - 2] == nums[j])
                    continue;

                nums[i] = nums[j];
                ++i;
            }

            return i;
        }
    }
}
