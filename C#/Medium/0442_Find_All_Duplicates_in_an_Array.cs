using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_442
    {
        public Medium_442()
        {

        }

        public IList<int> FindDuplicates(int[] nums)
        {
            List<int> solution = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int ptr = Math.Abs(nums[i]) - 1;
                if (nums[ptr] < 0)
                    solution.Add(ptr + 1);
                
                nums[ptr] = (-1) * nums[ptr];
            }

            return solution;
        }
    }
}
