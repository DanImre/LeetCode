using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_295
    {
        public Hard_295()
        {
            MedianFinder a = new MedianFinder();
            a.AddNum(0);
            a.AddNum(2);
            a.AddNum(4);
            a.AddNum(6);

            Console.WriteLine(a.FindMedian());
        }
        //intended
        public class MedianFinder
        {
            private PriorityQueue<int, int> high;
            private PriorityQueue<int, int> low;
            private bool odd;
            public MedianFinder()
            {
                high = new PriorityQueue<int, int>();
                low = new PriorityQueue<int, int>();
                odd = false;
            }

            public void AddNum(int num)
            {
                odd = !odd;
                num = low.EnqueueDequeue(num, -num);
                high.Enqueue(num, num);
                if (high.Count > low.Count + 1)
                {
                    num = high.Dequeue();
                    low.Enqueue(num, -num);
                }
            }

            public double FindMedian()
            {
                if (odd) return high.Peek();
                else return (low.Peek() + high.Peek()) / 2f;
            }
        }
        public class MedianFinderMyWay
        {
            int currIndex;
            bool isEven;
            private List<int> list;
            public MedianFinderMyWay()
            {
                currIndex = -1;
                isEven = true;
                list = new List<int>() { 0 };
            }

            public void AddNum(int num)
            {
                if (isEven)
                    ++currIndex;

                isEven = !isEven;

                insertElement(num);
            }

            private void insertElement(int num)
            {
                int start = 0;
                int end = list.Count - 1;
                while (start < end)
                {
                    int mid = start + (end - start) / 2;

                    if (list[mid] < num)
                        start = mid + 1;
                    else
                        end = mid;
                }

                list.Insert(start, num);
            }

            public double FindMedian()
            {
                if (!isEven)
                    return list[currIndex];

                return (list[currIndex] + list[currIndex + 1]) / 2.0;
            }
        }
    }
}
