using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_873
    {
        public Medium_873()
        {

        }
        public int LenLongestFibSubseq(int[] arr)
        {
            Dictionary<int, int> indexes = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; ++i)
                indexes.Add(arr[i], i);

            Dictionary<int, int> longest = new Dictionary<int, int>();
            int[,] dp = new int[arr.Length, arr.Length];
            int ans = 0;

            for (int i = 0; i < arr.Length; ++i)
                for (int j = 0; j < i; ++j)
                {
                    int index = indexes.GetValueOrDefault(arr[i] - arr[j], -1);
                    if (index != -1 && index < j)
                    {
                        int cand = (dp[index,j] > 2 ? dp[index,j] : 2) + 1;
                        dp[j,i] = cand;
                        ans = Math.Max(ans, cand);
                    }
                }

            return ans >= 3 ? ans : 0;
        }
    }
}
