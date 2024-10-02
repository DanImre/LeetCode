using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_84
    {
        public Hard_84()
        {

        }
        public int LargestRectangleArea(int[] heights)
        {
            int solution = 0;
            Stack<(int index, int height)> stack = new Stack<(int index, int height)>();

            for (int i = 0; i < heights.Length; i++)
            {
                int min = i;
                while (stack.Count > 0 && stack.Peek().height > heights[i])
                {
                    var curr = stack.Pop();
                    solution = Math.Max(solution, curr.height * (i - curr.index));
                    min = curr.index;
                }

                stack.Push((min, heights[i]));
            }

            while (stack.Count > 0)
            {
                var curr = stack.Pop();
                solution = Math.Max(solution, curr.height * (heights.Length - curr.index));
            }

            return solution;
        }
    }
}
