using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_2;

namespace Medium
{
    public class Medium_328
    {
        public Medium_328()
        {

        } 
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null
                || head.next == null
                || head.next.next == null)
                return head;

            //n >= 2
            ListNode odd = head;
            ListNode evenStart = head.next;
            ListNode even = head.next;
            ListNode curr = head.next;

            while (curr != null)
            {
                odd.next = curr.next;
                curr = curr.next;
                if (curr == null)
                    break;
                odd = odd.next;


                even.next = curr.next;
                even = even.next;
                curr = curr.next;
            }
            odd.next = evenStart;

            return head;
        }
    }
}
