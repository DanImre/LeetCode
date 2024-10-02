using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_808
    {
        public Medium_808()
        {

        }

        public Dictionary<(int A, int B), double> dp = new Dictionary<(int A, int B), double>();
        public double SoupServings(int n)
        {
            if (n > 4800)
                return 1;

            return RecursiveSolution(n, n);
        }

        public double RecursiveSolution(int A, int B)
        {
            if (A <= 0 || B <= 0)
            {
                if (A <= 0 && B <= 0)
                    return 0.5;
                if (A <= 0)
                    return 1;
                
                return 0;
            }

            if (dp.ContainsKey((A, B)))
                return dp[(A, B)];

            dp.Add((A, B), 0.25 * (
                RecursiveSolution(A - 100, B) +
                RecursiveSolution(A - 75, B - 25) +
                RecursiveSolution(A - 50, B - 50) +
                RecursiveSolution(A - 25, B - 75)
                ));

            return dp[(A, B)];
        }
    }
}
