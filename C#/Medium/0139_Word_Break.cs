using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_139
    {
        public Medium_139()
        {

        }

        public bool WordBreak(string s, IList<string> wordDict)
        {
            bool[] dp = new bool[s.Length];

            for (int i = 0; i < s.Length; i++)
                foreach (var item in wordDict)
                {
                    if (i < item.Length - 1)
                        continue;

                    if ((i == item.Length - 1 || dp[i - item.Length])
                        && (s.Substring(i - item.Length + 1, item.Length) == item))
                    {
                        dp[i] = true;
                        break;
                    }
                }

            return dp[s.Length - 1];
        }
    }
}
