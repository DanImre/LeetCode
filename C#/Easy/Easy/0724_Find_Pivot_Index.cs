using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_724
    {
        public Easy_724()
        {
            Console.WriteLine(PivotIndex(new int[] { -4, -2, 1, 4, 0, 4, -1, -1 }));
        }
        public int PivotIndex(int[] nums)
        {
            int sum = nums.Sum();
            int sumLeft = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (sum - (2 * sumLeft) - nums[i] == 0)
                    return i;

                sumLeft += nums[i];
                if(i == 7)
                    Console.WriteLine(sum + " " + sumLeft);
            }

            return -1;
        }
    }
}
