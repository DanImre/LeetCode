using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1249
    {
        public Medium_1249() { }
        public string MinRemoveToMakeValid(string s)
        {
            Stack<int> stack = new Stack<int>();

            List<char> chars = s.ToList();

            for (int i = 0; i < chars.Count; i++)
                if (chars[i] == '(')
                    stack.Push(i);
                else if (chars[i] == ')')
                {
                    if (stack.Count == 0)
                        chars.RemoveAt(i--);
                    else
                        stack.Pop();
                }

            while (stack.Count > 0)
                chars.RemoveAt(stack.Pop());

            return string.Join("", chars);
        }
    }
}
