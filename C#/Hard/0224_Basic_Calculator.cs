using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_224
    {
        public Hard_224()
        {
            Console.WriteLine(Calculate("(1+(4+5+2)-3)+(6+8)")); //23
            Console.WriteLine(Calculate("1 + 1"));
            Console.WriteLine(Calculate(" 2-1 + 2 "));
            Console.WriteLine(Calculate("   (  3 ) "));
            Console.WriteLine(Calculate("1-(     -2)"));
            Console.WriteLine(Calculate("-2+ 1"));
        }
        //O(n) time complexity, and O(n) space 
        public int Calculate(string s)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            Stack<char> signBeforeBracket = new Stack<char>();

            StringBuilder sb = new StringBuilder("0");

            char lastOperator = '+';
            foreach (var item in s)
            {
                if (Char.IsDigit(item))
                {
                    sb.Append(item);
                    continue;
                }


                switch (item)
                {
                    case '+':
                        if (lastOperator == '+')
                            stack.Push(stack.Pop() + int.Parse(sb.ToString()));
                        else
                        {
                            if (stack.Count > signBeforeBracket.Count)
                                stack.Push(stack.Pop() - int.Parse(sb.ToString()));
                            else
                                stack.Push(-int.Parse(sb.ToString()));
                        }

                        lastOperator = '+';
                        sb.Clear();
                        break;
                    case '-':
                        if (lastOperator == '+')
                            stack.Push(stack.Pop() + int.Parse(sb.ToString()));
                        else
                        {
                            if (stack.Count > signBeforeBracket.Count)
                                stack.Push(stack.Pop() - int.Parse(sb.ToString()));
                            else
                                stack.Push(-int.Parse(sb.ToString()));
                        }

                        lastOperator = '-';
                        sb.Clear();
                        break;
                    case '(':
                        signBeforeBracket.Push(lastOperator);

                        stack.Push(0);
                        sb.Append("0");

                        lastOperator = '+';
                        break;
                    case ')':

                        if (lastOperator == '+')
                            stack.Push(stack.Pop() + int.Parse(sb.ToString()));
                        else
                        {
                            if (stack.Count > signBeforeBracket.Count)
                                stack.Push(stack.Pop() - int.Parse(sb.ToString()));
                            else
                                stack.Push(-int.Parse(sb.ToString()));
                        }
                        sb.Clear();

                        lastOperator = signBeforeBracket.Pop();

                        var op2 = stack.Pop();
                        var op1 = stack.Pop();
                        if (lastOperator == '+')
                            stack.Push(op1 + op2);
                        if (lastOperator == '-')
                            stack.Push(op1 - op2);

                        sb.Append("0");

                        lastOperator = '+';
                        break;
                    default:
                        break;
                }
            }

            if (sb.Length > 0)
            {
                var op2 = int.Parse(sb.ToString());
                var op1 = stack.Pop();
                if (lastOperator == '+')
                    stack.Push(op1 + op2);
                if (lastOperator == '-')
                    stack.Push(op1 - op2);
            }

            return stack.Pop();
        }
    }
}
