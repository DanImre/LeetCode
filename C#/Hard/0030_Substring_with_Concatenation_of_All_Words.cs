using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_30
    {
        public Hard_30()
        {
            //[0, 9]
            /*
            string s = "barfoothefoobarman";
            string[] words = new string[] { "foo", "bar" };

            //[]
            string s = "wordgoodgoodgoodbestword";
            string[] words = new string[] { "word", "good", "best", "word" };
            
            //[6,9,12]
            string s = "barfoofoobarthefoobarman";
            string[] words = new string[] { "bar", "foo", "the" };
            */

            //[6,16,17,18,19,20]
            string s = "bcabbcaabbccacacbabccacaababcbb";
            string[] words = new string[] { "c", "b", "a", "c", "a", "a", "a", "b", "c" };

            Console.WriteLine("[" + string.Join(", ", FindSubstring(s,words)) + "]");
        }

        public IList<int> FindSubstring(string s, string[] words)
        {
            int concatenationLength = words.Length * words[0].Length;

            List<int> solution = new List<int>();

            if (s.Length < concatenationLength)
                return solution;

            Dictionary<string,int> wordCount = new Dictionary<string,int>();
            foreach (var item in words)
                if (wordCount.ContainsKey(item))
                    ++wordCount[item];
                else
                    wordCount.Add(item, 1);

            int i = 0;
            int j = concatenationLength - 1;

            while (j < s.Length)
            {
                bool valid = true;

                Dictionary<string, int> usedWords = new Dictionary<string, int>();
                for (int l = i; l <= j && valid; l += words[0].Length)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int z = l; z < l + words[0].Length; z++)
                        sb.Append(s[z]);

                    string value = sb.ToString();
                    if (wordCount.ContainsKey(value))
                    {
                        if (!usedWords.ContainsKey(value))
                            usedWords.Add(value, 1);
                        else if (usedWords[value] < wordCount[value])
                            ++usedWords[value];
                        else
                            valid = false;
                    }
                    else
                        valid = false;
                }

                if (valid)
                    solution.Add(i);

                ++i;
                ++j;
            }

            return solution;
        }
    }
}
