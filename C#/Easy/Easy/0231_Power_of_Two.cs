using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_231
    {
        public Easy_231()
        {

        }
        public bool IsPowerOfTwo(int n)
        {
            return n > 0 && (n & n - 1) == 0;
        }
    }
}
