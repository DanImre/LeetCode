using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_123
    {
        public Hard_123()
        {

        }
        public int MaxProfit(int[] prices)
        {
            int[] left = new int[prices.Length];
            int[] right = new int[prices.Length];

            //FromLeft
            int min = prices[0];
            int max = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < min) //reset
                {
                    min = prices[i];
                    max = prices[i];
                }

                max = Math.Max(max, prices[i]);
                left[i] = Math.Max(left[i - 1], max - min);
            }

            //FromRight
            min = prices[prices.Length - 1];
            max = prices[prices.Length - 1];
            for (int i = prices.Length - 2; i >= 0; i--)
            {
                if (prices[i] > max) //reset
                {
                    min = prices[i];
                    max = prices[i];
                }

                min = Math.Min(min, prices[i]);
                right[i] = Math.Max(right[i + 1], max - min);
            }

            int profit = 0;
            for (int i = 0; i < prices.Length; i++)
                profit = Math.Max(profit, left[i] + right[i]);

            return profit;
        }
    }
}
