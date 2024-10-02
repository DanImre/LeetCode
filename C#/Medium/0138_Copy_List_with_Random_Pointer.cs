namespace Medium
{
    public class Medium_138
    {
        // Definition for a Node.
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }
        public Medium_138()
        {

        }
        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return null;

            Node newHead = new Node(head.val);
            Node curr = newHead;
            curr.random = head.random;

            Node oldCurr = head;

            Dictionary<Node, Node> oldToNew = new Dictionary<Node, Node>();
            oldToNew.Add(head, newHead);

            oldCurr = oldCurr.next;

            while (oldCurr != null)
            {
                curr.next = new Node(oldCurr.val);
                curr = curr.next;
                curr.random = oldCurr.random;

                oldToNew.Add(oldCurr, curr);

                oldCurr = oldCurr.next;
            }

            curr = newHead;
            while (curr != null)
            {
                if(curr.random != null)
                    curr.random = oldToNew[curr.random];

                curr = curr.next;
            }

            return newHead;
        }
    }
}
