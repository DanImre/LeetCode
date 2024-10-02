using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_205
    {
        public Easy_205()
        {
            Console.WriteLine(IsIsomorphic("egg", "Add"));
            Console.WriteLine(IsIsomorphic("foo", "bar")); //False
            Console.WriteLine(IsIsomorphic("paper", "title"));
            Console.WriteLine(IsIsomorphic("badc", "baba"));//False
        }
        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            Dictionary<char, int> mapS = new Dictionary<char, int>();
            Dictionary<char, int> mapT = new Dictionary<char, int>();
            
            for (int i = 0; i < t.Length; i++)
            {
                bool hasS = mapS.ContainsKey(s[i]);
                bool hasT = mapT.ContainsKey(t[i]);

                if (!hasS && !hasT)
                {
                    mapS.Add(s[i], i);
                    mapT.Add(t[i], i);
                    continue;
                }

                if(!hasS || !hasT || mapS[s[i]] != mapT[t[i]])
                    return false;

                ++mapS[s[i]];
                ++mapT[t[i]];

            }

            return true;
        }
    }
}
