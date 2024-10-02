using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_992
    {
        public Hard_992()
        {

        }
        public int SubarraysWithKDistinct(int[] nums, int k)
        {
            return helper(k) - helper(k - 1);

            int helper(int k)
            {
                Dictionary<int, int> freq = new Dictionary<int, int>();
                int count = 0;

                int solution = 0;

                int i = 0;
                int j = 0;

                while (j < nums.Length)
                {
                    if (freq.ContainsKey(nums[j]))
                        freq[nums[j]]++;
                    else
                    {
                        count++;
                        freq[nums[j]] = 1;
                    }

                    while (count > k)
                        if (freq[nums[i]] == 1)
                        {
                            freq.Remove(nums[i++]);
                            count--;
                        }
                        else
                            freq[nums[i++]]--;
                    
                    solution += j - i + 1;
                    ++j;
                }

                return solution;
            }
        }
    }
}
