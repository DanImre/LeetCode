using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_2742
    {
        public Hard_2742()
        {

        }
        private int[][] dp;
        private int[] cost;
        private int[] time;

        public int PaintWalls(int[] cost, int[] time)
        {
            this.cost = cost;
            this.time = time;

            dp = new int[cost.Length][];
            for (int i = 0; i < cost.Length; i++)
                dp[i] = new int[cost.Length + 1];

            return RecursiveSolution(0, cost.Length);
        }

        public int RecursiveSolution(int currIndex, int remainingWalls)
        {
            if (remainingWalls <= 0)
                return 0;
            if (currIndex == cost.Length)
                return (int)1e9;

            if (dp[currIndex][remainingWalls] != 0)
                return dp[currIndex][remainingWalls];

            dp[currIndex][remainingWalls] = Math.Min(cost[currIndex] + RecursiveSolution(currIndex + 1, remainingWalls - 1 - time[currIndex]),
                RecursiveSolution(currIndex + 1, remainingWalls));

            return dp[currIndex][remainingWalls];
        }
    }
}
