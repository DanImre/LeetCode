using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_844
    {
        public Easy_844()
        {

        }
        public bool BackspaceCompare(string s, string t)
        {
            int si = s.Length - 1;
            int ti = t.Length - 1;

            while (si >= 0 && ti >= 0)
            {
                int backSpaceCount = 0;
                while (si >= 0 && s[si] == '#')
                {
                    backSpaceCount = 1;
                    --si;
                    while (si >= 0 && backSpaceCount > 0)
                    {
                        if (s[si] != '#')
                            --backSpaceCount;
                        else
                            ++backSpaceCount;

                        --si;
                    }
                }

                while (ti >= 0 && t[ti] == '#')
                {
                    backSpaceCount = 1;
                    --ti;
                    while (ti >= 0 && backSpaceCount > 0)
                    {
                        if (t[ti] != '#')
                            --backSpaceCount;
                        else
                            ++backSpaceCount;

                        --ti;
                    }
                }

                if (si >= 0 && ti >= 0 && s[si--] != t[ti--])
                    return false;
            }

            int b = 0;
            while (si >= 0 && s[si] == '#')
            {
                b = 1;
                --si;
                while (si >= 0 && b > 0)
                {
                    if (s[si] != '#')
                        --b;
                    else
                        ++b;

                    --si;
                }
            }
            while (ti >= 0 && t[ti] == '#')
            {
                b = 1;
                --ti;
                while (ti >= 0 && b > 0)
                {
                    if (t[ti] != '#')
                        --b;
                    else
                        ++b;

                    --ti;
                }
            }

            return si < 0 && ti < 0;
        }
    }
}
