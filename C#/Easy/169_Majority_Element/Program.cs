namespace _169_Majority_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static int MajorityElement(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();

            int maxNumber = nums[0];
            int maxCount = 1;
            dic.Add(nums[0], 1);

            for (int i = 1; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]))
                {
                    ++dic[nums[i]];
                    if (maxCount < dic[nums[i]])
                    {
                        maxCount = dic[nums[i]];
                        maxNumber = nums[i];
                    }
                }
                else
                    dic.Add(nums[i], 1);
            }

            return maxNumber;
        }

        //The best
        public static int MajorityElement2(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }
    }
}