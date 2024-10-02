using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_150
    {
        public Medium_150()
        {

        }
        public int EvalRPN(string[] tokens)
        {
            Dictionary<string, Func<int, int, int>> dic = new Dictionary<string, Func<int, int, int>>()
            {
                { "+", (a,b) => a + b },
                { "-", (a,b) => b - a }, //Cuz operands are in a reversed order
                { "*", (a,b) => a * b },
                { "/", (a,b) => b / a } //Same
            };

            Stack<int> stack = new Stack<int>();

            foreach (var item in tokens)
            {
                if (dic.ContainsKey(item))
                    stack.Push(dic[item](stack.Pop(), stack.Pop()));
                else
                    stack.Push(int.Parse(item));
            }

            return stack.Pop();
        }
    }
}
