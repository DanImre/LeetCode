using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Easy.Easy_104;

namespace Easy
{
    public class Easy_226
    {
        public Easy_226()
        {

        }
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;

            var left = root.left;
            root.left = root.right;
            root.right = left;

            InvertTree(root.left);
            InvertTree(root.right);

            return root;
        }
    }
}