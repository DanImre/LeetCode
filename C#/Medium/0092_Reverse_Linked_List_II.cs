using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_2;

namespace Medium
{
    public class Medium_92
    {
        public Medium_92()
        {

        }
        public class Solution
        {
            public ListNode ReverseBetween(ListNode head, int left, int right)
            {
                if(left == right)
                    return head;

                --left;
                --right; //So it becomes 0 based

                ListNode start = head;

                while(left > 1)  //One before the window
                {
                    start = start.next;
                    --left;
                    --right;
                }

                ListNode tempHead = new ListNode(0);

                ListNode curr = start.next; //Cant be null
                ListNode end = curr;
                --right;

                while (right > 0)
                {
                    var tempHeadNext = tempHead.next;
                    tempHead.next = curr;
                    curr = curr.next;
                    tempHead.next.next = tempHeadNext;

                    --right;
                }


                end.next = curr.next;
                ListNode endNext = end.next;

                var tempHeadNextOutside = tempHead.next;
                tempHead.next = curr;
                tempHead.next.next = tempHeadNextOutside;

                if (left == 0)
                {
                    end.next = head;
                    head.next = endNext;
                    return tempHead.next;
                }
                else
                    start.next = tempHead.next;

                return head;
            }
        }
    }
}
