using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1456
    {
        public Medium_1456()
        {

        }
        public int MaxVowels(string s, int k)
        {
            int count = 0;
            for (int i = 0; i < k; i++)
                if (IsVowel(s[i]))
                    ++count;

            int solution = count;

            for (int i = k; i < s.Length; i++)
            {
                if (IsVowel(s[i - k]))
                    --count;
                if (IsVowel(s[i]))
                    ++count;

                solution = Math.Max(solution, count);
            }

            return solution;
        }
        public bool IsVowel(char a)
        {
            return a == 'a'
                || a == 'e'
                || a == 'i'
                || a == 'o'
                || a == 'u';
        }
    }
}
