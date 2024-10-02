using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1759
    {
        public Medium_1759()
        {

        }
        public int CountHomogenous(string s)
        {
            int solution = 1;
            int mod = (int)1e9 + 7;
            int streak = 1;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i - 1] == s[i])
                    ++streak;
                else
                    streak = 1;

                solution = (solution + streak) % mod;
            }

            return solution;
        }
    }
}
