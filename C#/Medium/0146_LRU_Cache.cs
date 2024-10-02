using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medium.Medium_138;

namespace Medium
{
    public class Medium_146
    {
        public Medium_146()
        {
            LRUCache a = new LRUCache(2);
            a.Put(1, 0);
            Console.WriteLine(a.Get(1));
            a.Put(3, 3);
            Console.WriteLine(a.Get(2));
            a.Put(4, 4);
            Console.WriteLine(a.Get(1));
            Console.WriteLine(a.Get(3));
            Console.WriteLine(a.Get(4));
        }
        public class LRUCache
        {
            private class C2L
            {
                public int value;
                public int key;
                public C2L next;
                public C2L prev;

                public C2L(int value, int key, C2L prev = null, C2L next = null)
                {
                    this.value = value;
                    this.key = key;
                    this.next = next;
                    this.prev = prev;
                }
            }

            private C2L head;
            private Dictionary<int, C2L> dic;
            private int capacity;
            private int Count;

            public LRUCache(int capacity)
            {
                dic = new Dictionary<int, C2L>();
                this.capacity = capacity;
                head = new C2L(0,0);
                head.next = head;
                head.prev = head;
            }

            public int Get(int key)
            {
                if (!dic.ContainsKey(key))
                    return -1;

                C2L node = dic[key];

                node.prev.next = node.next;
                node.next.prev = node.prev;

                node.prev = head;
                node.next = head.next;
                head.next.prev = node;
                head.next = node;

                return node.value;
            }

            public void Put(int key, int value)
            {
                if (dic.ContainsKey(key))
                    Remove(key);
                if (Count == capacity)
                    Remove(head.prev.key);

                ++Count;
                C2L newNode = new C2L(value, key, head, head.next);
                head.next.prev = newNode;
                head.next = newNode;

                dic.Add(key, newNode);
            }

            private void Remove(int key)
            {
                --Count;
                C2L node = dic[key];
                dic.Remove(key);

                node.next.prev = node.prev;
                node.prev.next = node.next;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                C2L temp = head.next;
                while(temp != head)
                {
                    sb.Append(temp.key);
                    sb.Append(", ");
                    sb.Append(temp.value);
                    sb.Append(" - ");
                    temp = temp.next;
                }

                temp = temp.prev;
                sb.Append("  FROM THE BACK : ");
                while (temp != head)
                {
                    sb.Append(temp.key);
                    sb.Append(", ");
                    sb.Append(temp.value);
                    sb.Append(" - ");
                    temp = temp.prev;
                }


                return sb.ToString();
            }
        }
    }
}
