using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_242
    {
        public Easy_242()
        {
            Console.WriteLine(IsAnagram("anagram", "nagaram"));
            Console.WriteLine(IsAnagram("rat", "car")); //False
        }

        public bool IsAnagram(string s, string t)
        {
            if(s.Length != t.Length)
                return false;

            //bcs of lowercase letters => use arrays
            int[] letterCount = new int['z' - 'a' + 1];
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
