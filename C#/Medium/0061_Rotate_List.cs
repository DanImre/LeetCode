using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_2;

namespace Medium
{
    public class Medium_61
    {
        public Medium_61()
        {

        }
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null)
                return null;

            int length = 1;

            ListNode curr = head;
            while (curr.next != null)
            {
                curr = curr.next;
                ++length;
            }

            curr.next = head;

            k %= length;
            while (length != k)
            {
                --length;
                curr = curr.next;
            }

            head = curr.next;
            curr.next = null;

            return head;
        }
    }
}
