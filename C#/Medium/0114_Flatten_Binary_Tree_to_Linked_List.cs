using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static Medium.Medium_105;

namespace Medium
{
    public class Medium_114
    {
        public Medium_114()
        {

        }

        public void Flatten(TreeNode root)
        {
            if (root == null)
                return;

            preOrder(root);
        }

        public TreeNode preOrder(TreeNode root)
        {
            if(root.left == null || root.right == null)
            {
                if (root.left == null && root.right == null)
                    return root;
                if (root.left != null)
                    root.right = root.left;

                root.left = null;
                return preOrder(root.right);
            }

            TreeNode last = preOrder(root.left);
            TreeNode returnValue = preOrder(root.right);

            var right = root.right;
            root.right = root.left;
            last.right = right;

            root.left = null;

            return returnValue;
        }
    }
}
