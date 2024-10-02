using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_78
    {
        public Medium_78()
        {

        }

        List<IList<int>> Solutions = new List<IList<int>>();
        public int[] Nums = null!;
        public IList<IList<int>> Subsets(int[] nums)
        {
            Nums = nums;

            BackTrack(0, new HashSet<int>());

            return Solutions;
        }

        public void BackTrack(int index, HashSet<int> set)
        {
            if (index == Nums.Length)
            {
                Solutions.Add(set.ToArray());
                return;
            }

            BackTrack(index + 1, set);

            set.Add(Nums[index]);
            BackTrack(index + 1, set);
            set.Remove(Nums[index]);
        }
    }
}
