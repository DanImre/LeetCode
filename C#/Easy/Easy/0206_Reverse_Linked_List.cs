using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Easy._Program;

namespace Easy
{
    public class Easy_206
    {
        public Easy_206()
        {

        }
        public ListNode ReverseList(ListNode head)
        {
            if (head == null
                || head.next == null)
                return head;

            //n >= 1
            ListNode solution = new ListNode(0);

            ListNode curr = head;
            while (curr != null)
            {
                var temp = solution.next;
                solution.next = curr;
                curr = curr.next;
                solution.next.next = temp;
            }

            return solution.next;
        }
        public ListNode BetterReverseList(ListNode head)
        {
            if (head == null
                || head.next == null)
                return head;

            ListNode prev = null!;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
            }
            return prev;
        }
        public ListNode BetterRecursive(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode reversed = ReverseList(head.next);
            head.next.next = head;
            head.next = null; 
            return reversed;
        }
    }
}
