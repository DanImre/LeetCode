namespace _88_Merge_Sorted_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] solution = new int[] { 1, 2, 3, 0, 0, 0 };
            int[] b = new int[] { 2, 5, 6 };
            
            Merge(solution, 3, b, 3);

            foreach (var item in solution)
                Console.Write(item + "; ");
            Console.WriteLine();
            Console.WriteLine("---------");
            //-------------
            solution = new int[] { 4, 5, 6, 0, 0, 0 };
            b = new int[] { 1, 2, 3 };

            Merge(solution, 3, b, 3);

            foreach (var item in solution)
                Console.Write(item + "; ");
            Console.WriteLine();
            Console.WriteLine("---------");
            //-------------
            solution = new int[] { 0 };
            b = new int[] { 1 };

            Merge(solution, 0, b, 1);

            foreach (var item in solution)
                Console.Write(item + "; ");
            Console.WriteLine();
            Console.WriteLine("---------");
            //-------------
            solution = new int[] { 4, 0, 0, 0, 0, 0 };
            b = new int[] { 1, 2, 3, 5, 6 };

            Merge(solution, 1, b, 5);

            foreach (var item in solution)
                Console.Write(item + "; ");
            Console.WriteLine();
            Console.WriteLine("---------");
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m-1; //num1
            int j = n-1; //num2

            while (i >= 0 && j >= 0)
            {
                if (nums1[i] <= nums2[j])
                {
                    nums1[i + j + 1] = nums2[j];
                    --j;
                }
                else
                {
                    nums1[i + j + 1] = nums1[i];
                    --i;
                }
            }

            while (j >= 0)
            {
                nums1[j] = nums2[j];
                --j;
            }
        }
    }
}