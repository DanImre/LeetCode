using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_105;

namespace Medium
{
    public class Medium_1448
    {
        public Medium_1448()
        {

        }
        public int GoodNodes(TreeNode root)
        {
            //root is not null
            return 1 + GoodNodesRecursive(root.left, root.val) + GoodNodesRecursive(root.right, root.val);
        }
        public int GoodNodesRecursive(TreeNode root, int max)
        {
            if (root == null)
                return 0;

            if (root.val >= max)
                return 1 + GoodNodesRecursive(root.left, root.val) + GoodNodesRecursive(root.right, root.val);

            return GoodNodesRecursive(root.left, max) + GoodNodesRecursive(root.right, max);
        }
    }
}
