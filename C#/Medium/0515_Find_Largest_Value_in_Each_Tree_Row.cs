using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_105;

namespace Medium
{
    public class Medium_515
    {
        public Medium_515()
        {

        }

        public IList<int> LargestValues(TreeNode root)
        {
            if(root == null)
                return new List<int>();

            List<int> solution = new List<int>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                int qlen = q.Count;
                int max = int.MinValue;
                for (int i = 0; i < qlen; i++)
                {
                    var curr = q.Dequeue();
                    max = Math.Max(max, curr.val);
                    if (curr.left != null)
                        q.Enqueue(curr.left);
                    if (curr.right != null)
                        q.Enqueue(curr.right);

                }
                solution.Add(max);
            }

            return solution;
        }
    }
}
