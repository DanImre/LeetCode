using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_875
    {
        public Medium_875()
        {

        }
        private bool Doable(int[] piles, int h, int k)
        {
            int time = 0;
            foreach (var item in piles)
                time += (item + k - 1) / k;
                //same as time += item / k + (item % k == 0 ? 0 : 1);

            return time <= h;
        }
        public int MinEatingSpeed(int[] piles, int h)
        {
            int start = 1;
            int end = piles.Max();
            while (start < end)
            {
                int mid = start + (end - start) / 2;

                if (!Doable(piles, h, mid))
                    start = mid + 1;
                else
                    end = mid;
            }

            return start;
        }
    }
}
