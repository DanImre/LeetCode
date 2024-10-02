using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hard.Hard_124;

namespace Hard
{
    public class Hard_124
    {
        public Hard_124()
        {

        }

        //definition for a binary tree node.
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

        public int bestSumOfPath;
        public int MaxPathSum(TreeNode root)
        {
            bestSumOfPath = root.val;

            int helper = MaxPathSumHelper(root);
            bestSumOfPath = Math.Max(bestSumOfPath, helper);

            return bestSumOfPath;
        }

        public int MaxPathSumHelper(TreeNode root)
        {
            if (root.left == null || root.right == null)
            {
                if (root.left == null && root.right == null)
                {
                    bestSumOfPath = Math.Max(bestSumOfPath, root.val);
                    return root.val;
                }
                else if(root.left == null)
                {
                    int best = Math.Max(root.val, root.val + MaxPathSumHelper(root.right));
                    bestSumOfPath = Math.Max(bestSumOfPath, best);

                    return best;
                }
                else
                {
                    int best = Math.Max(root.val, root.val + MaxPathSumHelper(root.left));
                    bestSumOfPath = Math.Max(bestSumOfPath, best);

                    return best;
                }
            }

            //left and right isn't null

            int bestOnLeft = MaxPathSumHelper(root.left);
            int bestOnRight = MaxPathSumHelper(root.right);

            bestSumOfPath = Math.Max(bestSumOfPath, bestOnLeft + root.val + bestOnRight);

            int BestFromTheTwo = Math.Max(root.val + bestOnLeft, root.val + bestOnRight);
            int allAroundBest = Math.Max(BestFromTheTwo, root.val);

            bestSumOfPath = Math.Max(bestSumOfPath, allAroundBest);

            return allAroundBest;
        }
    }
}
