using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1915
    {
        public Medium_1915()
        {

        }
        public long WonderfulSubstrings(string word)
        {
            Dictionary<int,int> freq = new Dictionary<int,int>();

            freq.Add(0, 1);

            int mask = 0;
            long res = 0L;
            for (int i = 0; i < word.Length; i++)
            {
                mask ^= 1 << (word[i] - 'a');

                res += freq.GetValueOrDefault(mask, 0);

                freq[mask] = freq.GetValueOrDefault(mask, 0) + 1;

                for (int j = 0; j < 10; j++) //'a' - 'j'
                    res += freq.GetValueOrDefault(mask ^ (1 << j), 0);
            }

            return res;
        }
    }
}
