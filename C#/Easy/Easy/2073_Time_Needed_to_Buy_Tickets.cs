using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_2073
    {
        public Easy_2073()
        {

        }
        public int TimeRequiredToBuy(int[] tickets, int k)
        {
            int time = 0;
            int index = 0;
            while (tickets[k] != 0)
            {
                index %= tickets.Length;
                if (tickets[index] == 0)
                {
                    ++index;
                    continue;
                }
                tickets[index++] -= 1;
                time++;
            }

            return time;
        }
    }
}
