using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public  class Medium_151
    {
        public Medium_151()
        {
            Console.WriteLine(ReverseWords("the sky is blue"));
            Console.WriteLine(ReverseWords("  hello world  "));
            Console.WriteLine(ReverseWords("a good   example"));
        }
        public string ReverseWords(string s)
        {
            string[] splits = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (splits.Length == 0)
                return "";

            StringBuilder result = new StringBuilder();
            for (int i = splits.Length - 1; i > 0; i--)
            {
                result.Append(splits[i]);
                result.Append(' ');
            }

            result.Append(splits[0]);

            return result.ToString();
        }

        //One liner:
        public string ReverseWords2(string s)
        {
            return string.Join(" ", s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse());
        }
    }
}
