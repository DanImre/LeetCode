using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1544
    {
        public Easy_1544()
        {

        }
        public string MakeGood(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (var item in s)
            {
                if (stack.Count == 0)
                {
                    stack.Push(item);
                    continue;
                }

                if (char.IsUpper(stack.Peek()))
                {
                    if (char.ToLower(stack.Peek()) == item)
                        stack.Pop();
                    else
                        stack.Push(item);
                    continue;
                }

                if (char.ToUpper(stack.Peek()) == item)
                    stack.Pop();
                else
                    stack.Push(item);
            }

            return string.Join("", stack.Reverse());
        }
    }
}
