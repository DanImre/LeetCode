using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1431
    {
        public Easy_1431()
        {

        }
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            int max = candies.Max();

            bool[] solution = new bool[candies.Length];
            for (int i = 0; i < candies.Length; i++)
                solution[i] = candies[i] + extraCandies >= max;

            return solution;
        }
    }
}
