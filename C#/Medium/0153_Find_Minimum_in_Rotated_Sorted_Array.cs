using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_153
    {
        public Medium_153()
        {

        }
        public int FindMin(int[] nums)
        {
            int start = 0;
            int end = nums.Length - 1;

            while (start < end)
            {
                int mid = (end + start) / 2;

                if (nums[mid] < nums[end])
                    end = mid;
                else
                    start = mid + 1;
            }

            return nums[start];
        }
    }
}
