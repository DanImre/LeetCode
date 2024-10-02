using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_228
    {
        public Easy_228()
        {
            //No need
        }
        public IList<string> SummaryRanges(int[] nums)
        {
            List<string> solution = new List<string>();

            for (int i = 0; i < nums.Length; i++)
            {
                StringBuilder sb = new StringBuilder(nums[i].ToString());

                if (i == nums.Length - 1)
                {
                    solution.Add(sb.ToString());
                    break;
                }

                bool atleastOne = nums[i] + 1 == nums[i + 1];
                while (i < nums.Length - 1 && nums[i] + 1 == nums[i + 1])
                    ++i;

                if (atleastOne)
                {
                    sb.Append("->");
                    sb.Append(nums[i].ToString());
                }

                solution.Add(sb.ToString());
            }

            return solution;
        }
    }
}
