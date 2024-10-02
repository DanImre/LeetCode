using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    internal class _0142_Linked_List_Cycle_II
    {

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null!;
            }
        }

        public ListNode DetectCycle(ListNode head)
        {
            HashSet<ListNode> set = new HashSet<ListNode>();
            while (head != null)
            {
                if (!set.Add(head))
                    return head;

                head = head.next;
            }
            return null;
        }
    }
}
