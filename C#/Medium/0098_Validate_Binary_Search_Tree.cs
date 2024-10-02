using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_105;

namespace Medium
{
    public class Medium_98
    {
        public Medium_98()
        {
            Console.WriteLine(int.MinValue);
            Console.WriteLine(int.MaxValue);
        }
        bool firstNodeIsSet = false;
        int prevNode = 0;
        //Inorder traversal, if for all elements : prev < curr, than it's correct
        public bool IsValidBST(TreeNode root)
        {
            if (root == null)
                return true;

            if (!IsValidBST(root.left))
                return false;

            if (!firstNodeIsSet)
            {
                firstNodeIsSet = true;
                prevNode = root.val;
            }
            else
            {
                if (prevNode >= root.val)
                    return false;

                prevNode = root.val;
            }    


            return IsValidBST(root.right);
        }
    }
}
