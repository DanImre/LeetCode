using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1768
    {
        public Easy_1768()
        {

        }
        public string MergeAlternately(string word1, string word2)
        {
            int i = 0;

            StringBuilder sb = new StringBuilder();

            while (i < word1.Length && i < word2.Length)
            {
                sb.Append(word1[i]);
                sb.Append(word2[i]);
                ++i;
            }

            if (i < word1.Length)
                sb.Append(word1.Substring(i,word1.Length - i));
            else if (i < word2.Length)
                sb.Append(word2.Substring(i, word2.Length - i));

            return sb.ToString();
        }
    }
}
