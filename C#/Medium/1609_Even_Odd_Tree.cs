using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1609
    {

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

        public bool IsEvenOddTree(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            int parity = 0;
            while (q.Count > 0)
            {
                int qCount = q.Count;
                if (parity == 0)
                {
                    int lastElement = int.MinValue;
                    while (qCount-- > 0)
                    {
                        var curr = q.Dequeue();
                        if (curr.val % 2 == parity || lastElement >= curr.val)
                            return false;

                        lastElement = curr.val;
                        if (curr.left != null)
                            q.Enqueue(curr.left);
                        if (curr.right != null)
                            q.Enqueue(curr.right);
                    }
                }
                else
                {
                    int lastElement = int.MaxValue;
                    while (qCount-- > 0)
                    {
                        var curr = q.Dequeue();
                        if (curr.val % 2 == parity || lastElement <= curr.val)
                            return false;

                        lastElement = curr.val;
                        if (curr.left != null)
                            q.Enqueue(curr.left);
                        if (curr.right != null)
                            q.Enqueue(curr.right);
                    }
                }
                parity = (parity + 1) % 2;
            }

            return true;
        }
    }
}
