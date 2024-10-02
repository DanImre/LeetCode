using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1171
    {
        public Medium_1171()
        {

        }
        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null!)
            {
                this.val = val;
                this.next = next;
            }
        }
        public ListNode RemoveZeroSumSublists(ListNode head)
        {
            List<int> asList = new List<int>();
            while (head != null)
            {
                asList.Add(head.val);
                head = head.next;
            }

            for (int i = 0; i < asList.Count; i++)
            {
                int sum = 0;
                for (int j = i; j < asList.Count; j++)
                {
                    sum += asList[j];
                    if (sum == 0)
                    {
                        asList.RemoveRange(i, j - i + 1);
                        --i;
                        break;
                    }
                }
            }

            if (asList.Count == 0)
                return null!;

            ListNode solution = new ListNode(asList[0]);
            ListNode curr = solution;
            for (int i = 1; i < asList.Count; i++)
            {
                curr.next = new ListNode(asList[i]);
                curr = curr.next;
            }

            return solution;
        }
    }
}
