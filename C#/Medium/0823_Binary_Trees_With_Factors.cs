using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_823
    {
        public Medium_823()
        {

        }

        public int NumFactoredBinaryTrees(int[] arr)
        {
            int mod = (int)1e9 + 7;

            Array.Sort(arr);
            HashSet<int> hs = new HashSet<int>(arr);
            Dictionary<int, long> dp = new Dictionary<int, long>();
            foreach (var item in arr)
                dp.Add(item, 1);

            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] * arr[j] > arr[i])
                        break;

                    int temp = arr[i] / arr[j];
                    if (arr[i] % arr[j] != 0 || !hs.Contains(temp))
                        continue;

                    long soFar = dp[arr[j]] * dp[temp];
                    dp[arr[i]] = (dp[arr[i]] + (temp == arr[j] ? soFar : soFar * 2)) % mod;
                }

            long solution = 0;
            foreach (var item in dp)
                solution = (solution + item.Value) % mod;

            return (int)solution;
        }

    }
}
