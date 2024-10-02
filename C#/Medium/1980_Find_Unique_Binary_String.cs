using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1980
    {
        public Medium_1980()
        {

        }
        public string FindDifferentBinaryString(string[] nums)
        {
            HashSet<int> nusmAsNumbers = new HashSet<int>();

            int n = nums[0].Length;

            foreach (var item in nums)
                nusmAsNumbers.Add(Convert.ToInt32(item, 2));

            for (int i = 0; i <= n; i++)
                if (!nusmAsNumbers.Contains(i))
                {
                    string inBaseTwo = Convert.ToString(i, 2);
                    StringBuilder leadingZeros = new StringBuilder();
                    for (int j = inBaseTwo.Length; j < n; j++)
                        leadingZeros.Append("0");

                    return leadingZeros.ToString() + inBaseTwo;
                }

            return "";
        }
    }
}
