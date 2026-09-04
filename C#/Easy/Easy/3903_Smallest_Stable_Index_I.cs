using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public class _3903_Smallest_Stable_Index_I
    {
        public int FirstStableIndex(int[] nums, int k)
        {
            int[] minLookup = new int[nums.Length];
            int min = int.MaxValue;
            for (int i = nums.Length-1; i >= 0; i--)
            {
                min = Math.Min(min, nums[i]);
                minLookup[i] = min;
            }

            int max = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                max = Math.Max(max, nums[i]);

                if (max - minLookup[i] <= k)
                    return i;
            }

            return -1;
        }
    }
}
