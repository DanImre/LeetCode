using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Easy
{
    public class Easy_104
    {
        //Definition for a binary tree node.
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
        public Easy_104()
        {

        }
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }
    }
}
