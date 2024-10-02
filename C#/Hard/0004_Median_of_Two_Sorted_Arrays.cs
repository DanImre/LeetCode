using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_4
    {
        public Hard_4()
        {

        }
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int n = nums1.Length + nums2.Length;

            if ((nums1.Length + nums2.Length) % 2 == 1)
                return recursive(nums1, nums2, n / 2, 0, nums1.Length - 1, 0, nums2.Length - 1);
            else
                return (recursive(nums1, nums2, n / 2, 0, nums1.Length - 1, 0, nums2.Length - 1) + recursive(nums1, nums2, n / 2 - 1, 0, nums1.Length - 1, 0, nums2.Length - 1)) / 2.0;
        }

        public int recursive(int[] nums1, int[] nums2, int k, int start1, int end1, int start2, int end2)
        {
            if (end1 < start1)
                return nums2[k - start1];
            if(end2 < start2)
                return nums1[k - start2];

            int middle1 = (start1 + end1) / 2;
            int middle2 = (start2 + end2) / 2;

            if(middle1 + middle2 < k) //Discard the first half
            {
                if (nums1[middle1] > nums2[middle2])
                    return recursive(nums1, nums2, k, start1, end1, middle2 + 1, end2);
                else
                    return recursive(nums1, nums2, k, middle1 + 1, end1, start2, end2);
            }

            //Discard the second half
            if (nums1[middle1] > nums2[middle2])
                return recursive(nums1, nums2, k, start1, middle1 - 1, start2, end2);
            else
                return recursive(nums1, nums2, k, start1, end1, start2, middle2 - 1);
        }
    }
}
