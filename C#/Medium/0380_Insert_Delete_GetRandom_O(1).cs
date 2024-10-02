using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_380
    {
        public Medium_380()
        {
            RandomizedSet set = new RandomizedSet();
            Console.WriteLine(set.Insert(0));
            Console.WriteLine(set);
            Console.WriteLine(set.GetRandom());
            Console.WriteLine(set);
            Console.WriteLine(set.Remove(0));
            Console.WriteLine(set);
            Console.WriteLine(set.Insert(0));
        }
        public class RandomizedSet
        {
            private int n;
            private List<int> list;
            private Dictionary<int, int> elementToIndex;
            private Random random;

            public RandomizedSet()
            {
                n = 0;
                elementToIndex = new Dictionary<int, int>();
                list = new List<int>();
                random = new Random();
            }

            public bool Insert(int val)
            {
                if (elementToIndex.ContainsKey(val))
                    return false;

                elementToIndex.Add(val, n);
                list.Add(val);
                ++n;

                return true;
            }

            public bool Remove(int val)
            {
                if (!elementToIndex.ContainsKey(val))
                    return false;

                --n;
                int index = elementToIndex[val];
                if (n == index)
                {
                    elementToIndex.Remove(val);
                    list.RemoveAt(n);
                    return true;
                }

                elementToIndex.Remove(val);

                int lastElement = list[n];
                elementToIndex[lastElement] = index;

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

                foreach (var item in elementToIndex)
                    solution += "(" + item.Key + ", " + item.Value + ") ; ";

                solution += "\n";
                return solution;
            }
        }
    }
}
