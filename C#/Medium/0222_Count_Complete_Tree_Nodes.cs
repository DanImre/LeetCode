using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_105;

namespace Medium
{
    public class Medium_222
    {
        public Medium_222()
        {

        }
        //O(n) solution:
        public int CountNodes2(TreeNode root)
        {
            if (root == null)
                return 0;

            return 1 + CountNodes2(root.left) + CountNodes2(root.right);
        }

        //Idea: binary search + log(n) traversal
        public int CountNodes(TreeNode root)
        {
            if (root == null)
                return 0;
            if (root.left == null && root.right == null)
                return 1;

            int height = 0;
            TreeNode temp = root;
            while (temp != null)
            {
                ++height;
                temp = temp.left;
            }

            int sum = 1;
            for (int i = 1; i < height - 1; i++)
                sum += (int)Math.Pow(2, i);

            int start = 0;
            int end = height - 2;

            TreeNode curr = root;
            while (start != end)
            {
                curr = root;
                int midway = (start + end) / 2;

                int i = 0;
                while (i < height - 2 - midway)
                {
                    curr = curr.left;
                    ++i;
                }
                while (i < height-2)
                {
                    curr = curr.right;
                    ++i;
                }

                if (curr.right != null || curr.left != null)
                    start = midway + 1;
                else
                    end = midway;
            }
            curr = root;

            int j = 0;
            while (j < height - 2 - start)
            {
                curr = curr.left;
                ++j;
            }
            while (j < height - 2)
            {
                curr = curr.right;
                ++j;
            }

            sum += 2 * start;

            Console.WriteLine(curr.val + " " + start);

            if (curr.left != null)
                ++sum;
            if (curr.right != null)
                ++sum;

            return sum;
        }
    }
}
