using System.Text;

namespace Hard
{
    public class _3348_Smallest_Divisible_Digit_Product_II
    {
        public string SmallestNumber(string num, long t)
        {
            long temp = t;
            for (int i = 2; i <= 9; i++)
                while (temp % i == 0)
                    temp /= i;

            // has a prime factor which is > 10
            if (temp > 1)
                return "-1";

            int n = num.Length;
            int pos = n - 1;

            long[] remainingDivisors = new long[n + 1];
            remainingDivisors[0] = t;

            int[] nums = [.. num.ToCharArray().Select(x => x - '0')];
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == 0)
                {
                    pos = i;
                    break;
                }

                remainingDivisors[i + 1] = remainingDivisors[i] / GreatestCommonDivisor(remainingDivisors[i], nums[i]);
            }

            // The number is already the solution
            if (remainingDivisors[n] == 1)
                return num;

            //.....^...<-
            // ____0_____
            for (int i = pos; i >= 0; i--)
                while (++nums[i] <= 9)
                {
                    long tNow = remainingDivisors[i] / GreatestCommonDivisor(remainingDivisors[i], nums[i]);

                    int replacementNum = 9;
                    for (int j = n - 1; j > i; j--)
                    {
                        while (tNow % replacementNum != 0)
                        {
                            replacementNum--;
                        }
                        tNow /= replacementNum;
                        nums[j] = replacementNum;
                    }

                    // If the replacement made a valid solution, return it
                    if (tNow == 1)
                        return string.Join("", nums);
                }

            // Creating the smallest valid number and returning it
            StringBuilder ans = new ();
            long originalT = t;
            for (int i = 9; i > 1; i--)
                while (originalT % i == 0)
                {
                    ans.Append((char)('0' + i));
                    originalT /= i;
                }

            int padding = Math.Max(n + 1 - ans.Length, 0);
            ans.Append('1', padding);

            char[] charArray = [.. ans.ToString().Reverse()];
            return new string(charArray);
        }
        private long GreatestCommonDivisor(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
