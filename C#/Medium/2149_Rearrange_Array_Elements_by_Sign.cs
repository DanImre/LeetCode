using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2149
    {
        public Medium_2149()
        {

        }
        public int[] RearrangeArray(int[] nums)
        {
            int[] solution = new int[nums.Length];

            int lastPositiveIndex = -1;
            int lastNegativeIndex = -1;
            for (int i = 0; i < nums.Length - 1; i+=2)
            {
                ++lastPositiveIndex;
                ++lastNegativeIndex;

                while (nums[lastPositiveIndex] <= 0)
                    ++lastPositiveIndex;
                while (nums[lastNegativeIndex] > 0)
                    ++lastNegativeIndex;

                solution[i] = nums[lastPositiveIndex];
                solution[i + 1] = nums[lastNegativeIndex];
            }

            return solution;
        }
    }
}
