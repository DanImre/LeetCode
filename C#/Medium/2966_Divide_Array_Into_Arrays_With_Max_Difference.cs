using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2966
    {
        public int[][] DivideArray(int[] nums, int k)
        {
            Array.Sort(nums);
            int[][] solution = new int[nums.Length / 3][];
            int index = 0;
            for (int i = 0; i < nums.Length; i += 3)
                if (nums[i + 2] - nums[i] > k)
                    return new int[0][];
                else
                    solution[index++] = new int[] { nums[i], nums[i + 1], nums[i + 2] };

            return solution;
        }
    }
}
