using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_105;

namespace Medium
{
    public class Medium_129
    {
        public Medium_129()
        {

        }
        public int sum = 0;
        public int SumNumbers(TreeNode root)
        {
            SumNumbersSeged(root, new List<TreeNode>() { root });
            return sum;
        }
        public void SumNumbersSeged(TreeNode root, List<TreeNode> currStack)
        {
            if (root.left == null && root.right == null)
            {
                for (int i = 0; i < currStack.Count; i++)
                    sum += currStack[i].val * (int)Math.Pow(10, currStack.Count - i - 1);
                return;
            }

            if (root.left != null)
            {
                currStack.Add(root.left);
                SumNumbersSeged(root.left, currStack);
                currStack.RemoveAt(currStack.Count - 1);
            }
            if (root.right != null)
            {
                currStack.Add(root.right);
                SumNumbersSeged(root.right, currStack);
                currStack.RemoveAt(currStack.Count - 1);
            }
        }
    }
}
