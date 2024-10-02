using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_24
    {
        public Medium_24()
        {

        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null!)
            {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode one = head;
            ListNode two = head.next;
            while (true)
            {
                int temp = one.val;
                one.val = two.val;
                two.val = temp;

                if (two.next == null || two.next.next == null)
                    break;

                one = two.next;
                two = two.next.next;
            }

            return head;
        }
    }
}
