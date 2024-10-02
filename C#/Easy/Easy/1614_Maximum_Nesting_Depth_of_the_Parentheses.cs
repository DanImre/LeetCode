using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1614
    {
        public Easy_1614()
        {

        }
        public int MaxDepth(string s)
        {
            int max = 0;
            int count = 0;
            foreach (var item in s)
                if (item == '(')
                {
                    ++count;
                    max = Math.Max(count, max);
                }
                else if (item == ')')
                    --count;

            return max;
        }
    }
}
