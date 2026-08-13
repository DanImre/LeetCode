using System;
using System.Collections.Generic;
using System.Text;

namespace Hard
{
    public class _1563_Stone_Game_V
    {
        public int StoneGameV(int[] stoneValue)
        {
            int length = stoneValue.Length;
            int[,] dp = new int[length, length];

            for (int i = 1; i < length; i++)
            {
                for (int j = 1; j + i < length - 1; j++)
                {
                    dp[j, j + i] = Math.Min()
                }
            }
        }
    }
}
