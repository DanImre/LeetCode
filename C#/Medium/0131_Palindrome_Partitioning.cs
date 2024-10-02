using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_131
    {
        public Medium_131()
        {

        }

        public IList<IList<string>> Solutions = new List<IList<string>>();
        public List<string> Buffer = new List<string>();
        public string S = null!;
        public IList<IList<string>> Partition(string s)
        {
            S = s;

            BackTrack(0);

            return Solutions;
        }

        public void BackTrack(int index)
        {
            if (index == S.Length)
            {
                Solutions.Add(new List<string>(Buffer));
                return;
            }

            for (int i = index; i < S.Length; i++)
            {
                if (!IsPalindrome(S,index,i))
                    continue;

                Buffer.Add(S.Substring(index, i - index + 1));
                BackTrack(i + 1);
                Buffer.RemoveAt(Buffer.Count - 1);
            }

        }
        public bool IsPalindrome(string s, int low, int high)
        {
            while (low < high)
                if (s[low++] != s[high--]) return false;

            return true;
        }
    }
}
