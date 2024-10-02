using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_11
    {
        public Medium_11()
        {
            //int[] height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }; //49
            //int[] height = new int[] { 1, 1}; //1
            int[] height = new int[] { 1, 1}; //1
            Console.WriteLine(MaxArea(height));
        }
        public int MaxArea(int[] height)
        {
            int maxSum = 0;

            int i = 0;
            int j = height.Length - 1;
            while (i < j)
            {
                maxSum = Math.Max(maxSum, (j - i) * Math.Min(height[i], height[j]));

                if (height[i] < height[j])
                    ++i;
                else
                    --j;
            }

            return maxSum;
        }
    }
}
