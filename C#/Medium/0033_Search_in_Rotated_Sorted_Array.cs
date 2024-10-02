using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_33
    {
        public Medium_33()
        {

        }
        //Binary Search for pivot, then Binary Search for item
        public int Search(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;
            while (start < end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] < nums[end])
                    end = mid;
                else
                    start = mid + 1;
            }

            //start is the pivot-index
            end = nums.Length - 1 + start;

            while (start < end)
            {
                int mid = (start + end) / 2;
                if (nums[mid % nums.Length] < target)
                    start = mid + 1;
                else
                    end = mid;
            }

            if (nums[start % nums.Length] == target)
                return start;

            return -1;
        }
    }
}
