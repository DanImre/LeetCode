namespace Easy
{
    public class _3345_Smallest_Divisible_Digit_Product_I
    {
        public int SmallestNumber(int n, int t)
        {
            while (true)
            {
                int digitsProduct = n.ToString()
                    .ToCharArray()
                    .Aggregate(1, (x, y) => x * (y - '0'));

                if (digitsProduct % t == 0)
                    return n;
                n++;
            }
        }
    }
}
