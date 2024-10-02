using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_514
    {
        public Hard_514()
        {

        }
        public int FindRotateSteps(string ring, string key)
        {
            Dictionary<(int, int), int> dp = new Dictionary<(int, int), int>();

            int getDistBetween(int currIndex, int nextIndex)
            {
                int direct = Math.Abs(currIndex - nextIndex);
                int wrapAroung = ring.Length - direct;

                return Math.Min(wrapAroung, direct);
            }

            int recursiveSolution(int ringIndex, int keyIndex, int minSteps)
            {
                if (dp.ContainsKey((ringIndex, keyIndex)))
                    return dp[(ringIndex, keyIndex)];

                if (keyIndex == key.Length)
                    return 0;

                for (int i = 0; i < ring.Length; i++)
                    if (ring[i] == key[keyIndex])
                    {
                        int totalSteps = getDistBetween(ringIndex, i) + 1 + recursiveSolution(i, keyIndex + 1, int.MaxValue);

                        minSteps = Math.Min(minSteps, totalSteps);

                        dp[(ringIndex, keyIndex)] = minSteps;
                    }

                return minSteps;
            }

            return recursiveSolution(0, 0, int.MaxValue);
        }
    }
}
