using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text;

namespace Hard
{
    public class _2472_Maximum_Number_of_Non_overlapping_Palindrome_Substrings
    {
        public int MaxPalindromes(string s, int k)
        {
            int[] dp = new int[s.Length + 1];
            dp[^1] = 0;

            bool isPalindrome(string proposedPalindrome)
            {
                int leftIndex = 0;
                int rightIndex = proposedPalindrome.Length - 1;

                while (leftIndex < rightIndex)
                {
                    if (proposedPalindrome[leftIndex] != proposedPalindrome[rightIndex])
                        return false;
                    leftIndex++;
                    rightIndex--;
                }

                return true;
            }

            for (int i = s.Length - k; i >= 0; i--)
            {
                StringBuilder sb = new();
                bool found = false;
                int j = 0;
                while (!found
                    && i + j < s.Length)
                {
                    sb.Append(s[i + j]);
                    ++j;
                    found = j >= k && isPalindrome(sb.ToString());
                }

                dp[i] = dp[i + 1];

                if (found)
                    dp[i] = Math.Max(dp[i], 1 + dp[i + j]);
            }

            //Console.WriteLine(string.Join("|", dp));

            return dp[0];

            //int halfK = k / 2;
            //HashSet<string> hs = [];
            //for (int i = halfK; i < s.Length - halfK; i++)
            //{
            //    // odd numbered palindromes
            //    StringBuilder oddSB = new();
            //    oddSB.Append(s[i]);
            //    if (k == 1)
            //        hs.Add(oddSB.ToString());

            //    int j = 1;
            //    while (i - j >= 0
            //        && i + j < s.Length
            //        && s[i - j] == s[i + j])
            //    {
            //        oddSB.Insert(0, s[i - j]);
            //        oddSB.Append(s[i + j]);
            //        if (j >= halfK)
            //        {
            //            hs.Add(oddSB.ToString());
            //            Console.WriteLine(oddSB);
            //        }
            //        j++;
            //    }

            //    // even numbered palindromes
            //    StringBuilder evenSB = new();
            //    j = 0;
            //    while (i - j >= 0
            //        && i + j + 1 < s.Length
            //        && s[i - j] == s[i + j + 1])
            //    {
            //        evenSB.Insert(0, s[i - j]);
            //        evenSB.Append(s[i + j + 1]);
            //        if (j >= halfK)
            //        {
            //            hs.Add(evenSB.ToString());
            //            Console.WriteLine(oddSB);
            //        }
            //        j++;
            //    }
            //}

            //Console.WriteLine("---------------");
            //foreach (var item in hs)
            //{
            //    Console.WriteLine(item);
            //}
            //return hs.Count;
        }
    }
}
