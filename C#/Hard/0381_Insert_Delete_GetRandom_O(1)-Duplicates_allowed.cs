using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_381
    {
        public Hard_381()
        {
            RandomizedCollection a = new RandomizedCollection();
            Console.WriteLine(a.Insert(4));
            Console.WriteLine(a.Insert(3));
            Console.WriteLine(a.Insert(4));
            Console.WriteLine(a.Insert(2));
            Console.WriteLine(a.Insert(4));

            Console.WriteLine(a);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(a.Remove(4));
            Console.WriteLine(a);
            Console.WriteLine(a.Remove(3));
            Console.WriteLine(a.Remove(4));
            Console.WriteLine(a);
            Console.WriteLine(a.Remove(4));
            Console.WriteLine(a);

            Console.WriteLine(a);
        }
        private class RandomizedCollection
        {
            private class MyQueue
            {
                private class LNode
                {
                    public int value;
                    public LNode next;
                    public LNode prev;

                    public LNode(int value, LNode prev, LNode next)
                    {
                        this.value = value;
                        this.prev = prev;
                        this.next = next;
                    }
                    public LNode(int value)
                    {
                        this.value = value;
                        next = null;
                        prev = null;
                    }
                }

                private LNode head;
                private Dictionary<int, LNode> indexToElement;
                public MyQueue()
                {
                    head = new LNode(0);
                    head.prev = head;
                    head.next = head;
                    indexToElement = new Dictionary<int, LNode>();
                }

                public void Enqueue(int val)
                {
                    LNode temp = new LNode(val, head, head.next);
                    head.next.prev = temp;
                    head.next = temp;

                    indexToElement.Add(val, temp);
                }

                public int Dequeue()
                {
                    LNode temp = head.next;
                    head.next = temp.next;
                    temp.next.prev = head;

                    indexToElement.Remove(temp.value);
                    return temp.value;
                }

                public void ChangeIndex(int to, int from)
                {
                    LNode temp = indexToElement[from];
                    temp.value = to;

                    indexToElement.Remove(from);
                    indexToElement.Add(to, temp);
                }
                public bool IsEmpty()
                {
                    return head.next == head;
                }
            }


            private int n;
            private List<int> list;
            private Dictionary<int, MyQueue> elementToIndexes;
            private Random random;

            public RandomizedCollection()
            {
                n = 0;
                elementToIndexes = new Dictionary<int, MyQueue>();
                list = new List<int>();
                random = new Random();
            }

            public bool Insert(int val)
            {
                if (elementToIndexes.ContainsKey(val))
                {
                    elementToIndexes[val].Enqueue(n);
                    list.Add(val);
                    ++n;
                    return false;
                }

                MyQueue q = new MyQueue();
                q.Enqueue(n);
                elementToIndexes.Add(val, q);
                list.Add(val);
                ++n;

                return true;
            }

            public bool Remove(int val)
            {
                if (!elementToIndexes.ContainsKey(val))
                    return false;

                --n;
                int index = elementToIndexes[val].Dequeue();
                if (elementToIndexes[val].IsEmpty())
                {
                    Console.WriteLine("SHETTT" + val);
                    elementToIndexes.Remove(val);
                }

                if (n == index)
                {
                    list.RemoveAt(n);
                    return true;
                }

                int lastElement = list[n];
                elementToIndexes[lastElement].ChangeIndex(index, n);
                list[index] = lastElement;
                list.RemoveAt(n);

                return true;
            }

            public int GetRandom()
            {
                return list[random.Next(0, n)];
            }

            public override string ToString()
            {
                string solution = "n : " + n + " |";
                foreach (var item in list)
                    solution += item + ", ";
                solution += "\n";

                foreach (var item in elementToIndexes)
                    solution += "(" + item.Key + ", " + item.Value.IsEmpty() + ") ; ";

                solution += "\n";
                return solution;
            }
        }
    }
}

