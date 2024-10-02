using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1647
    {
        public Medium_1647()
        {
            
        }
        public int MinDeletions(string s)
        {
            int[] dic = new int[26];
            foreach (var item in s)
                ++dic[item - 'a'];

            int solution = 0;
            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < 26; i++)
            {
                if (dic[i] == 0 || hs.Add(dic[i]))
                    continue;

                ++solution;
                --dic[i];
                --i;
            }

            return solution;
        }
    }
}
