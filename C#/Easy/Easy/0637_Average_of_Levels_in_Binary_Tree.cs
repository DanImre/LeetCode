using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Easy.Easy_104;

namespace Easy
{
    public class Medium_637
    {
        public Medium_637()
        {

        }
        public IList<double> AverageOfLevels(TreeNode root)
        {
            List<double> solution = new List<double>();

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                double sum = 0;
                int count = q.Count;
                for (int i = 0; i < count; i++)
                {
                    var curr = q.Dequeue();
                    sum += curr.val;
                    if(curr.left != null)
                        q.Enqueue(curr.left);
                    if (curr.right != null)
                        q.Enqueue(curr.right);
                }

                solution.Add(sum / count);
            }
            return solution;
        }
    }
}
