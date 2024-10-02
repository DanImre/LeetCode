using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_443
    {
        public Medium_443()
        {

        }
        public int Compress(char[] chars)
        {
            int solution = 0;

            int i = 0;
            while (i < chars.Length)
            {
                int tempI = i + 1;
                while (tempI < chars.Length && chars[i] == chars[tempI])
                    ++tempI;

                if (tempI - i == 1)
                {
                    chars[solution] = chars[i];
                    ++solution;
                }
                else
                {
                    chars[solution] = chars[i];
                    ++solution; 
                    string asString = (tempI - i).ToString();
                    foreach (var item in asString)
                    {
                        chars[solution] = item;
                        ++solution;
                    }
                }

                i = tempI;
            }

            return solution;
        }
    }
}
