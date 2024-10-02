using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Easy.Easy_104;

namespace Easy
{
    public class Easy_108
    {
        public Easy_108()
        {

        }
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBSTHelper(nums, 0, nums.Length);
        }

        public TreeNode SortedArrayToBSTHelper(int[] nums, int start, int end)
        {
            if (start == end)
                return null;

            int mid = (start + end) / 2;
            TreeNode tempRoot = new TreeNode(nums[mid], SortedArrayToBSTHelper(nums, start, mid), SortedArrayToBSTHelper(nums, mid + 1, end));

            return tempRoot;
        }
    }
}
