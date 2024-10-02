using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_2864
    {
        public Easy_2864()
        {

        }
        public string MaximumOddBinaryNumber(string s)
        {
            StringBuilder sb = new StringBuilder();
            int onesCount = 0;
            int zeroscount = 0;
            foreach (var item in s)
                if (item == '1')
                    onesCount += 1;
                else
                    zeroscount += 1;

            sb.Append('1', onesCount - 1);
            sb.Append('0', zeroscount);
            sb.Append('1');
            return sb.ToString();
        }
    }
}
