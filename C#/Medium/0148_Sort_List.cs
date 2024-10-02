using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_2;

namespace Medium
{
    public class Medium_148
    {
        public Medium_148()
        {

        }

        //Using minheap, should be O(n * log n) time and O(n) memory
        public ListNode SortList(ListNode head)
        {
            if (head == null)
                return null;

            PriorityQueue<ListNode, int> prq = new PriorityQueue<ListNode, int>();
            while (head != null)
            {
                prq.Enqueue(head, head.val);
                head = head.next;
            }

            ListNode root = prq.Dequeue();
            ListNode temp = root;
            while (prq.Count != 0)
            {
                temp.next = prq.Dequeue();
                temp = temp.next;
            }

            temp.next = null;

            return root;
        }
    }
}
