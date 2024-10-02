using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Easy.Easy_104;

namespace Easy
{
    public class Easy_938
    {
        public Easy_938()
        {

        }
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            if (root == null)
                return 0;

            if (root.val > high)
                return RangeSumBST(root.left, low, high);
            else if (root.val < low)
                return RangeSumBST(root.right, low, high);
            else
                return root.val + RangeSumBST(root.left, low, high) + RangeSumBST(root.right, low, high);
        }
    }
}
