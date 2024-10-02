using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_2540
    {
        public Easy_2540()
        {

        }
        public int GetCommon(int[] nums1, int[] nums2)
        {
            int first = 0;
            int second = 0;

            while (first < nums1.Length && second < nums2.Length)
            {
                if (nums1[first] == nums2[second])
                    return nums1[first];
                if (nums1[first] < nums2[second])
                    ++first;
                else
                    ++second;
            }

            return -1;
        }
    }
}
