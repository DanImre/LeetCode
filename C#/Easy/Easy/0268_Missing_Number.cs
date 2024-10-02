using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_268
    {
        public Easy_268()
        {

        }
        public int MissingNumber(int[] nums)
        {
            int n = nums.Length;

            for (int i = 0; i < nums.Length; i++)
                n ^= i ^ nums[i];

            return n;
        }
    }
}
