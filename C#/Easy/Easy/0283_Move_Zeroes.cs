using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_283
    {
        public Easy_283()
        {

        }
        public void MoveZeroes(int[] nums)
        {
            int zerospot = 0;
            while (zerospot < nums.Length && nums[zerospot] != 0)
                ++zerospot;

            for (int i = zerospot + 1; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    continue;

                nums[zerospot] = nums[i];
                nums[i] = 0;
                ++zerospot;
            }
        }
    }
}
