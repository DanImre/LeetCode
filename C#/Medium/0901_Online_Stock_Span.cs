using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_901
    {
        public Medium_901()
        {

        }
        public class StockSpanner
        {
            private readonly Stack<(int price, int span)> stack;

            public StockSpanner()
            {
                stack = new Stack<(int price, int span)>();
            }

            public int Next(int price)
            {
                int solution = 1;

                while (stack.Count != 0 && stack.Peek().price <= price)
                    solution += stack.Pop().span;

                stack.Push((price, solution));
                return solution;
            }
        }
    }
}
