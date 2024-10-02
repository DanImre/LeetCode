using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hard.Hard_25;

namespace Hard
{
    public class Hard_23
    {
        public Hard_23()
        {

        }
        //memory efficient
        public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode root = new ListNode(0);
            ListNode curr = root;

            while (true)
            {
                int mindIndex = -1;
                int min = 100000; //-10^4 <= lists[i][j] <= 10^4

                for (int i = 0; i < lists.Length; i++)
                {
                    if (lists[i] == null || lists[i].val >= min)
                        continue;

                    min = lists[i].val;
                    mindIndex = i;
                }

                if (mindIndex == -1)
                    break;

                curr.next = lists[mindIndex];
                curr = curr.next;

                lists[mindIndex] = lists[mindIndex].next;
            }

            return root.next;
        }
    }
}
