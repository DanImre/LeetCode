using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_105;

namespace Medium
{
    public class Medium_173
    {
        public Medium_173()
        {

        }
        public class BSTIterator
        {
            private Queue<int> inorder;
            public BSTIterator(TreeNode root)
            {
                inorder = inorder = new Queue<int>();
                GetInorder(root);
            }

            public int Next()
            {
               return inorder.Dequeue();
            }

            private void GetInorder(TreeNode root)
            {
                if (root == null)
                    return;

                GetInorder(root.left);
                inorder.Enqueue(root.val);
                GetInorder(root.right);
            }

            public bool HasNext()
            {
                return inorder.Count != 0;
            }
        }

    }
}
