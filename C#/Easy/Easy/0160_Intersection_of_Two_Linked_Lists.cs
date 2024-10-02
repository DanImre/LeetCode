using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_160
    {
        public Easy_160()
        {

        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            HashSet<ListNode> set = new HashSet<ListNode>();
            while (headA != null)
            {
                set.Add(headA);
                headA = headA.next;
            }

            while (headB != null)
            {
                if (!set.Add(headB))
                    return headB;
                headB = headB.next;
            }

            return null;
        }
    }
}
