using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_997
    {
        public Easy_997()
        {

        }
        public int FindJudge(int n, int[][] trust)
        {
            int[] trustCount = new int[n + 1];
            int[] trustedByCount = new int[n + 1];

            foreach (var item in trust)
            {
                trustCount[item[0]]++;
                trustedByCount[item[1]]++;
            }

            for (int i = 1; i <= n; i++)
                if (trustCount[i] == 0 && trustedByCount[i] == n - 1)
                    return i;

            return -1;
        }
    }
}
