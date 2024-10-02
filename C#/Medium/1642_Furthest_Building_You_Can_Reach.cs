using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1642
    {
        public Medium_1642()
        {

        }
        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            PriorityQueue<int, int> prq = new PriorityQueue<int, int>();

            int i = 0;
            while (i < heights.Length - 1)
            {
                int diff = heights[i + 1] - heights[i];

                if (diff <= 0)
                {
                    ++i;
                    continue;
                }

                bricks -= diff;
                prq.Enqueue(diff, -diff);

                if(bricks < 0)
                {
                    bricks += prq.Dequeue();
                    --ladders;
                }

                if (ladders < 0)
                    break;

                ++i;
            }

            return i;
        }
    }
}
