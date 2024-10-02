using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_1601
    {
        public Hard_1601()
        {

        }
        public int MaximumRequests(int n, int[][] requests)
        {
            int[] state = new int[n];
            return backTrackSolution(state, requests, 0, 0);
        }

        public int backTrackSolution(int[] state, int[][] requests, int requestIndex, int transfersCompelte)
        {
            if (requestIndex == requests.Length)
            {
                if (state.All(kk => kk == 0))
                    return transfersCompelte;
                else
                    return 0;
            }

            //Dont make transfer
            int solution = backTrackSolution(state, requests, (requestIndex + 1), transfersCompelte);

            --state[requests[requestIndex][0]];
            ++state[requests[requestIndex][1]];
            solution = Math.Max(solution, backTrackSolution(state, requests, (requestIndex + 1), (transfersCompelte + 1)));
            ++state[requests[requestIndex][0]];
            --state[requests[requestIndex][1]];

            return solution;
        }
    }
}
