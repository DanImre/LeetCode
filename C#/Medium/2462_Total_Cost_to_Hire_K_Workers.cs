using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2462
    {
        public Medium_2462()
        {
            /*
            //11
            Console.WriteLine(TotalCost2(new int[] { 17, 12, 10, 2, 7, 2, 11, 20, 8 },
                3, 4));

            Console.WriteLine("----");

            //4
            Console.WriteLine(TotalCost2(new int[] { 1, 2, 4, 1 },
                3, 3));
            
            Console.WriteLine("----");

            //526
            Console.WriteLine(TotalCost2(new int[] { 57, 33, 26, 76, 14, 67, 24, 90, 72, 37, 30 },
                11, 2));

            Console.WriteLine("----");

            //21090
            Console.WriteLine(TotalCost2(new int[] { 515, 705, 303, 791, 304, 382, 756, 957, 402, 399, 743, 919, 568, 141, 894, 488, 14, 452, 459, 930, 981, 662, 464, 663, 576, 302, 720, 855, 838, 51, 174, 97, 375, 813, 537, 750, 191, 991, 915, 972, 908, 370, 758, 864, 209, 478, 442, 685, 552, 717, 860, 996, 171, 168, 560, 595, 460, 285, 18, 96, 970, 746, 512, 420, 844, 183, 607, 267, 40, 491, 232, 278, 751, 277, 19, 419, 384, 85, 563, 556, 643, 896, 333, 468 },
                57, 15));
            
             
            Console.WriteLine("----");
            //1380
            Console.WriteLine(TotalCost2(new int[] { 642, 56, 682 },
                3, 1));
            */
            Console.WriteLine("----");
            //261
            Console.WriteLine(TotalCost2(new int[] { 60, 87, 94, 42, 12, 60 },
                5, 4));
        }
        //Time limit exceeded
        public  long TotalCost(int[] costs, int k, int candidates)
        {
            long result = 0;
            HashSet<int> visitedIndexes = new HashSet<int>();
            for (int i = 0; i < k; i++)
            {
                int indexLeft = 0;
                int indexRight = costs.Length - 1;

                int skippedLeft = 0;
                int skippedRight = 0;

                int min = int.MaxValue;
                int minIndex = -1;

                while (indexLeft < candidates)
                {
                    while (visitedIndexes.Contains(indexLeft + skippedLeft))
                        ++skippedLeft;
                    while (visitedIndexes.Contains(indexRight - skippedRight))
                        ++skippedRight;

                    int realRightIndex = indexRight - skippedRight;
                    int realLeftIndex = indexLeft + skippedLeft;

                    if (realLeftIndex > realRightIndex)
                        break;

                    if (costs[realRightIndex] < min)
                    {
                        min = costs[realRightIndex];
                        minIndex = realRightIndex;
                    }

                    if (costs[realLeftIndex] <= min)
                    {
                        min = costs[realLeftIndex];
                        minIndex = realLeftIndex;
                    }

                    ++indexLeft;
                    --indexRight;
                }

                visitedIndexes.Add(minIndex);
                result += min;
            }

            return result;
        }

        //About to go overkill:
        public class bothWayQueue
        {
            private class Node
            {
                public int value = 0;
                public Node prev;
                public Node next;

                public Node(int value, Node prev, Node next)
                {
                    this.value = value;
                    this.prev = prev;
                    this.next = next;
                }
                public Node(int value)
                {
                    this.value = value;
                    this.prev = null;
                    this.next = null;
                }
            }

            private Node head;
            private int count;
            public bothWayQueue()
            {
                count = 0;
                head = new Node(0);
                head.next = head;
                head.prev = head;
            }

            public bool IsEmpty()
            {
                return count == 0;
            }

            public void Add(int val)
            {
                Node temp = new Node(val, head.prev, head);
                head.prev.next = temp;
                head.prev = temp;

                ++count;
            }

            public int PeekFirst()
            {
                return head.next.value;
            }
            public int PeekLast()
            {
                return head.prev.value;
            }

            public int PopFirst()
            {
                int solutuion = PeekFirst();
                head.next = head.next.next;
                head.next.prev = head;

                --count;

                return solutuion;
            }
            public int PopLast()
            {
                int solutuion = PeekLast();
                head.prev = head.prev.prev;
                head.prev.next = head;

                --count;

                return solutuion;
            }

            public override string ToString()
            {
                string solution = "";
                Node temp = head.next;
                while (temp != head)
                {
                    solution += temp.value + ", ";
                    temp = temp.next;
                }
                return solution;
            }
        }
        public class minHeap
        {
            public List<int> array;
            public int n;
            public minHeap()
            {
                n = 0;
                array = new List<int>();
            }

            public void Add(int value)
            {
                array.Add(value);
                int i = n;
                while (i >= 0)
                {
                    if (array[i / 2] <= array[i])
                        break;

                    //swap
                    int temp = array[i / 2];
                    array[i / 2] = array[i];
                    array[i] = temp;

                    i /= 2;
                }
                ++n;
            }

            private void sink(int honnan)
            {
                int i = honnan;
                int j = i * 2; //left i
                if (i == 0)
                    j = 1;
                while (j < n)
                {
                    if (j < n - 1 && array[j + 1] < array[j])
                        ++j;

                    if (array[i] < array[j])
                        break;

                    //Swap
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;

                    i = j;

                    j = j * 2;//left j
                }
            }

            public int PopMin()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("YOO");
                    return int.MaxValue;
                }
                int result = array[0];
                --n;

                array[0] = array[n];
                array.RemoveAt(n);

                sink(0);

                return result;
            }

            public int PeekMin()
            {
                return array[0];
            }

            public bool IsEmpty()
            {
                return n == 0;
            }
        }

        public  long TotalCost2(int[] costs, int k, int candidates)
        {
            minHeap LeftCandidates = new minHeap();
            minHeap RightCandidates = new minHeap();

            bothWayQueue Leftover = new bothWayQueue();

            int i = 0;
            while (i < (costs.Length + 1) / 2 && i < candidates)
            {
                LeftCandidates.Add(costs[i]);
                if (i != costs.Length - 1 - i)
                    RightCandidates.Add(costs[costs.Length - 1 - i]);

                ++i;
            }
            i = candidates;
            while (i < costs.Length - candidates)
            {
                Leftover.Add(costs[i]);
                ++i;
            }

            long result = 0;
            while (k > 0)
            {
                if (LeftCandidates.IsEmpty() || RightCandidates.IsEmpty())
                    break;

                if (LeftCandidates.PeekMin() <= RightCandidates.PeekMin())
                {
                    result += LeftCandidates.PopMin();
                    if (!Leftover.IsEmpty())
                        LeftCandidates.Add(Leftover.PopFirst());
                }
                else
                {
                    result += RightCandidates.PopMin();
                    if (!Leftover.IsEmpty())
                        RightCandidates.Add(Leftover.PopLast());
                }

                --k;
            }


            while (k > 0 && !LeftCandidates.IsEmpty())
            {
                result += LeftCandidates.PopMin();
                --k;
            }
            while (k > 0 && !RightCandidates.IsEmpty())
            {
                result += RightCandidates.PopMin();
                --k;
            }

            return result;
        }
    }
}
