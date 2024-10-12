import java.util.ArrayList;
import java.util.List;

public class _145_Binary_Tree_Postorder_Traversal {
    public List<Integer> postorderTraversal(TreeNode root) {
        List<Integer> solution = new ArrayList<Integer>();
        if (root == null)
            return solution;

        solution.addAll(postorderTraversal(root.left));
        solution.addAll(postorderTraversal(root.right));
        solution.add(root.val);
        return solution;
    }
}
