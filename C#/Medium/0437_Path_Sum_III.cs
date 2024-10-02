using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_105;

namespace Medium
{
    public class Medium_437
    {
        public Medium_437()
        {
            TreeNode testcase = new TreeNode(1, new TreeNode(-2, new TreeNode(1, new TreeNode(-1, null, null), null), new TreeNode(3, null, null)), new TreeNode(-3, new TreeNode(-2), null));
            Console.WriteLine(PathSum(testcase, -1)); //4
        }
        public int PathSum(TreeNode root, int targetSum)
        {
            if(root == null)
                return 0;

            return PathSumFromCurrentNode(root, targetSum)
                + PathSum(root.left, targetSum)
                + PathSum(root.right, targetSum);
        }
        public int PathSumFromCurrentNode(TreeNode root, long targetSum)
        {
            if (root == null)
                return 0;

            return (targetSum == root.val ? 1 : 0)
                + PathSumFromCurrentNode(root.left, targetSum - root.val)
                + PathSumFromCurrentNode(root.right, targetSum - root.val);
        }
    }
}
