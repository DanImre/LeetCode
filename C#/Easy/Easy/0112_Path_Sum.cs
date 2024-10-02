using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Easy.Easy_104;

namespace Easy
{
    public class Easy_112
    {
        public Easy_112()
        {
            
        }

        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null)
                return false;

            return HasPathSumRootNotNull(root, targetSum);
        }

        public bool HasPathSumRootNotNull(TreeNode root, int targetSum)
        {
            if (root.left == null && root.right == null && targetSum - root.val == 0)
                return true;

            if ((root.left != null && HasPathSum(root.left, targetSum - root.val))
                || (root.right != null && HasPathSum(root.right, targetSum - root.val)))
                return true;

            return false;
        }
    }
}
