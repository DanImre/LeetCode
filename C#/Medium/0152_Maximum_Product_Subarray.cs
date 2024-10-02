using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_152
    {
        public Medium_152()
        {

        }
        public int MaxProduct(int[] nums)
        {
            int max = 1;
            int min = 1;
            int solution = int.MinValue;

            foreach (var item in nums)
            {
                int maxBefore = max;

                max = Math.Max(item, Math.Max(item * max, item * min));
                min = Math.Min(item, Math.Min(item * maxBefore, item * min));

                solution = Math.Max(solution, max);
            }

            return solution;
        }
    }
}
