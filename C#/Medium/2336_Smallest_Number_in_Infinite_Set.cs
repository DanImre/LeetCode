using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2336
    {
        public Medium_2336()
        {

        }
        public class SmallestInfiniteSet
        {
            private HashSet<int> set;
            private PriorityQueue<int, int> prq;
            private int minNum;
            public SmallestInfiniteSet()
            {
                minNum = 1;
                set = new HashSet<int>();
                prq = new PriorityQueue<int, int>();
            }

            public int PopSmallest()
            {
                if(prq.Count == 0)
                    return minNum++;

                set.Remove(prq.Peek());
                return prq.Dequeue();
            }

            public void AddBack(int num)
            {
                if (minNum <= num
                    || set.Contains(num))
                    return;

                set.Add(num);
                prq.Enqueue(num, num);
            }
        }

        /**
         * Your SmallestInfiniteSet object will be instantiated and called as such:
         * SmallestInfiniteSet obj = new SmallestInfiniteSet();
         * int param_1 = obj.PopSmallest();
         * obj.AddBack(num);
         */
    }
}
