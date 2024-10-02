using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1004
    {
        public Medium_1004()
        {
            Console.WriteLine(LongestOnes(
                new int[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 },2));

            Console.WriteLine(LongestOnes(
                new int[] { 0,0 }, 1));

            Console.WriteLine(LongestOnes(
                new int[] { 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1 }, 3));
        }
        public int LongestOnes(int[] nums, int k)
        {
            int left = 0;
            int count = 0;
            int result = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    count++;

                while (count > k)
                {
                    if (nums[left] == 0)
                        count--;
                    left++;
                }

                result = Math.Max(result, i - left + 1);
            }

            return result;
        }
        public int LongestOnesShitOne(int[] nums, int k)
        {
            int solution = 0;

            int i = 0;
            while (i < nums.Length && nums[i] == 0)
                ++i;

            while (i < nums.Length)
            {
                int istart = i;
                while (i < nums.Length && nums[i] != 0)
                    ++i;

                int firstzero = i;

                int zeroCount = 0;
                while (i < nums.Length && zeroCount < k)
                {
                    if (nums[i] == 0)
                        ++zeroCount;

                    ++i;
                }

                while (i < nums.Length && nums[i] == 1)
                    ++i;

                solution = Math.Max(solution, i - istart);

                i = firstzero;
                while (i < nums.Length && nums[i] == 0)
                    ++i;
            }

            //from behind
            i = nums.Length - 1;
            int count = 0;
            while (i >= 0 && count < k)
            {
                if (nums[i] == 0)
                    ++count;
                --i;
            }
            while (i >= 0 && nums[i] == 1)
                --i;

            solution = Math.Max(solution, nums.Length - 1 - i);

            return solution;
        }
    }
}
