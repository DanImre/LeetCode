using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Medium.Medium_138;

namespace Medium
{
    public class Medium_105
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
        public Medium_105()
        {
            TreeNode temp = BuildTree(new int[] { 3, 9, 20, 15, 7 },
                new int[] { 9, 3, 15, 20, 7 });

            printTreePreorder(temp);
        }

        public void printTreePreorder(TreeNode root)
        {
            if (root == null)
                return;

            Console.WriteLine(root.val);
            printTreePreorder(root.left);
            printTreePreorder(root.right);
        }

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0)
                return null;
            if (preorder.Length == 1)
                return new TreeNode(preorder[0]);

            TreeNode root = new TreeNode(preorder[0]);

            int length = 0;
            while (inorder[length] != preorder[0])
                ++length;

            int[] preorderForLeft = new int[length];
            int[] preorderForRight = new int[preorder.Length - length - 1];

            int[] inorderForLeft = new int[length];
            int[] inorderForRight = new int[preorder.Length];

            for (int i = 1; i <= length; i++)
            {
                preorderForLeft[i - 1] = preorder[i];
                inorderForLeft[i - 1] = inorder[i - 1];
            }
            for (int i = length + 1; i < preorder.Length; i++)
            {
                preorderForRight[i - 1 - length] = preorder[i];
                inorderForRight[i - 1 - length] = inorder[i];
            }

            root.left = BuildTree(preorderForLeft, inorderForLeft);
            root.right = BuildTree(preorderForRight, inorderForRight);

            return root;
        }
    }
}