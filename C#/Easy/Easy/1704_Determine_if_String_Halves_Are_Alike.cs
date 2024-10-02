using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1704
    {
        public Easy_1704()
        {

        }
        public bool HalvesAreAlike(string s)
        {
            HashSet<char> vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };
            int countOne = 0;
            int countTwo = 0;

            int halfN = s.Length / 2;
            for (int i = 0; i < halfN; i++)
            {
                if (vowels.Contains(char.ToLower(s[i])))
                    ++countOne;
                if (vowels.Contains(char.ToLower(s[halfN + i])))
                    ++countTwo;
            }

            return countOne == countTwo;
        }
    }
}
