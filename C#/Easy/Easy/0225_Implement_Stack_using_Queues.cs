using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_225
    {
        public Easy_225()
        {
            MyStack mystack = new MyStack();
            mystack.Push(1);
            mystack.Push(2);
            mystack.Push(3);
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
        }
        public class MyStack
        {
            private Queue<int> q;
            public MyStack()
            {
                q = new Queue<int>();
            }

            public void Push(int x)
            {
                q.Enqueue(x);
                //flipping Queue, expect last element
                for (int i = 0; i < q.Count - 1; i++)
                    q.Enqueue(q.Dequeue());
            }

            public int Pop()
            {
                return q.Dequeue();
            }

            public int Top()
            {
                return q.Peek();
            }

            public bool Empty()
            {
                return q.Count == 0;
            }
        }
    }
}
