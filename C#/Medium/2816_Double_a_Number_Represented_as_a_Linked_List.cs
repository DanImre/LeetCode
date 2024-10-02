using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Medium._Program;

namespace Medium
{
    public class Medium_2816
    {
        public Medium_2816()
        {

        }
        public ListNode DoubleIt(ListNode head)
        {
            int carry = helper(head);
            if (carry == 0)
                return head;

            return new ListNode(1, head);
        }

        private int helper(ListNode head)
        {
            if(head == null)
                return 0;

            int lastCarry = helper(head.next);

            head.val = head.val * 2 + lastCarry;

            int carry = head.val >= 10 ? 1 : 0;

            head.val %= 10;

            return carry;
        }
    }
}
