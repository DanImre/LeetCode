using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_155
    {
        public Medium_155()
        {
            //Cant really test it
        }

        private class MinStack
        {
            private Stack<int> stack;
            private Stack<int> minStack;

            public MinStack()
            {
                stack = new Stack<int>();
                minStack = new Stack<int>();
            }

            public void Push(int val)
            {
                stack.Push(val);

                if(minStack.Count == 0 || minStack.Peek() >= val) 
                    minStack.Push(val);
            }

            public void Pop()
            {
                if (stack.Pop() == minStack.Peek()) //Cannot be empty here
                    minStack.Pop();
            }

            public int Top()
            {
                return stack.Peek();
            }

            public int GetMin()
            {
                return minStack.Peek();
            }
        }
    }
}
