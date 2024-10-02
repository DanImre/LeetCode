using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium._Program;

namespace Medium
{
    public class Medium_623
    {
        public Medium_623()
        {

        }
        public TreeNode AddOneRow(TreeNode root, int val, int depth)
        {
            if (depth == 1)
                return new TreeNode(val, root, null!);

            void recursiveSolution(TreeNode root, int d)
            {
                if (depth - 1 == d)
                {
                    root.left = new TreeNode(val, root.left, null!);
                    root.right = new TreeNode(val, null!, root.right);
                    return;
                }
                if (root.left != null)
                    recursiveSolution(root.left, d + 1);
                if (root.right != null)
                    recursiveSolution(root.right, d + 1);
            }
            recursiveSolution(root, 1);
            return root;
        }
    }
}
