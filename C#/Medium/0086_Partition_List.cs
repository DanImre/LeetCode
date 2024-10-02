using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_2;

namespace Medium
{
    public class Medium_86
    {
        public Medium_86()
        {

        }
        public ListNode Partition(ListNode head, int x)
        {
            if (head == null)
                return null;

            ListNode curr = head;

            ListNode smallerList = new ListNode(0);
            ListNode smallerCurr = smallerList;

            ListNode biggerList = new ListNode(0);
            ListNode biggerCurr = biggerList;

            while (curr != null)
            {
                if(curr.val < x)
                {
                    smallerCurr.next = curr;
                    smallerCurr = smallerCurr.next;
                }
                else
                {
                    biggerCurr.next = curr;
                    biggerCurr = biggerCurr.next;
                }

                curr = curr.next;
            }
            biggerCurr.next = null;

            smallerCurr.next = biggerList.next;

            return smallerList.next;
        }
    }
}
