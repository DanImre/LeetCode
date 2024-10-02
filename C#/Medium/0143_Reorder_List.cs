using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Medium._Program;

namespace Medium
{
    internal class _0143_Reorder_List
    {
        public void ReorderList(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head.next;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            ListNode secondHalf = slow.next;
            slow.next = null!;
            var reversed = ReverseLinkedList(secondHalf);

            ListNode l = head;
            while (reversed != null)
            {
                var temp = l.next;
                l.next = reversed;
                l = temp;
                
                temp = reversed.next;
                reversed.next = l;
                reversed = temp;
            }
        }
        private ListNode ReverseLinkedList(ListNode head)
        {
            if (head == null)
                return null!;
            if(head.next == null)
                return head;

            var curr = ReverseLinkedList(head.next);
            head.next.next = head;
            head.next = null!;

            return curr;
        }
    }
}
