using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1732
    {
        public Easy_1732()
        {

        }
        public int LargestAltitude(int[] gain)
        {
            int max = 0;
            int curr = 0;
            foreach (var item in gain)
            {
                curr += item;
                max = Math.Max(max, curr);
            }

            return max;
        }
    }
}
