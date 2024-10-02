using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_14
    {
        public Easy_14()
        {
            Console.WriteLine(LongestCommonPrefix(new string[] { "flower", "flow", "flight" }));
            Console.WriteLine(LongestCommonPrefix(new string[] { "dog", "racecar", "car" }));
            Console.WriteLine(LongestCommonPrefix(new string[] { "" }));
            Console.WriteLine(LongestCommonPrefix(new string[] { "a" }));
        }
        public string LongestCommonPrefix(string[] strs)
        {
            StringBuilder solution = new StringBuilder();

            if (strs[0].Length == 0)
                return "";

            char activeChar = strs[0][0];
            int index = 0;
            int minLength = strs[0].Length;

            int i = 1;

            while (i < strs.Length)
            {
                if (strs[i].Length < minLength)
                    minLength = strs[i].Length;

                if (minLength == 0 || strs[i][index] != activeChar)
                    return "";

                ++i;
            }
            solution.Append(activeChar);
            ++index;
            while (index < minLength)
            {
                activeChar = strs[0][index];

                i = 0;
                while (i < strs.Length)
                {
                    if (strs[i][index] != activeChar)
                        break;

                    ++i;
                }

                if (i != strs.Length)
                    break;

                solution.Append(activeChar);
                ++index;
            }

            return solution.ToString();
        }
    }
}
