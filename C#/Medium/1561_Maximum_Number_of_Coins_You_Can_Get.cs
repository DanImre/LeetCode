using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1561
    {
        public Medium_1561()
        {

        }
        public int MaxCoins(int[] piles)
        {
            Array.Sort(piles);
            int solution = 0;
            int seq = 0;
            for (int i = piles.Length - 2; i > 0 && seq++ < piles.Length / 3; i -= 2)
                solution += piles[i];
            return solution;
        }
    }
}
