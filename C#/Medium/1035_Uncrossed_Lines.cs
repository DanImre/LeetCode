namespace Medium
{
    public class _1035_Uncrossed_Lines
    {
        public int MaxUncrossedLines(int[] nums1, int[] nums2)
        {
            int[,] dp = new int[nums1.Length + 1, nums2.Length + 1];
            for (int i = nums1.Length - 1; i >= 0; i--)
                for (int j = nums2.Length - 1; j >= 0; j--)
                {
                    int tempSol = dp[i + 1, j];
                    tempSol = Math.Max(tempSol, dp[i, j + 1]);
                    if (nums1[i] == nums2[j])
                        tempSol = Math.Max(tempSol, 1 + dp[i + 1, j + 1]);

                    dp[i, j] = tempSol;
                }

            return dp[0, 0];
        }
        //return MaxUncrossedLinesRecursive(nums1, nums2, 0, 0);
        //private Dictionary<(int,int),int> memo = [];
        //public int MaxUncrossedLinesRecursive(int[] nums1, int[] nums2, int topIndex, int bottomIndex)
        //{
        //    if (topIndex == nums1.Length
        //        || bottomIndex == nums2.Length)
        //        return 0;

        //    if (memo.ContainsKey((topIndex, bottomIndex)))
        //        return memo[(topIndex, bottomIndex)];

        //    int solution = MaxUncrossedLinesRecursive(nums1, nums2, topIndex + 1, bottomIndex);
        //    for (int i = bottomIndex; i < nums2.Length; i++)
        //    {
        //        if (nums1[topIndex] != nums2[i])
        //            continue;

        //        solution = Math.Max(solution, 1 + MaxUncrossedLinesRecursive(nums1, nums2, topIndex + 1, i + 1));
        //    }

        //    memo[(topIndex, bottomIndex)] = solution;
        //    return solution;
        //}
    }
}
