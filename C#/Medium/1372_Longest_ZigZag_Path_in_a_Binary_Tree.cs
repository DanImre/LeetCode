using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_105;

namespace Medium
{
    public class Medium_1372
    {
        public Medium_1372()
        {

        }
        public int LongestZigZag(TreeNode root)
        {
            return Math.Max(ZigZagHelper(root.left, true, 0), ZigZagHelper(root.right, false, 0));
        }
        public int ZigZagHelper(TreeNode root, bool left, int count)
        {
            if (root == null)
                return count;

            if (left)
                return Math.Max(ZigZagHelper(root.left,true, 0), ZigZagHelper(root.right, false, count + 1));

            return Math.Max(ZigZagHelper(root.right, false, 0), ZigZagHelper(root.left, true, count + 1));
        }
    }
}
