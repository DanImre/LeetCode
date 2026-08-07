namespace Hard
{
    public class _3348_Smallest_Divisible_Digit_Product_II
    {
        public string SmallestNumber(string num, long t)
        {
            int[] primes = [2, 3, 5, 7];
            List<int> productPrimes = [];
            bool found = true;
            while (found)
            {
                found = false;
                foreach (var item in primes)
                {
                    if (t % item != 0)
                        continue;

                    found = true;
                    productPrimes.Add(item);
                    t /= item;
                    break;
                }
            }

            if (t >= 10)
                return "-1";

            string recursiveNumberGen(List<int> productPrimes)
            {
                return "";
            }



            return string.Join(", ", productPrimes.OrderBy(x => x));
        }
    }
}
