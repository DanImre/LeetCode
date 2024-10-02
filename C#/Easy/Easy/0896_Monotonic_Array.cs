using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_896
    {
        public Easy_896()
        {

        }
        public bool IsMonotonic(int[] nums)
        {
            if (nums.Length <= 1)
                return true;

            int i = 1;
            while (i < nums.Length && nums[i - 1] == nums[i])
                ++i;

            if (i == nums.Length)
                return true;

            if (nums[i] - nums[i - 1] > 0)
                while (i < nums.Length)
                {
                    if (nums[i - 1] > nums[i])
                        return false;
                    ++i;
                }
            else
                while (i < nums.Length)
                {
                    if (nums[i - 1] < nums[i])
                        return false;
                    ++i;
                }

            return true;
        }
    }
}
