using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_343
    {
        public Medium_343()
        {

        }
        public int IntegerBreak(int n)
        {
            if (n < 4)
                return n - 1;

            int solution = 1;
            while (n > 4)
            {
                solution *= 3;
                n -= 3;
            }

            return solution * n;
        }
    }
}
