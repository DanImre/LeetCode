using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_455
    {
        public Easy_455()
        {

        }

        public int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);

            int j = 0;
            for (int i = 0; i < s.Length && j < g.Length; i++)
            {
                if (s[i] >= g[j])
                    ++j;
            }

            return j;
        }
    }
}
