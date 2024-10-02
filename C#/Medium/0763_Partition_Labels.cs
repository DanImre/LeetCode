using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_763
    {
        public Medium_763()
        {

        }
        public IList<int> PartitionLabels(string s)
        {
            IList<int> solution = new List<int>();

            int[] lastDic = new int[26];
            for (int i = 0; i < s.Length; i++)
                lastDic[s[i] - 'a'] = i;

            int lastCutOff = 0;
            int end = 0;

            for (int i = 0; i < s.Length; ++i)
            {
                end = Math.Max(end, lastDic[s[i] - 'a']);

                if (end != i)
                    continue;

                solution.Add(i - lastCutOff + 1);
                lastCutOff = i + 1;
                end = 0;
            }

            return solution;
        }
    }
}
