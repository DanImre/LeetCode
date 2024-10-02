using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    internal class Medium_752
    {
        public Medium_752()
        {

        }
        public int OpenLock(string[] deadends, string target)
        {
            HashSet<string> seen = new HashSet<string>();
            HashSet<string> hs = new HashSet<string>(deadends);

            Queue<(string value, int steps)> q = new Queue<(string value, int steps)>();
            q.Enqueue(("0000", 0));

            while (q.Count > 0)
            {
                var curr = q.Dequeue();

                if (hs.Contains(curr.value))
                    continue;

                if (!seen.Add(curr.value))
                    continue;

                if (curr.value == target)
                    return curr.steps;

                for (int i = 0; i < 4; i++)
                {
                    var next = curr.value.ToArray();

                    if (next[i] == '9')
                        next[i] = '0';
                    else
                        next[i] = (char)(next[i] + 1);

                    q.Enqueue((new string(next), curr.steps + 1));

                    next = curr.value.ToArray();

                    if (next[i] == '0')
                        next[i] = '9';
                    else
                        next[i] = (char)(next[i] - 1);

                    q.Enqueue((new string(next), curr.steps + 1));
                }
            }

            return -1;
        }
    }
}
