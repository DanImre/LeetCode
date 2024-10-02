using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace _234_PalindromeLinkedList
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
            Console.WriteLine(IsPalindrome(ListNode.createListNode(new int[] { 1, 2, 2, 1 })));
            Console.WriteLine(IsPalindrome(ListNode.createListNode(new int[] { 1, 2 })));
            Console.WriteLine(IsPalindrome(ListNode.createListNode(new int[] { 1 })));
            Console.WriteLine(IsPalindrome(ListNode.createListNode(new int[] { 1,0,0 })));
            Console.WriteLine(IsPalindrome(ListNode.createListNode(new int[] { 1,0,1 })));
            Console.WriteLine(IsPalindrome(ListNode.createListNode(new int[] { 1, 2, 2, 3, 3, 1 })));

            Console.WriteLine("---------");
            Console.WriteLine(IsPalindrome2(ListNode.createListNode(new int[] { 1, 2, 2, 1 })));
            Console.WriteLine(IsPalindrome2(ListNode.createListNode(new int[] { 1, 2 })));
            Console.WriteLine(IsPalindrome2(ListNode.createListNode(new int[] { 1 })));
            Console.WriteLine(IsPalindrome2(ListNode.createListNode(new int[] { 1, 0, 0 })));
            Console.WriteLine(IsPalindrome2(ListNode.createListNode(new int[] { 1, 0, 1 })));
            Console.WriteLine(IsPalindrome2(ListNode.createListNode(new int[] { 1, 2, 2, 3, 3, 1 })));

        }

        //First
        public static bool IsPalindrome(ListNode head)
        {
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();

            while (head != null)
            {
                stack.Push(head.val);
                queue.Enqueue(head.val);

                head = head.next;
            }

            while (stack.Count != 0)
            {
                if (stack.Pop() != queue.Dequeue())
                    return false;
            }

            return true;
        }

        //Second
        public static bool IsPalindrome2(ListNode head)
        {
            Stack<int> stack = new Stack<int>();

            ListNode l = head;
            while (head != null)
            {
                stack.Push(head.val);
                head = head.next;
            }

            while (l != null && l.val == stack.Pop())
                l = l.next;

            return l == null;
        }
    }
}