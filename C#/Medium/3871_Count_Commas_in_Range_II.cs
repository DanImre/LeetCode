using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public class _3871_Count_Commas_in_Range_II
    {
        public long CountCommasWithBrackets(long n)
        {
            long solution = Math.Max(Math.Min(n, (long)1e6 - 1) - 999, 0);
            solution += 2 * Math.Max(Math.Min(n, (long)1e9 - 1) - (long)(1e6 - 1), 0);
            solution += 3 * Math.Max(Math.Min(n, (long)1e12 - 1) - (long)(1e9 - 1), 0);
            solution += 4 * Math.Max(Math.Min(n, (long)1e15 - 1) - (long)(1e12 - 1), 0);
            solution += 5 * Math.Max(Math.Min(n, (long)1e18 - 1) - (long)(1e15 - 1), 0);

            return solution;
        }

        public long CountCommas(long n)
        {
            long solution = 0;
            int powerOfThousand = (int)Math.Log(n, 1e3);
            for (int i = 1; i <= powerOfThousand; i++)
            {
                long upperBound = (long)Math.Pow(1e3, i + 1);
                long lowerBound = (long)Math.Pow(1e3, i);
                solution += i * Math.Max(Math.Min(n, upperBound - 1) - (lowerBound - 1), 0);
            }
            return solution;
        }

        public long CountCommasBestSolution(long n)
        {
            long p = 1000, res = 0;
            while (p <= n)
            {
                res += n - p + 1;
                p *= 1000;
            }
            return res;
        }
    }
}
