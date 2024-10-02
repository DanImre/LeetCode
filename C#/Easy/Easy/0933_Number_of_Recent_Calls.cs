using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Medium_0933
    {
        public Medium_0933()
        {

        }
        public class RecentCounter
        {
            private Queue<int> q;
            public RecentCounter()
            {
                q = new Queue<int>();
            }

            public int Ping(int t)
            {
                q.Enqueue(t);
                while (t - q.Peek() > 3000)
                    q.Dequeue();

                return q.Count;
            }
        }
    }
}
