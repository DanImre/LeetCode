using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_389
    {
        public Easy_389()
        {

        }
        public char FindTheDifference(string s, string t)
        {
            int bitwise = 0;
            foreach (var item in s + t)
                bitwise ^= (int)item;

            return (char)bitwise;
        }
    }
}
