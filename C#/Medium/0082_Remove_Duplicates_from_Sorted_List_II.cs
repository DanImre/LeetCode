using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_2;

namespace Medium
{
    public class Medium_82
    {
        public Medium_82()
        {
            var temp = DeleteDuplicates(new ListNode(1, new ListNode(1, new ListNode(2))));
            while (temp != null)
            {
                Console.WriteLine(temp.val);
                temp = temp.next;
            }
        }
        public ListNode DeleteDuplicates(ListNode head)
        {
            if(head == null) 
                return null;

            ListNode newHead = new ListNode(0);
            newHead.next = head;
            ListNode act = newHead;


            ListNode curr = act.next;

            while (curr != null)
            {
                if(curr.next == null || curr.next.val != curr.val)
                {
                    act.next = curr;
                    act = act.next;

                    curr = curr.next;
                    continue;
                }

                //Duplicate

                while (curr.next != null && curr.val == curr.next.val)
                    curr.next = curr.next.next;

                curr = curr.next;
            }
            act.next = null;

            return newHead.next;
        }
    }
}
