using System.Runtime.Serialization;

namespace Hard
{
    public class _2213_Longest_Substring_of_One_Repeating_Character
    {
        // Should create a segment tree
        public int[] LongestRepeating(string s, string queryCharacters, int[] queryIndices)
        {
            char[] sArr = s.ToCharArray();
            int length = s.Length;
            int[] seriesLength = new int[length];
            s += "1";
            int runningCount = 1;
            int max = 0;
            int maxI = -1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    runningCount++;
                    continue;
                }

                if (max < runningCount)
                {
                    max = runningCount;
                    maxI = i - 1;
                }

                for (int j = 1; j <= runningCount; j++)
                    seriesLength[i - j] = runningCount;

                runningCount = 1;
            }

            int[] solution = new int[queryIndices.Length];
            for (int i = 0; i < queryIndices.Length; i++)
            {
                //Console.WriteLine(string.Join(", ", seriesLength));
                //Console.WriteLine(string.Join(", ", sArr));
                //Console.WriteLine("-------------------");

                int replaceIndex = queryIndices[i];
                char replaceChar = queryCharacters[i];
                char previousChar = sArr[replaceIndex];

                if (replaceChar == previousChar)
                {
                    if (i == 0)
                        solution[i] = max;
                    else
                        solution[i] = solution[i - 1];

                    continue;
                }

                sArr[replaceIndex] = replaceChar;

                int countOnLeft = 0;
                int leftIndex = replaceIndex - 1;
                while (leftIndex >= 0 && sArr[leftIndex] == previousChar)
                {
                    countOnLeft++;
                    leftIndex--;
                }
                leftIndex++;

                int countOnRight = seriesLength[leftIndex] - countOnLeft - 1;

                while (leftIndex < replaceIndex)
                {
                    seriesLength[leftIndex] = countOnLeft;
                    leftIndex++;
                }

                leftIndex++;

                while (leftIndex < length && sArr[leftIndex] == previousChar)
                {
                    seriesLength[leftIndex] = countOnRight;
                    leftIndex++;
                }

                // ------------------ appending

                int totalCount = 1;
                leftIndex = replaceIndex - 1;
                while (leftIndex >= 0 && sArr[leftIndex] == replaceChar)
                {
                    totalCount++;
                    leftIndex--;
                }
                leftIndex++;


                int rightIndex = replaceIndex + 1;
                while (rightIndex < length && sArr[rightIndex] == replaceChar)
                {
                    totalCount++;
                    rightIndex++;
                }
                rightIndex--;

                int runningLeftIndex = leftIndex;
                while (runningLeftIndex <= rightIndex)
                {
                    seriesLength[runningLeftIndex] = totalCount;
                    runningLeftIndex++;
                }

                if (totalCount > max)
                {
                    solution[i] = totalCount;
                    max = totalCount;
                    maxI = rightIndex;
                    continue;
                }

                if (maxI < leftIndex || maxI > rightIndex)
                {
                    solution[i] = max;
                    continue;
                }

                int prevMax = max;
                max = 0;
                maxI = -1;
                for (int j = 0; j < seriesLength.Length; j++)
                {
                    if (max >= seriesLength[j])
                        continue;

                    max = seriesLength[j];
                    maxI = j;

                    if (prevMax == max)
                        break;
                }

                solution[i] = max;

            }

            //Console.WriteLine(string.Join(", ", solution));
            return solution;
        }
    }
}
