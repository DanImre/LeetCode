using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_2000
    {
        public Easy_2000()
        {

        }

        public string ReversePrefix(string word, char ch)
        {
            int index = word.IndexOf(ch);
            if (index == -1)
                return word;

            return new string(word.Substring(0, index).Reverse().ToArray()) + word.Substring(index + 1);
        }
    }
}
