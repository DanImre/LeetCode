using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Merdium_930
    {
        public Merdium_930()
        {

        }
        public int NumSubarraysWithSum(int[] nums, int goal)
        {
            int solution = 0;

            int i = 0;
            int j = 0;
            int zerosBefore = 0;
            int sum = 0;
            while (j < nums.Length)
            {
                sum += nums[j];
                while (i < j && (nums[i] == 0 || sum > goal))
                {
                    if (nums[i] == 1)
                        zerosBefore = 0;
                    else
                        zerosBefore++;
                    sum -= nums[i];
                    i++;
                }

                if (sum == goal)
                    solution += 1 + zerosBefore;
                j++;
            }

            return solution;
        }
    }
}
