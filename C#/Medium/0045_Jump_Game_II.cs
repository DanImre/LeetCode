using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_45
    {
        public Medium_45()
        {
            Console.WriteLine(Jump2(new int[] { 2, 3, 1, 1, 4 }));
            Console.WriteLine(Jump2(new int[] { 2, 3, 0, 1, 4 }));
        }
        //Graph like solution
        public int Jump(int[] nums)
        {
            int[] visited = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                visited[i] = int.MaxValue;

            Queue<(int index, int jumps)> q = new Queue<(int index, int jumps)>();
            q.Enqueue((0, 0));

            while (q.Count != 0)
            {
                (int index, int jumps) act = q.Dequeue();

                if (visited[act.index] <= act.jumps)
                    continue;

                visited[act.index] = act.jumps;

                for (int i = Math.Min(nums.Length - 1, act.index + nums[act.index]); i >= act.index + 1; i--)
                    q.Enqueue((i, act.jumps + 1));
            }

            return visited[nums.Length - 1];
        }

        //working towards the back
        public int Jump2(int[] nums)
        {
            int jumps = 0;
            int i = nums.Length - 1;
            while (i != 0)
            {
                ++jumps;
                for (int j = 0; j < i; j++)
                {
                    if (j + nums[j] >= i)
                    {
                        i = j;
                        break;
                    }
                }
            }

            return jumps;
        }
    }
}
