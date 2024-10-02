using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1578
    {
        public Medium_1578()
        {

        }

        public int MinCost(string colors, int[] neededTime)
        {
            int solution = 0;

            for (int i = 0; i < colors.Length; i++)
            {
                int j = i + 1;
                int max = neededTime[i];
                int sum = neededTime[i];
                while (j < colors.Length && colors[j] == colors[i])
                {
                    max = Math.Max(max, neededTime[j]);
                    sum += neededTime[j];
                    ++j;
                }

                if (j == i + 1)
                    continue;

                solution += sum - max;
                i = j - 1;
            }

            return solution;
        }
    }
}
