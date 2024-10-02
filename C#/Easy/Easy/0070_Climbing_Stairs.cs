using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_70
    {
        public Easy_70()
        {

        }

        public int ClimbStairs(int n)
        {
            if (n <= 2)
                return n;

            int onestep = 2;
            int twostep = 1;

            for (int i = 2; i < n - 1; i++)
            {
                int temp = onestep + twostep;
                twostep = onestep;
                onestep = temp;
            }

            return onestep + twostep;
        }
    }
}
