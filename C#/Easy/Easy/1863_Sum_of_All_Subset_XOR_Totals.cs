using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1863
    {
        public Easy_1863()
        {

        }
        public int SubsetXORSum(int[] nums)
        {
            List<List<int>> subsets = new List<List<int>>();
            List<int> subset = new List<int>();

            void backtrackForSubsets(int index)
            {
                if (index >= nums.Length)
                {
                    subsets.Add(new List<int>(subset));
                    return;
                }

                //chose it
                subset.Add(nums[index]);
                backtrackForSubsets(index + 1);
                subset.Remove(nums[index]);

                //dont chose
                backtrackForSubsets(index + 1);
            }

            backtrackForSubsets(0);

            int solution = 0;
            foreach (var sub in subsets)
            {
                int temp = 0;
                foreach (var item in sub)
                    temp ^= item;

                solution += temp;
            }

            return solution;
        }
    }
}
