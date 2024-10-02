using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_1335
    {
        public Hard_1335()
        {
            Console.WriteLine(MinDifficulty(new int[] { 6, 5, 4, 3, 2, 1 }, 2));
        }

        public int MinDifficulty(int[] jobDifficulty, int d)
        {
            if (jobDifficulty.Length < d)
                return -1;
            if (jobDifficulty.Length == d)
                return jobDifficulty.Sum();

            int[] dp = new int[jobDifficulty.Length];

            dp[0] = jobDifficulty[0];
            for (int i = 1; i < jobDifficulty.Length; i++)
                dp[i] = Math.Max(dp[i - 1], jobDifficulty[i]);

            int[] prevDp = new int[jobDifficulty.Length];
            for (int i = 1; i < d; i++)
            {
                int[] temp = prevDp;
                prevDp = dp;
                dp = temp;

                for (int j = i; j < jobDifficulty.Length; j++)
                {
                    int maxForTheDay = jobDifficulty[j];
                    int minForAllDays = maxForTheDay + prevDp[j - 1];

                    for (int l = j - 1; l > i - 1; l--)
                    {
                        maxForTheDay = Math.Max(maxForTheDay, jobDifficulty[l]);
                        minForAllDays = Math.Min(minForAllDays, maxForTheDay + prevDp[l - 1]);
                    }

                    dp[j] = minForAllDays;
                }
            }

            return dp[jobDifficulty.Length - 1];
        }
    }
}
