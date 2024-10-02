using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2958
    {
        public Medium_2958()
        {

        }
        public int MaxSubarrayLength(int[] nums, int k)
        {
            Dictionary<int, int> frequency = new Dictionary<int, int>();

            int i = 0;
            int j = 0;

            int max = 0;

            while (j < nums.Length)
            {
                if (frequency.GetValueOrDefault(nums[j], 0) < k)
                {
                    if (frequency.ContainsKey(nums[j]))
                        frequency[nums[j]]++;
                    else
                        frequency[nums[j]] = 1;

                    ++j;
                }
                else
                    frequency[nums[i++]]--;

                max = Math.Max(max, j - i);
            }

            return max;
        }
    }
}
