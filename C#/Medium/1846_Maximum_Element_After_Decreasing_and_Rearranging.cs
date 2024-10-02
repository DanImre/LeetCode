using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1846
    {
        public Medium_1846()
        {

        }
        public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
        {
            Array.Sort(arr);
            int solution = 1;
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] >= solution + 1)
                    ++solution;

            return solution;
        }
    }
}
