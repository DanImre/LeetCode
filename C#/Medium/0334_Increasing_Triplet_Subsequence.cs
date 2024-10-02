using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_334
    {
        public Medium_334()
        {

        }
        public bool IncreasingTriplet(int[] nums)
        {
            if(nums.Length < 3) 
                return false;

            int min = int.MaxValue;
            int secondMin = int.MaxValue;

            foreach (var item in nums)
                if (min >= item)
                    min = item;
                else if (secondMin >= item)
                    secondMin = item;
                else
                    return true; // found a third element, hence there is a sequence

            return false;
        }
    }
}
