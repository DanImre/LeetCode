using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_105;

namespace Medium
{
    public class Medium_236
    {
        public Medium_236()
        {

        }
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;
            if (root == p)
                return p;
            if(root == q)
                return q;

            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);

            if ((right == p && left == q) || (right == q && left == p))
                return root;

            if (left != null)
                return left;
            if (right != null)
                return right;

            return null;
        }
    }
}
