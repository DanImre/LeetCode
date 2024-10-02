using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_3
    {
        public Medium_3()
        {
            Console.WriteLine(LengthOfLongestSubstring("abcabcbb"));//3
            Console.WriteLine(LengthOfLongestSubstring("bbbbb"));//1
            Console.WriteLine(LengthOfLongestSubstring("pwwkew"));//3
        }

        public int LengthOfLongestSubstring(string s)
        {
            HashSet<char> characters = new HashSet<char>();

            int solution = 0;

            int i = 0;
            int j = 0;

            while (j < s.Length)
            {
                if (!characters.Add(s[j]))
                {
                    while (s[i] != s[j])
                    {
                        characters.Remove(s[i]);
                        ++i;
                    }
                    ++i;
                }

                solution = Math.Max(solution, j - i + 1);

                ++j;
            }

            return solution;
        }
    }
}
