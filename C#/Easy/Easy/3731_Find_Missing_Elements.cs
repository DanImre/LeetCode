namespace Easy
{
    public class _3731_Find_Missing_Elements
    {
        public IList<int> FindMissingElements(int[] nums)
        {
            Array.Sort(nums);
            int[] missingElements = new int[nums[^1] - nums[0] - 1 - (nums.Length - 2)];

            int msIndex = 0;
            int index = 1;
            for (int literalValue = nums[0] + 1; literalValue < nums[^1]; literalValue++)
            {
                if (literalValue == nums[index])
                {
                    index = Math.Min(index + 1, nums.Length - 1);
                    continue;
                }

                missingElements[msIndex++] = literalValue;
            }

            return missingElements;
        }
    }
}
