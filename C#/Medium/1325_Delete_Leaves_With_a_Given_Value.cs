using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium._Program;

namespace Medium
{
    public class Medium_1325
    {
        public Medium_1325()
        {

        }
        public TreeNode RemoveLeafNodes(TreeNode root, int target)
        {
            root = ReconstructNodes(root, target);

            return root;
        }

        public TreeNode ReconstructNodes(TreeNode root, int target)
        {
            if (root.left != null)
                root.left = ReconstructNodes(root.left, target);
            if (root.right != null)
                root.right = ReconstructNodes(root.right, target);

            if (root.left == null && root.right == null && root.val == target)
                return null!;

            return root;
        }
    }
}
