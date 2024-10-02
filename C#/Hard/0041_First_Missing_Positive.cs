using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_41
    {
        public Hard_41()
        {

        }

        public int FirstMissingPositive(int[] nums)
        {
            int index1 = 0;

            for (int i = 0; i < nums.Length; i++)
                if (nums[i] <= 0)
                {
                    int temp = nums[index1];
                    nums[index1] = nums[i];
                    nums[i] = temp;
                    ++index1;
                }

            for (int i = index1; i < nums.Length; i++)
            {
                int asIndex = Math.Abs(nums[i]);
                if (asIndex > 0 && asIndex <= nums.Length - index1)
                    nums[index1 + asIndex - 1] = -Math.Abs(nums[index1 + asIndex - 1]);
            }

            for (int i = index1; i < nums.Length; i++)
                if (nums[i] > 0)
                    return i - index1 + 1;

            return nums.Length - index1 + 1;
        }
    }
}
