namespace _27_Remove_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] solution = new int[] { 3, 2, 2, 3 }; 
            Console.WriteLine(RemoveElement(solution,3));

            foreach (var item in solution)
                Console.Write(item + "; ");
            Console.WriteLine();
        }

        public static int RemoveElement(int[] nums, int val)
        {
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    ++count;
                    continue;
                }

                nums[i - count] = nums[i];
            }

            return nums.Count() - count;
        }

        //evenFaster
        public static int RemoveElement2(int[] nums, int val)
        {
            int i = 0;

            foreach (var item in nums)
            {
                if (item == val)
                    continue;

                nums[i] = item;
                ++i;
            }

            return i;
        }
    }
}