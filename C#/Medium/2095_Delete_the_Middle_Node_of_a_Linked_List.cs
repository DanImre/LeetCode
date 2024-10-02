using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_2;

namespace Medium
{
    public class Medium_2095
    {
        public Medium_2095()
        {

        }
        public ListNode DeleteMiddle(ListNode head)
        {
            if (head.next == null)
                return null;

            ListNode pre = head;
            ListNode slow = head;
            ListNode fast = head;
            while (fast.next != null && fast.next.next != null)
            {
                pre = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            if(fast.next != null)
            {
                pre = slow;
                slow = slow.next;
            }

            pre.next = slow.next;

            return head;
        }
    }
}
