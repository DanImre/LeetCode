using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_137
    {
        public Medium_137()
        {
            
        }
        //Technicly sorting could be O(n):
        public int SingleNumber(int[] nums)
        {
            if(nums.Length == 1)
                return nums[0];

            Array.Sort(nums);

            int solutionIndex = -1;

            for (int i = 0; i < nums.Length - 2; i += 3)
                if (nums[i] != nums[i + 2])
                {
                    solutionIndex = i;
                    break;
                }

            if (solutionIndex == -1)
                solutionIndex = nums.Length - 1;

            return nums[solutionIndex];
        }
    }
}
