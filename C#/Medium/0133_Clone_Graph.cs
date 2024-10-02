using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_133
    {
        public Medium_133()
        {

        }
        // Definition for a Node.
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }
        public Node CloneGraph(Node node)
        {
            if (node == null)
                return null;

            Dictionary<Node, Node> oldtoNew = new Dictionary<Node, Node>();
            Node newHead = new Node(node.val, node.neighbors.ToList());
            oldtoNew.Add(node, newHead);

            Queue<Node> q = new Queue<Node>();
            foreach (var item in node.neighbors)
                q.Enqueue(item);

            while (q.Count != 0)
            {
                var curr = q.Dequeue();
                if (oldtoNew.ContainsKey(curr))
                    continue;

                Node newNode = new Node(curr.val, curr.neighbors.ToList());
                oldtoNew.Add(curr, newNode);

                foreach (var item in curr.neighbors)
                    q.Enqueue(item);
            }

            q.Enqueue(newHead);
            HashSet<Node> visited = new HashSet<Node>();
            while (q.Count != 0)
            {
                var curr = q.Dequeue();
                if (!visited.Add(curr))
                    continue;

                curr.neighbors = curr.neighbors.Select(kk => oldtoNew[kk]).ToList();
                foreach (var item in curr.neighbors)
                    q.Enqueue(item);
            }

            return newHead;
        }
    }
}
