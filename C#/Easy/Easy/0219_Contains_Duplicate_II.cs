using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_219
    {
        public Easy_219()
        {
            Console.WriteLine(ContainsNearbyDuplicate(new int[] { 1, 2, 3, 1, 2, 3 }, 2));
        }
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            HashSet<int> window = new HashSet<int>();

            int i = 0;
            for (int j = 0; j <= k && j < nums.Length; j++)
                if (!window.Add(nums[j]))
                    return true;

            while (i < nums.Length - k - 1)
            {
                window.Remove(nums[i]);
                ++i;
                if (!window.Add(nums[i + k]))
                    return true;
            }

            return false;
        }
    }
}
