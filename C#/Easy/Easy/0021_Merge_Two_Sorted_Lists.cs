using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Easy.Easy_141;

namespace Easy
{
    public class Easy_21
    {
        public Easy_21()
        {

        }
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null)
                return null;
            if (list1 == null)
                return list2;
            if (list2 == null)
                return list1;

            ListNode solution = null;

            if (list1.val < list2.val)
            {
                solution = list1;
                list1 = list1.next;
            }
            else
            {
                solution = list2;
                list2 = list2.next;
            }

            ListNode act = solution;
            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    act.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    act.next = list2;
                    list2 = list2.next;
                }

                act = act.next;
            }

            if (list1 != null)
                act.next = list1;
            else
                act.next = list2;

            return solution;

        }
    }
}
