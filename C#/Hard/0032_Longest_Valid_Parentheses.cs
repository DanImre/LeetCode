using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class _0032_Longest_Valid_Parentheses
    {
        public int LongestValidParentheses(string s)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
                if (s[i] == '(')
                    stack.Push(i);
                else if (stack.Count > 0 && s[stack.Peek()] == '(')
                    stack.Pop();
                else
                    stack.Push(i);

            if (stack.Count == 0)
                return s.Length;

            int solution = 0;
            int prev = s.Length;
            while (stack.Count > 0)
            {
                int curr = stack.Pop();
                solution = Math.Max(solution, prev - curr);
                prev = curr;
            }
            solution = Math.Max(solution, prev);

            return solution;
        }
    }
}
