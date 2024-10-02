using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_2;

namespace Medium
{
    public class Medium_19
    {
        public Medium_19()
        {
            ListNode temp = RemoveNthFromEnd(new ListNode(1, new ListNode(2)), 2);
            while (temp != null)
            {
                Console.WriteLine(temp.val);
                temp = temp.next;
            }
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (n == recursiveSolution(head, n))
                return head.next;

            return head;
        }

        public int recursiveSolution(ListNode head, int n)
        {
            if (head == null)
                return 0;

            int tempSolution = recursiveSolution(head.next, n);
            if (tempSolution == n)
                head.next = head.next.next;

            return tempSolution + 1;
        }
    }
}
