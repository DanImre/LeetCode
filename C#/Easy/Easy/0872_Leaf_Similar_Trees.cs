using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Easy.Easy_104;

namespace Easy
{
    public class Easy_872
    {
        public Easy_872()
        {

        }
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            List<int> leafs1 = new List<int>();
            getLeaf(root1, ref leafs1);
            List<int> leafs2 = new List<int>();
            getLeaf(root2, ref leafs2);

            if (leafs1.Count != leafs2.Count)
                return false;

            for (int i = 0; i < leafs1.Count; i++)
                if (leafs1[i] != leafs2[i])
                    return false;

            return true;
        }
        public void getLeaf(TreeNode root, ref List<int> list)
        {
            if(root.left == null && root.right == null)
            {
                list.Add(root.val);
                return;
            }


            if (root.left != null)
                getLeaf(root.left, ref list);
            if (root.right != null)
                getLeaf(root.right, ref list);
        }
    }
}
