using static Medium._Program;

namespace Medium
{
    public class _2265_Count_Nodes_Equal_to_Average_of_Subtree
    {
        public int AverageOfSubtree(TreeNode root)
        {
            return AverageOfSubtreeRecusrive(root).avgCount;
        }

        public (int avgCount, int sum, int count) AverageOfSubtreeRecusrive(TreeNode root)
        {
            if (root.left == null
                && root.right == null)
                return (1, root.val, 1);

            int solution = 0;
            int sum = root.val;
            int count = 1;
            if (root.left != null)
            {
                (int leftAvgCount, int leftSum, int leftCount) = AverageOfSubtreeRecusrive(root.left);

                solution += leftAvgCount;
                sum += leftSum;
                count += leftCount;
            }
            if (root.right != null)
            {
                (int rightAvgCount, int rightSum, int rightCount) = AverageOfSubtreeRecusrive(root.right);

                solution += rightAvgCount;
                sum += rightSum;
                count += rightCount;
            }

            if (sum / count == root.val)
                ++solution;

            return (solution, sum, count);
        }
    }
}
