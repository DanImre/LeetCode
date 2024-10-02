using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_125
    {
        public Easy_125()
        {
            Console.WriteLine(IsPalindrome("A man, a plan, a canal: Panama"));
            Console.WriteLine(IsPalindrome("race a car")); //False
            Console.WriteLine(IsPalindrome(" "));
            Console.WriteLine(IsPalindrome(".,"));
        }
        public bool IsPalindrome(string s)
        {
            int i = 0;
            int j = s.Length - 1;

            while (i < j)
            {
                while (i <= j && !char.IsLetterOrDigit(s[i]))
                    ++i;

                while (i <= j && !char.IsLetterOrDigit(s[j]))
                    --j;

                if (i >= j)
                    return true;

                if (char.ToLower(s[i]) != char.ToLower(s[j]))
                    return false;

                ++i;
                --j;
            }

            return true;
        }
    }
}
