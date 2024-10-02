using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_81
    {
        public Medium_81()
        {

        }
        public bool Search2(int[] nums, int target)
        {
            return SearchFrom33(nums.Distinct().ToArray(), target) != -1;
        }
        public int SearchFrom33(int[] nums, int target)
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
        //correct solution
        public bool Search(int[] nums, int target)
        {
            if(nums.Length == 0)
                return false;

            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target)
                    return true;
                if (nums[start] == nums[mid])
                {
                    ++start;
                    continue;
                }

                bool pivotArray = nums[start] <= nums[mid];
                bool targetArray = nums[start] <= target;

                if (pivotArray ^ targetArray)  //XOR operacion
                {
                    if (pivotArray)
                        start = mid + 1;
                    else
                        end = mid - 1;

                    continue;
                }

                if (nums[mid] < target)
                    start = mid + 1;
                else
                    end = mid - 1;
            }

            return false;
        }
    }
}
