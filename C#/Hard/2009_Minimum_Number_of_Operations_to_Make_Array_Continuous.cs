using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_2009
    {
        public Hard_2009()
        {

        }
        public List<int> list;
        public int MinOperations(int[] nums)
        {
            Array.Sort(nums);
            list = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                list.Add(nums[i]);
            }

            int ans = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int target = list[i] + nums.Length - 1;
                int index = BinarySearch(target);
                ans = Math.Max(ans, index - i + 1);
            }
            return nums.Length - ans;
        }
        private int BinarySearch(int num)
        {
            int start = 0;
            int end = list.Count - 1;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (list[mid] == num)
                    return mid;
                else if (list[mid] < num)
                    start = mid + 1;
                else
                    end = mid - 1;
            }

            return start - 1;
        }
    }
}
