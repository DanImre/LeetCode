using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_34
    {
        public Medium_34()
        {

        }
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 0)
                return new int[] { -1, -1 };

            int start = 0;
            int end = nums.Length - 1;

            while (start < end)
            {
                int mid = start + (end - start) / 2;

                if (nums[mid] < target)
                    start = mid + 1;
                else
                    end = mid;
            }

            if (nums[start] != target)
                return new int[] { -1, -1 };

            //Start is the left most number and it doesnt need reseting
            int[] solution = new int[2];
            solution[0] = start;

            end = nums.Length - 1;

            while (start < end)
            {
                int mid = start + (end - start + 1) / 2;

                if (nums[mid] > target)
                    end = mid - 1;
                else
                    start = mid;
            }

            solution[1] = start;

            return solution;
        }
    }
}
