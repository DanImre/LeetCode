using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_880
    {
        public Medium_880()
        {

        }
        public string DecodeAtIndex(string s, int k)
        {
            long length = 0;
            int index = 0;
            while (length < k)
            {
                if (Char.IsDigit(s[index]))
                    length *= s[index] - '0';
                else
                    ++length;
                ++index;
            }

            while (index-- > 0)
                if (Char.IsDigit(s[index]))
                {
                    length /= s[index] - '0';
                    k %= (int)length;
                }
                else if (k % length == 0)
                    return s[index].ToString();
                else
                    --length;

            return "";
        }
    }
}
