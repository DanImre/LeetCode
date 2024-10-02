using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_49
    {
        public Medium_49()
        {
            string[] strs = { "eat", "tea", "tan", "ate", "nat", "bat" };
            Console.WriteLine("[" + string.Join(", ", GroupAnagrams(strs).Select(kk => "[" + string.Join(", ", kk) + "]")) + "]");
        }

        //Correct solution would have been to sort the word and equals check them
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> solution = new List<IList<string>>();

            HashSet<int> usedIndexes = new HashSet<int>();

            //bcs of lowercase letters => use arrays
            int[] letterCount = new int['z' - 'a' + 1];

            for (int i = 0; i < strs.Length; i++)
            {
                if (!usedIndexes.Add(i))
                    continue;

                List<string> temp = new List<string>() { strs[i] };

                for (int j = i; j < strs.Length; j++)
                    if (!usedIndexes.Contains(j) && IsAnagram(strs[i], strs[j], letterCount)) //reusing lettercount
                    {
                        temp.Add(strs[j]);
                        usedIndexes.Add(j);
                    }

                solution.Add(temp);
            }

            return solution;
        }
        //From Easy_242
        public bool IsAnagram(string s, string t, int[] letterCount)
        {
            if (s.Length != t.Length)
                return false;

            Array.Fill(letterCount, 0);
            for (int i = 0; i < s.Length; i++)
                ++letterCount[s[i] - 'a'];

            for (int i = 0; i < t.Length; i++)
                if (--letterCount[t[i] - 'a'] < 0)
                    return false;

            return true;
        }

    }
}
