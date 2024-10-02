using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_2108
    {
        public Easy_2108()
        {

        }
        public string FirstPalindrome(string[] words)
        {
            foreach (string word in words)
            {
                int i = 0;
                int j = word.Length - 1;
                while (i < j && word[i] == word[j])
                {
                    ++i;
                    --j;
                }

                if (i >= j)
                    return word;
            }

            return "";
        }
    }
}
