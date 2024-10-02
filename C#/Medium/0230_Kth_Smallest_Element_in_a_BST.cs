using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_105;

namespace Medium
{
    internal class Medium_230
    {
        public Medium_230()
        {

        }
        //Inorder traversal, nad lower k till 1
        int globalK;
        public int KthSmallest(TreeNode root, int k)
        {
            globalK = k;

            return inorder(root);
        }
        public int inorder(TreeNode root)
        {
            if (root == null)
                return int.MaxValue;

            if (globalK < 0)
                return int.MaxValue;

            int solution = inorder(root.left);
            --globalK;

            if (globalK == 0)
                return root.val;

            if(globalK > 0)
                solution = Math.Min(solution, inorder(root.right));

            return solution;
        }
    }
}
