using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_1220
    {
        public Hard_1220()
        {

        }
        public int CountVowelPermutation(int n)
        {
            int mod = (int)1e9 + 7;

            long[,] dp = new long[n, 5];
            for (int i = 0; i < 5; i++)
                dp[0, i] = 1;

            for (int i = 1; i < n; i++)
            {
                //a
                dp[i, 0] = (dp[i, 0] + dp[i - 1, 1]) % mod; //***ea
                dp[i, 0] = (dp[i, 0] + dp[i - 1, 4]) % mod; //***ua
                dp[i, 0] = (dp[i, 0] + dp[i - 1, 2]) % mod; //***ia

                //e
                dp[i, 1] = (dp[i, 1] + dp[i - 1, 0]) % mod; //***ae
                dp[i, 1] = (dp[i, 1] + dp[i - 1, 2]) % mod; //***ie

                //i
                dp[i, 2] = (dp[i, 2] + dp[i - 1, 1]) % mod; //***ei
                dp[i, 2] = (dp[i, 2] + dp[i - 1, 3]) % mod; //***oi

                //o
                dp[i, 3] = (dp[i,3] + dp[i - 1, 2]) % mod; //***io

                //u
                dp[i, 4] = (dp[i, 4] + dp[i - 1, 2]) % mod; //***iu
                dp[i, 4] = (dp[i, 4] + dp[i - 1, 3]) % mod; //***ou
            }

            long solution = 0;
            for (int i = 0; i < 5; i++)
                solution = (solution + dp[n - 1, i]) % mod;

            return (int)solution;
        }
    }
}
