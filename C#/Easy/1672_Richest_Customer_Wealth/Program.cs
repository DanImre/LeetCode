namespace _1672_Richest_Customer_Wealth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //no need for tryout
        }

        public int MaximumWealth(int[][] accounts)
        {
            int max = 0;

            foreach (var item in accounts)
            {
                int sum = 0;
                foreach (var account in item)
                    sum += account;

                max = Math.Max(max, sum);
            }

            return max;
        }
    }
}