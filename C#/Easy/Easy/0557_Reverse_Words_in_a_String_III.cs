using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_557
    {
        public Easy_557()
        {

        }
        public string ReverseWords(string s)
        {
            StringBuilder sb = new StringBuilder();

            int lastSpace = -1;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                    continue;

                for (int j = i - 1; j > lastSpace; j--)
                    sb.Append(s[j]);
                sb.Append(' ');
                lastSpace = i;
            }

            for (int j = s.Length - 1; j > lastSpace; j--)
                sb.Append(s[j]);

            return sb.ToString();
        }
    }
}
