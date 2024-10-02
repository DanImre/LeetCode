using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_76
    {
        public Hard_76()
        {
            /*
            //"BANC"
            string s = "ADOBECODEBANC";
            string t = "ABC";

            //"a"
            string s = "a";
            string t = "a";

            //""
            string s = "a";
            string t = "aa";
            
            //"a"
            string s = "ab";
            string t = "a";
            */
            
            //"ba"
            string s = "bba";
            string t = "ab";
            

            Console.WriteLine("\"" + MinWindow(s,t) + "\"");
        }
        public string MinWindow(string s, string t)
        {
            int i = 0;
            int j = 0;

            Dictionary<char,int> charCount = new Dictionary<char, int>();
            foreach (var item in t)
                if (charCount.ContainsKey(item))
                    ++charCount[item];
                else
                    charCount.Add(item, 1);

            string best = "";
            StringBuilder sb = new StringBuilder();
            
            while (j < s.Length && !charCount.ContainsKey(s[i]))
            {
                ++i;
                ++j;
            }

            while (j < s.Length)
            {
                while (j < s.Length && charCount.Any(kk => kk.Value > 0))
                {
                    if (charCount.ContainsKey(s[j]))
                        --charCount[s[j]];

                    sb.Append(s[j]);
                    ++j; 
                }
                if (charCount.Any(kk => kk.Value > 0))
                    break;

                if (best.Length == 0 || sb.Length < best.Length)
                    best = sb.ToString();

                int iBefore = i;
                while (i < s.Length)
                {
                    if (charCount.ContainsKey(s[i]) && ++charCount[s[i]] > 0)
                    {
                        ++i;
                        break;
                    }
                    ++i;
                }

                int removeLength = i - iBefore - 1;
                int alreadyRemoved = 0;
                if (sb.Length - removeLength < best.Length)
                {
                    alreadyRemoved = removeLength;
                    sb.Remove(0, removeLength);
                    best = sb.ToString();
                }

                while (i < s.Length && !charCount.ContainsKey(s[i]))
                    ++i;
                removeLength = i - iBefore - alreadyRemoved;
                if (removeLength >= sb.Length)
                    sb.Clear();
                else
                    sb.Remove(0, removeLength);
            }

            return best;
        }
    }
}
