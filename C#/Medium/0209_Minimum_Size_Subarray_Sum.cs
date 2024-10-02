using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_209
    {
        public Medium_209()
        {
            /*
            //2
            int[] nums = new int[] { 2, 3, 1, 2, 4, 3 };
            int target = 7;

            //1
            int[] nums = new int[] { 1, 4, 4 };
            int target = 4;
            
            //0
            int[] nums = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
            int target = 11;
            */
            //3
            int[] nums = new int[] { 2, 3, 1, 2, 4, 3 };
            int target = 9;
            /*
            //1
            int[] nums = new int[] { 1, 3, 4 };
            int target = 4;*/

            Console.WriteLine(MinSubArrayLen(target, nums));
        }

        public int MinSubArrayLen(int target, int[] nums)
        {
            int solution = int.MaxValue; //min search

            int i = 0;
            int j = 0;

            int tempSum = 0;
            while (j < nums.Length)
            {
                tempSum += nums[j];

                while (tempSum >= target)
                {
                    solution = Math.Min(solution, j - i + 1);
                    tempSum -= nums[i];
                    ++i;
                }

                ++j;
            }

            if (solution == int.MaxValue)
                return 0;

            return solution;
        }
    }
}
