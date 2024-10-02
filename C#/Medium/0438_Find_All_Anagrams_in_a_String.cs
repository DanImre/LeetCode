using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_438
    {
        public Medium_438()
        {

        }
        public IList<int> FindAnagrams(string s, string p)
        {
            IList<int> solution = new List<int>();
            if (p.Length > s.Length)
                return solution;

            int[] dic = new int[26];
            for (int i = 0; i < p.Length; i++)
            {
                dic[p[i] - 'a']++;
                dic[s[i] - 'a']--;
            }

            if (dic.All(kk => kk == 0))
                solution.Add(0);

            for (int i = 0; i < s.Length - p.Length; i++)
            {
                dic[s[i] - 'a']++;
                dic[s[i + p.Length] - 'a']--;

                if (dic.All(kk => kk == 0))
                    solution.Add(i + 1);
            }

            return solution;
        }
    }
}
