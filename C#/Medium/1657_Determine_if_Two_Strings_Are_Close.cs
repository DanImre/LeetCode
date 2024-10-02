using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1657
    {
        public Medium_1657()
        {

        }
        public bool CloseStrings(string word1, string word2)
        {
            //Length check
            if (word1.Length != word2.Length)
                return false;

            //Counting characters
            int[] one = new int[26];
            foreach (var item in word1)
                    ++one[item - 'a'];
            int[] two = new int[26];
            foreach (var item in word2)
                ++two[item - 'a'];

            //Same characters are present
            for (int i = 0; i < 26; i++)
            {
                if ((one[i] == 0 && two[i] == 0)
                    || (one[i] > 0 && two[i] > 0))
                    continue;

                return false;
            }

            //amounts are the same
            Array.Sort(one);
            Array.Sort(two);

            for (int i = 0; i < 26; i++)
                if (one[i] != two[i])
                    return false;

            return true;
        }
    }
}
