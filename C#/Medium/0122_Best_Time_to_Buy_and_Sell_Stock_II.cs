using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_122
    {
        public Medium_122()
        {
            Console.WriteLine(MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));
            Console.WriteLine(MaxProfit(new int[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine(MaxProfit(new int[] { 7, 6, 4, 3, 1 }));
        }
        //primitive
        public  int MaxProfit(int[] prices)
        {
            if (prices.Length == 1)
                return 0;

            Dictionary<int, int> bestpossibleProfitFromIndex = new Dictionary<int, int>();
            bestpossibleProfitFromIndex.Add(prices.Length - 1, 0);
            bestpossibleProfitFromIndex.Add(prices.Length - 2, Math.Max(0, prices[prices.Length - 1] - prices[prices.Length - 2]));

            for (int i = prices.Length - 3; i >= 0; i--)
            {
                int tempMax = bestpossibleProfitFromIndex[i + 1];

                for (int j = i + 1; j < prices.Length; j++)
                    tempMax = Math.Max(tempMax, prices[j] - prices[i] + bestpossibleProfitFromIndex[j]);

                bestpossibleProfitFromIndex.Add(i, tempMax);
            }

            return bestpossibleProfitFromIndex[0];
        }

        //O(n) time and O(1) space solution
        public  int MaxProfit2(int[] prices)
        {
            if (prices.Length < 2) { return 0; }
            int min = prices[0];
            int max = prices[0];
            int sum = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > max)
                {
                    max = prices[i];
                    continue;
                }
                if (prices[i] < max)
                {
                    sum += max - min;
                    min = prices[i];
                    max = prices[i];
                }
            }
            sum += max - min;

            return sum;
        }
    }
}
