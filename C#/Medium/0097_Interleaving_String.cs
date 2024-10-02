using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_97
    {
        public Medium_97()
        {
            Console.WriteLine(IsInterleave("aabcc", "dbbca", "aadbbcbcac"));
            Console.WriteLine(IsInterleave("a", "b", "ab"));
        }
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s3.Length != s1.Length + s2.Length)
                return false;
            if (s1.Length == 0)
                return s2 == s3;
            if (s2.Length == 0)
                return s1 == s3;

            // dp[i, j] indicates whether the s3 prefix of length n = i + j
            // can be constructed from s1 prefix of length i and s2 prefix of length j
            bool[,] dp = new bool[s1.Length + 1, s2.Length + 1];
            dp[1, 0] = s3[0] == s1[0];
            dp[0, 1] = s3[0] == s2[0];

            for (int i = 2; i <= s3.Length; i++)
            {
                char curr = s3[i - 1];

                //how mnany chars from s1 ?
                int min = Math.Max(0, i - s2.Length);
                int max = Math.Min(i, s1.Length);

                for (int j = min; j <= max; j++)
                {
                    int z = i - j; //chars from s2
                    dp[j, z] = (j > 0 && curr == s1[j - 1] && dp[j - 1, z])
                        || (z > 0 && curr == s2[z - 1] && dp[j, z - 1]);
                }
            }

            return dp[s1.Length, s2.Length];
        }

    }
}
