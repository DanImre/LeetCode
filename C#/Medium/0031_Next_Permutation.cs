using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_31
    {
        public Medium_31()
        {

        }
        private void Reverse(int[] nums, int start)
        {
            int i = start;
            int j = nums.Length - 1;
            while (i < j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
                ++i;
                --j;
            }
        }
        public void NextPermutation(int[] nums)
        {
            int index1 = -1;
            int index2 = -1;

            for (int i = nums.Length - 2; i >= 0; i--)
                if (nums[i] < nums[i + 1])
                {
                    index1 = i;
                    break;
                }

            if (index1 == -1)
            {
                Reverse(nums,0);
                return;
            }

            for (int i = nums.Length - 1; i >= 0; i--)
                if (nums[i] > nums[index1])
                {
                    index2 = i;
                    break;
                }

            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;

            Reverse(nums, index1 + 1);
        }
    }
}
