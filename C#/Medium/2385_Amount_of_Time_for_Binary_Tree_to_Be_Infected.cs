using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_105;

namespace Medium
{
    public class Medium_2385
    {
        public Medium_2385()
        {

        }

        public int AmountOfTime(TreeNode root, int start)
        {
            DFSSolution(root, start);
            return Max;
        }

        public int Max = 0;

        public int DFSSolution(TreeNode root, int start)
        {
            if (root == null)
                return 0;

            int left = DFSSolution(root.left, start);
            int right = DFSSolution(root.right, start);

            if (root.val == start)
            {
                Max = Math.Max(left, right);
                return -1;
            }

            if (left >= 0 && right >= 0)
                return Math.Max(left, right) + 1;

            Max = Math.Max(Max, Math.Abs(left) + Math.Abs(right));
            return Math.Min(left, right) - 1;
        }
    }
}
