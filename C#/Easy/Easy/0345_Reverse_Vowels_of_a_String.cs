using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_345
    {
        public Easy_345()
        {
            Console.WriteLine(ReverseVowels("hello"));
            Console.WriteLine(ReverseVowels("leetcode"));
        }

        public string ReverseVowels(string s)
        {
            char[] array = s.ToArray();

            int start = 0;
            int end = array.Length - 1;
            while (start < end)
            {
                bool startIsVowel = IsVowel(array[start]);
                bool endIsVowel = IsVowel(array[end]);
                if (startIsVowel && endIsVowel)
                {
                    char temp = array[start];
                    array[start] = array[end];
                    array[end] = temp;
                    ++start;
                    --end;
                }
                else if (startIsVowel)
                    --end;
                else if (endIsVowel)
                    ++start;
                else
                {
                    ++start;
                    --end;
                }
            }

            return new string(array);
        }
        public bool IsVowel(char a)
        {
            a = Char.ToLower(a);
            return a == 'a'
                || a == 'e'
                || a == 'i'
                || a == 'o'
                || a == 'u';
        }
    }
}
