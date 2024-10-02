using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_2;

namespace Medium
{
    public class Medium_206
    {
        public Medium_206()
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
    }
}
