using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_105;

namespace Medium
{
    public class Medium_1026
    {
        public Medium_1026()
        {

        }

        public int MaxAncestorDiff(TreeNode root)
        {
            return Math.Max(RecursiveSolution(root.val, root.val, root.left), RecursiveSolution(root.val, root.val, root.right));
        }

        public int RecursiveSolution(int min, int max, TreeNode root)
        {
            if (root == null)
                return 0;

            int solution = Math.Max(root.val - min, max - root.val);
            int newMin = Math.Min(min, root.val);
            int newMax = Math.Max(max, root.val);

            return Math.Max(solution, Math.Max(RecursiveSolution(newMin, newMax, root.left), RecursiveSolution(newMin, newMax, root.right)));
        }
    }
}
