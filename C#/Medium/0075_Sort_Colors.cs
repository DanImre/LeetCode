using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_75
    {
        public Medium_75()
        {

        }
        public void SortColors(int[] nums)
        {
            int index = 0;
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] == 0)
                {
                    int temp = nums[index];
                    nums[index] = 0;
                    nums[i] = temp;
                    ++index;
                }

            for (int i = index; i < nums.Length; i++)
                if (nums[i] == 1)
                {
                    int temp = nums[index];
                    nums[index] = 0;
                    nums[i] = temp;
                    ++index;
                }
        }
    }
}
