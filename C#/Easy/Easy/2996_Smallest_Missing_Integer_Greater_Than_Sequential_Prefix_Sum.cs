using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace Easy
{
    public class _2996_Smallest_Missing_Integer_Greater_Than_Sequential_Prefix_Sum
    {
        public int MissingInteger(int[] nums)
        {
            int x = nums[0];
            int i = 1;
            for (; i < nums.Length; i++)
            {
                if (nums[i] - nums[i - 1] != 1)
                    break;

                x += nums[i];
            }

            --i;
            HashSet<int> hs = [.. nums[i..]];
            while (hs.Contains(x))
                ++x;

            return x;
        }


        public int MissingIntegerWithBitshift(int[] nums)
        {
            int x = nums[0];
            int i = 1;
            for (; i < nums.Length; i++)
            {
                if (nums[i] - nums[i - 1] != 1)
                    break;

                x += nums[i];
            }
            if (i == 1)
                x++;

            int max = x + nums.Length - i - 1;
            long mask = 0;
            for (; i < nums.Length; i++)
            {
                if (nums[i] < x || nums[i] > max)
                    continue;

                mask |= 1L << (nums[i] - x);
            }

            int trailingZeroCount(long num)
            {
                int solution = 0;
                while (num % 2 == 0)
                {
                    num >>= 1;
                    ++solution;
                }

                return solution;
            }

            return x + trailingZeroCount(~mask);
            //return x + (int)long.TrailingZeroCount(~mask);
        }
    }
}
