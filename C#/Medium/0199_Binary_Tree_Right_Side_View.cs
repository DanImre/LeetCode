using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_105;

namespace Medium
{
    public class Mediium_199
    {
        public Mediium_199()
        {

        }
        public IList<int> RightSideView(TreeNode root)
        {
            if(root == null)
                return new List<int>();

            List<int> solution = new List<int>();

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                int count = q.Count;
                for (int i = 0; i < count; i++)
                {
                    var act = q.Dequeue();
                    if (act.left != null)
                        q.Enqueue(act.left);
                    if (act.right != null)
                        q.Enqueue(act.right);

                    if(i == count-1)
                        solution.Add(act.val);
                }
            }

            return solution;
        }
    }
}
