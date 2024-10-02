using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_2;

namespace Medium
{
    public class Medium_445
    {
        public Medium_445()
        {

        }
        //without reversing the inputs, only using stacks:
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            Stack<int> one = new Stack<int>();
            Stack<int> two = new Stack<int>();

            while (l1 != null)
            {
                one.Push(l1.val);
                l1 = l1.next;
            }
            while (l2 != null)
            {
                two.Push(l2.val);
                l2 = l2.next;
            }

            ListNode head = null;

            int leftover = 0;
            while (one.Count != 0 || two.Count != 0)
            {
                int sum = leftover;

                if(one.Count != 0)
                    sum += one.Pop();
                if (two.Count != 0)
                    sum += two.Pop();

                if (sum >= 10)
                {
                    sum -= 10;
                    leftover = 1;
                }
                else
                    leftover = 0;

                ListNode temp = new ListNode(sum, head);
                head = temp;
            }

            if(leftover != 0)
            {
                ListNode temp = new ListNode(leftover, head);
                head = temp;
            }

            return head;
        }
    }
}
