using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_513
    {
        public Medium_513() { }

        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null!, TreeNode right = null!)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        public int FindBottomLeftValue(TreeNode root)
        {
            int solution = 0;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                solution = q.Peek().val;
                int qCount = q.Count;
                while (qCount-- > 0)
                {
                    var curr = q.Dequeue();
                    if(curr.left != null)
                        q.Enqueue(curr.left);
                    if (curr.right != null)
                        q.Enqueue(curr.right);
                }
            }

            return solution;
        }
    }
}
