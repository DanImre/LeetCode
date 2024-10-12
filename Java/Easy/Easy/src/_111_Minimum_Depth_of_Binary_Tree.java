public class _111_Minimum_Depth_of_Binary_Tree {
    public int minDepth(TreeNode root) {
        if (root == null)
            return 0;

        return helper(root);
    }

    public int helper(TreeNode root) {
        if (root.left == null && root.right == null) // Leaf node
            return 1;

        return Math.min(
                root.left == null ? Integer.MAX_VALUE : helper(root.left),
                root.right == null ? Integer.MAX_VALUE : helper(root.right)
        ) + 1;
    }
}
