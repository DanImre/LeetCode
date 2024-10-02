using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2305
    {
        public Medium_2305()
        {

        }

        public int DistributeCookies(int[] cookies, int k)
        {
            int[] currentState = new int[k];
            return recursiveSolution(currentState, cookies, 0);
        }

        public int recursiveSolution(int[] currentState, int[] cookies, int currIndex)
        {
            if (currIndex == cookies.Length)
                return currentState.Max();

            int solution = int.MaxValue;
            for (int i = 0; i < currentState.Length; i++)
            {
                if ((currentState.Length - i - 1) > (cookies.Length - currIndex - 1))
                    continue;

                currentState[i] += cookies[currIndex];
                solution = Math.Min(solution, recursiveSolution(currentState,cookies,(currIndex + 1)));
                currentState[i] -= cookies[currIndex];
            }

            return solution;
        }
    }
}
