using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_394
    {
        public Medium_394()
        {
            //Console.WriteLine(DecodeString("3[a]2[bc]"));

            Console.WriteLine(DecodeString("3[a2[c]]"));

            //Console.WriteLine(DecodeString("2[abc]3[cd]ef"));
        }
        public string DecodeString(string s)
        {
            int i = 0;
            StringBuilder solutionSB = new StringBuilder();
            while (i < s.Length)
            {
                int startI = i;
                while (i < s.Length && !Char.IsDigit(s[i]))
                {
                    solutionSB.Append(s[i]);
                    ++i;
                }

                if (i == s.Length)
                    break;

                StringBuilder numberSB = new StringBuilder();
                while (i < s.Length && Char.IsDigit(s[i]))
                {
                    numberSB.Append(s[i]);
                    ++i;
                }

                int number = int.Parse(numberSB.ToString());

                ++i; //stepping over '['
                startI = i;
                int bracketCount = 1;
                while (bracketCount != 0)
                {
                    ++i;
                    if (i == s.Length)
                        break;

                    if (s[i] == ']')
                        --bracketCount;
                    else if (s[i] == '[')
                        ++bracketCount;
                }

                string tempSolution = DecodeString(s.Substring(startI, i - startI));
                for (int j = 0; j < number; j++)
                    solutionSB.Append(tempSolution);

                ++i;//stepping over ']'
            }

            return solutionSB.ToString();
        }
    }
}
