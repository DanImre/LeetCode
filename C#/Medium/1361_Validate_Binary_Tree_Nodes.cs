using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1361
    {
        public Medium_1361()
        {

        }
        public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
        {
            int root = FindRoot(n, leftChild, rightChild);
            if (root == -1)
                return false;
            HashSet<int> visited = new HashSet<int>();
            Queue<int> q = new Queue<int>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                var curr = q.Dequeue();

                if (visited.Contains(curr))
                    return false;

                if (leftChild[curr] != -1)
                    q.Enqueue(leftChild[curr]);
                if (rightChild[curr] != -1)
                    q.Enqueue(rightChild[curr]);

                visited.Add(curr);
            }

            int notPresentNodeCount = 0;
            for (int i = 0; i < n; i++)
                if ((leftChild[i] != -1 || rightChild[i] != -1) && !visited.Contains(i))
                    return false;                    

            return (visited.Count - notPresentNodeCount) == n;
        }

        public int FindRoot(int n, int[] leftChild, int[] rightChild)
        {
            HashSet<int> children = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                children.Add(leftChild[i]);
                children.Add(rightChild[i]);
            }

            for (int i = 0; i < n; i++)
                if (!children.Contains(i))
                    return i;

            return -1;
        }
    }
}
