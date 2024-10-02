using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_643
    {
        public Easy_643()
        {
            Console.WriteLine(FindMaxAverage(
                new int[] { 1, 12, -5, -6, 50, 3 },
                4));
        }
        public double FindMaxAverage(int[] nums, int k)
        {
            double solution = 0;

            double tempSum = 0;
            for (int i = 0; i < k; i++)
                tempSum += nums[i];

            tempSum /= k;
            solution = tempSum;

            for (int i = k; i < nums.Length; i++)
            {
                tempSum += nums[i] / (double)k;
                tempSum -= nums[i - k] / (double)k;
                solution = Math.Max(solution, tempSum);
            }

            return solution;
        }
    }
}
