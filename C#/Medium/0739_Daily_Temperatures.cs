using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_739
    {
        public Medium_739()
        {

        }

        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] solution = new int[temperatures.Length];

            Stack<(int index, int temp)> stack = new Stack<(int index, int temp)>();

            for (int i = 0; i < temperatures.Length; i++)
            {
                while (stack.Count != 0 && stack.Peek().temp < temperatures[i])
                {
                    var curr = stack.Pop();
                    solution[curr.index] = i - curr.index;
                }

                stack.Push((i, temperatures[i]));
            }

            return solution;
        }
    }
}
