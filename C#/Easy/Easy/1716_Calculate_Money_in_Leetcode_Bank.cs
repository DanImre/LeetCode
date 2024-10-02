using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1716
    {
        public Easy_1716()
        {

        }
        public int TotalMoney(int n)
        {
            //62 = 8w + 6d -> (w * 28) + (0 + 1*7 + 2*7 .. + w7) + [(w+1) + (w + 2) + ..(w + 6)]
            //n(n - 1)/2
            
            int weeks = n / 7;
            int days = n % 7;

            int solution = weeks * 28;
            solution += 7 * weeks * (weeks - 1) / 2;

            solution += (weeks * days) + ((days + 1) * days / 2); //n == days + 1

            return solution;
        }
    }
}
