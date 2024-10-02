using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1679
    {
        public Medium_1679()
        {

        }
        public int MaxOperations(int[] nums, int k)
        {
            int solution = 0;

            Dictionary<int, int> wantedNumbers = new Dictionary<int, int>();
            foreach (var item in nums)
                if (wantedNumbers.ContainsKey(item))
                {
                    if (wantedNumbers[item] == 1)
                        wantedNumbers.Remove(item);
                    else
                        --wantedNumbers[item];

                    ++solution;
                }
                else
                {
                    if (!wantedNumbers.ContainsKey(k - item))
                        wantedNumbers.Add(k - item, 1);
                    else
                        ++wantedNumbers[k - item];
                }

            return solution;
        }
    }
}
