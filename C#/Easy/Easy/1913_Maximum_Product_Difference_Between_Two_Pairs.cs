using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1913
    {
        public Easy_1913()
        {

        }
        public int MaxProductDifference(int[] nums)
        {
            int min1 = int.MaxValue;
            int min2 = int.MaxValue;

            int max1 = int.MinValue;
            int max2 = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if(min1 > nums[i])
                {
                    min2 = min1;
                    min1 = nums[i];
                }
                else if(min2 > nums[i])
                    min2 = nums[i];

                if (max1 < nums[i])
                {
                    max2 = max1;
                    max1 = nums[i];
                }
                else if (max2 < nums[i])
                    max2 = nums[i];
            }

            //Console.WriteLine(max1 + " " + max2 + " || " + min1 + " " + min2);

            return (max1 * max2) - (min1 * min2);
        }
    }
}
