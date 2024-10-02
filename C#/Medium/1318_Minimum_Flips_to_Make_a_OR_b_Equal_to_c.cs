using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1318
    {
        public Medium_1318()
        {

        }
        public int MinFlips(int a, int b, int c)
        {
            int solution = 0;

            for (int i = 0; i <= 30; i++)
            {
                int bitAtI = (1 << i);
                if ((c & bitAtI) == 0)
                {
                    if ((a & bitAtI) != 1)
                        ++solution;
                    if ((b & bitAtI) != 1)
                        ++solution;
                }
                else if ((a & bitAtI) == 0 && (b & bitAtI) == 0)
                    ++solution;
            }

            return solution;
        }
    }
}
