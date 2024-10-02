using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_20
    {
        public Easy_20()
        {
            //No need
        }

        public bool IsValid(string s)
        {
            Dictionary<char, char> openClosed = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };

            Stack<char> stack = new Stack<char>();
            foreach (var item in s)
                if (openClosed.ContainsKey(item))
                    stack.Push(item);
                else if (stack.Count == 0 || openClosed[stack.Pop()] != item)
                    return false;

            return stack.Count == 0;
        }
    }
}
