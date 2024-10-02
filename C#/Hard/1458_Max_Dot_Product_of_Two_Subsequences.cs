using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_1458
    {
        public Hard_1458()
        {

        }
        private int?[][] dp;
        public int MaxDotProduct(int[] nums1, int[] nums2)
        {
            int nums1Max = int.MinValue;
            int nums1Min = int.MaxValue;
            int nums2Max = int.MinValue;
            int nums2Min = int.MaxValue;

            for (int i = 0; i < nums1.Length; i++)
            {
                nums1Max = Math.Max(nums1Max, nums1[i]);
                nums1Min = Math.Min(nums1Min, nums1[i]);
            }
            for (int i = 0; i < nums2.Length; i++)
            {
                nums2Max = Math.Max(nums2Max, nums2[i]);
                nums2Min = Math.Min(nums2Min, nums2[i]);
            }

            if (nums1Max < 0 && nums2Min > 0)
                return nums1Max * nums2Min;
            if (nums2Max < 0 && nums1Min > 0)
                return nums2Max * nums1Min;


            dp = new int?[nums1.Length][];
            for (int i = 0; i < nums1.Length; i++)
            {
                dp[i] = new int?[nums2.Length];
                Array.Fill(dp[i], null);
            }

            return RecursiveSolution(0, 0, nums1, nums2);
        }

        public int RecursiveSolution(int index1, int index2, int[] nums1, int[] nums2)
        {
            if (index1 == nums1.Length || index2 == nums2.Length)
                return 0;

            if (dp[index1][index2].HasValue)
                return dp[index1][index2].Value;

            //3 options
            //Select this 'pair'
            int max = (nums1[index1] * nums2[index2]) + RecursiveSolution(index1 + 1, index2 + 1, nums1, nums2);
            //Skip from num1
            max = Math.Max(max, RecursiveSolution(index1 + 1, index2, nums1, nums2));
            //Skip from num2
            max = Math.Max(max, RecursiveSolution(index1, index2 + 1, nums1, nums2));

            dp[index1][index2] = max;
            return max;
        }
    }
}
