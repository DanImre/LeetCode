using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_136
    {
        public Easy_136()
        {
            Console.WriteLine((1026 & 24));
        }
        public int SingleNumber(int[] nums)
        {
            int bits = 0;

            foreach (var item in nums)
                bits ^= item; //XOR
                /* 
                if ((bits & item) == item)
                    bits &= ~item;
                else
                    bits |= item;*/

            return bits;
        }
    }
}
