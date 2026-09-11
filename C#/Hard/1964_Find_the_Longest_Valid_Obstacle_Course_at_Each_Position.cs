using System.Runtime.Intrinsics.Arm;

namespace Hard
{
    public class _1964_Find_the_Longest_Valid_Obstacle_Course_at_Each_Position
    {
        public int[] LongestObstacleCourseAtEachPosition(int[] obstacles)
        {
            // LIS (Longest Increasing (or same) Subsequence)
            // DP O(n^2)
            // TLE

            //int[] dp = new int[obstacles.Length];
            //Array.Fill(dp, 1);

            //for (int i = 0; i < obstacles.Length; i++)
            //    for (int j = i - 1; j >= 0; j--)
            //    {
            //        if (obstacles[i] >= obstacles[j])
            //            dp[i] = Math.Max(dp[i], dp[j] + 1);
            //    }

            //return dp;


            // LIS(Longest Increasing (or same) Subsequence)
            // Binary search O(n (log n))
            int[] bucket = new int[obstacles.Length];
            bucket[0] = obstacles[0];
            int len = 1;

            var customComparer = Comparer<int>.Create((a, b) => a == b ? -1 : a.CompareTo(b));
            int[] result = new int[obstacles.Length];
            result[0] = 1;

            for (int i = 1; i < obstacles.Length; i++)
            {
                if (bucket[len - 1] <= obstacles[i])
                {
                    bucket[len] = obstacles[i];
                    result[i] = ++len;
                }
                else
                {
                    int index = ~Array.BinarySearch(bucket, 0, len, obstacles[i], customComparer);

                    result[i] = index + 1;
                    bucket[index] = obstacles[i];
                }

            }

            return result;
        }
    }
}
