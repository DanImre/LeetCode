using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public class _3483_Unique_3_Digit_Even_Numbers
    {
        public int TotalNumbers(int[] digits)
        {
            int solution = 0;
            foreach (var last in digits.Where(x => x % 2 == 0).Distinct())
            {
                List<int> digitCopy = new(digits);
                digitCopy.Remove(last);
                foreach (var first in digitCopy.Where(x => x != 0).Distinct())
                {
                    List<int> digitCopyForMiddle = new(digitCopy);
                    digitCopyForMiddle.Remove(first);
                    solution += digitCopyForMiddle.Distinct().Count();
                }
            }

            return solution;
        }
    }
}
