using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_948
    {
        public Medium_948() { }
        public int BagOfTokensScore(int[] tokens, int power)
        {
            Array.Sort(tokens);
            int left = 0;
            int right = tokens.Length - 1;

            int solution = 0;
            while (left <= right)
                if (tokens[left] <= power)
                {
                    power -= tokens[left++];
                    ++solution;
                }
                else if (left < right && solution > 0)
                {
                    power += tokens[right--];
                    --solution;
                }
                else
                    return solution;

            return solution;
        }
    }
}
