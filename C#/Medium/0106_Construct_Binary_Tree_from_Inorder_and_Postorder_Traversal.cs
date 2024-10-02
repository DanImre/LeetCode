using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_105;

namespace Medium
{
    public class Medium_106
    {
        public Medium_106()
        {

        }
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            return BuildTreeWithoutArrayCopy(inorder, postorder, 0, inorder.Length, 0, postorder.Length);
        }

        public TreeNode BuildTreeWithoutArrayCopy(int[] inorder, int[] postorder, int inorderIndexStart, int inorderIndexEnd, int postorderIndexStart, int postorderIndexEnd)
        {
            if (inorderIndexStart - inorderIndexEnd == 0)
                return null;
            if (inorderIndexStart - inorderIndexEnd == 1)
                return new TreeNode(inorder[inorderIndexStart]);

            TreeNode curr = new TreeNode(postorder[postorderIndexEnd - 1]);

            int currPlusIndex = 0;
            while (inorder[currPlusIndex + inorderIndexStart] != curr.val)
                ++currPlusIndex;

            curr.left = BuildTreeWithoutArrayCopy(inorder, postorder, inorderIndexStart, inorderIndexStart + currPlusIndex, postorderIndexStart, postorderIndexStart + currPlusIndex);
            curr.right = BuildTreeWithoutArrayCopy(inorder, postorder, inorderIndexStart + currPlusIndex + 1, inorderIndexEnd, postorderIndexStart + currPlusIndex, postorderIndexEnd - 1);

            return curr;
        }
    }
}
