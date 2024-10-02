using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_2;

namespace Medium
{
    public class Medium_725
    {
        public Medium_725()
        {

        }
        public ListNode[] SplitListToParts(ListNode head, int k)
        {
            int nodeCount = 0;
            ListNode temp = head;
            while (temp != null)
            {
                ++nodeCount;
                temp = temp.next;
            }

            int partSize = nodeCount / k;
            int extraNodes = nodeCount % k;
            ListNode[] solution = new ListNode[k];
            for (int i = 0; i < k; i++)
            {
                solution[i] = head;
                for (int j = partSize + (--extraNodes >= 0 ? 1 : 0) - 2; j >= 0; j--)
                    head = head.next;

                if (head == null)
                    break;
                
                temp = head.next;
                head.next = null;
                head = temp;
            }

            return solution;
        }
    }
}
