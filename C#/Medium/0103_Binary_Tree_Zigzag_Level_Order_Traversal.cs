using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_105;

namespace Medium
{
    public class Medium_103
    {
        public Medium_103()
        {

        }
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            if (root == null)
                return new List<IList<int>>();

            List<IList<int>> solution = new List<IList<int>>();

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            bool odd = true;

            while (q.Count != 0)
            {
                if (odd)
                    solution.Add(q.Select(kk => kk.val).ToList());
                else
                    solution.Add(q.Select(kk => kk.val).Reverse().ToList());

                odd = !odd;

                int count = q.Count;
                while (count != 0)
                {
                    --count;
                    var curr = q.Dequeue();
                    if (curr.left != null)
                        q.Enqueue(curr.left);
                    if (curr.right != null)
                        q.Enqueue(curr.right);
                }
            }

            return solution;
        }
    }
}
