using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_2272
    {
        public Hard_2272()
        {
            //3
            Console.WriteLine(LargestVariance("aababbb"));
        }
        //O(n + 26*26*n) => O(n)
        public int LargestVariance(string s)
        {
            int[] characters = new int[26];
            foreach (var item in s)
                ++characters[item - 'a'];


            int max = 0;

            for (char i = 'a'; i <= 'z'; i++)
                for (char j = 'a'; j <= 'z'; j++)
                {
                    if (i == j || characters[i - 'a'] == 0 && characters[j - 'a'] == 0)
                        continue;

                    max = Math.Max(max, maxSumOfAllSubbarays(characters, s, i, j));
                }

            return max;
        }
        public int maxSumOfAllSubbarays(int[] characters, string s, char main, char other)
        {
            int max = 0;

            int otherRemaining = characters[other - 'a'];

            int mainCount = 0;
            int otherCount = 0;


            foreach (var item in s)
            {
                if (item == main)
                    ++mainCount;
                else if (item == other)
                {
                    ++otherCount;
                    --otherRemaining;
                }

                if (mainCount < otherCount && otherRemaining > 0)
                {
                    mainCount = 0;
                    otherCount = 0;
                }
                else if (otherCount > 0)
                    max = Math.Max(mainCount - otherCount, max);
            }

            return max;
        }
        //TLE
        public int LargestVariance2(string s)
        {
            int max = int.MinValue;
            for (int i = 0; i < s.Length; i++)
                for (int j = i; j < s.Length; j++)
                    max = Math.Max(max, varianceOfAString(s, i, j));

            return max;
        }
        public int varianceOfAString(string s, int start, int end)
        {
            int[] characters = new int[26]; //lowercase english letters

            for (int i = start; i <= end; i++)
                ++characters[s[i] - 'a'];

            int max = int.MinValue;
            int min = int.MaxValue;
            foreach (var item in characters)
            {
                if (item == 0)
                    continue;

                if (item > max)
                    max = item;
                if (item < min)
                    min = item;
            }

            return max - min;
        }
    }
}
