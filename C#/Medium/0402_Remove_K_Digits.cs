using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_402
    {
        public Medium_402()
        {

        }
        public string RemoveKdigits(string num, int k)
        {
            Stack<int> stack = new Stack<int>();
            foreach (var item in num)
            {
                int curr = item - '0';
                while (stack.Count > 0 && k > 0 && stack.Peek() > curr)
                {
                    stack.Pop();
                    --k;
                }

                stack.Push(curr);
            }

            while (k-- > 0)
                stack.Pop();

            string solution = string.Join("",stack.Reverse()).TrimStart('0');
            if (solution.Length == 0)
                return "0";
            else
                return solution;
        }
    }
}
