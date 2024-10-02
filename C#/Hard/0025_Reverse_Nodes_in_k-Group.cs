using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_25
    {
        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public Hard_25()
        {
            ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

            ListNode newHead = ReverseKGroup(head, 2);
            while (newHead != null)
            {
                Console.WriteLine(newHead.val);
                newHead = newHead.next;
            }
        }
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (k == 1)
                return head;

            ListNode newHead = new ListNode(0);
            newHead.next = head;
            ListNode newHeadAct = newHead;

            ListNode act = head;

            while (true)
            {
                Stack<ListNode> stack = new Stack<ListNode>();
                int tempCount = 0;
                while (tempCount < k && act != null)
                {
                    ++tempCount;
                    stack.Push(act);
                    act = act.next;
                }

                //Didn't complete a full cycle
                if (tempCount < k)
                    return newHead.next;

                //completed a cycle
                while (stack.Count != 0)
                {
                    newHeadAct.next = stack.Pop();
                    newHeadAct = newHeadAct.next;
                }
                newHeadAct.next = act;
            }

            return newHead.next;
        }
    }
}
