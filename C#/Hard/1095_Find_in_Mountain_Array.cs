using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    internal class Hard_1095
    {
        public Hard_1095()
        {

        }
        // This is MountainArray's API interface.
        // You should not implement it, or speculate about its implementation
        public class MountainArray
        {
            public int Get(int index) { return 0; }
            public int Length() { return 0; }
        }
        public int FindInMountainArray(int target, MountainArray mountainArr)
        {
            //The tip of the mountain can't be the first or last element
            int start = 1;
            int end = mountainArr.Length() - 2;
            while (start != end)
            {
                int mid = start + (end - start) / 2;

                if (mountainArr.Get(mid) < mountainArr.Get(mid + 1))
                    start = mid + 1;
                else
                    end = mid;
            }
            int topOfTheMountain = start;

            //Search for it in the first half
            start = 0;
            end = topOfTheMountain;
            while (start != end)
            {
                int mid = start + (end - start) / 2;

                if (mountainArr.Get(mid) < target)
                    start = mid + 1;
                else
                    end = mid;
            }
            if (mountainArr.Get(start) == target)
                return start;

            //Search in the second half
            start = topOfTheMountain + 1;
            end = mountainArr.Length() - 1;
            while (start != end)
            {
                int mid = start + (end - start) / 2;

                if (mountainArr.Get(mid) > target)
                    start = mid + 1;
                else
                    end = mid;
            }
            if (mountainArr.Get(start) == target)
                return start;

            return -1;
        }
    }
}
