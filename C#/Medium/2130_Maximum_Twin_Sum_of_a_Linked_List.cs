using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_2;

namespace Medium
{
    public class Medium_2130
    {
        public Medium_2130()
        {

        }
        public int PairSum(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            //reverse list from slow onwards
            ListNode flippedList = new ListNode(0);
            ListNode curr = slow.next;

            while (curr != null)
            {
                var temp = flippedList.next;
                flippedList.next = curr;
                curr = curr.next;
                flippedList.next.next = temp;
            }
            flippedList = flippedList.next;

            int max = int.MinValue;
            curr = head;
            while (flippedList != null)
            {
                max = Math.Max(max, flippedList.val + curr.val);
                curr = curr.next;
                flippedList = flippedList.next;
            }

            return max;
        }
    }
}
