using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_042
    {
        public Hard_042()
        {
            //6
            Console.WriteLine(Trap2(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
            //9
            Console.WriteLine(Trap2(new int[] { 4, 2, 0, 3, 2, 5 }));
        }

        //Time limit exceeded
        public static int Trap(int[] height)
        {
            int solution = 0;

            int startIndex = 0;
            while (startIndex + 1 < height.Length && height[startIndex] < height[startIndex + 1])
                ++startIndex;

            if (startIndex == height.Length - 1)
                return 0;

            int min = height.Min();
            if (min != 0)
                for (int i = 0; i < height.Length; i++)
                    height[i] -= min;

            while (true)
            {
                int firstAboveZero = -1;
                for (int i = startIndex; i < height.Length; i++)
                {
                    --height[i];
                    if (height[i] < 0)
                        continue;

                    if (firstAboveZero == -1)
                    {
                        firstAboveZero = i;
                        startIndex = i;
                    }
                    else
                    {
                        solution += i - firstAboveZero - 1;
                        firstAboveZero = i;
                    }
                }

                if (firstAboveZero == -1)
                    break;
            }

            return solution;
        }

        //Prefix and postfix max:
        //Waterlevel at index 'i' =
        //Min( Max(height[0],height[1] .. height[i-1], Max(height[i + 1],height[i + 2], .. height[n - 1])
        //Than just subtract the rock below
        public static int Trap2(int[] height)
        {
            int[] leftMax = new int[height.Length];
            int max = 0;
            for (int i = 0; i < height.Length; i++)
            {
                leftMax[i] = max;
                max = Math.Max(max, height[i]);
            }

            int[] rightMax = new int[height.Length];
            max = 0;
            for (int i = height.Length - 1; i >= 0; i--)
            {
                rightMax[i] = max;
                max = Math.Max(max, height[i]);
            }

            int solution = 0;

            for (int i = 0; i < height.Length; i++)
            {
                int waterheight = Math.Min(leftMax[i], rightMax[i]) - height[i];
                if (waterheight > 0)
                    solution += waterheight;
            }

            return solution;
        }
    }
}
