import java.util.ArrayList;
import java.util.List;

public class _144_Binary_Tree_Preorder_Traversal {
    public List<Integer> preorderTraversal(TreeNode root) {
        List<Integer> solution = new ArrayList<Integer>();
        if (root == null)
            return solution;

        solution.add(root.val);
        solution.addAll(preorderTraversal(root.left));
        solution.addAll(preorderTraversal(root.right));
        return solution;
    }
}
