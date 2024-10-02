using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_162
    {
        public Medium_162()
        {

        }
        public int FindPeakElement(int[] nums)
        {
            if (nums.Length == 1 || nums[0] > nums[1])
                return 0;

            int start = 1;
            int end = nums.Length;

            while (start < end)
            {
                int mid = (start + end) / 2;

                if (nums[mid - 1] < nums[mid])
                {
                    if (mid == nums.Length - 1 || nums[mid] > nums[mid + 1])
                        return mid;

                    start = mid + 1;
                }
                else
                    end = mid - 1;
            }

            return start;
        }
    }
}
