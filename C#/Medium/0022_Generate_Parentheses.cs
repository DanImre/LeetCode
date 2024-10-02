using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_22
    {
        public Medium_22()
        {
            foreach (var item in GenerateParenthesis(3))
                Console.WriteLine(item);
        }

        public IList<string> solution = new List<string>();
        public IList<string> GenerateParenthesis(int n)
        {
            backTrackWithStringBuilder(n, 0, new StringBuilder());

            return solution;
        }

        public void backTrackWithStringBuilder(int n, int openCount, StringBuilder sb)
        {
            if (n == 0) //Got to the end
            {
                for (int i = 0; i < openCount; i++) //Still have open parenthesis, so we close them
                    sb.Append(')');

                solution.Add(sb.ToString());
                sb.Remove(sb.Length - openCount, openCount);
                return;
            }

            //Open a new one
            sb.Append('(');
            backTrackWithStringBuilder(n - 1, openCount + 1, sb);
            sb.Remove(sb.Length - 1, 1);

            if (openCount == 0) //If there is ->
                return;

            // -> Close an already open one
            sb.Append(')');
            backTrackWithStringBuilder(n, openCount - 1, sb);
            sb.Remove(sb.Length - 1, 1);
        }

        public void backTrack(int n, int openCount, Stack<char> stack)
        {
            if (n == 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in stack.Reverse())
                    sb.Append(item);
                
                for (int i = 0; i < openCount; i++)
                    sb.Append(')');

                solution.Add(sb.ToString());
                return;
            }

            stack.Push('(');
            backTrack(n - 1, openCount + 1, stack);
            stack.Pop();

            if (openCount == 0)
                return;

            stack.Push(')');
            backTrack(n, openCount - 1, stack);
            stack.Pop();
        }
    }
}
