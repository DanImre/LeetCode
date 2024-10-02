using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Medium
{
    public class Medium_1291
    {
        public IList<int> SequentialDigits(int low, int high)
        {
            string digits = "123456789";

            List<int> solution = new List<int>();

            int lowDigitCount = (int)Math.Log10(low) + 1;
            int highDigitCount = (int)Math.Log10(high) + 1;

            for (int i = 0; i <= 9 - lowDigitCount; i++)
                for (int j = lowDigitCount; j <= 9 - i && j <= highDigitCount; j++)
                {
                    int curr = int.Parse(digits.Substring(i, j));
                    if (curr >= low && curr <= high)
                        solution.Add(curr);
                }

            solution.Sort();

            return solution;
        }
    }
}
