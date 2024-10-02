using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_605
    {
        public Easy_605()
        {

        }
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            if (n == 0)
                return true;

            if(flowerbed.Length == 1)
                return n == 1 && flowerbed[0] == 0;

            if (flowerbed[0] == 0 && flowerbed[1] == 0)
            {
                if (n == 1)
                    return true;
                flowerbed[0] = 1;
                --n;
            }

            for (int i = 1; i < flowerbed.Length - 1; i++)
            {
                if (flowerbed[i - 1] == 1
                    || flowerbed[i] == 1
                    || flowerbed[i + 1] == 1)
                    continue;

                flowerbed[i] = 1;
                --n;
                ++i;

                if (n <= 0)
                    return true;
            }

            if (flowerbed[flowerbed.Length - 2] == 0 && flowerbed[flowerbed.Length - 1] == 0)
                --n;

            return n <= 0;
        }
    }
}
