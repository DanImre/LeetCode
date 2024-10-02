using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2300
    {
        public Medium_2300()
        {

        }
        public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            Array.Sort(potions);

            int[] solution = new int[spells.Length];
            for (int i = 0; i < spells.Length; i++)
            {
                int start = 0;
                int end = potions.Length;
                while (start < end)
                {
                    int mid = start + (end - start) / 2;

                    if ((long)potions[mid] * spells[i] < success)
                        start = mid + 1;
                    else
                        end = mid;
                }

                solution[i] = potions.Length - start;
            }

            return solution;
        }
    }
}
