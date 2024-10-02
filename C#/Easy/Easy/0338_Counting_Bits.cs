using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_338
    {
        public Easy_338()
        {

        }
        public int[] CountBits(int n)
        {
            int[] solution = new int[n + 1];
            for (int i = 1; i <= n; i++)
                solution[i] = (i & 1) + solution[(i >> 1)];

            return solution;
        }
    }
}
