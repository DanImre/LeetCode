using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_191
    {
        public Easy_191()
        {

        }
        public int HammingWeight(uint n)
        {
            int count = 0;
            while (n != 0)
            {
                if ((n & 1) == 1)//faster then if(n % 2 == 1)
                    ++count;

                n >>= 1; //same as n = n >> 1; //Shifting one bit right
            }
            return count;
        }
    }
}
