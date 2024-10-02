using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1750
    {
        public Medium_1750() { }
        public int MinimumLength(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (s[left] != s[right])
                    break;

                char c = s[left];
                ++left;
                --right;
                while (left <= right && s[left] == c)
                    ++left;

                while (right >= left && s[right] == c)
                    --right;

                if (left >= right)
                    return Math.Max(0, right - left + 1);
            }

            return right - left + 1;
        }
    }
}
