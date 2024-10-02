namespace _876_Middle_of_the_Linked_List
{
    internal class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }

            public override string ToString()
            {
                ListNode l = this;

                string solution = "[";

                while (l.next != null)
                {
                    solution += l.val + ", ";
                    l = l.next;
                }

                solution += l.val + "]";
                return solution;
            }
            public static ListNode createListNode(int[] array)
            {
                if (array.Length == 0)
                    return null;

                ListNode l = new ListNode(array[0]);
                ListNode p = l;
                for (int i = 1; i < array.Length; i++)
                {
                    p.next = new ListNode(array[i]);
                    p = p.next;
                }

                return l;
            }
        }

        static void Main(string[] args)
        {
            ListNode l = ListNode.createListNode(new int[] { 1, 2, 3, 4, 5 });
            ListNode p = l;
            while (p != null)
            {
                p = p.next;
            }

            //return;
            Console.WriteLine(MiddleNode(l));
            Console.WriteLine(MiddleNode(ListNode.createListNode(new int[] { 1, 2, 3, 4, 5, 6 })));
        }
        public static ListNode MiddleNode(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            
            return slow;
        }
    }
}