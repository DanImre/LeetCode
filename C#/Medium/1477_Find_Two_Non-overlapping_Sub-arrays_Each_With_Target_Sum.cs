using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public class _1477_Find_Two_Non_overlapping_Sub_arrays_Each_With_Target_Sum
    {
        public int MinSumOfLengths(int[] arr, int target)
        {
            int sum = arr[0];
            int start = 0;
            int end = 1;

            List<(int start, int end)> foundSolutions = [];

            while (true)
            {
                if (sum == target)
                    foundSolutions.Add((start, end));

                if (sum > target)
                {
                    sum -= arr[start];
                    start++;
                    continue;
                }

                if (end == arr.Length)
                    break;

                sum += arr[end];
                end++;
            }

            if (foundSolutions.Count < 2)
                return -1;

            foundSolutions.Sort((a, b) => (a.end - a.start).CompareTo(b.end - b.start));

            int min = int.MaxValue;

            for (int i = 0; i < foundSolutions.Count; i++)
                for (int j = i + 1; j < foundSolutions.Count; j++)
                {
                    if (foundSolutions[i].end <= foundSolutions[j].start
                        || foundSolutions[j].end <= foundSolutions[i].start)
                    {
                        int iSubArrayLen = foundSolutions[i].end - foundSolutions[i].start;
                        int jSubArrayLen = foundSolutions[j].end - foundSolutions[j].start;
                        min = Math.Min(min, iSubArrayLen + jSubArrayLen);
                        break;
                    }
                }

            return min == int.MaxValue ? -1 : min;
        }
    }
}
