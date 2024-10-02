using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_190
    {
        public Easy_190()
        {

        }
        //O(1) time and space
        public uint reverseBits(uint n)
        {
            uint solution = 0;

            for (int i = 0; i < 32; i++)
            {
                solution = solution << 1; //Shifted left

                if (n % 2 == 1)
                    ++solution; //last one set to 1

                n = n >> 1; //shifted right
            }

            return solution;
        }
        //bad
        public uint reverseBitsBad(uint n)
        {
            uint solution = 0;
            for (int i = 0; i < 32; i++)
                if ((n & ((uint)1 << i)) != 0)
                    solution = solution |= ((uint)1 << 31 - i);
            return solution;
        }
    }
}
