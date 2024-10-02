using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_735
    {
        public Medium_735()
        {
            int[] asteroids = { -2, -2, 1, -2 };
            Console.WriteLine("[" + string.Join(", ", AsteroidCollision(asteroids)) + "]");
        }
        public int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < asteroids.Length; i++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(asteroids[i]);
                    continue;
                }

                if (stack.Peek() <= 0 || asteroids[i] >= 0)
                    stack.Push(asteroids[i]);
                else if (stack.Peek() == Math.Abs(asteroids[i]))
                    stack.Pop();
                else if (Math.Abs(asteroids[i]) > stack.Peek())
                {
                    --i;
                    stack.Pop();
                }
            }

            return stack.Reverse().ToArray();
        }
    }
}
