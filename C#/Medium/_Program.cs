
namespace Medium
{
    public class _Program
    {
        static void Main(string[] args)
        {
            var obj = new _1477_Find_Two_Non_overlapping_Sub_arrays_Each_With_Target_Sum();
            Console.WriteLine(obj.MinSumOfLengths([1, 1, 1, 2, 2, 2, 4, 4], 6));
        }

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
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}