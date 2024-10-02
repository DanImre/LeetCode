using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_1793
    {
        public Hard_1793()
        {

        }
        public int MaximumScore(int[] nums, int k)
        {
            int solution = Helper(nums, k);
            Array.Reverse(nums);
            return Math.Max(solution, Helper(nums, nums.Length - k - 1));
        }
        public int Helper(int[] nums, int k)
        {
            int[] mins = new int[k + 1];
            mins[k] = nums[k];
            for (int i = k - 1; i >= 0; i--)
                mins[i] = Math.Min(mins[i + 1], nums[i]);

            int currMin = nums[k];
            int solution = nums[k];
            for (int i = k + 1; i < nums.Length; i++)
            {
                currMin = Math.Min(currMin, nums[i]);
                int start = 0;
                int end = k;
                while (start < end)
                {
                    int mid = (start + end) / 2;

                    if (mins[mid] < currMin)
                        start = mid + 1;
                    else
                        end = mid;
                }

                int size = i - start + 1;
                solution = Math.Max(solution, currMin * size);

            }

            return solution;
        }
    }
}
