using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_232
    {
        public Easy_232()
        {

        }
        public class MyQueue
        {
            private Stack<int> Stack;
            public MyQueue()
            {
                Stack = new Stack<int>();
            }

            public void Push(int x)
            {
                Stack<int> temp = new Stack<int>();
                while (Stack.Count > 0)
                    temp.Push(Stack.Pop());

                Stack.Push(x);
                while (temp.Count > 0)
                    Stack.Push(temp.Pop());
            }

            public int Pop()
            {
                return Stack.Pop();
            }

            public int Peek()
            {
                return Stack.Peek();
            }

            public bool Empty()
            {
                return Stack.Count == 0;
            }
        }

        /**
         * Your MyQueue object will be instantiated and called as such:
         * MyQueue obj = new MyQueue();
         * obj.Push(x);
         * int param_2 = obj.Pop();
         * int param_3 = obj.Peek();
         * bool param_4 = obj.Empty();
         */
    }
}
