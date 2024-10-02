using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_2441
    {
        public Easy_2441()
        {

        }
        public int FindMaxK(int[] nums)
        {
            HashSet<int> neg = new HashSet<int>();
            HashSet<int> pos = new HashSet<int>();

            int solution = -1;

            foreach (var item in nums)
                if (item < 0)
                {
                    if (pos.Contains(-item))
                        solution = Math.Max(-item, solution);
                    neg.Add(item);
                }
                else
                {
                    if (neg.Contains(-item))
                        solution = Math.Max(item, solution);
                    pos.Add(item);
                }

            return solution;
        }
    }
}
