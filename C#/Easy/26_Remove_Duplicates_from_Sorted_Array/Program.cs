using System.Drawing;

namespace _26_Remove_Duplicates_from_Sorted_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        public static int RemoveDuplicates(int[] nums)
        {
            int i = 1;

            foreach (var item in nums)
            {
                if (nums[i-1] == item)
                    continue;

                nums[i] = item;
                ++i;
            }

            return i;
        }
    }
}