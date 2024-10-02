using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1624
    {
        public Easy_1624()
        {

        }
        public int MaxLengthBetweenEqualCharacters(string s)
        {
            int[] dic = new int[26];

            int solution = -1;

            for (int i = 0; i < s.Length; i++)
            {
                int index = s[i]  - 'a';
                if (dic[index] != 0)
                    solution = Math.Max(solution, i - dic[index]);
                else
                    dic[index] = i + 1;
            }

            return solution;
        }
    }
}
