using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1
    {
        public Easy_1()
        {
            //Noo need to test
        }
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> wantedValues = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (wantedValues.ContainsKey(nums[i]))
                    return new int[] { wantedValues[nums[i]], i };

                wantedValues.TryAdd(target - nums[i], i);
            }

            return null;
        }
    }
}
