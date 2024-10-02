using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_290
    {
        public Easy_290()
        {
            Console.WriteLine(WordPattern("abba", "dog cat cat dog"));
            Console.WriteLine(WordPattern("abba", "dog cat cat fish"));//False
            Console.WriteLine(WordPattern("aaaa", "dog cat cat dog")); //False
            Console.WriteLine(WordPattern("abba", "dog dog dog dog"));//False
        }
        public bool WordPattern(string pattern, string s)
        {
            string[] words = s.Split(' ');

            if (words.Length != pattern.Length)
                return false;

            HashSet<char> assignedChars = new HashSet<char>();
            Dictionary<string, char> wordToChar = new Dictionary<string, char>();

            for (int i = 0; i < pattern.Length; i++)
                if (wordToChar.TryAdd(words[i], pattern[i]))
                {
                    if (!assignedChars.Add(pattern[i]))
                        return false;
                }
                else if (wordToChar[words[i]] != pattern[i])
                    return false;

            return true;
        }
    }
}
 