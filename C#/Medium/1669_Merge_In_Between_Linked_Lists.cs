using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1669
    {
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
        public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
        {
            var last = list1;
            for (int i = 1; i < a; i++)
                last = last.next;

            var todelete = last.next;
            for (int i = a; i < b; i++)
                todelete = todelete.next;
            last.next = list2;
            while (last.next != null)
                last = last.next;
            last.next = todelete.next;

            return list1;
        }
    }
}
