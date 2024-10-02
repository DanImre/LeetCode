using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1071
    {
        public Easy_1071()
        {
            Console.WriteLine(GcdOfStrings("ABCABC", "ABC"));
            Console.WriteLine(GcdOfStrings("ABABAB", "ABAB"));
            Console.WriteLine(GcdOfStrings("LEET", "CODE"));

            Console.WriteLine();
            Console.WriteLine(GcdOfStrings("AA", "A"));
        }

        public string GcdOfStrings(string str1, string str2)
        {
            if (str2.Length < str1.Length)
                return GcdOfStrings(str2, str1);

            for (int i = 1; i <= str1.Length; i++)
            {
                if (str1.Length % i != 0
                    || str2.Length % (str1.Length / i) != 0)
                    continue;

                string temp = str1.Substring(0,str1.Length/i);
                StringBuilder tempSb = new StringBuilder();
                for (int j = 0; j < i; j++)
                    tempSb.Append(temp);

                if (tempSb.ToString() != str1)
                    continue;

                for (int j = i; j < str2.Length / (str1.Length / i); j++)
                    tempSb.Append(temp);

                if (tempSb.ToString() != str2)
                    continue;

                return temp;
            }

            return "";
        }
    }
}
