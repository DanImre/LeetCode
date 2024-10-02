using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Easy.Easy_104;

namespace Easy
{
    public class Easy_606
    {
        public Easy_606()
        {

        }
        public string Tree2str(TreeNode root)
        {
            string solution = root.val.ToString();
            if (root.left != null)
                solution += "(" + Tree2str(root.left) + ")";
            if (root.right != null)
            {
                if (root.left == null)
                    solution += "()";
                solution += "(" + Tree2str(root.right) + ")";
            }

            return solution;
        }
    }
}
