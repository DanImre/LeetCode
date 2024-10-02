using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2
    {
        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x = 0, ListNode next = null)
            {
                val = x;
                this.next = next;
            }
        }
        public Medium_2()
        {

        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return null;
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            int sum = l1.val + l2.val;
            int remainder = sum / 10;
            ListNode result = new ListNode(sum % 10);
            ListNode act = result;

            l1 = l1.next;
            l2 = l2.next;
            while (l1 != null && l2 != null)
            {
                sum = l1.val + l2.val + remainder;
                remainder = sum / 10;

                act.next = new ListNode(sum % 10);
                act = act.next;

                l1 = l1.next;
                l2 = l2.next;
            }

            if (l1 == null && l2 == null)
            {
                if (remainder != 0)
                    act.next = new ListNode(remainder);
                
                return result;
            }
            if (l1 == null)
            {
                act.next = l2;
                while (remainder != 0)
                {
                    if (act.next == null)
                    {
                        act.next = new ListNode(remainder);
                        break;
                    }
                    act = act.next;

                    int tempsum = act.val + remainder;
                    act.val = tempsum % 10;
                    remainder = tempsum / 10;
                }
                return result;
            }
            else //if (l2 == null)
            {
                act.next = l1;
                while (remainder != 0)
                {
                    if (act.next == null)
                    {
                        act.next = new ListNode(remainder);
                        break;
                    }
                    act = act.next;

                    int tempsum = act.val + remainder;
                    act.val = tempsum % 10;
                    remainder = tempsum / 10;
                }
                return result;
            }
        }
    }
}
