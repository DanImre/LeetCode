using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_509
    {
        public int Fib(int n)
        {
            if (n <= 1)
                return n;

            int oneAway = 0;
            int twoAway = 1;
            for (int i = 1; i < n; i++)
            {
                int temp = oneAway + twoAway;
                oneAway = twoAway;
                twoAway = temp;
            }

            return twoAway;
        }
    }
}
