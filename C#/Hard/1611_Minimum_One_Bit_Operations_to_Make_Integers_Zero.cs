using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_1611
    {
        public Hard_1611()
        {

        }
        public int MinimumOneBitOperations(int n)
        {
            if (n == 0)
                return 0;

            int power = (int)Math.Log2(n);

            int solution = 0;
            for (int i = 0; i <= power; i++)
                solution += (int)Math.Pow(2, i);

            return solution - MinimumOneBitOperations(n - (int)Math.Pow(2, power));
        }
    }
}
