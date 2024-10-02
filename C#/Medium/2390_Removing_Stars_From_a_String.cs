using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2390
    {
        public Medium_2390()
        {

        }
        public string RemoveStars(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (var item in s)
            {
                if (item == '*')
                    stack.Pop();
                else
                    stack.Push(item);
            }

            return new string(stack.Reverse().ToArray());
        }
    }
}
