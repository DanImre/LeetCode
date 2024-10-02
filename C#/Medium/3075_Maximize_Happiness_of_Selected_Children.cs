using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_3075
    {
        public Medium_3075()
        {

        }
        public long MaximumHappinessSum(int[] happiness, int k)
        {
            long solution = 0;

            Array.Sort(happiness, (a,b) => b.CompareTo(a));

            for (int i = 0; i < k; ++i)
                solution += Math.Max(happiness[i] - i, 0);

            return solution;
        }
    }
}
