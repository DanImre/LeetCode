using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_85
    {
        public Hard_85()
        {

        }

        public int MaximalRectangle(char[][] matrix)
        {
            int[] heights = new int[matrix[0].Length + 1];
            int maxArea = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                    heights[j] = matrix[i][j] == '1' ? heights[j] + 1 : 0;


                Stack<int> stack = new Stack<int>();
                for (int j = 0; j < heights.Length; j++)
                {
                    while (stack.Count > 0 && heights[j] < heights[stack.Peek()])
                    {
                        int height = heights[stack.Pop()];
                        int width = stack.Count > 0 ? j - stack.Peek() - 1 : j;
                        maxArea = Math.Max(maxArea, height * width);
                    }
                    stack.Push(j);
                }
            }


            return maxArea;
        }
    }
}
