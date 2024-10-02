using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2616
    {
        public Medium_2616()
        {

        }
        public int MinimizeMax(int[] nums, int p)
        {
            if (p == 0)
                return 0;

            Array.Sort(nums);

            int smallestPossibleThreshold = 0;
            int biggestPossibleThreshold = nums[nums.Length - 1] - nums[0];

            while (smallestPossibleThreshold < biggestPossibleThreshold)
            {
                int mid = (smallestPossibleThreshold + biggestPossibleThreshold) / 2;

                if (pairsWithThreshold(nums, mid) >= p)
                    biggestPossibleThreshold = mid;
                else
                    smallestPossibleThreshold = mid + 1;
            }

            return smallestPossibleThreshold;
        }

        public int pairsWithThreshold(int[] nums, int threshold)
        {
            int count = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i + 1] - nums[i] > threshold)
                    continue;

                ++i;
                ++count;
            }

            return count;
        }
    }
}
