using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2038
    {
        public Medium_2038()
        {

        }
        public bool WinnerOfGame(string colors)
        {
            int stepsAlice = 0;
            int stepsBob = 0;

            int lengthSoFar = 0;
            char active = colors[0];
            foreach (var item in colors)
            {
                if (item == active)
                {
                    ++lengthSoFar;
                    continue;
                }


                if (active == 'A')
                    stepsAlice += Math.Max(0, lengthSoFar - 2);
                else
                    stepsBob += Math.Max(0, lengthSoFar - 2);

                active = active == 'A' ? 'B' : 'A';
                lengthSoFar = 1;
            }

            if (active == 'A') //Alice
                stepsAlice += Math.Max(0, lengthSoFar - 2);
            else
                stepsBob += Math.Max(0, lengthSoFar - 2);

            return stepsAlice > stepsBob;
        }
    }
}
