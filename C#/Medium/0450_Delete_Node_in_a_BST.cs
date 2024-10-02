using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_105;

namespace Medium
{
    public class Medium_450
    {
        public Medium_450()
        {

        }
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
                return null;

            if (key < root.val)
            {
                root.left = DeleteNode(root.left, key);
                return root;
            }
            if (key > root.val)
            {
                root.right = DeleteNode(root.right, key);
                return root;
            }

            if (root.left == null && root.right == null)
                return null;
            if (root.left == null)
                return root.right;
            if (root.right == null)
                return root.left;

            TreeNode temp = root.right;
            while (temp.left != null)
                temp = temp.left;

            root.val = temp.val;
            root.right = DeleteNode(root.right, temp.val);

            return root;
        }
    }
}
