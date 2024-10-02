using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium._Program;

namespace Medium
{
    internal class Medium_2487
    {
        public Medium_2487()
        {

        }

        private int max = int.MinValue;
        public ListNode RemoveNodes(ListNode head)
        {
            ListNode wrapper = new ListNode(0, head);
            return helper(wrapper);
        }

        private ListNode helper(ListNode head)
        {
            if (head.next == null)
            {
                max = Math.Max(max, head.val);
                return head;
            }

            var last = helper(head.next);

            if (head.val < max)
                return last;

            max = Math.Max(max, head.val);
            head.next = last;
            return head;
        }
    }
}
