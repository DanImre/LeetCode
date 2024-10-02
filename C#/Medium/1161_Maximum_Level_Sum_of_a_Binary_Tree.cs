using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_105;

namespace Medium
{
    public class Medium_1161
    {
        public Medium_1161()
        {

        }
        public int MaxLevelSum(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            int max = root.val;
            int solution = 1;
            int level = 0;
            while (q.Count != 0)
            {
                ++level;
                int qCount = q.Count;
                int tempMax = 0;
                for (int i = 0; i < qCount; i++)
                {
                    var curr = q.Dequeue();
                    tempMax += curr.val;
                    if (curr.left != null)
                        q.Enqueue(curr.left);
                    if (curr.right != null)
                        q.Enqueue(curr.right);
                }

                if(tempMax > max)
                {
                    solution = level;
                    max = tempMax;
                }
            }

            return solution;
        }
    }
}
