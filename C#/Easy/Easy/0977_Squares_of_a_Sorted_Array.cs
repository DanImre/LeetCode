using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_977
    {
        public Easy_977()
        {

        }
        public int[] SortedSquares(int[] nums)
        {
            if (nums.Length == 1)
                return new int[1] { nums[0] * nums[0] };

            int index = 0;
            while (index < nums.Length - 1 && Math.Abs(nums[index]) > Math.Abs(nums[index + 1]))
                ++index;

            int[] solution = new int[nums.Length];
            solution[0] = nums[index] * nums[index];

            int left = index - 1;
            int right = index + 1;
            index = 1;
            while (index < nums.Length)
                if (left < 0)
                    solution[index++] = nums[right] * nums[right++];
                else if (right == nums.Length)
                    solution[index++] = nums[left] * nums[left--];
                else if (Math.Abs(nums[left]) <= Math.Abs(nums[right]))
                    solution[index++] = nums[left] * nums[left--];
                else
                    solution[index++] = nums[right] * nums[right++];

            return solution;
        }
    }
}
