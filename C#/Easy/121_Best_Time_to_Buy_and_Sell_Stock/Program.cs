using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace _121_Best_Time_to_Buy_and_Sell_Stock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxProfit2(new int[] { 7, 1, 5, 3, 6, 4 }));
            Console.WriteLine(MaxProfit2(new int[] { 7, 6, 4, 3, 1 }));
        }

        //O(n'2) 
        //Time limit exceeded
        public static int MaxProfit(int[] prices)
        {
            int max = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                for (int j = i; j < prices.Length; j++)
                {
                    max = Math.Max(max, prices[j] - prices[i]);
                }
            }
            return max;
        }

        //O(n) in theory
        public static int MaxProfit2(int[] prices)
        {
            if (prices.Length < 2)
                return 0;

            int solution = 0;

            int[] maxAfterIndexes = new int[prices.Length];

            int max = -1;
            int maxIndexBefore = -1;
            int maxIndex = -1;

            while (maxIndexBefore + 1 < prices.Length)
            {
                max = -1;
                for (int i = maxIndexBefore + 1; i < prices.Length; i++)
                {
                    if (prices[i] < max)
                        continue;

                    max = prices[i];
                    maxIndex = i;
                }

                for (int i = maxIndexBefore + 1; i <= maxIndex; i++)
                    maxAfterIndexes[i] = max;

                maxIndexBefore = maxIndex;
            }

            for (int i = 0; i < prices.Length - 1; i++)
                solution = Math.Max(solution, maxAfterIndexes[i + 1] - prices[i]);

            return solution;
        }

        //True O(n) and O(1) in memory
        public static int MaxProfit3(int[] prices)
        {
            int maxProfit = 0;
            int minCost = int.MaxValue;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minCost)
                    minCost = prices[i];
                else
                    maxProfit = Math.Max(maxProfit, prices[i] - minCost);
            }

            return maxProfit;
        }
    }
}