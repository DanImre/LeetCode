using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_71
    {
        public Medium_71()
        {
            //Console.WriteLine(SimplifyPath(""));
        }

        public string SimplifyPath(string path)
        {
            string[] splitted = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new Stack<string>();

            foreach (var item in splitted)
            {
                if (item == ".")
                    continue;
                else if (item == "..")
                {
                    if (stack.Count != 0)
                        stack.Pop();
                }
                else
                    stack.Push(item);
            }

            if (stack.Count == 0)
                return "/";

            path = "";
            while (stack.Count != 0)
            {
                path = "/" + stack.Pop() + path;
            }

            return path;
        }
    }
}
