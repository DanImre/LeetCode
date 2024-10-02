using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_392
    {
        public Easy_392()
        {
            Console.WriteLine(IsSubsequence("abc", "ahbgdc"));
            Console.WriteLine(IsSubsequence("axc", "ahbgdc"));//False
        }

        public bool IsSubsequence(string s, string t)
        {
            int i = 0;
            int j = 0;

            while (j < t.Length && i < s.Length)
            {
                if (t[j] == s[i])
                    ++i;

                ++j;
            }

            return i == s.Length;
        }
    }
}
