using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_28
    {
        public Easy_28()
        {
            Console.WriteLine(StrStr("sadbutsad", "sad") + " - > " + (StrStr("sadbutsad", "sad") == 0));
            Console.WriteLine(StrStr("leetcode", "leeto") + " - > " + (StrStr("leetcode", "leeto") == -1));
            Console.WriteLine(StrStr("Helelo", "elo") + " - > " + (StrStr("Helelo", "elo") == 3));
        }

        public int StrStr(string haystack, string needle)
        {
            int i = 0;
            int maxIndex = haystack.Length - needle.Length;

            while (i <= maxIndex)
            {
                int temp = 0;
                while (temp<needle.Length && haystack[i + temp] == needle[temp])
                    ++temp;

                if (temp == needle.Length)
                    return i;

                ++i;
            }

            return -1;
        }
    }
}
