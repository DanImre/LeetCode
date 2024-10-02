using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1027
    {
        public Medium_1027()
        {
            Console.WriteLine(LongestArithSeqLength(new int[] { 3, 6, 9, 12 }));
            Console.WriteLine(LongestArithSeqLength(new int[] { 9, 4, 7, 2, 10 }));
            Console.WriteLine(LongestArithSeqLength(new int[] { 20, 1, 15, 3, 10, 5, 8 }));
        }
        public int LongestArithSeqLength(int[] nums)
        {
            int maxCount = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int tempCount = 2;
                    int value = nums[j] - nums[i];

                    int latestGoodNumbersIndex = j;

                    for (int z = j + 1; z < nums.Length; z++)
                    {
                        if (nums[z] - nums[latestGoodNumbersIndex] != value)
                            continue;

                        latestGoodNumbersIndex = z;
                        ++tempCount;
                    }

                    if (tempCount > maxCount)
                        maxCount = tempCount;
                }
            }

            return maxCount;
        }
    }
}
