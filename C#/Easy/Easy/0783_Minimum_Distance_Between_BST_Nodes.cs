using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Easy.Easy_104;

namespace Easy
{
    public class Easy_783
    {
        public Easy_783()
        {

        }
        //inorder -> sorted list
        public int MinDiffInBST(TreeNode root)
        {
            inorder(root);

            return minDistance;
        }
        int lastValue = -1000000000; //Larger than limit
        int minDistance = int.MaxValue;
        public void inorder(TreeNode root)
        {
            if (root == null)
                return;

            inorder(root.left);

            minDistance = Math.Min(minDistance, root.val - lastValue);
            lastValue = root.val;

            inorder(root.right);
        }
    }
}
