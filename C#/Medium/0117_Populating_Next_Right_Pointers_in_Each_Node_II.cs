using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_117
    {
        // Definition for a Node.
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
        public Medium_117()
        {

        }
        public Node Connect(Node root)
        {
            if (root == null)
                return null;

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                Node prevNode = q.Dequeue();

                int count = q.Count;

                if (prevNode.left != null)
                    q.Enqueue(prevNode.left);
                if (prevNode.right != null)
                    q.Enqueue(prevNode.right);

                while (count != 0)
                {
                    --count;
                    Node currNode = q.Dequeue();

                    prevNode.next = currNode;
                    prevNode = currNode;

                    if (currNode.left != null)
                        q.Enqueue(currNode.left);
                    if (currNode.right != null)
                        q.Enqueue(currNode.right);
                }
            }

            return root;
        }
    }
}
