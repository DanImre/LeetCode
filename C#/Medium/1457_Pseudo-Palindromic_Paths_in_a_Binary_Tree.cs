using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1457
    {
        public Medium_1457()
        {

        }

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

        public bool[] Buffer = new bool[10];
        public int PseudoPalindromicPaths(TreeNode root)
        {
            return RecursiveSolution(root);
        }

        public int RecursiveSolution(TreeNode root)
        {
            Buffer[root.val] = !Buffer[root.val];
            if (root.left == null && root.right == null)
            {
                int temp = (Buffer.Count(kk => kk) == 1) ? 1 : 0;
                Buffer[root.val] = !Buffer[root.val];
                return temp;
            }

            int solution = 0;
            if (root.left != null)
                solution += RecursiveSolution(root.left);
            if (root.right != null)
                solution += RecursiveSolution(root.right);

            Buffer[root.val] = !Buffer[root.val];
            return solution;
        }
    }
}
