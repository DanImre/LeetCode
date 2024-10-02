using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_543
    {
        public Easy_543()
        {

        }
         
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public int maxPath = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            recursiveSolution(root);

            return maxPath;
        }
        public int recursiveSolution(TreeNode root)
        {
            if (root == null)
                return 0;

            int left = recursiveSolution(root.left);
            int right = recursiveSolution(root.right);

            maxPath = Math.Max(maxPath, left + right);

            return Math.Max(left, right) + 1;
        }
    }
}
