using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_403
    {
        public Hard_403()
        {
            Console.WriteLine(CanCross(new int[] { 0, 1, 3, 5, 6, 8, 12, 17 }));
            Console.WriteLine(CanCross(new int[] { 0, 1, 2, 3, 4, 8, 9, 11 }) == false);
        }
        public bool CanCross(int[] stones)
        {
            Dictionary<int, bool>[] dp = new Dictionary<int, bool>[stones.Length];
            for (int i = 0; i < stones.Length; i++)
                dp[i] = new Dictionary<int, bool>();

            if (stones[1] - stones[0] != 1)
                return false;
            return CanCrossRecursive(stones, 1, 1, dp);
        }

        public bool CanCrossRecursive(int[] stones, int k, int pos, Dictionary<int, bool>[] dp)
        {
            if (pos == stones.Length - 1)
                return true;

            for (int i = pos + 1; i < stones.Length; i++)
            {
                int temp = stones[i] - stones[pos];
                if (temp > k + 1)
                    break;

                if (temp < k - 1)
                    continue;

                if (temp == k - 1)
                {
                    if (!dp[i].ContainsKey(k - 1))
                        dp[i].Add(k - 1, CanCrossRecursive(stones, k - 1, i, dp));

                    if (dp[i][k - 1])
                        return true;
                }
                else if (temp == k)
                {
                    if (!dp[i].ContainsKey(k))
                        dp[i].Add(k, CanCrossRecursive(stones, k, i, dp));

                    if (dp[i][k])
                        return true;
                }
                if (temp == k + 1)
                {
                    if (!dp[i].ContainsKey(k + 1))
                        dp[i].Add(k + 1, CanCrossRecursive(stones, k + 1, i, dp));

                    if (dp[i][k + 1])
                        return true;
                }
            }

            return false;
        }
    }
}
