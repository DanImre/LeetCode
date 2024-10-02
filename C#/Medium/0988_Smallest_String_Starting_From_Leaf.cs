using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium._Program;

namespace Medium
{
    public class Medium_988
    {
        public Medium_988()
        {

        }
        private string smallest = null!;
        public string SmallestFromLeaf(TreeNode root)
        {
            Helper(root, "");
            return smallest;
        }
        private void Helper(TreeNode root, string curr)
        {
            curr = ((char)('a' + root.val)) + curr;

            if (root.left == null && root.right == null)
            {
                if(smallest == null)
                    smallest = curr;
                else
                    smallest = MyCompareTo(smallest, curr) < 0 ? smallest : curr;
                return;
            }

            if (root.left != null)
                Helper(root.left, curr);
            if (root.right != null)
                Helper(root.right, curr);
        }

        private int MyCompareTo(string l, string r)
        {
            int i = 0;
            int n = Math.Min(l.Length, r.Length);
            while (i < n)
            {
                if (l[i] < r[i])
                    return -1;
                else if (l[i] > r[i])
                    return 1;
                ++i;
            }

            if (l.Length < r.Length)
                return -1;
            else if (l.Length > r.Length)
                return 1;

            return 0;
        }
    }
}
