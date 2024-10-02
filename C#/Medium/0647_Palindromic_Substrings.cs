using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_647
    {
        public Medium_647()
        {

        }
        public int CountSubstrings(string s)
        {
            int solution = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int odd = PalindromeCount(s, i - 1, i + 1);
                int even = PalindromeCount(s, i, i + 1);

                solution += odd + even + 1;
            }

            return solution;
        }
        public int PalindromeCount(string s, int left, int right)
        {
            int count = 0;
            while (left >= 0 && right < s.Length && s[left--] == s[right++])
                ++count;

            return count;
        }

        public bool IsPalindrome(string s, int left, int right)
        {
            while (left < right)
                if (s[left++] != s[right--])
                    return false;

            return true;
        }

    }
}
